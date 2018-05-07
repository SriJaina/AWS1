using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Azure_Automation
{
 
    public class CreateSQLRequest : BaseTest
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

               // Properties.driver.Quit();
                extent.EndTest(test);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

               // Properties.driver.Quit();
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
        [Test]
        [TestMethod]
        public void createSQLRequest()
        {
            BaseTest.test = BaseTest.extent.StartTest("Create General service request");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            Exceldatareader excel = new Exceldatareader();
            Data_createSQLPaaS data = new Data_createSQLPaaS(excel, "SQL", 0);
            reuse.TryCatchMethod(reuse.clickOnNewButton, "Clicked on New button", "Unable to click on New button");
            reuse.TryCatchMethod(reuse.navigateToAzureSQLRequest, "Navigated to Creation of Azure SQL PaaS instance", "Unable to navigate to SQL PaaS instance creation page");
            reuse.TryCatchMethod(data.los, selectLOS,"Selected the line of service as " + data.los, "Unable to select the los");
            reuse.TryCatchMethod(data.envtype, selectEnvType, "Selected the Environment type as "+data.envtype, "Unable to select the Environment type");
            reuse.TryCatchMethod(data.nickname, EnterNickname, "Entered the Environment nickname as " + data.nickname, "Unable to enter the environment nickname");
            reuse.TryCatchMethod(data.hostinglocation, selectHostingLocation, "Selected the hosting location as " + data.hostinglocation, "Unable to select the hosting location");
            reuse.TryCatchMethod(data.partnerorsponsor, enterPartnerorSponsor, "Entered the partner email id as " + data.partnerorsponsor, "Unable to enter the partner/sponsor name");
          //  reuse.TryCatchMethod(data.billingterritory,selectBillingTerritory,"Selected the billing territory as "+data.billingterritory,"Unable to select the billing territory");
            reuse.TryCatchMethod(data.chargecode,enterChargecode,"Entered the charge code as "+data.chargecode,"Unable to enter the charge code");
           // reuse.TryCatchMethod(data.consumer, selectConsumingCountry, "Selected the consuming territory as " + data.consumer, "Unable to select the Consuming territory");
            reuse.TryCatchMethod(data.friendlyname, EnterFriendlyName, "Entered the friendly/alias name as " + data.friendlyname, "Unable to enter the friendly name");
            reuse.TryCatchMethod(data.dataclassification, selectDataClassification, "Selected the data classification as" + data.dataclassification, "Unable to select the data classification");
            reuse.TryCatchMethod(data.tier,selectDatabasePricingtier,"Selected the data base pricing tier as "+data.tier,"Unable to select the database pricing tier");
            reuse.TryCatchMethod(data.admin, Enterserveradmin, "Enter the server administrator name as " + data.admin, "Unable to enter the server administrator");
            reuse.TryCatchMethod(data.adminpwd, EnterServerAdminPassword, "Entered the server administrator password", "Unable to enter the server administrator password");
            reuse.TryCatchMethod(data.adminpwd, EnterConfirmServerAdminPassword, "Confirmed the server admin password", "Unable to enter the password in confirmation field");
            reuse.TryCatchMethod(data.golivedate, Entergolivedate, "Entered the go live date as " + data.golivedate, "Unable to enter the golive date");
            reuse.TryCatchMethod(reuse.completeCreationOfRequest, "SQL PaaS Instance request is created successfully", "Unable to complete the SQL PaaS Intance request creation");
        }

        #region select LOS

        public void selectLOS(string los)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_los_link_xpath, "click", "");
             common.smallwait();
            IList<IWebElement> losvalues = Properties.driver.FindElements(By.XPath(obj.sql_los_ddvalues_xpath));
            
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
            IList<IWebElement> EnvTypevalues = Properties.driver.FindElements(By.XPath(obj.sql_envtype_ddvalues_ul_li_xpath));
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

        #region Enter Environment nickname

        public void EnterNickname(string nickname)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.envnickname_input_xpath, "sendkeys", nickname);
        }
        #endregion

        #region select hosting location

        public void selectHostingLocation(string location)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.hostinglocation_dropdown_arrowlink_xpath, "sendkeys", location);
            common.smallwait();
            IList<IWebElement> hostinglocations = Properties.driver.FindElements(By.XPath(obj.hostinglocation_dropdwon_values_xpath));
            common.selectValueFromDropdown(hostinglocations, location);
        }
        #endregion

        #region Enter value in partner/sponsor field
        public void enterPartnerorSponsor(string partner)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.gsr_partnerorsponsor_edit_xpath, "sendkeys", partner);
        }

        #endregion

        #region select billing territory

        public void selectBillingTerritory(string territory)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.billingterritory_input_xpath, "sendkeys", territory);
            common.smallwait();
            IList<IWebElement> billingterritories = Properties.driver.FindElements(By.XPath(obj.billingterritories_dropdown_values_xpath));
            common.selectValueFromDropdown(billingterritories, territory);
            common.smallwait();
        }
        #endregion

        #region Enter value in charge code field

        public void enterChargecode(string wbscode)
        {
            common.smallwait(); common.smallwait(); common.smallwait();
            IWebElement wbscodeElement = Properties.driver.FindElement(By.XPath(obj.gsr_chargcode_edit_xpath));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", wbscodeElement);
            common.ElementOperations("Xpath", obj.gsr_chargcode_edit_xpath, "sendkeys", wbscode);
        }

        #endregion

        #region select consuming country

        public void selectConsumingCountry(string country)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.consumingcountry_dd_link_xpath, "sendkeys", country);
            common.smallwait();
            IList<IWebElement> consumingcountries = Properties.driver.FindElements(By.XPath(obj.consumingcountries_ddvalues_xpath));
            common.selectValueFromDropdown(consumingcountries, country);
        }
        #endregion

        #region Enter Friendly name

        public void EnterFriendlyName(string aliasname)
        {
            common.smallwait(); common.smallwait(); common.smallwait();
            common.ElementOperations("Xpath", obj.friendlyname_input_xpath, "sendkeys", aliasname);
            reuse.moveToNextPage();
            common.smallwait();

        }
        #endregion

        #region Selectdataclassification

        public void selectDataClassification(string dc)
        {
            common.ElementOperations("Xpath", obj.dataclassification_input_xpath, "sendkeys", dc);
            common.smallwait();
            IList<IWebElement> dcs = Properties.driver.FindElements(By.XPath(obj.dataclassifications_ddvalues_xapth));
            common.selectValueFromDropdown(dcs, dc);
            common.smallwait();
        }
        #endregion

        #region select database pricing tier

        public void selectDatabasePricingtier(string tier)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.pricingtier_input_xpath, "sendkeys", tier);
            common.smallwait();
            IList<IWebElement> pricingtiers = Properties.driver.FindElements(By.XPath(obj.pricingtiers_ddvalues_xpath));
            common.selectValueFromDropdown(pricingtiers, tier);
        }
        #endregion

        #region Enter server administrator

        public void Enterserveradmin(string admin)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.serveradmin_input_xpath, "sendkeys", admin);
        }
        #endregion

        #region Enter server admin pwd

        public void EnterServerAdminPassword(string pwd)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.serveradminpwd_input_xpath, "sendkeys", pwd);

        }
        #endregion

        #region confirm server admin pwd

        public void EnterConfirmServerAdminPassword(string confirmpwd)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.confirmserveradminpwd_input_xpath, "sendkeys", confirmpwd);

        }
        #endregion

        #region enter go live date
        public void Entergolivedate(string golivedate)
        {
            common.smallwait();
            common.ElementOperations("Xpath", obj.golivedate_input_xpath, "sendkeys", golivedate);
            common.smallwait();
            reuse.moveToNextPage();
            common.smallwait();
            reuse.moveToNextPage();
        }
        #endregion

 
    }
}
