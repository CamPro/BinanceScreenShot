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
            this.label1 = new System.Windows.Forms.Label();
            this.textTelegramLink = new System.Windows.Forms.TextBox();
            this.buttonOpenProfile = new System.Windows.Forms.Button();
            this.checkShutdownAfterFinish = new System.Windows.Forms.CheckBox();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.checkExitApp = new System.Windows.Forms.CheckBox();
            this.textBinanceCoin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioChart1Day = new System.Windows.Forms.RadioButton();
            this.radioChart7Day = new System.Windows.Forms.RadioButton();
            this.radioChart1Month = new System.Windows.Forms.RadioButton();
            this.radioChart3Month = new System.Windows.Forms.RadioButton();
            this.radioChart1Year = new System.Windows.Forms.RadioButton();
            this.dateTimeClock = new System.Windows.Forms.DateTimePicker();
            this.labelMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(13, 13);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(150, 50);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Telegram group";
            // 
            // textTelegramLink
            // 
            this.textTelegramLink.Location = new System.Drawing.Point(162, 80);
            this.textTelegramLink.Name = "textTelegramLink";
            this.textTelegramLink.Size = new System.Drawing.Size(310, 23);
            this.textTelegramLink.TabIndex = 5;
            this.textTelegramLink.TextChanged += new System.EventHandler(this.textTelegramLink_TextChanged);
            // 
            // buttonOpenProfile
            // 
            this.buttonOpenProfile.Location = new System.Drawing.Point(322, 13);
            this.buttonOpenProfile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenProfile.Name = "buttonOpenProfile";
            this.buttonOpenProfile.Size = new System.Drawing.Size(150, 50);
            this.buttonOpenProfile.TabIndex = 3;
            this.buttonOpenProfile.Text = "Open profile";
            this.buttonOpenProfile.UseVisualStyleBackColor = true;
            this.buttonOpenProfile.Click += new System.EventHandler(this.buttonOpenProfile_Click);
            // 
            // checkShutdownAfterFinish
            // 
            this.checkShutdownAfterFinish.AutoSize = true;
            this.checkShutdownAfterFinish.Location = new System.Drawing.Point(13, 232);
            this.checkShutdownAfterFinish.Name = "checkShutdownAfterFinish";
            this.checkShutdownAfterFinish.Size = new System.Drawing.Size(159, 21);
            this.checkShutdownAfterFinish.TabIndex = 13;
            this.checkShutdownAfterFinish.Text = "Shutdown after finish";
            this.checkShutdownAfterFinish.UseVisualStyleBackColor = true;
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
            this.checkExitApp.Location = new System.Drawing.Point(325, 232);
            this.checkExitApp.Name = "checkExitApp";
            this.checkExitApp.Size = new System.Drawing.Size(147, 21);
            this.checkExitApp.TabIndex = 14;
            this.checkExitApp.Text = "Exit app after finish";
            this.checkExitApp.UseVisualStyleBackColor = true;
            // 
            // textBinanceCoin
            // 
            this.textBinanceCoin.Location = new System.Drawing.Point(163, 119);
            this.textBinanceCoin.Name = "textBinanceCoin";
            this.textBinanceCoin.Size = new System.Drawing.Size(310, 23);
            this.textBinanceCoin.TabIndex = 7;
            this.textBinanceCoin.TextChanged += new System.EventHandler(this.textBinanceCoin_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Binance coin";
            // 
            // radioChart1Day
            // 
            this.radioChart1Day.AutoSize = true;
            this.radioChart1Day.Checked = true;
            this.radioChart1Day.Location = new System.Drawing.Point(14, 168);
            this.radioChart1Day.Name = "radioChart1Day";
            this.radioChart1Day.Size = new System.Drawing.Size(69, 21);
            this.radioChart1Day.TabIndex = 8;
            this.radioChart1Day.TabStop = true;
            this.radioChart1Day.Text = "1 ngày";
            this.radioChart1Day.UseVisualStyleBackColor = true;
            // 
            // radioChart7Day
            // 
            this.radioChart7Day.AutoSize = true;
            this.radioChart7Day.Location = new System.Drawing.Point(106, 168);
            this.radioChart7Day.Name = "radioChart7Day";
            this.radioChart7Day.Size = new System.Drawing.Size(69, 21);
            this.radioChart7Day.TabIndex = 9;
            this.radioChart7Day.Text = "7 ngày";
            this.radioChart7Day.UseVisualStyleBackColor = true;
            // 
            // radioChart1Month
            // 
            this.radioChart1Month.AutoSize = true;
            this.radioChart1Month.Location = new System.Drawing.Point(204, 168);
            this.radioChart1Month.Name = "radioChart1Month";
            this.radioChart1Month.Size = new System.Drawing.Size(74, 21);
            this.radioChart1Month.TabIndex = 10;
            this.radioChart1Month.Text = "1 tháng";
            this.radioChart1Month.UseVisualStyleBackColor = true;
            // 
            // radioChart3Month
            // 
            this.radioChart3Month.AutoSize = true;
            this.radioChart3Month.Location = new System.Drawing.Point(309, 168);
            this.radioChart3Month.Name = "radioChart3Month";
            this.radioChart3Month.Size = new System.Drawing.Size(74, 21);
            this.radioChart3Month.TabIndex = 11;
            this.radioChart3Month.Text = "3 tháng";
            this.radioChart3Month.UseVisualStyleBackColor = true;
            // 
            // radioChart1Year
            // 
            this.radioChart1Year.AutoSize = true;
            this.radioChart1Year.Location = new System.Drawing.Point(407, 168);
            this.radioChart1Year.Name = "radioChart1Year";
            this.radioChart1Year.Size = new System.Drawing.Size(65, 21);
            this.radioChart1Year.TabIndex = 12;
            this.radioChart1Year.Text = "1 năm";
            this.radioChart1Year.UseVisualStyleBackColor = true;
            // 
            // dateTimeClock
            // 
            this.dateTimeClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeClock.Location = new System.Drawing.Point(170, 13);
            this.dateTimeClock.Name = "dateTimeClock";
            this.dateTimeClock.Size = new System.Drawing.Size(145, 23);
            this.dateTimeClock.TabIndex = 1;
            this.dateTimeClock.ValueChanged += new System.EventHandler(this.dateTimeClock_ValueChanged);
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMsg.Location = new System.Drawing.Point(169, 42);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(12, 17);
            this.labelMsg.TabIndex = 2;
            this.labelMsg.Text = ".";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.dateTimeClock);
            this.Controls.Add(this.radioChart1Year);
            this.Controls.Add(this.radioChart3Month);
            this.Controls.Add(this.radioChart1Month);
            this.Controls.Add(this.radioChart7Day);
            this.Controls.Add(this.radioChart1Day);
            this.Controls.Add(this.textBinanceCoin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkExitApp);
            this.Controls.Add(this.checkShutdownAfterFinish);
            this.Controls.Add(this.buttonOpenProfile);
            this.Controls.Add(this.textTelegramLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTelegramLink;
        private System.Windows.Forms.Button buttonOpenProfile;
        private System.Windows.Forms.CheckBox checkShutdownAfterFinish;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.CheckBox checkExitApp;
        private System.Windows.Forms.TextBox textBinanceCoin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioChart1Day;
        private System.Windows.Forms.RadioButton radioChart7Day;
        private System.Windows.Forms.RadioButton radioChart1Month;
        private System.Windows.Forms.RadioButton radioChart3Month;
        private System.Windows.Forms.RadioButton radioChart1Year;
        private System.Windows.Forms.DateTimePicker dateTimeClock;
        private System.Windows.Forms.Label labelMsg;
    }
}

