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
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace BinanceScreenShot
{
    public partial class FrmMain : Form
    {
        public static string FolderUserData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BinanceUserData");
        public string SettingTelegramLinks = Path.Combine(Application.StartupPath, "setting_telegram_links.txt");
        public string SettingBinanceCoin = Path.Combine(Application.StartupPath, "setting_binance_coin.txt");

        public FrmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // read links
            if (File.Exists(SettingTelegramLinks))
            {
                string[] teleLinks = File.ReadAllLines(SettingTelegramLinks, Encoding.UTF8);

                textTelegram1day.Text = teleLinks[0];
                textTelegram7day.Text = teleLinks[1];
                textTelegram1month.Text = teleLinks[2];
                textTelegram3month.Text = teleLinks[3];
                textTelegram1year.Text = teleLinks[4];
            }
            // read coin url
            if (File.Exists(SettingBinanceCoin))
            {
                textBinanceCoin.Text = File.ReadAllText(SettingBinanceCoin, Encoding.UTF8);
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

            string binanceCoin = textBinanceCoin.Text;

            string telegramLink1day = textTelegram1day.Text;
            string telegramLink7day = textTelegram7day.Text;
            string telegramLink1month = textTelegram1month.Text;
            string telegramLink3month = textTelegram3month.Text;
            string telegramLink1year = textTelegram1year.Text;

            if (string.IsNullOrEmpty(telegramLink1day))
            {
                textTelegram1day.Focus();
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

            // GO demo
            driver.Navigate().GoToUrl("https://www.binance.com/vi");
            Thread.Sleep(2000);

            // go coin url
            driver.Navigate().GoToUrl(binanceCoin);
            Thread.Sleep(5000);

            // move mouse
            Cursor.Position = new Point(0, 0);

            // xóa header
            js.ExecuteScript("document.querySelector('div#__APP_HEADER').remove()");
            js.ExecuteScript("document.querySelector('div.coin-price__breadcrumb-wrapper').remove()");
            Thread.Sleep(250);

            // 1 day, 7 day, 1 month, 
            string coinName = driver.FindElement(By.CssSelector("div.relative h1")).Text.Trim().Split('(').Last().Replace(")", "").Trim();
            string imgFileName1day = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{coinName} 1 day {DateTime.Now.ToString("yyyy-MM-dd")}.png");
            string imgFileName1dayCopy = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{coinName} 1 day {DateTime.Now.ToString("yyyy-MM-dd")} copy.png");
            string imgFileName7day = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{coinName} 7 day {DateTime.Now.ToString("yyyy-MM-dd")}.png");
            string imgFileName1month = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{coinName} 1 month {DateTime.Now.ToString("yyyy-MM-dd")}.png");
            string imgFileName3month = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{coinName} 3 month {DateTime.Now.ToString("yyyy-MM-dd")}.png");
            string imgFileName1year = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{coinName} 1 year {DateTime.Now.ToString("yyyy-MM-dd")}.png");
            
            bool isUp1day = false;
            bool isUp7day = false;
            bool isUp1month = false;
            bool isUp3month = false;
            bool isUp1year = false;

            Screenshot sc = null;
            Bitmap bmimg = null;

            // chose time
            elements = driver.FindElements(By.CssSelector("div.relative button.bn-button__text__yellow.data-size-small"));
            if (true)
            {
                // element chart
                element = driver.FindElement(By.CssSelector("div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl'] div.relative"));

                // screen shot
                sc = ((ITakesScreenshot)driver).GetScreenshot();
                bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
                bmimg.Save(imgFileName1day, ImageFormat.Png);

                isUp1day = true;
            }

            // neu la chu nhat se up chart 7 ngay
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                elements[1].Click();
                Thread.Sleep(5000);

                // element chart
                element = driver.FindElement(By.CssSelector("div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl'] div.relative"));

                // screen shot
                sc = ((ITakesScreenshot)driver).GetScreenshot();
                bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
                bmimg.Save(imgFileName7day, ImageFormat.Png);

                isUp7day = true;
            }

            // neu la ngay cuoi thang se up chart 1 thang
            if (DateTime.Today.Day == DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))
            {
                elements[2].Click();
                Thread.Sleep(5000);

                // element chart
                element = driver.FindElement(By.CssSelector("div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl'] div.relative"));

                // screen shot
                sc = ((ITakesScreenshot)driver).GetScreenshot();
                bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
                bmimg.Save(imgFileName1month, ImageFormat.Png);

                isUp1month = true;
            }

            // neu la ngay cuoi quy 3, 6, 9, 12 se up chart 3 thang
            List<int> list3months = new List<int>() { 3, 6, 9, 12 };
            if (DateTime.Today.Day == DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) && list3months.Contains(DateTime.Today.Month))
            {
                elements[3].Click();
                Thread.Sleep(5000);

                // element chart
                element = driver.FindElement(By.CssSelector("div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl'] div.relative"));

                // screen shot
                sc = ((ITakesScreenshot)driver).GetScreenshot();
                bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
                bmimg.Save(imgFileName3month, ImageFormat.Png);

                isUp3month = true;
            }

            // neu la ngay cuoi nam se up chart 1 nam
            if (DateTime.Today.Month == 12 && DateTime.Today.Day == 31)
            {
                elements[4].Click();
                Thread.Sleep(5000);

                // element chart
                element = driver.FindElement(By.CssSelector("div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl'] div.relative"));

                // screen shot
                sc = ((ITakesScreenshot)driver).GetScreenshot();
                bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
                bmimg.Save(imgFileName1year, ImageFormat.Png);

                isUp1year = true;
            }
            Thread.Sleep(500);

            // refresh
            driver.Navigate().GoToUrl("https://www.binance.com/vi/markets/overview");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl(binanceCoin);
            Thread.Sleep(5000);

            // xóa header
            js.ExecuteScript("document.querySelector('div#__APP_HEADER').remove()");
            js.ExecuteScript("document.querySelector('div.coin-price__breadcrumb-wrapper').remove()");
            Thread.Sleep(250);

            // element chart
            element = driver.FindElement(By.CssSelector("div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl'] div.relative"));

            // screen shot
            sc = ((ITakesScreenshot)driver).GetScreenshot();
            bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
            bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
            bmimg.Save(imgFileName1dayCopy, ImageFormat.Png);

            // upload telegram
            driver.Navigate().GoToUrl("https://web.telegram.org");
            Thread.Sleep(1000);

            if (isUp1day)
            {
                driver.Navigate().GoToUrl(telegramLink1day);
                Thread.Sleep(3000);

                // send image
                driver.FindElement(By.CssSelector("div.attach-file")).Click();
                Thread.Sleep(250);

                // click Image or Video
                driver.FindElement(By.CssSelector("div[class='btn-menu top-left active was-open'] > div[class='btn-menu-item rp-overflow']")).Click();
                Thread.Sleep(10);

                driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(imgFileName1day);
                Thread.Sleep(3000);

                AutoIt.AutoItX.WinWait("[CLASS:#32770]", "", 5);
                IntPtr winHandle = AutoIt.AutoItX.WinGetHandle("[CLASS:#32770]");
                AutoIt.AutoItX.WinClose(winHandle);

                // send text
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).Click();
                Thread.Sleep(250);
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).SendKeys($"{coinName} {DateTime.Now.ToString("dd-MM-yyyy")}");
                Thread.Sleep(250);

                // click send
                driver.FindElement(By.CssSelector("div.popup-input-container button.btn-primary")).Click();
                Thread.Sleep(3000);
                driver.Navigate().GoToUrl("chrome://downloads");
                Thread.Sleep(1000);
            }

            if (isUp7day)
            {
                driver.Navigate().GoToUrl(telegramLink7day);
                Thread.Sleep(3000);

                // send image
                driver.FindElements(By.CssSelector("div.attach-file")).Last().Click();
                Thread.Sleep(250);

                // click Image or Video
                driver.FindElement(By.CssSelector("div[class='btn-menu top-left active was-open'] > div[class='btn-menu-item rp-overflow']")).Click();
                Thread.Sleep(10);

                driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(imgFileName7day);
                Thread.Sleep(3000);

                AutoIt.AutoItX.WinWait("[CLASS:#32770]", "", 5);
                IntPtr winHandle = AutoIt.AutoItX.WinGetHandle("[CLASS:#32770]");
                AutoIt.AutoItX.WinClose(winHandle);

                // send text
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).Click();
                Thread.Sleep(250);
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).SendKeys($"{coinName} {DateTime.Now.ToString("dd-MM-yyyy")}");
                Thread.Sleep(250);

                // click send
                driver.FindElement(By.CssSelector("div.popup-input-container button.btn-primary")).Click();
                Thread.Sleep(3000);
                driver.Navigate().GoToUrl("chrome://downloads");
                Thread.Sleep(1000);
            }

            if (isUp1month)
            {
                driver.Navigate().GoToUrl(telegramLink1month);
                Thread.Sleep(3000);

                // send image
                driver.FindElements(By.CssSelector("div.attach-file")).Last().Click();
                Thread.Sleep(250);

                // click Image or Video
                driver.FindElement(By.CssSelector("div[class='btn-menu top-left active was-open'] > div[class='btn-menu-item rp-overflow']")).Click();
                Thread.Sleep(10);

                driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(imgFileName1month);
                Thread.Sleep(3000);

                AutoIt.AutoItX.WinWait("[CLASS:#32770]", "", 5);
                IntPtr winHandle = AutoIt.AutoItX.WinGetHandle("[CLASS:#32770]");
                AutoIt.AutoItX.WinClose(winHandle);

                // send text
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).Click();
                Thread.Sleep(250);
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).SendKeys($"{coinName} {DateTime.Now.ToString("dd-MM-yyyy")}");
                Thread.Sleep(250);

                // click send
                driver.FindElement(By.CssSelector("div.popup-input-container button.btn-primary")).Click();
                Thread.Sleep(3000);
                driver.Navigate().GoToUrl("chrome://downloads");
                Thread.Sleep(1000);
            }

            if (isUp3month)
            {
                driver.Navigate().GoToUrl(telegramLink3month);
                Thread.Sleep(3000);

                // send image
                driver.FindElements(By.CssSelector("div.attach-file")).Last().Click();
                Thread.Sleep(250);

                // click Image or Video
                driver.FindElement(By.CssSelector("div[class='btn-menu top-left active was-open'] > div[class='btn-menu-item rp-overflow']")).Click();
                Thread.Sleep(10);

                driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(imgFileName3month);
                Thread.Sleep(3000);

                AutoIt.AutoItX.WinWait("[CLASS:#32770]", "", 5);
                IntPtr winHandle = AutoIt.AutoItX.WinGetHandle("[CLASS:#32770]");
                AutoIt.AutoItX.WinClose(winHandle);

                // send text
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).Click();
                Thread.Sleep(250);
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).SendKeys($"{coinName} {DateTime.Now.ToString("dd-MM-yyyy")}");
                Thread.Sleep(250);

                // click send
                driver.FindElement(By.CssSelector("div.popup-input-container button.btn-primary")).Click();
                Thread.Sleep(3000);
                driver.Navigate().GoToUrl("chrome://downloads");
                Thread.Sleep(1000);
            }

            if (isUp1year)
            {
                driver.Navigate().GoToUrl(telegramLink1year);
                Thread.Sleep(3000);

                // send image
                driver.FindElements(By.CssSelector("div.attach-file")).Last().Click();
                Thread.Sleep(250);

                // click Image or Video
                driver.FindElement(By.CssSelector("div[class='btn-menu top-left active was-open'] > div[class='btn-menu-item rp-overflow']")).Click();
                Thread.Sleep(10);

                driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(imgFileName1year);
                Thread.Sleep(3000);

                AutoIt.AutoItX.WinWait("[CLASS:#32770]", "", 5);
                IntPtr winHandle = AutoIt.AutoItX.WinGetHandle("[CLASS:#32770]");
                AutoIt.AutoItX.WinClose(winHandle);

                // send text
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).Click();
                Thread.Sleep(250);
                driver.FindElement(By.CssSelector("div.popup-input-container div.input-message-input")).SendKeys($"{coinName} {DateTime.Now.ToString("dd-MM-yyyy")}");
                Thread.Sleep(250);

                // click send
                driver.FindElement(By.CssSelector("div.popup-input-container button.btn-primary")).Click();
                Thread.Sleep(3000);
                driver.Navigate().GoToUrl("chrome://downloads");
                Thread.Sleep(1000);
            }

            // delete image
            if (File.Exists(imgFileName1day)) File.Delete(imgFileName1day);
            if (File.Exists(imgFileName7day)) File.Delete(imgFileName7day);
            if (File.Exists(imgFileName1month)) File.Delete(imgFileName1month);
            if (File.Exists(imgFileName3month)) File.Delete(imgFileName3month);
            if (File.Exists(imgFileName1year)) File.Delete(imgFileName1year);

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
            //pc_chrome.WaitForExit();
        }

        private void shutdown()
        {
            Process sd_proc = Process.Start("shutdown.exe", "-s -t 0");
            sd_proc.WaitForExit();
        }

        private void textBinanceCoin_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(SettingBinanceCoin, textBinanceCoin.Text);
        }

        private void dateTimeClock_ValueChanged(object sender, EventArgs e)
        {
            timerClock.Enabled = true;
        }

        private void checkShutdownAfterFinish_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShutdownAfterFinish.Checked)
            {
                checkExitApp.Checked = true;
            }
        }

        private void SaveSettings()
        {
            string[] teleLinks = new string[5];
            teleLinks[0] = textTelegram1day.Text;
            teleLinks[1] = textTelegram7day.Text;
            teleLinks[2] = textTelegram1month.Text;
            teleLinks[3] = textTelegram3month.Text;
            teleLinks[4] = textTelegram1year.Text;

            File.WriteAllLines(SettingTelegramLinks, teleLinks, Encoding.UTF8);
        }

        private void textTelegram1day_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void textTelegram7day_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void textTelegram1month_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void textTelegram3month_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void textTelegram1year_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void buttonFastSet_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dateTimeClock.Value = new DateTime(today.Year, today.Month, today.Day, 23, 55, today.Second);

            checkShutdownAfterFinish.Checked = true;

            buttonFastSet.Visible = false;
        }
    }
}
