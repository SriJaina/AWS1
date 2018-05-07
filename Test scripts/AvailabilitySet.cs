using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
//Test
namespace Azure_Automation
{
    //[TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
        public void CreateAvailabilitySet()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("CreateAvailabilitySet");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Request Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string tier = ExcelMethods.GetValueOfHeader(ds, "Tier");
            #endregion


            BaseTest.test = BaseTest.extent.StartTest("Create Availability Set");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Create Availability Set Offering'", "Unable select  'Create Availability Set Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, tier, FillRequestDetails, "Describe your request page is loaded", "Failed to load Describe your request page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
         }

        [Test]
        [TestMethod]
        public void DecommissionAvailabilitySet()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("DecommissionAvailabilitySet");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Request Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string availSet = ExcelMethods.GetValueOfHeader(ds, "AvailabilitySet");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Decommission Availability Set");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            BaseTest.test = BaseTest.extent.StartTest("Decommission Availability Set");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Decommission Availability Set Offering'", "Unable select  'Decommission Availability Set Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, availSet, FillDecAvaSetDetails, "Decommission Availability Set page is loaded", "Failed to load Decommission Availability Set");
            System.Threading.Thread.Sleep(5000);
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirmation page", "Unable to navigate to Confirmation page");
            reuse.TryCatchMethod(ConfirmDecom, "User is able to select Yes to Decommission the environment", "User is able to select Yes to Decommission the environment");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }


        public void FillRequestDetails(string appServ, string appServEnv, string tier)
        {
            System.Threading.Thread.Sleep(3000);
            CreateAvailabilitySet_DescYourRequestPage RequestDetails = new CreateAvailabilitySet_DescYourRequestPage();


            common.Perform(RequestDetails.ddlappServ, "click", "");
            clickElement(CreateAvailabilitySet_DescYourRequestPage.listAppServ, appServ);
            common.Perform(RequestDetails.ddlappServEnv, "click", "");
            clickElement(CreateAvailabilitySet_DescYourRequestPage.listAppServEnv, appServEnv);
            common.Perform(RequestDetails.ddltier, "click", "");
            clickElement(CreateAvailabilitySet_DescYourRequestPage.listtier, tier);


        }


        public void FillDecAvaSetDetails(string appServ, string appServEnv, string availSet)
        {
            System.Threading.Thread.Sleep(3000);
            DecommissionAvailabilitySetPage RequestDetails = new DecommissionAvailabilitySetPage();

            common.Perform(RequestDetails.ddlappServ, "click", "");
            clickElement(DecommissionAvailabilitySetPage.listAppServ, appServ);
            common.Perform(RequestDetails.ddlappServEnv, "click", "");
            clickElement(DecommissionAvailabilitySetPage.listAppServEnv, appServEnv);
            common.Perform(RequestDetails.ddlavaSet, "click", "");
            clickElement(DecommissionAvailabilitySetPage.listAvaSet, availSet);


        }
    }
}
