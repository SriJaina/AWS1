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
            
            public void DecomAppEnv_ActiveLoadBalancer()
            {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("DecomAppEnv_ActiveLoadBalancer");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            string appService = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string envName = ExcelMethods.GetValueOfHeader(ds, "EnvironmentName");
            #endregion

                BaseTest.test = BaseTest.extent.StartTest("Decommission Application Environment");
                reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
                reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
                reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Decommission Application Environment Offering'", "Unable select 'Decommission Application Environment Offering'");
                reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
                reuse.TryCatchMethod(appService, envName, SelectEnvironment, "User is able to select Environment which is to be Decommissioned", "User is not able to select Environment which is to be Decommissioned");
                reuse.TryCatchMethod(reuse.moveToNextPage, "Next button is clicked", "Unable to click on next button");
                reuse.TryCatchMethod(ScreenNavigationVerification, "Environment with active Load Balancer is restriced from decommissioning", "User is able to decommission an environment containing active load balancer");




        }
        
        public void ScreenNavigationVerification()
        {
            System.Threading.Thread.Sleep(5000);
            DecomAppEnv_AppEnvDetailsPage EnvDetails = new DecomAppEnv_AppEnvDetailsPage();
            string actualmessage = (Properties.driver.FindElement(By.XPath("//label[text()='Application Environment Validation']/following-sibling::textarea"))).GetAttribute("value");
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("DecomAppEnv_ActiveLoadBalancer");
            string validmessage = ExcelMethods.GetValueOfHeader(ds, "ValidMessage");

            if (EnvDetails.txtPageHeader.Displayed)
            {
                if (actualmessage.Equals(validmessage))
                {
                    BaseTest.test.Log(LogStatus.Pass, "Proper validation message is displayed");
                }
                else
                {
                    BaseTest.test.Log(LogStatus.Fail, "Improper validation message is displayed");
                    NUnit.Framework.Assert.Fail();
                }



                
            }
            else
            {
                BaseTest.test.Log(LogStatus.Fail, "Navigated to Confirmation page even after containing active Load Balancers");
                NUnit.Framework.Assert.Fail();
            }


        }

    }
}
