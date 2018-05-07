using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System.Collections.Generic;
using System.Data;
using OpenQA.Selenium.Support.UI;

namespace Azure_Automation
{
    public partial class TestClass 
    {
        // Test Method to Create an Application Service
        // [Test]
        [Test]
        [TestMethod]
        public void CreateApplicationService()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("ApplicationService");
            String offeringName = ExcelMethods.GetValueOfHeader(ds,"Offering");
            string applicationOwner = ExcelMethods.GetValueOfHeader(ds, "ApplicationOwner");
            string technicalContact = ExcelMethods.GetValueOfHeader(ds, "TechnicalContact");
            string los = ExcelMethods.GetValueOfHeader(ds, "Los");
            string timeVariable = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string serviceName = "testService " + timeVariable;
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Create Application Service");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Create Application Service Offering'", "Unable select  'Create Application Service Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(serviceName, applicationOwner, technicalContact, los, fillApplicationServiceDetails, "Selected 'Create Application Service Offering'", "Unable select  'Create Application Service Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
            //reuse.TryCatchMethod(verifyRequestRegisterMessageDisplayed, "Request registered successfully message is displayed", "Request registered successfully message is not displayed");
           // reuse.TryCatchMethod("Requests", "Create a new HyCS Application Service", "New", verifyRequestRegistered, "Request registered successfully", "Request not registered successfully");
        }

        // Test Method to Manage an Application Service
        [Test]
        [TestMethod]
        public void ManageApplicationService()
        {
            string oldServiceName = "testService14July_001";
            string newServiceName = "testService14July_0000001";

            BaseTest.test = BaseTest.extent.StartTest("Manage Application Service");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            // Exceldatareader excel = new Exceldatareader();
            //Data_createGSR data = new Data_createGSR(excel, "GSR", 0);
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod("Manage Application Service", SelectOfferings, "Selected 'Manage Application Service Offering'", "Unable select  'Manage Application Service Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(oldServiceName, newServiceName, updateApplicationServiceName, "Updated Application Service Name", "Could not update Application Service Name'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
            //reuse.TryCatchMethod(verifyRequestRegisterMessageDisplayed, "Request registered successfully message is displayed", "Request registered successfully message is not displayed");
           
        }

        //Method to Click on complete icon
        public void clickOnCompleteIcon()
        {
            CreateAppService cas = new CreateAppService();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true); ",cas.imgComplete);
            js.ExecuteScript("arguments[0].click()", cas.imgComplete);
        }

        //Method to update service name in Manage Application Service flow
        public void updateApplicationServiceName(String oldServiceName, String newServiceName )
        {
            CreateAppService cas = new CreateAppService();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            common.smallwait();
            common.Perform(cas.txtApplicationServiceName, "sendkeys", oldServiceName);
            cas.testNewAppServiceName.Clear();
            common.Perform(cas.testNewAppServiceName, "sendkeys", newServiceName);

        }

        //Method to verify that success message is displayed after completed the flow fo a request
        public void verifyRequestRegisterMessageDisplayed()
        {
            CreateAppService cas = new CreateAppService();
            IWebElement registerMsg = cas.divRegisterSuccess;
            common.smallwait();

            if (!registerMsg.Displayed)
            {
                throw new Exception();
            }
        }

        //Method to verify that new SR request has been placed
        public void verifyRequestRegistered(String requestTitle, String typeOfItem, String Status)
        {
            DashboardPage dp = new DashboardPage();

            //click on the item type ('All Items', 'Requests', Activities', Requests')

            if(requestTitle.Equals("All Items"))
            {
                common.Perform(dp.divAllItems, "click", "");
            }
            else if (requestTitle.Equals("Requests"))
            {
                common.Perform(dp.divRequests, "click", "");
            }
           else if (requestTitle.Equals("Activities"))
            {
                common.Perform(dp.divActivities, "click", "");
            }
           else if (requestTitle.Equals("Resources"))
            {
                common.Perform(dp.divResources, "click", "");
            }else
            {
                throw new Exception();
            }

            //double click on 'Id' header column to sort the recoeds present
            //common.Perform(dp.divIdHeaderColumn, "click", "");
            //common.smallwait();
            //common.Perform(dp.divIdHeaderColumn, "click", "");

            //verify the name and status of the created SR request
            IWebElement requestTable = dp.tblRequestGrid;
            //getting the title of the request
            IWebElement firstTitle = Properties.driver.FindElement(By.XPath("//table[contains(@id,'__fx-grid')]//tbody//tr[1]//td[2]"));

            if (!firstTitle.Text.Contains(typeOfItem))
                throw new Exception();

            //getting the status of the request
            IWebElement firstStatus = Properties.driver.FindElement(By.XPath("//table[contains(@id,'__fx-grid')]//tbody//tr[1]//td[4]"));

            if (!firstStatus.Text.Contains(Status))
                throw new Exception();

        }

        //Method to select offerings option
        public void SelectOfferings(String offeringName)
        {
            /*CreateAppService cas = new CreateAppService();
            common.Perform(cas.txtOfferingSearch, "sendkeys", offeringName);
            string offeringXpath = "//li[@data-filter='"+offeringName+"']";
           IWebElement offeringElement =  Properties.driver.FindElement(By.XPath(offeringXpath));
            common.Perform(offeringElement, "click", "");*/

            CreateAppService cas = new CreateAppService();
            // common.Perform(cas.txtOfferingSearch, "sendkeys", offeringName);
            // common.ElementOperations(cas.txtOfferingSearch, "sendkeys", offeringName,);
            
        
            var wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[text()='All']")));

            cas.txtOfferingSearch.SendKeys(offeringName);
            string offeringXpath = "//li[@data-filter='" + offeringName + "']";
            IWebElement offeringElement = Properties.driver.FindElement(By.XPath(offeringXpath));
            common.Perform(offeringElement, "click", "");
        }

        public void fillApplicationServiceDetails(String serviceName, String applicationOwner, String technicalContact, String los)
        {
            CreateAppService cas = new CreateAppService();
            common.Perform(cas.txtAppServiceName, "sendkeys", serviceName);
            common.Perform(cas.txtApplicationOwner, "sendkeys", applicationOwner);
            common.Perform(cas.txtTechnicalContact, "sendkeys", technicalContact);
            common.Perform(cas.ddlLOS, "sendkeys", los);
        }

        public void navigateToChooseOffering()
        {
                CreateAppService cas = new CreateAppService();
                common.Perform(cas.lnkNew, "click", "");
                common.Perform(cas.divRequestIcon, "click", "");
                common.Perform(cas.divCreateCloudRequest, "click", "");
           
        }
    }
}
