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
        public void CreateAzureLoadBalancer()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("CreateAzureLoadBalancer");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Request Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string tier = ExcelMethods.GetValueOfHeader(ds, "Tier");
            //Load Balancer Details page
            string availabilitySet = ExcelMethods.GetValueOfHeader(ds, "AvailabilitySet");
            string port = ExcelMethods.GetValueOfHeader(ds, "Port");
            string sessionPersistence = ExcelMethods.GetValueOfHeader(ds, "SessionPersistence");
            string vmsToBeAdded = ExcelMethods.GetValueOfHeader(ds, "VMsToBeAdded");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Create Azure Load Balancer");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected Create Azure Load Balancer Offering", "Unable select Create Azure Load Balancer Offering");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, tier, FillCreateAzureLoadBalancerRequestDetails, "Request Details page loaded", "Failed to load Request Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(availabilitySet, port, sessionPersistence, vmsToBeAdded, FillCreateAzureLoadBalancer_LBDetails, "Load Balancer Details page loaded", "Failed to load Load Balancer Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");


        }

        public void FillCreateAzureLoadBalancerRequestDetails(string appServ, string appServEnv, string tier)
        {
            System.Threading.Thread.Sleep(3000);
            CreateAzureLoadBalancer_RequestDetaislPage RequestDetails = new CreateAzureLoadBalancer_RequestDetaislPage();

            common.Perform(RequestDetails.ddlappServ, "click", "");
            clickElement(CreateAzureLoadBalancer_RequestDetaislPage.listAppServ, appServ);
            common.Perform(RequestDetails.ddlappServEnv, "click", "");
            clickElement(CreateAzureLoadBalancer_RequestDetaislPage.listAppServEnv, appServEnv);
            common.Perform(RequestDetails.ddltier, "click", "");
            clickElement(CreateAzureLoadBalancer_RequestDetaislPage.listtier, tier);
            System.Threading.Thread.Sleep(8000);
        }

        public void FillCreateAzureLoadBalancer_LBDetails(string availabilitySet, string port, string sessionPersistence, string vmsToBeAdded)
        {
            System.Threading.Thread.Sleep(3000);
            CreateAzureLoadBalancer_LoadBalancerDetailsPage LBDetails = new CreateAzureLoadBalancer_LoadBalancerDetailsPage();

            common.Perform(LBDetails.ddlavailabilitySet, "click", "");
            clickElement(CreateAzureLoadBalancer_LoadBalancerDetailsPage.listavailabilitySet, availabilitySet);
            common.Perform(LBDetails.ddlport, "click", "");
            clickElement(CreateAzureLoadBalancer_LoadBalancerDetailsPage.listport, port);
            common.Perform(LBDetails.ddlsessionPersistence, "click", "");
            clickElement(CreateAzureLoadBalancer_LoadBalancerDetailsPage.listsessionPersistence, sessionPersistence);
            common.Perform(LBDetails.txtvmsToBeAdded, "sendkeys", vmsToBeAdded);
            System.Threading.Thread.Sleep(8000);
        }


    }
}
