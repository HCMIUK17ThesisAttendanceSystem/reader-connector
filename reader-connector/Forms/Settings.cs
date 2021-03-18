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
using reader_connector.Shared;
using Newtonsoft.Json;

namespace reader_connector.Forms
{
    public partial class Settings : Form, IAsynchronousMessage
    {
        string url = "https://hcmiu-presence.herokuapp.com";
        //string url = "http://localhost:8080";

        public class Room
        {
            public Room() { }

            public string Code { set; get; }
            public string IpAddress { set; get; }
        }

        public class Course
        {
            public Course() { }

            public string _id { set; get; }
            public string SubjectName { set; get; }
            public string SubjectId { set; get; }
            public string RoomCode { set; get; }
            public int[] Periods { set; get; }
            public string Weekday { set; get; }
        }

        public class ScheduledCoursesResponse
        {
            public ScheduledCoursesResponse() { }

            public string action { get; set; }
            public Course[] data { get; set; }
        }

        public Settings()
        {
            InitializeComponent();

            BtnStart.Enabled = false;
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room() { Code = "LA1.605", IpAddress = "10.8.42.28:9090" });
            rooms.Add(new Room() { Code = "LA1.302", IpAddress = "10.8.46.51:9090" });
            ComboRoom.DataSource = rooms;
            ComboRoom.DisplayMember = "Code";
            ComboRoom.ValueMember = "Code";

            ConnectSocket();
        }

        public void ConnectSocket()
        {
            LogOutput("Connecting to server...");
            var client = IO.Socket(url);

            client.On(Socket.EVENT_CONNECT, () =>
            {
                LogOutput("Connected to server via Socket.io :D");
            });

            client.On(Socket.EVENT_DISCONNECT, (reason) =>
            {
                LogOutput($"Disconnected from server due to:{reason}\r\n");
            });

            client.On(Socket.EVENT_RECONNECT, () =>
            {
                LogOutput("Reconnected to server :D");
                GetCurrentCourse();
            });

            client.On("current-courses", response =>
            {
                LogOutput(response.ToString());
            });

            client.On("scheduled-courses", response =>
            {
                string JsonResponse = JsonConvert.SerializeObject(response);
                ScheduledCoursesResponse res = JsonConvert.DeserializeObject<ScheduledCoursesResponse>(JsonResponse);
                Course[] scheduledCourses = res.data;

                string roomCode = ComboRoom.GetItemText(ComboRoom.SelectedItem);
                for (int i = 0; i < scheduledCourses.Length; i++)
                {
                    if (scheduledCourses[i].RoomCode == roomCode)
                    {
                        Course course = scheduledCourses[i];
                        TxtCourseId.Text = course._id;
                        LogOutput($"Current course of {roomCode} is {course.SubjectName} :D\n" +
                            $"On {GetWeekdayString(course.Weekday)}, " +
                            $"periods {course.Periods[0]} - {course.Periods[course.Periods.Length - 1]}");
                        break;
                    }
                }
            });
        }

        private string GetWeekdayString(string Number)
        {
            switch (Number)
            {
                case "1":
                    return "monday";
                case "2":
                    return "tuesday";
                case "3":
                    return "wednesday";
                case "4":
                    return "thursday";
                case "5":
                    return "friday";
                case "6":
                    return "saturday";
                default:
                    return "unknown weekday";
            }
        }

