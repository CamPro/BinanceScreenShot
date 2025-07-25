using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BinanceScreenShot
{
    public partial class FrmMain : Form
    {
        public static string FolderUserData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BinanceUserData");
        public string SettingTelegramLink = Path.Combine(Application.StartupPath, "setting_telegram_link.txt");
        public string SettingBinanceCoin = Path.Combine(Application.StartupPath, "setting_binance_coin.txt");

        public FrmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (File.Exists(SettingTelegramLink))
            {
                textTelegramLink.Text = File.ReadAllText(SettingTelegramLink);
            }
            if (File.Exists(SettingBinanceCoin))
            {
                textBinanceCoin.Text = File.ReadAllText(SettingBinanceCoin);
            }
            dateTimeClock.Format = DateTimePickerFormat.Custom;
            dateTimeClock.CustomFormat = "dd-MM-yyyy HH:mm";
            dateTimeClock.Value = DateTime.Today;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Process pc_chrome = new Process();
            pc_chrome.StartInfo.FileName = ".\\selenium-manager\\windows\\selenium-manager.exe";
            pc_chrome.StartInfo.Arguments = "--browser chrome";
            pc_chrome.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pc_chrome.Start();
            pc_chrome.WaitForExit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ChromeDriver driver = null;
            ReadOnlyCollection<IWebElement> elements = null;
            IWebElement element = null;
            By bselector = By.CssSelector("");
            IJavaScriptExecutor js;
            string telegramLink = textTelegramLink.Text;
            string binanceCoin = textBinanceCoin.Text;
            string chartTime = string.Empty;

            if (string.IsNullOrEmpty(telegramLink))
            {
                textTelegramLink.Focus();
                return;
            }
            if (string.IsNullOrEmpty(binanceCoin))
            {
                textBinanceCoin.Focus();
                return;
            }

            // start chrome driver
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();

            options.AddArgument($"--user-data-dir={FolderUserData}");

            options.AddArgument("--start-maximized");
            //options.AddArgument("--disable-notifications");
            //options.AddArgument("--disable-infobars");
            //options.AddArgument("--disable-popup-blocking");

            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            // Undetected webdriver
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddExcludedArgument("enable-automation");
            options.AddExcludedArguments(new List<string>() { "enable-automation" });
            options.AddAdditionalChromeOption("useAutomationExtension", false);

            driver = new ChromeDriver(service, options);
            Thread.Sleep(1000);
            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl(binanceCoin);
            Thread.Sleep(5 * 1000);

            // xóa header
            js.ExecuteScript("document.querySelector('div#__APP_HEADER').remove()");
            js.ExecuteScript("document.querySelector('div.coin-price__breadcrumb-wrapper').remove()");
            Thread.Sleep(250);

            // chose time
            elements = driver.FindElements(By.CssSelector("div.relative button.bn-button__text__yellow.data-size-small"));
            if (radioChart1Day.Checked)
            {
                element = elements[0];
                chartTime = element.Text.Trim();
                //element.Click();
            }
            if (radioChart7Day.Checked)
            {
                element = elements[1];
                chartTime = element.Text.Trim();
                element.Click();
            }
            if (radioChart1Month.Checked)
            {
                element = elements[2];
                chartTime = element.Text.Trim();
                element.Click();
            }
            if (radioChart3Month.Checked)
            {
                element = elements[3];
                chartTime = element.Text.Trim();
                element.Click();
            }
            if (radioChart1Year.Checked)
            {
                element = elements[4];
                chartTime = element.Text.Trim();
                element.Click();
            }
            Thread.Sleep(3000);

            // element chart
            element = driver.FindElement(By.CssSelector("div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl'] div.relative"));

            // move mouse
            Cursor.Position = new Point(0, 0);

            // screen shot
            string textInfo = driver.FindElement(By.CssSelector("div.relative h1")).Text.Trim().Split('(').Last().Replace(")", "").Trim();
            string imgFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{textInfo} {DateTime.Now.ToString("yyyy-MM-dd")}.png");
            
            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            var img = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
            Bitmap bmimg = img.Clone(new Rectangle(element.Location, element.Size), img.PixelFormat);
            bmimg.Save(imgFileName, ImageFormat.Png);
            Thread.Sleep(500);

            driver.Navigate().GoToUrl("https://web.telegram.org");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl(telegramLink);
            Thread.Sleep(3000);

            // send image
            driver.FindElement(By.CssSelector("div.attach-file")).Click();
            Thread.Sleep(250);
            
            // click Image or Video
            driver.FindElement(By.CssSelector("div[class='btn-menu top-left active was-open'] > div[class='btn-menu-item rp-overflow']")).Click();
            Thread.Sleep(10);

            driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(imgFileName);
            Thread.Sleep(5000);

            // send text
            driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).Click();
            Thread.Sleep(250);
            driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).SendKeys($"{textInfo} {chartTime} {DateTime.Now.ToString("dd-MM-yyyy")}");
            Thread.Sleep(250);

            // click send
            driver.FindElement(By.CssSelector("div.popup-input-container button.btn-primary")).Click();
            Thread.Sleep(3000);

            // delete image
            File.Delete(imgFileName);

            driver.Quit();
            Thread.Sleep(1000);

            // shutdown computer
            if (checkShutdownAfterFinish.Checked) shutdown();

            // exit application
            if (checkExitApp.Checked) Application.Exit();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            string timeNow = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            string timeSet = dateTimeClock.Value.ToString("dd-MM-yyyy HH:mm");

            if (dateTimeClock.Value.Hour == 0 && dateTimeClock.Value.Minute == 0)
            {
                timerClock.Enabled = false;
                return;
            }

            labelMsg.Text = timeNow;

            if (DateTime.Now.Second % 2 == 0)
            {
                labelMsg.Font = new Font("Arial", 9, FontStyle.Regular);
            }
            else
            {
                labelMsg.Font = new Font("Arial", 9, FontStyle.Bold);
            }

            if (timeNow == timeSet)
            {
                timerClock.Enabled = false;
                buttonStart_Click(null, null);
            }
        }

        private void buttonOpenProfile_Click(object sender, EventArgs e)
        {
            Process pc_chrome = new Process();
            pc_chrome.StartInfo.FileName = "chrome.exe";
            pc_chrome.StartInfo.Arguments = $"--start-maximized --user-data-dir={FolderUserData}";
            pc_chrome.Start();
            pc_chrome.WaitForExit();
        }

        private void shutdown()
        {
            Process sd_proc = Process.Start("shutdown.exe", "-s -t 0");
            sd_proc.WaitForExit();
        }

        private void textTelegramLink_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(SettingTelegramLink, textTelegramLink.Text);
        }

        private void textBinanceCoin_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(SettingBinanceCoin, textBinanceCoin.Text);
        }

        private void dateTimeClock_ValueChanged(object sender, EventArgs e)
        {
            timerClock.Enabled = true;
        }
    }
}
