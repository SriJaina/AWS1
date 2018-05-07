using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Azure_Automation
{
    [TestClass]
    public class PasswordReset : BaseTest
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
        Reusablefunctions reuse = new Reusablefunctions();
        Commonfunctions common = new Commonfunctions();
        ObjectRepository obj = new ObjectRepository();

        [Test]
        
        public void ResetPassword()
        {
            BaseTest.test = BaseTest.extent.StartTest("Create Password reset request");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(reuse.clickOnNewButton, "Clicked on New button", "Unable to click on New button");
            reuse.TryCatchMethod(reuse.navigateToPasswordReset, "Navigated to Password Reset Page", "Unable to navigate to Password Reset page");
            reuse.TryCatchMethod(moveNextandConfirmValidation,"Moved to Next page and Confirmed the Validation","Unable to confirm the validation");
            reuse.TryCatchMethod(reuse.completeCreationOfRequest, "Password reset request is submitted successfully", "Could not complete the creation of password reset request");
        }

        #region Confirm the Validation
        public void moveNextandConfirmValidation()
        {
            common.smallwait();
            reuse.moveToNextPage();
            common.smallwait();
            common.ElementOperations("Xpath", obj.pwdreset_confirmvalidation_xpath, "click", "");
            common.smallwait();
            reuse.moveToNextPage();
            common.smallwait();
        }

        #endregion
    }
}
