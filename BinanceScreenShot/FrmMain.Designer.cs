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
            this.textTelegram1day = new System.Windows.Forms.TextBox();
            this.buttonOpenProfile = new System.Windows.Forms.Button();
            this.checkShutdownAfterFinish = new System.Windows.Forms.CheckBox();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.checkExitApp = new System.Windows.Forms.CheckBox();
            this.textBinanceCoin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeClock = new System.Windows.Forms.DateTimePicker();
            this.labelMsg = new System.Windows.Forms.Label();
            this.textTelegram7day = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textTelegram1month = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textTelegram3month = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textTelegram1year = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonFastSet = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(11, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Telegram 1 ngày";
            // 
            // textTelegram1day
            // 
            this.textTelegram1day.Location = new System.Drawing.Point(163, 112);
            this.textTelegram1day.Name = "textTelegram1day";
            this.textTelegram1day.Size = new System.Drawing.Size(310, 23);
            this.textTelegram1day.TabIndex = 7;
            this.textTelegram1day.TextChanged += new System.EventHandler(this.textTelegram1day_TextChanged);
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
            this.checkShutdownAfterFinish.Location = new System.Drawing.Point(13, 284);
            this.checkShutdownAfterFinish.Name = "checkShutdownAfterFinish";
            this.checkShutdownAfterFinish.Size = new System.Drawing.Size(159, 21);
            this.checkShutdownAfterFinish.TabIndex = 16;
            this.checkShutdownAfterFinish.Text = "Shutdown after finish";
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
            this.checkExitApp.Location = new System.Drawing.Point(325, 284);
            this.checkExitApp.Name = "checkExitApp";
            this.checkExitApp.Size = new System.Drawing.Size(147, 21);
            this.checkExitApp.TabIndex = 17;
            this.checkExitApp.Text = "Exit app after finish";
            this.checkExitApp.UseVisualStyleBackColor = true;
            // 
            // textBinanceCoin
            // 
            this.textBinanceCoin.Location = new System.Drawing.Point(163, 74);
            this.textBinanceCoin.Name = "textBinanceCoin";
            this.textBinanceCoin.Size = new System.Drawing.Size(310, 23);
            this.textBinanceCoin.TabIndex = 5;
            this.textBinanceCoin.TextChanged += new System.EventHandler(this.textBinanceCoin_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Binance coin";
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
            // textTelegram7day
            // 
            this.textTelegram7day.Location = new System.Drawing.Point(163, 143);
            this.textTelegram7day.Name = "textTelegram7day";
            this.textTelegram7day.Size = new System.Drawing.Size(310, 23);
            this.textTelegram7day.TabIndex = 9;
            this.textTelegram7day.TextChanged += new System.EventHandler(this.textTelegram7day_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Telegram 7 ngày";
            // 
            // textTelegram1month
            // 
            this.textTelegram1month.Location = new System.Drawing.Point(163, 174);
            this.textTelegram1month.Name = "textTelegram1month";
            this.textTelegram1month.Size = new System.Drawing.Size(310, 23);
            this.textTelegram1month.TabIndex = 11;
            this.textTelegram1month.TextChanged += new System.EventHandler(this.textTelegram1month_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Telegram 1 tháng";
            // 
            // textTelegram3month
            // 
            this.textTelegram3month.Location = new System.Drawing.Point(163, 205);
            this.textTelegram3month.Name = "textTelegram3month";
            this.textTelegram3month.Size = new System.Drawing.Size(310, 23);
            this.textTelegram3month.TabIndex = 13;
            this.textTelegram3month.TextChanged += new System.EventHandler(this.textTelegram3month_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Telegram 3 Tháng";
            // 
            // textTelegram1year
            // 
            this.textTelegram1year.Location = new System.Drawing.Point(163, 236);
            this.textTelegram1year.Name = "textTelegram1year";
            this.textTelegram1year.Size = new System.Drawing.Size(310, 23);
            this.textTelegram1year.TabIndex = 15;
            this.textTelegram1year.TextChanged += new System.EventHandler(this.textTelegram1year_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Telegram 1 năm";
            // 
            // buttonFastSet
            // 
            this.buttonFastSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFastSet.Location = new System.Drawing.Point(208, 40);
            this.buttonFastSet.Name = "buttonFastSet";
            this.buttonFastSet.Size = new System.Drawing.Size(75, 23);
            this.buttonFastSet.TabIndex = 2;
            this.buttonFastSet.Text = "set faster";
            this.buttonFastSet.UseVisualStyleBackColor = true;
            this.buttonFastSet.Click += new System.EventHandler(this.buttonFastSet_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.buttonFastSet);
            this.Controls.Add(this.textTelegram1year);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textTelegram3month);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textTelegram1month);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textTelegram7day);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.dateTimeClock);
            this.Controls.Add(this.textBinanceCoin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkExitApp);
            this.Controls.Add(this.checkShutdownAfterFinish);
            this.Controls.Add(this.buttonOpenProfile);
            this.Controls.Add(this.textTelegram1day);
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
        private System.Windows.Forms.TextBox textTelegram1day;
        private System.Windows.Forms.Button buttonOpenProfile;
        private System.Windows.Forms.CheckBox checkShutdownAfterFinish;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.CheckBox checkExitApp;
        private System.Windows.Forms.TextBox textBinanceCoin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeClock;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.TextBox textTelegram7day;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTelegram1month;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTelegram3month;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textTelegram1year;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonFastSet;
    }
}

