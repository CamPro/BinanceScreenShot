namespace BinanceScreenShot
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonOpenProfile = new System.Windows.Forms.Button();
            this.checkShutdownAfterFinish = new System.Windows.Forms.CheckBox();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.checkExitApp = new System.Windows.Forms.CheckBox();
            this.dateTimeClock = new System.Windows.Forms.DateTimePicker();
            this.buttonFastSet = new System.Windows.Forms.Button();
            this.check7day = new System.Windows.Forms.CheckBox();
            this.check1month = new System.Windows.Forms.CheckBox();
            this.check3month = new System.Windows.Forms.CheckBox();
            this.check1year = new System.Windows.Forms.CheckBox();
            this.labelMsg = new System.Windows.Forms.Label();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.richTextCoin = new System.Windows.Forms.RichTextBox();
            this.buttonOpenDriver = new System.Windows.Forms.Button();
            this.buttonScanTopList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 47);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(308, 50);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonOpenProfile
            // 
            this.buttonOpenProfile.Location = new System.Drawing.Point(119, 415);
            this.buttonOpenProfile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenProfile.Name = "buttonOpenProfile";
            this.buttonOpenProfile.Size = new System.Drawing.Size(100, 40);
            this.buttonOpenProfile.TabIndex = 3;
            this.buttonOpenProfile.Text = "Open profile";
            this.buttonOpenProfile.UseVisualStyleBackColor = true;
            this.buttonOpenProfile.Click += new System.EventHandler(this.buttonOpenProfile_Click);
            // 
            // checkShutdownAfterFinish
            // 
            this.checkShutdownAfterFinish.AutoSize = true;
            this.checkShutdownAfterFinish.Location = new System.Drawing.Point(209, 478);
            this.checkShutdownAfterFinish.Name = "checkShutdownAfterFinish";
            this.checkShutdownAfterFinish.Size = new System.Drawing.Size(126, 21);
            this.checkShutdownAfterFinish.TabIndex = 16;
            this.checkShutdownAfterFinish.Text = "Shutdown finish";
            this.checkShutdownAfterFinish.UseVisualStyleBackColor = true;
            this.checkShutdownAfterFinish.CheckedChanged += new System.EventHandler(this.checkShutdownAfterFinish_CheckedChanged);
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // checkExitApp
            // 
            this.checkExitApp.AutoSize = true;
            this.checkExitApp.Checked = true;
            this.checkExitApp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExitApp.Location = new System.Drawing.Point(12, 478);
            this.checkExitApp.Name = "checkExitApp";
            this.checkExitApp.Size = new System.Drawing.Size(114, 21);
            this.checkExitApp.TabIndex = 17;
            this.checkExitApp.Text = "Exit app finish";
            this.checkExitApp.UseVisualStyleBackColor = true;
            // 
            // dateTimeClock
            // 
            this.dateTimeClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeClock.Location = new System.Drawing.Point(12, 110);
            this.dateTimeClock.Name = "dateTimeClock";
            this.dateTimeClock.Size = new System.Drawing.Size(180, 23);
            this.dateTimeClock.TabIndex = 1;
            this.dateTimeClock.ValueChanged += new System.EventHandler(this.dateTimeClock_ValueChanged);
            // 
            // buttonFastSet
            // 
            this.buttonFastSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFastSet.Location = new System.Drawing.Point(198, 110);
            this.buttonFastSet.Name = "buttonFastSet";
            this.buttonFastSet.Size = new System.Drawing.Size(122, 25);
            this.buttonFastSet.TabIndex = 2;
            this.buttonFastSet.Text = "set faster";
            this.buttonFastSet.UseVisualStyleBackColor = true;
            this.buttonFastSet.Click += new System.EventHandler(this.buttonFastSet_Click);
            // 
            // check7day
            // 
            this.check7day.AutoSize = true;
            this.check7day.Checked = true;
            this.check7day.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check7day.Location = new System.Drawing.Point(12, 12);
            this.check7day.Name = "check7day";
            this.check7day.Size = new System.Drawing.Size(62, 21);
            this.check7day.TabIndex = 19;
            this.check7day.Text = "7 day";
            this.check7day.UseVisualStyleBackColor = true;
            // 
            // check1month
            // 
            this.check1month.AutoSize = true;
            this.check1month.Location = new System.Drawing.Point(85, 12);
            this.check1month.Name = "check1month";
            this.check1month.Size = new System.Drawing.Size(78, 21);
            this.check1month.TabIndex = 20;
            this.check1month.Text = "1 month";
            this.check1month.UseVisualStyleBackColor = true;
            // 
            // check3month
            // 
            this.check3month.AutoSize = true;
            this.check3month.Location = new System.Drawing.Point(169, 12);
            this.check3month.Name = "check3month";
            this.check3month.Size = new System.Drawing.Size(78, 21);
            this.check3month.TabIndex = 21;
            this.check3month.Text = "3 month";
            this.check3month.UseVisualStyleBackColor = true;
            // 
            // check1year
            // 
            this.check1year.AutoSize = true;
            this.check1year.Location = new System.Drawing.Point(253, 12);
            this.check1year.Name = "check1year";
            this.check1year.Size = new System.Drawing.Size(67, 21);
            this.check1year.TabIndex = 22;
            this.check1year.Text = "1 year";
            this.check1year.UseVisualStyleBackColor = true;
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Location = new System.Drawing.Point(11, 136);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(39, 17);
            this.labelMsg.TabIndex = 24;
            this.labelMsg.Text = "timer";
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(12, 415);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(100, 40);
            this.buttonOpenFolder.TabIndex = 25;
            this.buttonOpenFolder.Text = "Open folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // richTextCoin
            // 
            this.richTextCoin.Location = new System.Drawing.Point(341, 12);
            this.richTextCoin.Name = "richTextCoin";
            this.richTextCoin.Size = new System.Drawing.Size(431, 487);
            this.richTextCoin.TabIndex = 26;
            this.richTextCoin.Text = "";
            this.richTextCoin.WordWrap = false;
            // 
            // buttonOpenDriver
            // 
            this.buttonOpenDriver.Location = new System.Drawing.Point(227, 415);
            this.buttonOpenDriver.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenDriver.Name = "buttonOpenDriver";
            this.buttonOpenDriver.Size = new System.Drawing.Size(100, 40);
            this.buttonOpenDriver.TabIndex = 28;
            this.buttonOpenDriver.Text = "Open driver";
            this.buttonOpenDriver.UseVisualStyleBackColor = true;
            this.buttonOpenDriver.Click += new System.EventHandler(this.buttonOpenDriver_Click);
            // 
            // buttonScanTopList
            // 
            this.buttonScanTopList.Location = new System.Drawing.Point(12, 356);
            this.buttonScanTopList.Name = "buttonScanTopList";
            this.buttonScanTopList.Size = new System.Drawing.Size(120, 40);
            this.buttonScanTopList.TabIndex = 30;
            this.buttonScanTopList.Text = "Scan top list";
            this.buttonScanTopList.UseVisualStyleBackColor = true;
            this.buttonScanTopList.Click += new System.EventHandler(this.buttonScanTopList_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.buttonScanTopList);
            this.Controls.Add(this.buttonOpenDriver);
            this.Controls.Add(this.richTextCoin);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.check1year);
            this.Controls.Add(this.check3month);
            this.Controls.Add(this.check1month);
            this.Controls.Add(this.check7day);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.checkExitApp);
            this.Controls.Add(this.buttonFastSet);
            this.Controls.Add(this.checkShutdownAfterFinish);
            this.Controls.Add(this.buttonOpenProfile);
            this.Controls.Add(this.dateTimeClock);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "Binance Screen Shot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonOpenProfile;
        private System.Windows.Forms.CheckBox checkShutdownAfterFinish;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.CheckBox checkExitApp;
        private System.Windows.Forms.DateTimePicker dateTimeClock;
        private System.Windows.Forms.Button buttonFastSet;
        private System.Windows.Forms.CheckBox check7day;
        private System.Windows.Forms.CheckBox check1month;
        private System.Windows.Forms.CheckBox check3month;
        private System.Windows.Forms.CheckBox check1year;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.RichTextBox richTextCoin;
        private System.Windows.Forms.Button buttonOpenDriver;
        private System.Windows.Forms.Button buttonScanTopList;
    }
}

