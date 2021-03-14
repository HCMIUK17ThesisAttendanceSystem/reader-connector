using RFIDReaderAPI;
using RFIDReaderAPI.Interface;
using RFIDReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using xNet;
using Quobject.SocketIoClientDotNet.Client;

namespace reader_connector.Forms
{
    public partial class Settings : Form, IAsynchronousMessage
    {
        string url = "https://hcmiu-presence.herokuapp.com";
        //string url = "http://localhost:8080";

        public class Item
        {
            public Item() { }

            public string Value { set; get; }
            public string Text { set; get; }
        }
        public Settings()
        {
            InitializeComponent();

            BtnStart.Enabled = false;
            List<Item> tcps = new List<Item>();
            tcps.Add(new Item() { Text = "LA1.605 (10.8.42.28:9090)", Value = "10.8.42.28:9090" });
            tcps.Add(new Item() { Text = "LA1.302 (10.8.46.51:9090)", Value = "10.8.46.51:9090" });
            ComboTcp.DataSource = tcps;
            ComboTcp.DisplayMember = "Text";
            ComboTcp.ValueMember = "Value";

            ConnectSocket();
        }

        public void ConnectSocket()
        {
            var client = IO.Socket(url);

            client.On(Socket.EVENT_CONNECT, () =>
            {
                LogOutput("Connected to server :D");
                client.Emit("get-current-courses"); // emit not work
            });

            client.On(Socket.EVENT_DISCONNECT, (reason) =>
            {
                LogOutput($"Disconnected from server due to: {reason}\r\n");
            });

            client.On(Socket.EVENT_RECONNECT, () =>
            {
                LogOutput("Reconnected to server :D");
            });

            client.On("current-courses", response =>
            {
                LogOutput(response.ToString());
            });

            client.On("scheduled-courses", response =>
            {
                LogOutput(response.ToString());
            });
        }

        private string AddNewRfidTag(string tagTID)
        {
            //TxtLog.Text += tagTID + "\r\n";
            HttpRequest request = new HttpRequest();
            string response = request.Post($"{url}/reader/rfid?rfidTag={tagTID}").ToString();
            return response;
        }

        private string CheckAttendance(string tagTID, string courseId)
        {
            HttpRequest request = new HttpRequest();
            string response = request.Post($"{url}/reader/attendance?rfidTag={tagTID}&courseId={courseId}").ToString();
            return response;
        }

        private void LogOutput(string output)
        {
            TxtLog.Text += output + "\r\n";
            TxtLog.SelectionStart = TxtLog.SelectionLength;
            TxtLog.ScrollToCaret();
        }

        public void GPIControlMsg(GPI_Model gpi_model)
        {

        }

        public void OutPutTags(Tag_Model tag)
        {
            Console.WriteLine("Someone is near the door :D");
            //string res = AddNewRfidTag(tag.TID);
            string res = CheckAttendance(tag.TID, TxtCourseId.Text);
            LogOutput(res);
        }

        public void OutPutTagsOver()
        {
            //Thực thi khi dừng chế độ đọc thẻ
        }

        public void PortClosing(string connID)
        {
            //Thực thi khi ngắt kết nối với đầu đọc
        }

        public void PortConnecting(string connID)
        {
            //Thực thi khi kết nối với đầu đọc
        }

        public void WriteDebugMsg(string msg)
        {

        }

        public void WriteLog(string msg)
        {

        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            string tcp = ComboTcp.SelectedValue.ToString();
            if (BtnConnect.Text == "Connect")
            {
                LogOutput($"Connecting to reader {tcp}");
                bool cn = RFIDReader.CreateTcpConn(tcp, this); // Connect to reader
                if (cn)
                {
                    LogOutput("Connect successfully to reader :D");
                    BtnConnect.Text = "Disconnect";
                    ComboTcp.Enabled = false;
                    TxtCourseId.Enabled = false;
                    BtnStart.Enabled = true;

                    RFIDReader._RFIDConfig.Stop(tcp);
                }
                else
                {
                    LogOutput("Failed connection to reader D:");
                }

            }
            else
            {
                RFIDReader._RFIDConfig.Stop(tcp); // Stop reading before disconnect
                RFIDReader.CloseConn(tcp); // Disconnect with reader
                ComboTcp.Enabled = true;
                TxtCourseId.Enabled = true;
                BtnStart.Enabled = false;
                BtnConnect.Text = "Connect";
                LogOutput("Disconnected");
            }
        }

        private void BtnGetSettings_Click(object sender, EventArgs e)
        {

        }

        private void BtnSetSettings_Click(object sender, EventArgs e)
        {
            string tcp = ComboTcp.SelectedValue.ToString();

            // Stop reading the same tag for 1 minute (6000 centiseconds) (value = 6000)
            int stup = RFIDReader._RFIDConfig.SetTagUpdateParam(tcp, int.Parse(TxtTagFilter.Text), 0);
            if (stup == 0) LogOutput("Set tag update filter successfully :D");
            else LogOutput("Set tag update filter failed D:");

            // auto sleep in 1/2 second (value = "50")
            int srasp = RFIDReader._RFIDConfig.SetReaderAutoSleepParam(tcp, true, TxtAutosleep.Text); 
            if (srasp == 0) LogOutput("Set auto sleep successfully :D");
            else LogOutput("Set auto sleep failed D:");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            string tcp = ComboTcp.SelectedValue.ToString();
            if (BtnStart.Text == "Start")
            {
                // Start reading with antenna 1, inventory mode (continuous reading)
                int st = RFIDReader._Tag6C.GetEPC_TID(tcp, eAntennaNo._1, eReadType.Inventory); 
                if (st == 0)
                {
                    LogOutput("Reading tags :D");
                    BtnStart.Text = "Stop";
                    BtnConnect.Enabled = false;
                    BtnExit.Enabled = false;
                }
                else
                {
                    LogOutput("Reading tag failed D:");
                }
            }
            else
            {
                // Reading mode off
                RFIDReader._RFIDConfig.Stop(tcp); 
                BtnStart.Text = "Start";
                LogOutput("Stop reading tag");
                BtnConnect.Enabled = true;
                BtnExit.Enabled = true;
            }
        }

        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            TxtLog.Clear();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
