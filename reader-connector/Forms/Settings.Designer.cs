
namespace reader_connector.Forms
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TxtCourseId = new System.Windows.Forms.TextBox();
            this.GrpSetup = new System.Windows.Forms.GroupBox();
            this.TxtTcp = new System.Windows.Forms.TextBox();
            this.BtnSerialConnect = new System.Windows.Forms.Button();
            this.TxtSerial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboRoom = new System.Windows.Forms.ComboBox();
            this.BtnTcpConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCheckConn = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.GrpSettings = new System.Windows.Forms.GroupBox();
            this.LabelTime = new System.Windows.Forms.Label();
            this.LabelCourseName = new System.Windows.Forms.Label();
            this.BtnSetSettings = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTagFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtAutosleep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtLog = new System.Windows.Forms.RichTextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnClearLog = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.ComboMidANTPower = new System.Windows.Forms.ComboBox();
            this.ComboStartANTPower = new System.Windows.Forms.ComboBox();
            this.GrpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.GrpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCourseId
            // 
            this.TxtCourseId.Enabled = false;
            this.TxtCourseId.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCourseId.Location = new System.Drawing.Point(105, 73);
            this.TxtCourseId.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCourseId.Name = "TxtCourseId";
            this.TxtCourseId.Size = new System.Drawing.Size(132, 24);
            this.TxtCourseId.TabIndex = 1;
            // 
            // GrpSetup
            // 
            this.GrpSetup.Controls.Add(this.TxtTcp);
            this.GrpSetup.Controls.Add(this.BtnSerialConnect);
            this.GrpSetup.Controls.Add(this.TxtSerial);
            this.GrpSetup.Controls.Add(this.label8);
            this.GrpSetup.Controls.Add(this.label7);
            this.GrpSetup.Controls.Add(this.label6);
            this.GrpSetup.Controls.Add(this.ComboRoom);
            this.GrpSetup.Controls.Add(this.BtnTcpConnect);
            this.GrpSetup.Controls.Add(this.label2);
            this.GrpSetup.Controls.Add(this.label1);
            this.GrpSetup.Controls.Add(this.TxtCourseId);
            this.GrpSetup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpSetup.Location = new System.Drawing.Point(16, 15);
            this.GrpSetup.Margin = new System.Windows.Forms.Padding(4);
            this.GrpSetup.Name = "GrpSetup";
            this.GrpSetup.Padding = new System.Windows.Forms.Padding(4);
            this.GrpSetup.Size = new System.Drawing.Size(690, 112);
            this.GrpSetup.TabIndex = 2;
            this.GrpSetup.TabStop = false;
            this.GrpSetup.Text = "Setup";
            // 
            // TxtTcp
            // 
            this.TxtTcp.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTcp.Location = new System.Drawing.Point(397, 15);
            this.TxtTcp.Margin = new System.Windows.Forms.Padding(4);
            this.TxtTcp.Name = "TxtTcp";
            this.TxtTcp.Size = new System.Drawing.Size(150, 24);
            this.TxtTcp.TabIndex = 14;
            this.TxtTcp.Text = "10.8.42.28:9090";
            // 
            // BtnSerialConnect
            // 
            this.BtnSerialConnect.Location = new System.Drawing.Point(555, 76);
            this.BtnSerialConnect.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSerialConnect.Name = "BtnSerialConnect";
            this.BtnSerialConnect.Size = new System.Drawing.Size(127, 28);
            this.BtnSerialConnect.TabIndex = 13;
            this.BtnSerialConnect.Text = "Serial connect";
            this.BtnSerialConnect.UseVisualStyleBackColor = true;
            this.BtnSerialConnect.Click += new System.EventHandler(this.BtnSerialConnect_Click);
            // 
            // TxtSerial
            // 
            this.TxtSerial.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSerial.Location = new System.Drawing.Point(397, 78);
            this.TxtSerial.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSerial.Name = "TxtSerial";
            this.TxtSerial.Size = new System.Drawing.Size(150, 24);
            this.TxtSerial.TabIndex = 12;
            this.TxtSerial.Text = "COM3:115200";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 50);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 21);
            this.label8.TabIndex = 10;
            this.label8.Text = "or";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 81);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "RS232";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "TCP";
            // 
            // ComboRoom
            // 
            this.ComboRoom.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboRoom.FormattingEnabled = true;
            this.ComboRoom.Location = new System.Drawing.Point(105, 23);
            this.ComboRoom.Margin = new System.Windows.Forms.Padding(4);
            this.ComboRoom.Name = "ComboRoom";
            this.ComboRoom.Size = new System.Drawing.Size(132, 25);
            this.ComboRoom.TabIndex = 6;
            // 
            // BtnTcpConnect
            // 
            this.BtnTcpConnect.Location = new System.Drawing.Point(555, 15);
            this.BtnTcpConnect.Margin = new System.Windows.Forms.Padding(4);
            this.BtnTcpConnect.Name = "BtnTcpConnect";
            this.BtnTcpConnect.Size = new System.Drawing.Size(127, 28);
            this.BtnTcpConnect.TabIndex = 5;
            this.BtnTcpConnect.Text = "TCP connect";
            this.BtnTcpConnect.UseVisualStyleBackColor = true;
            this.BtnTcpConnect.Click += new System.EventHandler(this.BtnTcpConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Course ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Room";
            // 
            // BtnCheckConn
            // 
            this.BtnCheckConn.Location = new System.Drawing.Point(555, 54);
            this.BtnCheckConn.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCheckConn.Name = "BtnCheckConn";
            this.BtnCheckConn.Size = new System.Drawing.Size(127, 27);
            this.BtnCheckConn.TabIndex = 7;
            this.BtnCheckConn.Text = "Check Reader";
            this.BtnCheckConn.UseVisualStyleBackColor = true;
            this.BtnCheckConn.Click += new System.EventHandler(this.BtnCheckConn_Click);
            // 
            // GrpSettings
            // 
            this.GrpSettings.Controls.Add(this.ComboStartANTPower);
            this.GrpSettings.Controls.Add(this.ComboMidANTPower);
            this.GrpSettings.Controls.Add(this.label10);
            this.GrpSettings.Controls.Add(this.label9);
            this.GrpSettings.Controls.Add(this.BtnSetSettings);
            this.GrpSettings.Controls.Add(this.label4);
            this.GrpSettings.Controls.Add(this.TxtTagFilter);
            this.GrpSettings.Controls.Add(this.label5);
            this.GrpSettings.Controls.Add(this.BtnCheckConn);
            this.GrpSettings.Controls.Add(this.TxtAutosleep);
            this.GrpSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpSettings.Location = new System.Drawing.Point(16, 135);
            this.GrpSettings.Margin = new System.Windows.Forms.Padding(4);
            this.GrpSettings.Name = "GrpSettings";
            this.GrpSettings.Padding = new System.Windows.Forms.Padding(4);
            this.GrpSettings.Size = new System.Drawing.Size(690, 91);
            this.GrpSettings.TabIndex = 6;
            this.GrpSettings.TabStop = false;
            this.GrpSettings.Text = "Settings";
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTime.Location = new System.Drawing.Point(23, 280);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(0, 29);
            this.LabelTime.TabIndex = 9;
            this.LabelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelCourseName
            // 
            this.LabelCourseName.AutoSize = true;
            this.LabelCourseName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCourseName.Location = new System.Drawing.Point(23, 238);
            this.LabelCourseName.Name = "LabelCourseName";
            this.LabelCourseName.Size = new System.Drawing.Size(0, 29);
            this.LabelCourseName.TabIndex = 8;
            this.LabelCourseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSetSettings
            // 
            this.BtnSetSettings.Location = new System.Drawing.Point(555, 23);
            this.BtnSetSettings.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSetSettings.Name = "BtnSetSettings";
            this.BtnSetSettings.Size = new System.Drawing.Size(127, 28);
            this.BtnSetSettings.TabIndex = 5;
            this.BtnSetSettings.Text = "Set Parameters";
            this.BtnSetSettings.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSetSettings.UseVisualStyleBackColor = true;
            this.BtnSetSettings.Click += new System.EventHandler(this.BtnSetSettings_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Autosleep";
            // 
            // TxtTagFilter
            // 
            this.TxtTagFilter.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTagFilter.Location = new System.Drawing.Point(105, 23);
            this.TxtTagFilter.Margin = new System.Windows.Forms.Padding(4);
            this.TxtTagFilter.Name = "TxtTagFilter";
            this.TxtTagFilter.Size = new System.Drawing.Size(118, 24);
            this.TxtTagFilter.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tag Filter";
            // 
            // TxtAutosleep
            // 
            this.TxtAutosleep.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAutosleep.Location = new System.Drawing.Point(105, 58);
            this.TxtAutosleep.Margin = new System.Windows.Forms.Padding(4);
            this.TxtAutosleep.Name = "TxtAutosleep";
            this.TxtAutosleep.Size = new System.Drawing.Size(118, 24);
            this.TxtAutosleep.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 309);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Log";
            // 
            // TxtLog
            // 
            this.TxtLog.Font = new System.Drawing.Font("Calibri", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLog.Location = new System.Drawing.Point(16, 334);
            this.TxtLog.Margin = new System.Windows.Forms.Padding(4);
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ReadOnly = true;
            this.TxtLog.Size = new System.Drawing.Size(576, 613);
            this.TxtLog.TabIndex = 7;
            this.TxtLog.Text = "";
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(598, 370);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(100, 28);
            this.BtnStart.TabIndex = 7;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnClearLog
            // 
            this.BtnClearLog.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearLog.Location = new System.Drawing.Point(598, 334);
            this.BtnClearLog.Margin = new System.Windows.Forms.Padding(4);
            this.BtnClearLog.Name = "BtnClearLog";
            this.BtnClearLog.Size = new System.Drawing.Size(100, 28);
            this.BtnClearLog.TabIndex = 8;
            this.BtnClearLog.Text = "Clear Log";
            this.BtnClearLog.UseVisualStyleBackColor = true;
            this.BtnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.Location = new System.Drawing.Point(600, 919);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(100, 28);
            this.BtnExit.TabIndex = 9;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 21);
            this.label9.TabIndex = 8;
            this.label9.Text = "Start/End ANT Power";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(249, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 21);
            this.label10.TabIndex = 9;
            this.label10.Text = "Middle ANT Power";
            // 
            // ComboMidANTPower
            // 
            this.ComboMidANTPower.FormattingEnabled = true;
            this.ComboMidANTPower.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.ComboMidANTPower.Location = new System.Drawing.Point(397, 54);
            this.ComboMidANTPower.Name = "ComboMidANTPower";
            this.ComboMidANTPower.Size = new System.Drawing.Size(150, 27);
            this.ComboMidANTPower.TabIndex = 15;
            // 
            // ComboStartANTPower
            // 
            this.ComboStartANTPower.FormattingEnabled = true;
            this.ComboStartANTPower.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.ComboStartANTPower.Location = new System.Drawing.Point(397, 21);
            this.ComboStartANTPower.Name = "ComboStartANTPower";
            this.ComboStartANTPower.Size = new System.Drawing.Size(150, 27);
            this.ComboStartANTPower.TabIndex = 16;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 960);
            this.Controls.Add(this.LabelTime);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.LabelCourseName);
            this.Controls.Add(this.BtnClearLog);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.GrpSettings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GrpSetup);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(737, 1007);
            this.Name = "Settings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.GrpSetup.ResumeLayout(false);
            this.GrpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.GrpSettings.ResumeLayout(false);
            this.GrpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtCourseId;
        private System.Windows.Forms.GroupBox GrpSetup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button BtnTcpConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GrpSettings;
        private System.Windows.Forms.Button BtnSetSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtTagFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtAutosleep;
        private System.Windows.Forms.ComboBox ComboRoom;
        private System.Windows.Forms.Button BtnCheckConn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox TxtLog;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnClearLog;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnSerialConnect;
        private System.Windows.Forms.TextBox TxtSerial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtTcp;
        private System.Windows.Forms.Label LabelTime;
        private System.Windows.Forms.Label LabelCourseName;
        private System.Windows.Forms.ComboBox ComboStartANTPower;
        private System.Windows.Forms.ComboBox ComboMidANTPower;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}