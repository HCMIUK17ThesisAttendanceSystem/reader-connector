
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
            this.BtnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.GrpSettings = new System.Windows.Forms.GroupBox();
            this.BtnSetSettings = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTagFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtAutosleep = new System.Windows.Forms.TextBox();
            this.BtnGetSettings = new System.Windows.Forms.Button();
            this.TxtLog = new System.Windows.Forms.RichTextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnClearLog = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.ComboTcp = new System.Windows.Forms.ComboBox();
            this.GrpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.GrpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtCourseId
            // 
            this.TxtCourseId.Location = new System.Drawing.Point(79, 45);
            this.TxtCourseId.Name = "TxtCourseId";
            this.TxtCourseId.Size = new System.Drawing.Size(154, 20);
            this.TxtCourseId.TabIndex = 1;
            // 
            // GrpSetup
            // 
            this.GrpSetup.Controls.Add(this.ComboTcp);
            this.GrpSetup.Controls.Add(this.BtnConnect);
            this.GrpSetup.Controls.Add(this.label2);
            this.GrpSetup.Controls.Add(this.label1);
            this.GrpSetup.Controls.Add(this.TxtCourseId);
            this.GrpSetup.Location = new System.Drawing.Point(12, 12);
            this.GrpSetup.Name = "GrpSetup";
            this.GrpSetup.Size = new System.Drawing.Size(322, 74);
            this.GrpSetup.TabIndex = 2;
            this.GrpSetup.TabStop = false;
            this.GrpSetup.Text = "Setup";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(239, 17);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 23);
            this.BtnConnect.TabIndex = 5;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Course ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "TCP Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Log";
            // 
            // GrpSettings
            // 
            this.GrpSettings.Controls.Add(this.BtnGetSettings);
            this.GrpSettings.Controls.Add(this.BtnSetSettings);
            this.GrpSettings.Controls.Add(this.label4);
            this.GrpSettings.Controls.Add(this.TxtTagFilter);
            this.GrpSettings.Controls.Add(this.label5);
            this.GrpSettings.Controls.Add(this.TxtAutosleep);
            this.GrpSettings.Location = new System.Drawing.Point(340, 12);
            this.GrpSettings.Name = "GrpSettings";
            this.GrpSettings.Size = new System.Drawing.Size(265, 74);
            this.GrpSettings.TabIndex = 6;
            this.GrpSettings.TabStop = false;
            this.GrpSettings.Text = "Settings";
            // 
            // BtnSetSettings
            // 
            this.BtnSetSettings.Location = new System.Drawing.Point(185, 43);
            this.BtnSetSettings.Name = "BtnSetSettings";
            this.BtnSetSettings.Size = new System.Drawing.Size(75, 23);
            this.BtnSetSettings.TabIndex = 5;
            this.BtnSetSettings.Text = "Set";
            this.BtnSetSettings.UseVisualStyleBackColor = true;
            this.BtnSetSettings.Click += new System.EventHandler(this.BtnSetSettings_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Autosleep";
            // 
            // TxtTagFilter
            // 
            this.TxtTagFilter.Location = new System.Drawing.Point(79, 19);
            this.TxtTagFilter.Name = "TxtTagFilter";
            this.TxtTagFilter.Size = new System.Drawing.Size(100, 20);
            this.TxtTagFilter.TabIndex = 0;
            this.TxtTagFilter.Text = "6000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tag Filter";
            // 
            // TxtAutosleep
            // 
            this.TxtAutosleep.Location = new System.Drawing.Point(79, 45);
            this.TxtAutosleep.Name = "TxtAutosleep";
            this.TxtAutosleep.Size = new System.Drawing.Size(100, 20);
            this.TxtAutosleep.TabIndex = 1;
            this.TxtAutosleep.Text = "50";
            // 
            // BtnGetSettings
            // 
            this.BtnGetSettings.Location = new System.Drawing.Point(184, 17);
            this.BtnGetSettings.Name = "BtnGetSettings";
            this.BtnGetSettings.Size = new System.Drawing.Size(75, 23);
            this.BtnGetSettings.TabIndex = 6;
            this.BtnGetSettings.Text = "Get";
            this.BtnGetSettings.UseVisualStyleBackColor = true;
            this.BtnGetSettings.Click += new System.EventHandler(this.BtnGetSettings_Click);
            // 
            // TxtLog
            // 
            this.TxtLog.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLog.Location = new System.Drawing.Point(12, 106);
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.Size = new System.Drawing.Size(506, 453);
            this.TxtLog.TabIndex = 7;
            this.TxtLog.Text = "";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(524, 106);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 7;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnClearLog
            // 
            this.BtnClearLog.Location = new System.Drawing.Point(524, 135);
            this.BtnClearLog.Name = "BtnClearLog";
            this.BtnClearLog.Size = new System.Drawing.Size(75, 23);
            this.BtnClearLog.TabIndex = 8;
            this.BtnClearLog.Text = "Clear Log";
            this.BtnClearLog.UseVisualStyleBackColor = true;
            this.BtnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(524, 536);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 9;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // ComboTcp
            // 
            this.ComboTcp.FormattingEnabled = true;
            this.ComboTcp.Location = new System.Drawing.Point(79, 19);
            this.ComboTcp.Name = "ComboTcp";
            this.ComboTcp.Size = new System.Drawing.Size(154, 21);
            this.ComboTcp.TabIndex = 6;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 571);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnClearLog);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.GrpSettings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GrpSetup);
            this.Name = "Settings";
            this.Text = "Settings";
            this.GrpSetup.ResumeLayout(false);
            this.GrpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.GrpSettings.ResumeLayout(false);
            this.GrpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtCourseId;
        private System.Windows.Forms.GroupBox GrpSetup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GrpSettings;
        private System.Windows.Forms.Button BtnGetSettings;
        private System.Windows.Forms.Button BtnSetSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtTagFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtAutosleep;
        private System.Windows.Forms.RichTextBox TxtLog;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnClearLog;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.ComboBox ComboTcp;
    }
}