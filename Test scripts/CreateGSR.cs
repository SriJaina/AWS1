using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Azure_Automation
{
    /// <summary>
    /// Summary description for CreateGSR
    /// </summary>
   // [TestClass]
    public partial class TestClass : BaseTest
    {
        #region Additional test attributes
        [OneTimeSetUp]
        public void testSetup()
        {
            Console.WriteLine("setup");
            ExcelMethods.OpenDBConnection();
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
                ExcelMethods.conn.Close();
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
            try
            {
                ExcelMethods.conn.Close();
            }catch(Exception e)
            {
                Console.WriteLine("No Open Excel connection is present");
            }
            
            extent.Flush();
            extent.Close();

        }
        #endregion
        Commonfunctions common = new Commonfunctions();
        ObjectRepository obj = new ObjectRepository();
        Reusablefunctions reuse = new Reusablefunctions();
      //  public CreateGSR()
       // {
            //
            // TODO: Add constructor logic here
            //
       // }

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
        
        public void createGSR()
        {
            
                BaseTest.test = BaseTest.extent.StartTest("Create General service request");
                reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
                Exceldatareader excel = new Exceldatareader();
                Data_createGSR data = new Data_createGSR(excel, "GSR", 0);
                reuse.TryCatchMethod(reuse.clickOnNewButton, "Clicked on New button", "Unable to click on New button");
                reuse.TryCatchMethod(reuse.navigateToGeneralServiceRequest, "Navigated to General service request page", "Unable to navigate to General service request page");
                reuse.TryCatchMethod(data.los, selectLOS, "Selected los as Advisory", "Unable to select the los");
                reuse.TryCatchMethod(data.envType, selectEnvType, "Selected the Environment type as Stage", "Unable to select the Environment type");
                reuse.TryCatchMethod(data.partnerorsponsor, enterPartnerorSponsor, "Entered the partner/sponsor as abhinaya.veeramally@pwc.com", "Unable to enter the partner/sponsor details");
                reuse.TryCatchMethod(data.chargecode, enterChargecode, "Entered the charge code as 1234567", "Unable to enter the charge code");
                reuse.TryCatchMethod(data.riskorsecurityinfo, enterRiskorsecurityinfoandMoveNext, "Entered the risk or security information as No risks", "Unable to enter the risk or security information");
                reuse.TryCatchMethod(data.cloudservices, enterCloudservices, "Entered the cloud services as SQL PaaS", "Unable to enter the Services");
                reuse.TryCatchMethod(data.accessdate, enterAccessDate, "Entered the access date as tomorrow", "Unable to enter the access date");
                reuse.TryCatchMethod(data.golivedate, enterGoliveDateandMoveNext, "Entered the go live date as tomorrow", "Unable to enter the go live date");
                reuse.TryCatchMethod(reuse.completeCreationOfRequest, "Completed General service request creation successfully", "Unable to complete the general service request creation");
            
         }

        

       

        #region select LOS

        public void selectLOS(string los)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_los_link_xpath, "click", "");
           // common.smallwait();
            IList<IWebElement> losvalues = Properties.driver.FindElements(By.XPath(obj.gsr_los_ddvalues_ul_li_xpath));
            int losCount = losvalues.Count;
            for (int i = 0; i < losCount; i++)
            {
                if (losvalues[i].GetAttribute("title").Equals(los))
                {
                    losvalues[i].Click();
                    break;
                }
            }
        }

        #endregion

        #region select Environment type
        public void selectEnvType(string EnvType)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_envtype_link_xpath, "click", "");
            IList<IWebElement> EnvTypevalues = Properties.driver.FindElements(By.XPath(obj.gsr_envtype_ddvalues_ul_li_xpath));
            int envtypesCount = EnvTypevalues.Count;
            for (int i = 0; i < envtypesCount; i++)
            {
                if (EnvTypevalues[i].FindElement(By.XPath("div")).Text.Equals(EnvType))
                {
                    EnvTypevalues[i].Click();
                    break;
                }
            }
        }

        #endregion

        #region Enter value in partner/sponsor field
        public void enterPartnerorSponsor(string partner)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_partnerorsponsor_edit_xpath, "sendkeys", partner);
        }

        #endregion

        #region Enter value in charge code field

        public void enterChargecode(string wbscode)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_chargcode_edit_xpath, "sendkeys", wbscode);
        }

        #endregion

        #region Enter risks/security information
        public void enterRiskorsecurityinfoandMoveNext(string info)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_riskorsecurity_textarea_xpath, "sendkeys", info);
            common.smallwait();
            reuse.moveToNextPage();
        }

        #endregion

        #region Enter cloud services list

        public void enterCloudservices(string services)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_cloudservices_edit_xpath, "sendkeys", services);
        }

        #endregion

        #region Enter value in access date field

        public void enterAccessDate(string accessdate)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_accessdate_edit_xpath, "sendkeys", accessdate);
        }

        #endregion

        #region Enter value in go live date field

        public void enterGoliveDateandMoveNext(string golivedate)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_golivedate_edit_xpath, "sendkeys", golivedate);
            common.smallwait();
            reuse.moveToNextPage();
        }

        #endregion

        
    }
}
