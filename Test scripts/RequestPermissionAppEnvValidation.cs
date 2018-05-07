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
        public void RequestPermissionAppEnvValidation()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("RequestPermissionEnvValidation");

            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            string appServName = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string envName = ExcelMethods.GetValueOfHeader(ds, "ApplicationEnvironment");
            string reason = ExcelMethods.GetValueOfHeader(ds, "Reason");
            
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Request permission to deploy Resource(s) to an environment");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Request Permission to deploy resource on application environment'", "Unable select  'Request Permission to deploy resource on application environment'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Request Details screen", "Unable to navigate to Request Details screen");
            reuse.TryCatchMethod(appServName, envName, reason, FillRequestPermissionAppEnvValidation, "User is able to fill details", "User is not able to fill all the details");
            reuse.TryCatchMethod(RequestPermissionValidation, "User is able to Validate", "User is unable to Validate");
            
            

        }

        public void FillRequestPermissionAppEnvValidation(string appServ, string appEnv, string reason)
        {
            common.smallwait();
            RequestPermissionPage reqObj = new RequestPermissionPage();
            common.Perform(reqObj.txtAppService, "sendkeys", appServ);
            common.Perform(reqObj.txtRequestOwner, "click", "");
            common.Perform(reqObj.txtAppEnv, "sendkeys", appEnv);
            common.Perform(reqObj.txtReasonforRequest, "sendkeys", reason);
        }

        public void RequestPermissionValidation()
        {
            System.Threading.Thread.Sleep(5000);
            string actualmessage = (Properties.driver.FindElement(By.XPath("//label[text()='App Environment Validation']/following-sibling::input"))).GetAttribute("value"); 
            
            if (actualmessage.Equals("Requestor is an existing Admin."))
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