        private async void GetCurrentCourse()
        {
            LogOutput("Fetching current course...");
            string roomCode = ComboRoom.GetItemText(ComboRoom.SelectedItem);
            string uri = $"{url}/reader/current-course/{roomCode}";
            string response = await RestAPIHelper.Get(uri);
            Course currentCourse = JsonConvert.DeserializeObject<Course>(response);
            TxtCourseId.Text = currentCourse._id;
            LogOutput($"Current course of {roomCode} is {currentCourse.SubjectName} :D\n" +
                $"On {GetWeekdayString(currentCourse.Weekday)}, " +
                $"periods {currentCourse.Periods[0]} - {currentCourse.Periods[currentCourse.Periods.Length - 1]}");
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
            TxtLog.SelectionStart = TxtLog.Text.Length;
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
            LogOutput("Read operation finished");
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

        private void BtnTcpConnect_Click(object sender, EventArgs e)
        {
            string tcp = TxtTcp.Text;
            if (BtnTcpConnect.Text == "TCP connect")
            {
                LogOutput($"Connecting to reader {tcp}...");
                bool cn = RFIDReader.CreateTcpConn(tcp, this); // Connect to reader
                if (cn)
                {
                    LogOutput("Connect successfully to reader :D");
                    BtnTcpConnect.Text = "Disconnect";
                    ComboRoom.Enabled = false;
                    TxtSerial.Enabled = false;
                    TxtTcp.Enabled = false;
                    BtnSerialConnect.Enabled = false;
                    BtnStart.Enabled = true;
                    TxtCourseId.Enabled = true;
                    RFIDReader._RFIDConfig.Stop(tcp);

                    GetCurrentCourse();
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
                ComboRoom.Enabled = true;
                TxtSerial.Enabled = true;
                TxtTcp.Enabled = true;
                TxtCourseId.Enabled = false;
                BtnSerialConnect.Enabled = true;
                BtnStart.Enabled = false;
                BtnTcpConnect.Text = "TCP connect";
                LogOutput("Disconnected");
            }
        }

        private void BtnSerialConnect_Click(object sender, EventArgs e)
        {
            string serial = TxtSerial.Text;
            if (BtnTcpConnect.Text == "Serial connect")
            {
                LogOutput($"Connecting to reader {serial}...");
                bool cn = RFIDReader.CreateSerialConn(serial, this); // Connect to reader
                if (cn)
                {
                    LogOutput("Connect successfully to reader :D");
                    BtnTcpConnect.Text = "Disconnect";
                    ComboRoom.Enabled = false;
                    TxtSerial.Enabled = false;
                    TxtTcp.Enabled = false;
                    BtnTcpConnect.Enabled = false;
                    BtnStart.Enabled = true;
                    TxtCourseId.Enabled = true;
                    RFIDReader._RFIDConfig.Stop(serial);

                    GetCurrentCourse();
                }
                else
                {
                    LogOutput("Failed connection to reader D:");
                }
            }
            else
            {
                RFIDReader._RFIDConfig.Stop(serial); // Stop reading before disconnect
                RFIDReader.CloseConn(serial); // Disconnect with reader
                ComboRoom.Enabled = true;
                TxtSerial.Enabled = true;
                TxtTcp.Enabled = true;
                TxtCourseId.Enabled = false;
                BtnTcpConnect.Enabled = true;
                BtnStart.Enabled = false;
                BtnTcpConnect.Text = "Serial connect";
                LogOutput("Disconnected");
            }
        }

        private void BtnGetSettings_Click(object sender, EventArgs e)
        {

        }

        private void BtnSetSettings_Click(object sender, EventArgs e)
        {
            string tcp = ComboRoom.SelectedValue.ToString();

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
            string tcp = ComboRoom.SelectedValue.ToString();
            if (BtnStart.Text == "Start")
            {
                // Start reading with antenna 1, inventory mode (continuous reading)
                int st = RFIDReader._Tag6C.GetEPC_TID(tcp, eAntennaNo._1, eReadType.Inventory); 
                if (st == 0)
                {
                    LogOutput("Reading tags :D");
                    BtnStart.Text = "Stop";
                    BtnTcpConnect.Enabled = false;
                    BtnExit.Enabled = false;
                    TxtCourseId.Enabled = false;
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
                BtnTcpConnect.Enabled = true;
                BtnExit.Enabled = true;
                TxtCourseId.Enabled = true;
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

        private void BtnCheckConn_Click(object sender, EventArgs e)
        {
            if (RFIDReader.CheckConnect(ComboRoom.SelectedValue.ToString()))
            {
                LogOutput("Connection normal :D");
            }
            else
            {
                LogOutput("Connection abnormal!!!");
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
