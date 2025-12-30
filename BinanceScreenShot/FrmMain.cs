using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BinanceScreenShot
{
    public partial class FrmMain : Form
    {
        //public static string FolderUserData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ChromeUserData");
        public static string FolderUserData = Path.Combine(Application.StartupPath, "ChromeUserData");
        public static string SettingStableCoinFile = Path.Combine(Application.StartupPath, "setting_stablecoin.txt");
        public static string SettingCoinFile = Path.Combine(Application.StartupPath, "setting_coins.txt");
        public static List<string> StableCoins = new List<string>();

        public static ChromeDriver driver = null;
        public static ReadOnlyCollection<IWebElement> elements = null;
        public static IWebElement element = null;
        public static Actions actions = null;
        public static IJavaScriptExecutor js;

        public FrmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // setting
            if (File.Exists(SettingStableCoinFile))
            {
                StableCoins  = File.ReadAllLines(SettingStableCoinFile, Encoding.UTF8).ToList();
            }
            if (File.Exists(SettingCoinFile))
            {
                richTextCoin.Lines = File.ReadAllLines(SettingCoinFile, Encoding.UTF8);
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

        private void StartChromeDriver()
        {
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

            js = (IJavaScriptExecutor)driver;
            actions = new Actions(driver);
        }

        private void CloseChromeDriver()
        {
            try
            {
                driver.Navigate().GoToUrl("chrome://downloads");
                Thread.Sleep(500);
            }
            catch (Exception)
            {
            }
            try
            {
                driver.Quit();
                Thread.Sleep(500);
            }
            catch (Exception)
            {
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            List<string> listUrls = richTextCoin.Lines.ToList();
            string coinName = string.Empty;

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            // go coin url
            driver.Navigate().GoToUrl("https://www.binance.com/vi/markets/overview");
            Thread.Sleep(5000);

            foreach (var linkCoin in listUrls)
            {
                try
                {
                    // move mouse
                    Cursor.Position = new Point(0, 0);

                    driver.Navigate().GoToUrl(linkCoin);
                    Thread.Sleep(1000);

                    // xóa header
                    js.ExecuteScript("document.querySelector('div#__APP_HEADER').remove()");
                    js.ExecuteScript("document.querySelector('div.coin-price__breadcrumb-wrapper').remove()");
                    js.ExecuteScript("if (document.querySelector(\"div[role='alert']\")) document.querySelector(\"div[role='alert']\").remove()");
                    Thread.Sleep(100);

                    // coin name
                    coinName = driver.FindElement(By.CssSelector("section div.relative h1")).Text.Trim().Split('(').Last().Replace(")", "").Trim();

                    // chose time
                    elements = driver.FindElements(By.CssSelector("section div.relative button.bn-button__text__yellow.data-size-small"));

                    /*
                    // scroll to chart
                    element = driver.FindElement(By.CssSelector("section div.relative div.relative"));
                    int targetHeight = element.Location.Y - 100;
                    js.ExecuteScript($"window.scrollTo(0, {targetHeight});");
                    Thread.Sleep(500);
                    */

                    // neu la chu nhat se up chart 7 ngay
                    if (check7day.Checked)
                    {
                        try
                        {
                            // save
                            Calendar calendar = CultureInfo.CurrentCulture.Calendar;
                            int weekNumber = calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                            string saveFolder = Path.Combine(Application.StartupPath, $"weeks{weekNumber}");
                            string imgFileName = Path.Combine(saveFolder, $"{coinName} w{weekNumber} {DateTime.Now.ToString("yyyy-MM-dd")}.png");
                            if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                            if (checkSkipCoinExistImage.Checked && File.Exists(imgFileName))
                            {
                                throw new Exception("Skip exist");
                            }

                            elements[1].Click();
                            Thread.Sleep(3000);

                            // element chart
                            element = driver.FindElement(By.CssSelector("section div.relative div.relative"));

                            // screen shot
                            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                            Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                            Rectangle cropArea = new Rectangle(element.Location.X - 3, element.Location.Y - 65, element.Size.Width + 8, element.Size.Height + 57);
                            bmimg = bmimg.Clone(cropArea, bmimg.PixelFormat);
                            bmimg.Save(imgFileName, ImageFormat.Png);
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("error.txt", $"{coinName} - 7 day: {ex.Message}\n");
                        }
                    }

                    // neu la ngay cuoi thang se up chart 1 thang
                    if (check1month.Checked)
                    {
                        try
                        {
                            // save
                            string saveFolder = Path.Combine(Application.StartupPath, $"months{DateTime.Now.Month}");
                            string imgFileName = Path.Combine(saveFolder, $"{coinName} {DateTime.Now.ToString("yyyy-MM")}.png");
                            if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                            if (checkSkipCoinExistImage.Checked && File.Exists(imgFileName))
                            {
                                throw new Exception("Skip exist");
                            }

                            elements[2].Click();
                            Thread.Sleep(3500);

                            // element chart
                            element = driver.FindElement(By.CssSelector("section div.relative div.relative"));

                            // screen shot
                            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                            Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                            Rectangle cropArea = new Rectangle(element.Location.X - 3, element.Location.Y - 65, element.Size.Width + 8, element.Size.Height + 57);
                            bmimg = bmimg.Clone(cropArea, bmimg.PixelFormat);
                            bmimg.Save(imgFileName, ImageFormat.Png);
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("error.txt", $"{coinName} - 1 month: {ex.Message}\n");
                        }
                    }

                    // neu la ngay cuoi quy 3, 6, 9, 12 se up chart 3 thang
                    if (check3month.Checked)
                    {
                        try
                        {
                            // save
                            string saveFolder = Path.Combine(Application.StartupPath, $"3months{DateTime.Now.Month - 2}-{DateTime.Now.Month}");
                            string imgFileName = Path.Combine(saveFolder, $"{coinName} {DateTime.Now.Year} {DateTime.Now.Month - 2}--{DateTime.Now.Month}.png");
                            if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                            if (checkSkipCoinExistImage.Checked && File.Exists(imgFileName))
                            {
                                throw new Exception("Skip exist");
                            }

                            elements[3].Click();
                            Thread.Sleep(4500);

                            // element chart
                            element = driver.FindElement(By.CssSelector("section div.relative div.relative"));

                            // screen shot
                            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                            Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                            Rectangle cropArea = new Rectangle(element.Location.X - 3, element.Location.Y - 65, element.Size.Width + 8, element.Size.Height + 57);
                            bmimg = bmimg.Clone(cropArea, bmimg.PixelFormat);
                            bmimg.Save(imgFileName, ImageFormat.Png);
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("error.txt", $"{coinName} - 3 month: {ex.Message}\n");
                        }
                    }

                    // neu la ngay cuoi nam se up chart 1 nam
                    if (check1year.Checked)
                    {
                        try
                        {
                            // save
                            string saveFolder = Path.Combine(Application.StartupPath, $"years{DateTime.Now.Year}");
                            string imgFileName = Path.Combine(saveFolder, $"{coinName} {DateTime.Now.Year}.png");
                            if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                            if (checkSkipCoinExistImage.Checked && File.Exists(imgFileName))
                            {
                                throw new Exception("Skip exist");
                            }

                            elements[4].Click();
                            Thread.Sleep(5000);

                            // element chart
                            element = driver.FindElement(By.CssSelector("section div.relative div.relative"));

                            // screen shot
                            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                            Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                            Rectangle cropArea = new Rectangle(element.Location.X - 3, element.Location.Y - 65, element.Size.Width + 8, element.Size.Height + 57);
                            bmimg = bmimg.Clone(cropArea, bmimg.PixelFormat);
                            bmimg.Save(imgFileName, ImageFormat.Png);
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("error.txt", $"{coinName} - 1 year: {ex.Message}\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText("error.txt", $"{coinName}: {ex.Message}\n");
                }
            }

            // quit
            CloseChromeDriver();

            SystemSounds.Asterisk.Play();

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
            pc_chrome.StartInfo.Arguments = $"https://www.binance.com/vi --start-maximized --user-data-dir={FolderUserData}";
            pc_chrome.Start();
        }

        private void shutdown()
        {
            Process sd_proc = Process.Start("shutdown.exe", "-s -t 0");
            sd_proc.WaitForExit();
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

        private void buttonFastSet_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dateTimeClock.Value = new DateTime(today.Year, today.Month, today.Day, 23, 50, today.Second);
            System.Media.SystemSounds.Hand.Play();
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath);
        }

        private void buttonOpenDriver_Click(object sender, EventArgs e)
        {
            StartChromeDriver();
            for (int i = 0; i < 60 * 60; i++)
            {
                Thread.Sleep(1000);
                try
                {
                    driver.FindElement(By.CssSelector("body, div"));
                }
                catch (Exception)
                {
                    break;
                }
            }
            driver.Quit();
        }

        private void buttonScanTopList_Click(object sender, EventArgs e)
        {
            List<string> listUrls = new List<string>();

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            for (int page = 1; page <= 2; page++)
            {
                driver.Navigate().GoToUrl($"https://www.binance.com/vi/markets/overview?p={page}");
                Thread.Sleep(1000);

                for (int i = 0; i < 5; i++)
                {
                    js.ExecuteScript($"window.scrollTo(0, {470 * i})");
                    Thread.Sleep(500);

                    elements = driver.FindElements(By.CssSelector("div.flex div.overview-table-row"));

                    foreach (var coinRow in elements)
                    {
                        string textRow = coinRow.Text.Trim();
                        string coinCode = textRow.Split('\r').First().Trim();

                        if (StableCoins.Contains(coinCode) || coinCode.Equals("Tên"))
                        {
                            continue;
                        }

                        try
                        {
                            string coinLink = coinRow.FindElement(By.CssSelector("a[href*='/price/']")).GetAttribute("href");

                            if (!listUrls.Contains(coinLink))
                            {
                                listUrls.Add(coinLink);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }

            driver.Quit();

            richTextCoin.Lines = listUrls.ToArray();

            File.WriteAllLines(SettingCoinFile, listUrls, Encoding.UTF8);

            SystemSounds.Asterisk.Play();
        }

        private void buttonViewChart_Click(object sender, EventArgs e)
        {
            List<string> listUrls = new List<string>();
            int numPage = Convert.ToInt32(numViewPage.Value);

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            for (int page = 1; page <= numPage; page++)
            {
                try
                {
                    driver.Navigate().GoToUrl($"https://www.binance.com/vi/markets/overview?p={page}");
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {
                    break;
                }

                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        js.ExecuteScript($"window.scrollTo(0, {470 * i})");
                        Thread.Sleep(500);

                        elements = driver.FindElements(By.CssSelector("div.flex div.overview-table-row"));

                        foreach (var coinRow in elements)
                        {
                            string textRow = coinRow.Text.Trim();
                            string coinCode = textRow.Split('\r').First().Trim();

                            if (StableCoins.Contains(coinCode) || coinCode.Equals("Tên"))
                            {
                                continue;
                            }

                            try
                            {
                                string coinLink = coinRow.FindElement(By.CssSelector("a[href*='/price/']")).GetAttribute("href");

                                if (!listUrls.Contains(coinLink))
                                {
                                    listUrls.Add(coinLink);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }

            foreach (var linkUrl in listUrls)
            {
                try
                {
                    // Open a new tab
                    driver.SwitchTo().NewWindow(WindowType.Tab);
                    Thread.Sleep(500);

                    driver.Navigate().GoToUrl(linkUrl);
                    Thread.Sleep(1000);

                    // chose time
                    elements = driver.FindElements(By.CssSelector("div.relative button.bn-button__text__yellow.data-size-small"));

                    if (radioView7day.Checked) elements[1].Click();

                    if (radioView1month.Checked) elements[2].Click();

                    if (radioView3month.Checked) elements[3].Click();

                    if (radioView1year.Checked) elements[4].Click();

                    Thread.Sleep(1000);
                }
                catch (Exception)
                {
                    break;
                }
            }

            driver.SwitchTo().Window(driver.WindowHandles.First());

            SystemSounds.Asterisk.Play();

            this.Enabled = false;

            for (int i = 0; i < 60 * 60; i++)
            {
                try
                {
                    string title = driver.Title;
                }
                catch (Exception)
                {
                    try
                    {
                        driver.SwitchTo().Window(driver.WindowHandles.First());
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                Thread.Sleep(1000);
            }

            this.Enabled = true;

            driver.Quit();
        }

        private void buttonViewChartLink_Click(object sender, EventArgs e)
        {
            List<string> listUrls = new List<string>();
            int numPage = Convert.ToInt32(numViewPage.Value);

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            for (int page = 1; page <= numPage; page++)
            {
                try
                {
                    driver.Navigate().GoToUrl($"https://www.binance.com/vi/markets/overview?p={page}");
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {
                    break;
                }

                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        js.ExecuteScript($"window.scrollTo(0, {470 * i})");
                        Thread.Sleep(500);

                        elements = driver.FindElements(By.CssSelector("div.flex div.overview-table-row"));

                        foreach (var coinRow in elements)
                        {
                            string textRow = coinRow.Text.Trim();
                            string coinCode = textRow.Split('\r').First().Trim();

                            if (StableCoins.Contains(coinCode) || coinCode.Equals("Tên"))
                            {
                                continue;
                            }

                            try
                            {
                                string coinLink = coinRow.FindElement(By.CssSelector("a[href*='/price/']")).GetAttribute("href");

                                if (!listUrls.Contains(coinLink))
                                {
                                    listUrls.Add(coinLink);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }

            driver.Quit();

            foreach (var linkUrl in listUrls)
            {
                Process.Start(linkUrl);
                Thread.Sleep(2500);
            }

            SystemSounds.Asterisk.Play();
        }

        private void buttonKillDriver_Click(object sender, EventArgs e)
        {
            Process[] listProcess = Process.GetProcessesByName("chromedriver");
            foreach (var process in listProcess)
            {
                try { process.Kill(); } catch { }
            }
        }

        private void buttonViewLiquidationHeatmap_Click(object sender, EventArgs e)
        {
            List<string> listUrls = new List<string>();
            int numPage = Convert.ToInt32(numViewPage.Value);

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            for (int page = 1; page <= numPage; page++)
            {
                try
                {
                    driver.Navigate().GoToUrl($"https://www.binance.com/vi/markets/overview?p={page}");
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {
                    break;
                }

                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        js.ExecuteScript($"window.scrollTo(0, {470 * i})");
                        Thread.Sleep(500);

                        elements = driver.FindElements(By.CssSelector("div.flex div.overview-table-row"));

                        foreach (var coinRow in elements)
                        {
                            string textRow = coinRow.Text.Trim();
                            string coinCode = textRow.Split('\r').First().Trim();

                            if (StableCoins.Contains(coinCode) || coinCode.Equals("Tên"))
                            {
                                continue;
                            }

                            string liquidationLink = $"https://www.coinglass.com/en/pro/futures/LiquidationHeatMap?coin={coinCode}&type=symbol";                      

                            if (!listUrls.Contains(liquidationLink))
                            {
                                listUrls.Add(liquidationLink);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }

            driver.Quit();

            foreach (var linkUrl in listUrls)
            {
                Process.Start(linkUrl);
                Thread.Sleep(2000);
            }

            SystemSounds.Asterisk.Play();
        }

    }
}
