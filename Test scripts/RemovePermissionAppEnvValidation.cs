using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using RelevantCodes.ExtentReports;

namespace Azure_Automation
{
    //[TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
       
        public void RemovePermissionAppEnvValidation()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("RemovePermissionEnvValidation");

            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            string appServName = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string envName = ExcelMethods.GetValueOfHeader(ds, "ApplicationEnvironment");
            string reason = ExcelMethods.GetValueOfHeader(ds, "Reason");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Remove permission to deploy Resource(s) to an environment");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Remove Permission to deploy resource on application environment'", "Unable select  'Remove Permission to deploy resource on application environment'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Request Details screen", "Unable to navigate to Request Details screen");
            reuse.TryCatchMethod(appServName, envName, reason, FillRemovePermissionAppEnvValidation, "User is able to fill details", "User is not able to fill all the details");
            reuse.TryCatchMethod(RemovePermissionValidation, "User is able to Validate", "User is unable to Validate");



        }

        public void FillRemovePermissionAppEnvValidation(string appServ, string appEnv, string reason)
        {
            common.smallwait();
            RemovePermissionPage reqObj = new RemovePermissionPage();
            common.Perform(reqObj.txtAppService, "sendkeys", appServ);
            common.Perform(reqObj.txtRequestOwner, "click", "");
            common.Perform(reqObj.txtAppEnv, "sendkeys", appEnv);
            common.Perform(reqObj.txtReasonforRequest, "sendkeys", reason);
        }
        public void RemovePermissionValidation()
        {
            System.Threading.Thread.Sleep(5000);
            string actualmessage = (Properties.driver.FindElement(By.XPath("//label[text()='App Environment Validation']/following-sibling::textarea"))).GetAttribute("value");

            if (actualmessage.Equals("There must be atleast one admin present. Cannot request for removing permission."))
            {
                BaseTest.test.Log(LogStatus.Pass, "Active Deployment manager is restricted from submitting a request for his own requirement");
            }
            else
            {
                BaseTest.test.Log(LogStatus.Fail, "Active Deployment manager is able to submit a request for his own requirement");
                NUnit.Framework.Assert.Fail();
            }


        }
    }
}
