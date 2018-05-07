using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;


namespace Azure_Automation
{
    public class BaseTest
    {

        public static ExtentReports extent;
        public static ExtentTest test;



        /******************Report*********************************/
        public static void StartReport()
        {
            //local path
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.IndexOf("Azure_Automation"));
            string projectPath = new Uri(actualPath).LocalPath;

            string todayDate = DateTime.Today.ToString("MMMddyyyy");
            string presentTime = DateTime.Now.ToString("HHmm");
            string reportPath = projectPath + "Azure_Automation\\Reports\\AzureExecutionReport_" + todayDate + presentTime + ".html";
            Console.WriteLine(reportPath);
            extent = new ExtentReports(reportPath, true);//replace existing 
                                                         //extent.AddSystemInfo("Host Name", "Bhaskar").
                                                         //  AddSystemInfo("Environment ", "QA").AddSystemInfo("System", "Remote Desk");

            extent.LoadConfig(projectPath + "Azure_Automation\\extent-config.xml");


        }

        public static string currentFolder = null;
        public static string takeScreenShot(IWebDriver driver)
        {

            DateTime d = new DateTime();
            Random rand = new Random();
            ITakesScreenshot screen = (ITakesScreenshot)driver;
            Screenshot screenshot = screen.GetScreenshot();

            string random = Guid.NewGuid().ToString("N");
            //currentFolder = "\\ImgID" + rand.Next(1, 1000);
            currentFolder = "\\ImgID" + random;
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.IndexOf("GCP_Automation"));
            string projectPath = new Uri(actualPath).LocalPath;
            string finalPath1 = projectPath + "GCP_Automation\\GCP_Automation\\Reports\\ErrorScreenshots" + currentFolder + ".png";
            string finalPath = "ErrorScreenshots" + currentFolder + ".png";
            // System.IO.DirectoryInfo file = new System.IO.DirectoryInfo(currentFolder);//path.Substring(0, path.LastIndexOf("bin"))
            // currentFolder = file.FullName;
            //string localPath = new Uri(finalPath).LocalPath;
            screenshot.SaveAsFile(finalPath1, ScreenshotImageFormat.Png);
            screenshot.SaveAsFile(projectPath + "GCP_Automation\\GCP_Automation\\ErrorScreenshots" + currentFolder + ".png", ScreenshotImageFormat.Png);
            return finalPath1;


        }

        public void reportPass(string msg)
        {
            test.Log(LogStatus.Pass, msg);
        }

        public void reportFailure(string msg)
        {
            test.Log(LogStatus.Fail, msg);

            Assert.Fail();
        }

        public void startingtest(string testname)
        {
            extent.StartTest(testname);
        }

    }
}
