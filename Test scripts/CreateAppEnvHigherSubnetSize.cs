using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Data;

namespace Azure_Automation
{
   // [TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
        public void CreateApplicationEnvironment()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("CreateAppEnv2");

            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Environment Details page 
            string appServName = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string timeVariable = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string envName = "testEnv_" + timeVariable;
            string envType = ExcelMethods.GetValueOfHeader(ds, "EnvironmentType");
            string dataClassification = ExcelMethods.GetValueOfHeader(ds, "DataClassification");
            //Billing Information page fields
            string billingTerritory = ExcelMethods.GetValueOfHeader(ds, "BillingTerritory");
            string chargeCode = ExcelMethods.GetValueOfHeader(ds, "ChargeCode");
            string partner = ExcelMethods.GetValueOfHeader(ds, "PartnerOrSponser");
            string depManageType = ExcelMethods.GetValueOfHeader(ds, "DeploymentManageType");
            //Technical Information page fields
            string depType = ExcelMethods.GetValueOfHeader(ds, "DeploymentType");
            string hostingLocation = ExcelMethods.GetValueOfHeader(ds, "HostingLocation");
            string webTierSize = ExcelMethods.GetValueOfHeader(ds, "WebTierSize");
            string appTierSize = ExcelMethods.GetValueOfHeader(ds, "AppTierSize");
            string DataTierSize = ExcelMethods.GetValueOfHeader(ds, "DataTierSize");
            #endregion
            BaseTest.test = BaseTest.extent.StartTest("Create Application Service");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Create Application Service Environment Offering'", "Unable select  'Create Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServName, envName, envType, dataClassification, FillAppEnvDetails, "Environment Details page loaded", "Failed to load Environment Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(billingTerritory, chargeCode, partner, depManageType, FillBillingDetails, "Billing Information page loaded successfully", "Failed to load Billing Information page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(depType, hostingLocation, appTierSize, FillTechnicalDetails, "Technical Information page loaded successfully", "Failed to load Technical Information page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");


            //Approval part
        }

      /*  [Test]
        [TestMethod]
        public void ManageApplicationEnvironment()
        {
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("ManageAppEnv2");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            string appServiceName = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string oldEnvName = ExcelMethods.GetValueOfHeader(ds, "EnvironmentName");
            #endregion
            string uniqueVariable = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string newEnvName = "NewEnvName_" + uniqueVariable;
            BaseTest.test = BaseTest.extent.StartTest("Create Application Service");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Manage Application Service Environment Offering'", "Unable select  'Manage Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServiceName, oldEnvName, newEnvName, ManageEnvironment, "User is able to edit the details in Environment Details page", "User is not able to edit the details in Environment Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Billing Information page", "Unable to navigate to Billing Information Page");
            System.Threading.Thread.Sleep(3000);
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Technical Information page", "Unable to navigate to Technical Information page");
            System.Threading.Thread.Sleep(3000);
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Management Roles page", "Unable to navigate to Management Roles page");
            System.Threading.Thread.Sleep(3000);
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirmation page", "Unable to navigate to Confirmation page");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }*/

    }
}
