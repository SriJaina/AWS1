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
        public void RequestdotNetIaasPlatform()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("RequestdotNetIaasPlatform");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Choose Offerings page
            //string subscription = ExcelMethods.GetValueOfHeader(ds, "Subscription");
            //VSTS Details page
            string vstsact = ExcelMethods.GetValueOfHeader(ds, "VSTSAccount");
            string vstsprotemplate = ExcelMethods.GetValueOfHeader(ds, "VSTSProTemplate");
            //Application Service Details page
            string timeVariable = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string appServName = "ApplicationService_" + timeVariable;
            string appOwner = ExcelMethods.GetValueOfHeader(ds, "ApplicationOwner");
            string techContact = ExcelMethods.GetValueOfHeader(ds, "TechnicalContact");
            string los = ExcelMethods.GetValueOfHeader(ds, "LineOfService");
            //Application Environment Details page
            string dataclassification = ExcelMethods.GetValueOfHeader(ds, "Dataclassification");
            string hostingloc = ExcelMethods.GetValueOfHeader(ds, "HostingLocation");
            string billterritory = ExcelMethods.GetValueOfHeader(ds, "BillingTerritory");
            string chargeCode = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string partner = ExcelMethods.GetValueOfHeader(ds, "Partner/Sponsor");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Request .NET IaaS Platform");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Request .NET IaaS Platform Offering'", "Unable select Request .NET IaaS Platform Offering'");
            //reuse.TryCatchMethod(subscription, SelectSubscription, "User is able to select Subscription", "User is unable to select Subscription");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(vstsact, vstsprotemplate, FillVSTSDetails, "VSTS Details page loaded", "Failed to load VSTS Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServName, appOwner, techContact, los, FillAppServDetails, "Application Service Details page loaded", "Failed to loadApplication Service Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(dataclassification, hostingloc, billterritory, chargeCode, partner, FillAppEnvDetails, "Application Environment Details page loaded", "Application Environment Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }
        public void SelectSubscription(string subscription)
        {
            System.Threading.Thread.Sleep(3000);
            RequestIaas_SelSubscription sub = new RequestIaas_SelSubscription();

            common.Perform(sub.ddlsubscription, "click", "");
            common.Perform(sub.ddlsubscription, "sendkeys", subscription);
        }

        public void FillVSTSDetails(string vstsact, string vstsprotemplate)
        {
            System.Threading.Thread.Sleep(3000);
            RequestIaas_VSTSDetailsPage vstsdetails = new RequestIaas_VSTSDetailsPage();

            common.Perform(vstsdetails.ddlvstsact, "click", "");
            clickElement(RequestIaas_VSTSDetailsPage.listvstsact, vstsact);
            common.Perform(vstsdetails.ddlvstsprotemplate, "click", "");
            clickElement(RequestIaas_VSTSDetailsPage.listvstsprotemplate, vstsprotemplate);

        }

        public void FillAppServDetails(string appServName, string appOwner, string techContact, string los)
        {
            System.Threading.Thread.Sleep(3000);
            RequestIaas_ApplicationServiceDetailsPage appservdetails = new RequestIaas_ApplicationServiceDetailsPage();

            common.Perform(appservdetails.txtappServName, "sendkeys", appServName);
            common.Perform(appservdetails.txtappOwner, "sendkeys", appOwner);
            common.Perform(appservdetails.txttechContact, "sendkeys", techContact);
            common.Perform(appservdetails.ddllos, "click", "");
            clickElement(RequestIaas_ApplicationServiceDetailsPage.listlos, los);

        }

        public void FillAppEnvDetails(string dataclassification, string hostingloc, string billterritory, string chargeCode, string partner)
        {
            System.Threading.Thread.Sleep(3000);
            RequestIaas_AppEnvironmentDetailsPage appenvdetails = new RequestIaas_AppEnvironmentDetailsPage();

            common.Perform(appenvdetails.ddldataclassification, "click", "");
            clickElement(RequestIaas_AppEnvironmentDetailsPage.listdataclassification, dataclassification);
            common.Perform(appenvdetails.ddlhostingloc, "click", "");
            clickElement(RequestIaas_AppEnvironmentDetailsPage.listhostingloc, hostingloc);
            common.Perform(appenvdetails.ddlbillterritory, "click", "");
            System.Threading.Thread.Sleep(8000);
            common.Perform(appenvdetails.ddlbillterritory, "sendkeys", billterritory);
            common.Perform(appenvdetails.txtchargeCode, "sendkeys", chargeCode);
            common.Perform(appenvdetails.txtpartner, "sendkeys", partner);

        }

    }
}
