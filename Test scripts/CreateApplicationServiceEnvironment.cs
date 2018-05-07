using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using OpenQA.Selenium.Support.UI;

namespace Azure_Automation
{
//[TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
        public void CreateApplicationServiceEnvironment()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("AppEnv");

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
            reuse.TryCatchMethod(appServName, envName, envType, dataClassification, FillAppEnvDetails, "Environment Details page loaded","Failed to load Environment Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(billingTerritory, chargeCode, partner, depManageType, FillBillingDetails, "Billing Information page loaded successfully", "Failed to load Billing Information page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(depType, hostingLocation, appTierSize, FillTechnicalDetails, "Technical Information page loaded successfully", "Failed to load Technical Information page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");

        }

        [Test]
        [TestMethod]
        public void ManageApplicationServiceEnvironment()
        {
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("ManageAppEnv");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            string appServiceName = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string oldEnvName = ExcelMethods.GetValueOfHeader(ds,"EnvironmentName");
            string uniqueVariable  = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string newEnvName = "NewEnvName_"+uniqueVariable;
            #endregion

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
        }

        [Test]
        [TestMethod]
        public void DecommissionApplicationEnvironment()
        {
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("DecomAppEnv");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            string appService = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string envName = ExcelMethods.GetValueOfHeader(ds, "EnvironmentName");
            #endregion
            BaseTest.test = BaseTest.extent.StartTest("Create Application Service");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Manage Application Service Environment Offering'", "Unable select  'Manage Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appService, envName, SelectEnvironment, "User is able to select Environment which is to be Decommissioned", "User is not able to select Environment which is to be Decommissioned");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirmation page", "Unable to navigate to Confirmation page");
            reuse.TryCatchMethod(ConfirmDecom, "User is able to select Yes to Decommission the environment", "User is able to select Yes to Decommission the environment");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }
        public void FillAppEnvDetails(string appService, string envName, string envType, string dataClassification)
        {
            System.Threading.Thread.Sleep(3000);
            CreateAppEnv_ApplicationEnvironmentDetailsPage appEnvDetails = new CreateAppEnv_ApplicationEnvironmentDetailsPage();
            common.Perform(appEnvDetails.ddlApplicationService, "click", "");
            clickElement(CreateAppEnv_ApplicationEnvironmentDetailsPage.ddls, appService);
            common.Perform(appEnvDetails.txtApplicationServiceEnvironmentName, "sendkeys", envName);
            common.Perform(appEnvDetails.ddlEnvironmentType, "click", "");
            clickElement(CreateAppEnv_ApplicationEnvironmentDetailsPage.ddls, envType);
            common.Perform(appEnvDetails.ddlDataClassification, "click", "");
            clickElement(CreateAppEnv_ApplicationEnvironmentDetailsPage.ddls, dataClassification);
        }

        public void FillBillingDetails(string billingTerritory, string chargeCode, string partner, string depManageType)
        {
            System.Threading.Thread.Sleep(3000);
            CreateAppEnv_BillingInformationPage billInfo = new CreateAppEnv_BillingInformationPage();
            common.Perform(billInfo.txtBillingTerritory, "sendkeys", billingTerritory);
            common.Perform(billInfo.txtChargeCode, "sendkeys", chargeCode);
            common.Perform(billInfo.txtPartner, "sendkeys", partner);
            common.Perform(billInfo.txtEnvManagedOrSelfManaged, "sendkeys", depManageType);
        }

        public void FillTechnicalDetails(string depType, string hostingLocation, string appTierSize)
        {
            System.Threading.Thread.Sleep(3000);
            CreateAppEnv_TechnicalInformationPage objTechInfo = new CreateAppEnv_TechnicalInformationPage();
            common.Perform(objTechInfo.txtDeploymentType, "sendkeys", depType);
            common.Perform(objTechInfo.txtHostingLocation, "sendkeys", hostingLocation);
            common.Perform(objTechInfo.txtAppTierSubnetSize, "sendkeys", appTierSize);
        }

        public void ManageEnvironment(string appService, string appEnv, string newEnvName)
        {
            System.Threading.Thread.Sleep(3000);
            ManageAppEnv_AppEnvDetailsPage mngAppEnvObj = new ManageAppEnv_AppEnvDetailsPage();
            common.Perform(mngAppEnvObj.txtAppService, "sendkeys", appService);
            System.Threading.Thread.Sleep(2000);
            common.Perform(mngAppEnvObj.txtRequestOwner, "click", "");
            common.Perform(mngAppEnvObj.txtAppEnv, "sendkeys", appEnv);
            common.Perform(mngAppEnvObj.txtRequestOwner, "click", "");
            common.Perform(mngAppEnvObj.txtAppEnvName, "sendKeys", newEnvName);
        }

        public void SelectEnvironment(string appService, string appEnv)
        {
            System.Threading.Thread.Sleep(3000);
            DecomAppEnv_AppEnvDetailsPage objDecomEnv = new DecomAppEnv_AppEnvDetailsPage();
            common.Perform(objDecomEnv.txtAppService, "sendkeys", appService);
            common.smallwait();
            common.Perform(objDecomEnv.txtRequestOwner, "click", "");
            common.Perform(objDecomEnv.txtAppEnv, "sendkeys", appEnv);
            common.Perform(objDecomEnv.txtRequestOwner, "click", "");
            common.smallwait();
        }
        public void ConfirmDecom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            DecomAppEnv_ConfirmationPage objConfirm = new DecomAppEnv_ConfirmationPage();
            WebDriverWait wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
            common.smallwait(); //common.smallwait(); common.smallwait();
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", objConfirm.btnYes);
            common.Perform(objConfirm.btnYes, "click", "");
            common.smallwait(); common.smallwait();
        }
        public void clickElement(string xpath, string itemtobeclicked)
        {

            System.Threading.Thread.Sleep(3000);
            IList<IWebElement> linkElements = Properties.driver.FindElements(By.XPath(xpath));
            foreach (IWebElement obj in linkElements)
            {
                if (obj.Text.ToString().Trim().Equals(itemtobeclicked))
                { 
                    obj.Click();
                    break;
                }
            }

        }
    }
}
