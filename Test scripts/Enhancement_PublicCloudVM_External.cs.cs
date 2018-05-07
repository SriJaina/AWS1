using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;

namespace Azure_Automation
{
    //[TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
        public void RequestAzurePublicCloudVM_External()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("RequestAzurePublicCloudVM_External");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Environment Details Page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string osFamily = ExcelMethods.GetValueOfHeader(ds, "OSFamily");
            //Web Tier Details Page
            string webTierQuantity = ExcelMethods.GetValueOfHeader(ds, "WebTierQuantity");
            string webTierDiskSize = ExcelMethods.GetValueOfHeader(ds, "WebTierDiskSize");
            string webTierAvaSet = ExcelMethods.GetValueOfHeader(ds, "WebTierAvailabilitySet");
            string webTierServerClass = ExcelMethods.GetValueOfHeader(ds, "WebTierServerClass");
            string webTierServerType = ExcelMethods.GetValueOfHeader(ds, "WebTierServerTypes");
            //App Tier Details Page
            string appTierQuantity = ExcelMethods.GetValueOfHeader(ds, "AppTierQuantity");
            string appTierDiskSize = ExcelMethods.GetValueOfHeader(ds, "AppTierDiskSize");
            string appTierAvaSet = ExcelMethods.GetValueOfHeader(ds, "AppTierAvailabilitySet");
            string appTierServerClass = ExcelMethods.GetValueOfHeader(ds, "AppTierServerClass");
            string appTierServerType = ExcelMethods.GetValueOfHeader(ds, "AppTierServerType");
            //Data Tier Details Page
            string dBTierQuantity = ExcelMethods.GetValueOfHeader(ds, "DataBaseTierQuantity");
            string dBTierDiskSize = ExcelMethods.GetValueOfHeader(ds, "DataBaseTierDiskSize");
            string dBTierAvaSet = ExcelMethods.GetValueOfHeader(ds, "DataBaseTierAvailabitySet");
            string dBTierServerClass = ExcelMethods.GetValueOfHeader(ds, "DataBaseTierServerClass");
            string dBTierServerType = ExcelMethods.GetValueOfHeader(ds, "DataBaseTierServerType");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Request Azure Public Cloud VM(s) for External-facing Apps");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected Request Azure Public Cloud VM(s) for External-facing Apps Offering", "Unable select Request Azure Public Cloud VM(s) for External-facing Apps Offering");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, osFamily, FillVMExternalEnvDetailsPage, "Environment Details Page loaded", "Failed to load Environment Details Page");
            reuse.TryCatchMethod(webTierQuantity, webTierDiskSize, webTierAvaSet, webTierServerClass , webTierServerType, FillVMExtWebTierDetailsPage, "Web Tier Details Page loaded", "Failed to load Web Tier Details Page");

        }
        public void FillVMExternalEnvDetailsPage(string appServ, string appServEnv, string osFamily)
        {
            System.Threading.Thread.Sleep(3000);
            RequestAzurePublicCloudVMExt_EnvDetailsPage EnvDetails = new RequestAzurePublicCloudVMExt_EnvDetailsPage();

            common.Perform(EnvDetails.ddlappServ, "click", "");
            clickElement(RequestAzurePublicCloudVMExt_EnvDetailsPage.listAppServ, appServ);
            common.Perform(EnvDetails.ddlappServEnv, "click", "");
            clickElement(RequestAzurePublicCloudVMExt_EnvDetailsPage.listAppServEnv, appServEnv);
            common.Perform(EnvDetails.ddlosFamily, "click", "");
            clickElement(RequestAzurePublicCloudVMExt_EnvDetailsPage.listOSFamily, osFamily);
          
        }

        public void FillVMExtWebTierDetailsPage(string webTierQuantity, string webTierDiskSize, string webTierAvaSet, string webTierServerClass, string webTierServerType)
        {
            System.Threading.Thread.Sleep(3000);
            RequestAzurePublicCloudVMExt_EnvDetailsPage EnvDetails = new RequestAzurePublicCloudVMExt_EnvDetailsPage();

            common.Perform(EnvDetails.ddlappServ, "click", "");
            clickElement(RequestAzurePublicCloudVMExt_EnvDetailsPage.listAppServ, webTierQuantity);
            common.Perform(EnvDetails.ddlappServEnv, "click", "");
            clickElement(RequestAzurePublicCloudVMExt_EnvDetailsPage.listAppServEnv, webTierDiskSize);
            common.Perform(EnvDetails.ddlosFamily, "click", "");
            clickElement(RequestAzurePublicCloudVMExt_EnvDetailsPage.listOSFamily, webTierAvaSet);

        }



    }
}
