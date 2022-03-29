
namespace FaceRecognition
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_en = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_vi = new System.Windows.Forms.ToolStripMenuItem();
            this.aaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giớiThiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceTreeview = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CameraLiveView = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picSettingDisplayMode = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtMotorCount = new System.Windows.Forms.Label();
            this.txtPersonWithMask = new System.Windows.Forms.Label();
            this.txtCarCount = new System.Windows.Forms.Label();
            this.txtPersonWithNoMask = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtPersonCount = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.Label();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.TimerGetDataFromQueue = new System.Windows.Forms.Timer(this.components);
            this.GCTimer = new System.Windows.Forms.Timer(this.components);
            this.txtCheckInStatus = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraLiveView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingDisplayMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.trợGiúpToolStripMenuItem,
            this.báoCáoToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSetting,
            this.tsmLanguage,
            this.aaToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            resources.ApplyResources(this.systemToolStripMenuItem, "systemToolStripMenuItem");
            // 
            // tsmSetting
            // 
            resources.ApplyResources(this.tsmSetting, "tsmSetting");
            this.tsmSetting.Name = "tsmSetting";
            this.tsmSetting.Click += new System.EventHandler(this.tsmSetting_Click);
            // 
            // tsmLanguage
            // 
            this.tsmLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_en,
            this.MI_vi});
            resources.ApplyResources(this.tsmLanguage, "tsmLanguage");
            this.tsmLanguage.Name = "tsmLanguage";
            // 
            // MI_en
            // 
            resources.ApplyResources(this.MI_en, "MI_en");
            this.MI_en.Name = "MI_en";
            this.MI_en.Click += new System.EventHandler(this.MI_en_Click);
            // 
            // MI_vi
            // 
            resources.ApplyResources(this.MI_vi, "MI_vi");
            this.MI_vi.Name = "MI_vi";
            this.MI_vi.Click += new System.EventHandler(this.MI_vi_Click);
            // 
            // aaToolStripMenuItem
            // 
            this.aaToolStripMenuItem.Name = "aaToolStripMenuItem";
            resources.ApplyResources(this.aaToolStripMenuItem, "aaToolStripMenuItem");
            this.aaToolStripMenuItem.Click += new System.EventHandler(this.aaToolStripMenuItem_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giớiThiệuToolStripMenuItem,
            this.hướngDẫnSửDụngToolStripMenuItem});
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            resources.ApplyResources(this.trợGiúpToolStripMenuItem, "trợGiúpToolStripMenuItem");
            // 
            // giớiThiệuToolStripMenuItem
            // 
            resources.ApplyResources(this.giớiThiệuToolStripMenuItem, "giớiThiệuToolStripMenuItem");
            this.giớiThiệuToolStripMenuItem.Name = "giớiThiệuToolStripMenuItem";
            // 
            // hướngDẫnSửDụngToolStripMenuItem
            // 
            resources.ApplyResources(this.hướngDẫnSửDụngToolStripMenuItem, "hướngDẫnSửDụngToolStripMenuItem");
            this.hướngDẫnSửDụngToolStripMenuItem.Name = "hướngDẫnSửDụngToolStripMenuItem";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáo1ToolStripMenuItem,
            this.timKiếmToolStripMenuItem,
            this.vehicleReportToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            resources.ApplyResources(this.báoCáoToolStripMenuItem, "báoCáoToolStripMenuItem");
            // 
            // báoCáo1ToolStripMenuItem
            // 
            resources.ApplyResources(this.báoCáo1ToolStripMenuItem, "báoCáo1ToolStripMenuItem");
            this.báoCáo1ToolStripMenuItem.Name = "báoCáo1ToolStripMenuItem";
            this.báoCáo1ToolStripMenuItem.Click += new System.EventHandler(this.báoCáo1ToolStripMenuItem_Click);
            // 
            // timKiếmToolStripMenuItem
            // 
            this.timKiếmToolStripMenuItem.Name = "timKiếmToolStripMenuItem";
            resources.ApplyResources(this.timKiếmToolStripMenuItem, "timKiếmToolStripMenuItem");
            this.timKiếmToolStripMenuItem.Click += new System.EventHandler(this.timKiếmToolStripMenuItem_Click);
            // 
            // vehicleReportToolStripMenuItem
            // 
            this.vehicleReportToolStripMenuItem.Name = "vehicleReportToolStripMenuItem";
            resources.ApplyResources(this.vehicleReportToolStripMenuItem, "vehicleReportToolStripMenuItem");
            this.vehicleReportToolStripMenuItem.Click += new System.EventHandler(this.vehicleReportToolStripMenuItem_Click);
            // 
            // DeviceTreeview
            // 
            resources.ApplyResources(this.DeviceTreeview, "DeviceTreeview");
            this.DeviceTreeview.Name = "DeviceTreeview";
            this.DeviceTreeview.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.DeviceTreeview_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ball_green.ico");
            this.imageList1.Images.SetKeyName(1, "ball_red.ico");
            // 
            // CameraLiveView
            // 
            resources.ApplyResources(this.CameraLiveView, "CameraLiveView");
            this.CameraLiveView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CameraLiveView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CameraLiveView.Name = "CameraLiveView";
            this.CameraLiveView.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picSettingDisplayMode);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.txtMotorCount);
            this.panel1.Controls.Add(this.txtPersonWithMask);
            this.panel1.Controls.Add(this.txtCarCount);
            this.panel1.Controls.Add(this.txtPersonWithNoMask);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.txtPersonCount);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // picSettingDisplayMode
            // 
            resources.ApplyResources(this.picSettingDisplayMode, "picSettingDisplayMode");
            this.picSettingDisplayMode.Name = "picSettingDisplayMode";
            this.picSettingDisplayMode.TabStop = false;
            this.picSettingDisplayMode.Click += new System.EventHandler(this.PicSellectDisplayMode_Click);
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // txtMotorCount
            // 
            resources.ApplyResources(this.txtMotorCount, "txtMotorCount");
            this.txtMotorCount.Name = "txtMotorCount";
            // 
            // txtPersonWithMask
            // 
            resources.ApplyResources(this.txtPersonWithMask, "txtPersonWithMask");
            this.txtPersonWithMask.Name = "txtPersonWithMask";
            // 
            // txtCarCount
            // 
            resources.ApplyResources(this.txtCarCount, "txtCarCount");
            this.txtCarCount.Name = "txtCarCount";
            // 
            // txtPersonWithNoMask
            // 
            resources.ApplyResources(this.txtPersonWithNoMask, "txtPersonWithNoMask");
            this.txtPersonWithNoMask.Name = "txtPersonWithNoMask";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // txtPersonCount
            // 
            resources.ApplyResources(this.txtPersonCount, "txtPersonCount");
            this.txtPersonCount.Name = "txtPersonCount";
            // 
            // txtServerName
            // 
            resources.ApplyResources(this.txtServerName, "txtServerName");
            this.txtServerName.Name = "txtServerName";
            // 
            // picStatus
            // 
            resources.ApplyResources(this.picStatus, "picStatus");
            this.picStatus.Name = "picStatus";
            this.picStatus.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.timerServerStatusCheck_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtServerName);
            this.panel2.Controls.Add(this.picStatus);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // TimerGetDataFromQueue
            // 
            this.TimerGetDataFromQueue.Enabled = true;
            this.TimerGetDataFromQueue.Interval = 1000;
            this.TimerGetDataFromQueue.Tick += new System.EventHandler(this.TimerGetDataFromQueue_Tick);
            // 
            // GCTimer
            // 
            this.GCTimer.Enabled = true;
            this.GCTimer.Interval = 30000;
            this.GCTimer.Tick += new System.EventHandler(this.GCTimer_Tick);
            // 
            // txtCheckInStatus
            // 
            resources.ApplyResources(this.txtCheckInStatus, "txtCheckInStatus");
            this.txtCheckInStatus.Name = "txtCheckInStatus";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.txtCheckInStatus);
            this.panel3.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.CameraLiveView);
            this.Controls.Add(this.DeviceTreeview);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraLiveView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSettingDisplayMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmLanguage;
        private System.Windows.Forms.ToolStripMenuItem MI_en;
        private System.Windows.Forms.ToolStripMenuItem MI_vi;
        private System.Windows.Forms.TreeView DeviceTreeview;
        private System.Windows.Forms.PictureBox CameraLiveView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtPersonCount;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giớiThiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnSửDụngToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label txtPersonWithNoMask;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label txtPersonWithMask;
        private System.Windows.Forms.Label txtServerName;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáo1ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem timKiếmToolStripMenuItem;
        private System.Windows.Forms.Timer TimerGetDataFromQueue;
        private System.Windows.Forms.Label txtMotorCount;
        private System.Windows.Forms.Label txtCarCount;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Timer GCTimer;
        private System.Windows.Forms.ToolStripMenuItem vehicleReportToolStripMenuItem;
        private System.Windows.Forms.PictureBox picSettingDisplayMode;
        private System.Windows.Forms.Label txtCheckInStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem aaToolStripMenuItem;
    }
}

