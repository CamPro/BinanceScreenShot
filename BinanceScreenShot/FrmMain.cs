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
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BinanceScreenShot
{
    public partial class FrmMain : Form
    {
        public static string FolderUserData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ChromeUserData");
        public static string SettingFile = Path.Combine(Application.StartupPath, "settings.txt");

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
            // read links
            if (File.Exists(SettingFile))
            {
                string[] teleLinks = File.ReadAllLines(SettingFile, Encoding.UTF8);
                /*
                textTelegram1day.Text = teleLinks[0];
                textTelegram7day.Text = teleLinks[1];
                textTelegram1month.Text = teleLinks[2];
                textTelegram3month.Text = teleLinks[3];
                textTelegram1year.Text = teleLinks[4];
                */
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
            //SaveSettings();
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

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            // go coin url
            driver.Navigate().GoToUrl("https://www.binance.com/vi/markets/overview");
            Thread.Sleep(5000);

            foreach (var linkCoin in listUrls)
            {
                try
                {// move mouse
                    Cursor.Position = new Point(0, 0);

                    driver.Navigate().GoToUrl(linkCoin);
                    Thread.Sleep(3000);

                    // xóa header
                    js.ExecuteScript("document.querySelector('div#__APP_HEADER').remove()");
                    js.ExecuteScript("document.querySelector('div.coin-price__breadcrumb-wrapper').remove()");
                    js.ExecuteScript("if (document.querySelector(\"div[role='alert']\")) document.querySelector(\"div[role='alert']\").remove()");
                    Thread.Sleep(100);

                    // coin name
                    string coinName = driver.FindElement(By.CssSelector("div.relative h1")).Text.Trim().Split('(').Last().Replace(")", "").Trim();

                    // chose time
                    elements = driver.FindElements(By.CssSelector("div.relative button.bn-button__text__yellow.data-size-small"));

                    // neu la chu nhat se up chart 7 ngay
                    if (check7day.Checked)
                    {
                        elements[1].Click();
                        Thread.Sleep(5000);

                        // save
                        Calendar calendar = CultureInfo.CurrentCulture.Calendar;
                        int weekNumber = calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                        string saveFolder = Path.Combine(Application.StartupPath, $"weeks{weekNumber}");
                        string imgFileName = Path.Combine(saveFolder, $"{coinName} w{weekNumber} {DateTime.Now.ToString("yyyy-MM-dd")}.png");
                        if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                        // element chart
                        element = driver.FindElement(By.CssSelector("section div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl']"));

                        // screen shot
                        Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                        Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                        bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
                        // crop
                        Rectangle cropArea = new Rectangle(0, 20, bmimg.Width, 435);
                        Bitmap croppedImage = new Bitmap(cropArea.Width, cropArea.Height);
                        Graphics g = Graphics.FromImage(croppedImage);
                        g.DrawImage(bmimg, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);
                        // save
                        croppedImage.Save(imgFileName, ImageFormat.Png);
                    }

                    // neu la ngay cuoi thang se up chart 1 thang
                    if (check1month.Checked)
                    {
                        elements[2].Click();
                        Thread.Sleep(5000);

                        // save
                        string saveFolder = Path.Combine(Application.StartupPath, $"months{DateTime.Now.Month}");
                        string imgFileName = Path.Combine(saveFolder, $"{coinName} {DateTime.Now.ToString("yyyy-MM")}.png");
                        if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                        // element chart
                        element = driver.FindElement(By.CssSelector("section div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl']"));

                        // screen shot
                        Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                        Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                        bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
                        // crop
                        Rectangle cropArea = new Rectangle(0, 20, bmimg.Width, 435);
                        Bitmap croppedImage = new Bitmap(cropArea.Width, cropArea.Height);
                        Graphics g = Graphics.FromImage(croppedImage);
                        g.DrawImage(bmimg, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);
                        // save
                        croppedImage.Save(imgFileName, ImageFormat.Png);
                    }

                    // neu la ngay cuoi quy 3, 6, 9, 12 se up chart 3 thang
                    if (check3month.Checked)
                    {
                        elements[3].Click();
                        Thread.Sleep(5000);

                        // save
                        string saveFolder = Path.Combine(Application.StartupPath, $"3months{DateTime.Now.Month - 3}-{DateTime.Now.Month}");
                        string imgFileName = Path.Combine(saveFolder, $"{coinName} {DateTime.Now.ToString("yyyy-MM")}.png");
                        if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                        // element chart
                        element = driver.FindElement(By.CssSelector("section div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl']"));

                        // screen shot
                        Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                        Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                        bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
                        // crop
                        Rectangle cropArea = new Rectangle(0, 20, bmimg.Width, 435);
                        Bitmap croppedImage = new Bitmap(cropArea.Width, cropArea.Height);
                        Graphics g = Graphics.FromImage(croppedImage);
                        g.DrawImage(bmimg, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);
                        // save
                        croppedImage.Save(imgFileName, ImageFormat.Png);
                    }

                    // neu la ngay cuoi nam se up chart 1 nam
                    if (check1year.Checked)
                    {
                        elements[4].Click();
                        Thread.Sleep(5000);

                        // save
                        string saveFolder = Path.Combine(Application.StartupPath, $"years{DateTime.Now.Year}");
                        string imgFileName = Path.Combine(saveFolder, $"{coinName} {DateTime.Now.Year}.png");
                        if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                        // element chart
                        element = driver.FindElement(By.CssSelector("section div[class='md:w-3/5 md:flex-grow lg:w-2/3 xl:max-w-3xl']"));

                        // screen shot
                        Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                        Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                        bmimg = bmimg.Clone(new Rectangle(element.Location, element.Size), bmimg.PixelFormat);
                        // crop
                        Rectangle cropArea = new Rectangle(0, 20, bmimg.Width, 435);
                        Bitmap croppedImage = new Bitmap(cropArea.Width, cropArea.Height);
                        Graphics g = Graphics.FromImage(croppedImage);
                        g.DrawImage(bmimg, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);
                        // save
                        croppedImage.Save(imgFileName, ImageFormat.Png);
                    }
                }
                catch (Exception ex)
                {
                    File.WriteAllText("error.txt", ex.Message);
                }
            }

            // quit
            CloseChromeDriver();

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

        private void SaveSettings()
        {
            string[] settings = new string[5];
            /*
            settings[0] = textTelegram1day.Text;
            settings[1] = textTelegram7day.Text;
            settings[2] = textTelegram1month.Text;
            settings[3] = textTelegram3month.Text;
            settings[4] = textTelegram1year.Text;
            */
            File.WriteAllLines(SettingFile, settings, Encoding.UTF8);
        }

        private void buttonFastSet_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dateTimeClock.Value = new DateTime(today.Year, today.Month, today.Day, 23, 50, today.Second);
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

        private void buttonCrop_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles("D:\\BinanceScreenShot\\BinanceScreenShot\\bin\\Debug\\weeks37");

            foreach (string imgfile in files)
            {
                Bitmap originalImage = new Bitmap(imgfile);

                Rectangle cropArea = new Rectangle(0, 20, originalImage.Width, 435);
                Bitmap croppedImage = new Bitmap(cropArea.Width, cropArea.Height);
                Graphics g = Graphics.FromImage(croppedImage);
                g.DrawImage(originalImage, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);
                croppedImage.Save(imgfile.Replace("weeks37", "weekscrop"), ImageFormat.Png);
            }

            Application.Exit();
        }
    }
}
