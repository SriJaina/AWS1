using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;

namespace Azure_Automation.Test_scripts
{
    [TestClass]
    public class CreatePortalAccessRequest : BaseTest
    {
        #region Additional test attributes
        [OneTimeSetUp]
        public void testSetup()
        {
            Console.WriteLine("setup");
            StartReport();
        }

        [TearDown]
        public void getResult()
        {
            Console.WriteLine("TearDown");
            var status = NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + NUnit.Framework.TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = NUnit.Framework.TestContext.CurrentContext.Result.Message;
            try
            {
                if (status == TestStatus.Failed)
                {
                    string screenShotPath = takeScreenShot(Properties.driver);

                    // test.Log(LogStatus.Fail, errorMessage);
                    test.Log(LogStatus.Fail, "Screen shot below: " + test.AddScreenCapture(screenShotPath));

                }

                Properties.driver.Quit();
                extent.EndTest(test);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Properties.driver.Quit();
                extent.EndTest(test);
            }
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            Console.WriteLine("cleanUp");
            // Properties.driver.Quit();
            extent.Flush();
            extent.Close();

        }
        #endregion
        Commonfunctions common = new Commonfunctions();
        ObjectRepository obj = new ObjectRepository();
        Reusablefunctions reuse = new Reusablefunctions();
        public CreatePortalAccessRequest()
        {

        }
        private NUnit.Framework.TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>


        public NUnit.Framework.TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        [Test]
        [TestMethod]
        public void CreatePAR()
        {
            BaseTest.test = BaseTest.extent.StartTest("Create PwC Cloud Portal Access request");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
/*Exceldatareader excel = new Exceldatareader();
            Data_createGSR data = new Data_createPAR(excel, "PAR", 0);*/
            reuse.TryCatchMethod(reuse.clickOnNewButton, "Clicked on New button", "Unable to click on New button");
           // reuse.TryCatchMethod(reuse.navigateToPwCCloudPortalAccessRequest, "Navigated to PwC Cloud Portal Access request page", "Unable to navigate to PwC Cloud Portal Access request page");
            System.Threading.Thread.Sleep(5000);
            //reuse.TryCatchMethod(common.ElementOperations("Xpath",)

        }
    }
}
