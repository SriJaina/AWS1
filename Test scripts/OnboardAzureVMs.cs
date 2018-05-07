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
    
        public void OnboardAzureVMs()
        {
            
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("OnboardAzureVMs");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");

            //Request Details page
            string appService = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string azureSubscription = ExcelMethods.GetValueOfHeader(ds, "AzureSubscription");
            string vnet = ExcelMethods.GetValueOfHeader(ds, "Vnet");
            string resourceGroup = ExcelMethods.GetValueOfHeader(ds, "ResourceGroup");
            //Application Environment Details page
            string environmentType= ExcelMethods.GetValueOfHeader(ds, "EnvironmentType");


            #endregion


            BaseTest.test = BaseTest.extent.StartTest("Onboard Azure VMs");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Onboard Azure VMs'", "Unable select 'Onboard Azure VMs'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Request Details screen", "Unable to navigate to Request Details screen");
            reuse.TryCatchMethod(appService, azureSubscription, vnet, resourceGroup, OnboardAzureVMsRequestDetails, "User is able to fill details", "User is not able to fill all the details");
            System.Threading.Thread.Sleep(20000);
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Application Environment Details page screen", "Unable to navigate to Application Environment Details page screen");
            reuse.TryCatchMethod(environmentType, OnboardAzureVMsAppEnvDetails, "User is able to fill details", "User is not able to fill all the details");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Billing Information screen", "Unable to navigate to Billing Information screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Technical Information screen", "Unable to navigate to Technical Information screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Management Roles screen", "Unable to navigate to Management Roles screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        public void OnboardAzureVMsRequestDetails(string appService, string azureSubscription, string vnet, string resourceGroup)
        {
            System.Threading.Thread.Sleep(8000);
            OnboardAzureVMs_RequestDetailsPage RequestDetails = new OnboardAzureVMs_RequestDetailsPage();

            

            common.Perform(RequestDetails.ddlappService, "sendkeys", appService);
            common.Perform(RequestDetails.ddlazureSubscription, "click", "");
            clickElement(OnboardAzureVMs_RequestDetailsPage.listAzureSubscription, azureSubscription);
            var wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[contains(text(),'VNET')]/following-sibling::div//div//a")));
            common.Perform(RequestDetails.ddlvnet, "click", "");
            clickElement(OnboardAzureVMs_RequestDetailsPage.listvnet, vnet);
            common.Perform(RequestDetails.ddlresourceGroup, "click", "");
            clickElement(OnboardAzureVMs_RequestDetailsPage.listresourceGroup, resourceGroup);

            //common.Perform(RequestDetails.ddlresourceGroup, "sendkeys", resourceGroup);


        }

        public void OnboardAzureVMsAppEnvDetails(string environmentType)
        {
            System.Threading.Thread.Sleep(3000);
            OnboardVirtualVMs_AppEnvironmentDetailsPage Details = new OnboardVirtualVMs_AppEnvironmentDetailsPage();

            common.Perform(Details.ddlenvironmentType, "sendkeys", environmentType);

        }
    }
}
