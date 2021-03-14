
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
            this.TxtTcp = new System.Windows.Forms.TextBox();
            this.TxtCourseId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtTcp
            // 
            this.TxtTcp.Location = new System.Drawing.Point(42, 12);
            this.TxtTcp.Name = "TxtTcp";
            this.TxtTcp.Size = new System.Drawing.Size(100, 20);
            this.TxtTcp.TabIndex = 0;
            // 
            // TxtCourseId
            // 
            this.TxtCourseId.Location = new System.Drawing.Point(42, 39);
            this.TxtCourseId.Name = "TxtCourseId";
            this.TxtCourseId.Size = new System.Drawing.Size(100, 20);
            this.TxtCourseId.TabIndex = 1;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtCourseId);
            this.Controls.Add(this.TxtTcp);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtTcp;
        private System.Windows.Forms.TextBox TxtCourseId;
    }
}