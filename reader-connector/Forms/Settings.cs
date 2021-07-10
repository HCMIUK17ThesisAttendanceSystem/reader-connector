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
            public int CurrentPeriod { set; get; }
            public string Weekday { set; get; }
        }

        public class Student
        {
            public Student() { }

            public string Name { get; set; }
            public bool Registered { get; set; }
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

            List<Room> rooms = new List<Room>();
            rooms.Add(new Room() { Code = "LA1.605", IpAddress = "10.8.42.28:9090" });
            rooms.Add(new Room() { Code = "LA1.302", IpAddress = "10.8.46.51:9090" });
            ComboRoom.DataSource = rooms;
            ComboRoom.DisplayMember = "Code";
            ComboRoom.ValueMember = "Code";

            ComboStartANTPower.SelectedItem = "24";
            ComboMidANTPower.SelectedItem = "20";

            LogSampleText();
            //ConnectSocket();
        }

        private void LogSampleNoCourse()
        {
            LogOutput($"There is no current course for LA1.605! Enjoy :D");
            LogOutput($"Stop reading tag :D");

        }
        private void LogSampleConnection()
        {
            LogOutput("Connecting to server...");
            LogOutput("Connected to server.");
            LogOutput("Connecting to reader...");
            LogOutput("Connect successfully to reader.");
            LogOutput("Fetching current course...");
            LogOutput($"Current course of LA1.605 is Introduction to Artificial Intelligence " +
                $"on tuesday (1-4)");
            LogOutput($"Antenna power is set to 24dBm for period 1.");
            LogOutput("Reading tags :D");
        }
        private void LogSampleAttendance()
        {
            LogOutput("Detecting tag...");
            LogOutput("Chiêm Quốc Hùng checked attendance successfully :D");
            LogOutput("Detecting tag...");
            LogOutput("Trần Minh Duy did not registered for this class :D");
            LogOutput("Detecting tag...");
            LogOutput("No tag data D:");
        }
        private void LogSampleAdjustPower()
        {
            LogOutput("Detecting tag...");
            LogOutput("Phan Nguyễn Xuân Phúc did not registered for this class :D");
            LogOutput("Detecting tag...");
            LogOutput("Chiêm Quốc Hùng checked attendance successfully :D");
            LogOutput($"Antenna power is set to 20dBm for period 2.");
            LogOutput($"Antenna power is set to 20dBm for period 3.");
            LogOutput("Detecting tag...");
            LogOutput("Chiêm Quốc Hùng checked attendance successfully :D");
            LogOutput($"Antenna power is set to 24dBm for period 4.");
        }
        private void LogSampleText()
        {
            LogSampleConnection();
            LogSampleAttendance();
            LogSampleAdjustPower();
            LogSampleNoCourse();
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

            client.On("scheduled-courses", response =>
            {
                string JsonResponse = JsonConvert.SerializeObject(response);
                ScheduledCoursesResponse res = JsonConvert.DeserializeObject<ScheduledCoursesResponse>(JsonResponse);
                Course[] scheduledCourses = res.data;

                string roomCode = ComboRoom.GetItemText(ComboRoom.SelectedItem);
                for (int i = 0; i < scheduledCourses.Length; i++)
                {
                    Course course = scheduledCourses[i];
                    if (course.RoomCode == roomCode)
                    {
                        SetCourseProp(course);
                        ToggleReadTags(true);
                        return;
                    }
                }
                SetNoCourseProp(roomCode);
                ToggleReadTags(false);
            });
        }

        private void ToggleReadTags(bool isReading)
        {
            string connection = GetConnectionString();
            if (isReading)
            {
                // Start reading with antenna 1, inventory mode (continuous reading)
                int st = RFIDReader._Tag6C.GetEPC_TID(connection, eAntennaNo._1, eReadType.Inventory);
                if (st == 0)
                {
                    LogOutput("Reading tags :D");
                    BtnStart.Text = "Stop";
                    BtnTcpConnect.Enabled = false;
                    BtnSerialConnect.Enabled = false;
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
                RFIDReader._RFIDConfig.Stop(connection);
                BtnStart.Text = "Start";
                LogOutput("Stop reading tag");
                if (BtnTcpConnect.Text == "Disconnect")
                    BtnTcpConnect.Enabled = true;
                else
                    BtnSerialConnect.Enabled = true;
                BtnExit.Enabled = true;
                TxtCourseId.Enabled = true;
            }
        }

        private void SetCourseProp(Course course)
        {
            TxtCourseId.Text = course._id;
            string periods = $"{course.Periods[0]} - {course.Periods[course.Periods.Length - 1]}";
            string weekday = GetWeekdayString(course.Weekday);
            LogOutput($"Current course of {course.RoomCode} is {course.SubjectName} :D\n" +
                $"On {weekday}, " +
                $"periods {periods}");
            LabelCourseName.Text = course.SubjectName;
            LabelTime.Text = $"{weekday} ({periods})";

            RFIDReader._RFIDConfig.Stop(GetConnectionString());
            int antPower = int.Parse(ComboMidANTPower.SelectedItem.ToString());
            if (course.CurrentPeriod == course.Periods[0] || course.CurrentPeriod == course.Periods[course.Periods.Length - 1])
                antPower = int.Parse(ComboStartANTPower.SelectedItem.ToString());
            int result = RFIDReader._RFIDConfig.SetANTPowerParam(GetConnectionString(), new Dictionary<int, int>()
                {{1, antPower}});
            if (result == 0) LogOutput($"Antenna power is set to {antPower}dBm for period {course.CurrentPeriod}");
            else LogOutput("Failure setting antenna power");

        }

        private void SetNoCourseProp(string roomCode)
        {
            LogOutput($"There is no current course for {roomCode}! Enjoy :D");
            LabelCourseName.Text = $"No course now! Enjoy :D";
            LabelTime.Text = "";
            TxtCourseId.Text = "nocourse";
        }

        private string GetWeekdayString(string Number)
        {
            switch (Number)
            {
                case "1":
                    return "Monday";
                case "2":
                    return "Tuesday";
                case "3":
                    return "Wednesday";
                case "4":
                    return "Thursday";
                case "5":
                    return "Friday";
                case "6":
                    return "Saturday";
                default:
                    return "unknown weekday";
            }
        }

        private void GetReaderParameters(string connection)
        {
            string antPower = RFIDReader._RFIDConfig.GetANTPowerParam(connection).ElementAt(0).Value.ToString();
            string autoSleep = RFIDReader._RFIDConfig.GetReaderAutoSleepParam(connection);
            string tagFilter = RFIDReader._RFIDConfig.GetTagUpdateParam(connection);
            LogOutput("Power of ANT1: " + antPower);
            LogOutput("Autosleep Param: " + autoSleep);
            LogOutput("Tag filtering: " + tagFilter);
            string[] aS = autoSleep.Split('|');
            string[] tF = tagFilter.Split('|');
            TxtAutosleep.Text = aS[1];
            TxtTagFilter.Text = tF[0];
        }

        private string GetConnectionString()
        {
            if (BtnTcpConnect.Text == "Disconnect")
                return TxtTcp.Text;
            else return TxtSerial.Text;
        }

        private async void GetCurrentCourse()
        {
            string roomCode = ComboRoom.GetItemText(ComboRoom.SelectedItem);
            LogOutput($"Fetching current course of {roomCode}...");
            string uri = $"{url}/reader/current-course/{roomCode}";
            string response = await RestAPIHelper.Get(uri);
            try
            {
                Course currentCourse = JsonConvert.DeserializeObject<Course>(response);
                SetCourseProp(currentCourse);
                ToggleReadTags(true);
            }
            catch (NullReferenceException)
            {
                SetNoCourseProp(roomCode);
                ToggleReadTags(false);
            }
        }

        private string AddNewRfidTag(string tagTID)
        {
            //TxtLog.Text += tagTID + "\r\n";
            HttpRequest request = new HttpRequest();
            string response = request.Post($"{url}/reader/rfid?rfidTag={tagTID}").ToString();
            return response;
        }

        private void CheckAttendance(string tagTID, string courseId)
        {
            if (courseId == "nocourse")
                return;
            HttpRequest request = new HttpRequest();
            string response = request.Post($"{url}/reader/attendance?rfidTag={tagTID}&courseId={courseId}").ToString();
            Student student = JsonConvert.DeserializeObject<Student>(response);
            if (student.Name != "Unknown" && student.Name != null)
            {
                if (student.Registered)
                {
                    LogOutput($"{student.Name} checked attendance successfully :D");
                }
                else
                {
                    LogOutput($"{student.Name} did not registered for this class :D");
                }
            }
            else
            {
                LogOutput("Unknown tag data D:");
            }
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
            LogOutput("Detecting tag(s)...");
            //string res = AddNewRfidTag(tag.TID);
            CheckAttendance(tag.TID, TxtCourseId.Text);
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

                    GetReaderParameters(tcp);
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
            if (BtnSerialConnect.Text == "Serial connect")
            {
                LogOutput($"Connecting to reader {serial}...");
                bool cn = RFIDReader.CreateSerialConn(serial, this); // Connect to reader
                if (cn)
                {
                    LogOutput("Connect successfully to reader :D");
                    BtnSerialConnect.Text = "Disconnect";
                    ComboRoom.Enabled = false;
                    TxtSerial.Enabled = false;
                    TxtTcp.Enabled = false;
                    BtnTcpConnect.Enabled = false;
                    BtnStart.Enabled = true;
                    TxtCourseId.Enabled = true;
                    RFIDReader._RFIDConfig.Stop(serial);

                    GetReaderParameters(serial);
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
                BtnSerialConnect.Text = "Serial connect";
                LogOutput("Disconnected");
            }
        }

        private void BtnGetSettings_Click(object sender, EventArgs e)
        {

        }

        private void BtnSetSettings_Click(object sender, EventArgs e)
        {
            string connection = GetConnectionString();

            // Stop reading the same tag for 1 minute (6000 centiseconds) (value = 6000)
            int stup = RFIDReader._RFIDConfig.SetTagUpdateParam(connection, int.Parse(TxtTagFilter.Text), 0);
            if (stup == 0) LogOutput("Set tag update filter successfully :D");
            else LogOutput("Set tag update filter failed D:");

            // auto sleep in 1/2 second (value = "50")
            int srasp = RFIDReader._RFIDConfig.SetReaderAutoSleepParam(connection, true, TxtAutosleep.Text);
            if (srasp == 0) LogOutput("Set auto sleep successfully :D");
            else LogOutput("Set auto sleep failed D:");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            string connection = GetConnectionString();

            if (BtnStart.Text == "Start")
            {
                // Start reading with antenna 1, inventory mode (continuous reading)
                int st = RFIDReader._Tag6C.GetEPC_TID(connection, eAntennaNo._1, eReadType.Inventory);
                if (st == 0)
                {
                    LogOutput("Reading tags :D");
                    BtnStart.Text = "Stop";
                    BtnTcpConnect.Enabled = false;
                    BtnSerialConnect.Enabled = false;
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
                RFIDReader._RFIDConfig.Stop(connection);
                BtnStart.Text = "Start";
                LogOutput("Stop reading tag");
                if (BtnTcpConnect.Text == "Disconnect")
                    BtnTcpConnect.Enabled = true;
                else
                    BtnSerialConnect.Enabled = true;
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
            string connection = GetConnectionString();

            if (RFIDReader.CheckConnect(connection))
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
