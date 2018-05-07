using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;

namespace Azure_Automation
{
    [TestClass]
    public partial class TestClass { 

        [Test]
        [TestMethod]
        public void RequestAzureSQLPass()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("AzureSQLPaaS");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Environment Details page
            string appService = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appEnvironment = ExcelMethods.GetValueOfHeader(ds, "ApplicationEnvironment");
            //Technical Details page
            string instancesQty = ExcelMethods.GetValueOfHeader(ds, "DBInstancesQuantity");
            string pricingTier = ExcelMethods.GetValueOfHeader(ds, "DBPricingTier");
            string serverAdmin = ExcelMethods.GetValueOfHeader(ds, "SQLServerAdmin");
            string password = ExcelMethods.GetValueOfHeader(ds, "Password");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Request Azure SQL PaaS Instance");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Create Application Service Environment Offering'", "Unable select  'Create Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Environment Details page", "Unable to navigate to Environment Details page");
            reuse.TryCatchMethod(appService, appEnvironment, FillEnvDetails, "User is able to fill the details in Environment Details Page", "User is not able to fill the details in Environment Details Page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Technical Details page", "Unable to navigate to Technical Details page");
            reuse.TryCatchMethod(instancesQty, pricingTier, serverAdmin, password, FillTechnicalDetails, "User is able to fill the details in Technical Details page", "User is able to fill the details in Technical Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Validation page", "Unable to navigate to Validation page");
            common.smallwait();
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        public void FillEnvDetails(string appService, string appEnv)
        {
            SQLPaaS_EnvironmentDetails objEnvDtls = new SQLPaaS_EnvironmentDetails();
            common.smallwait();
            common.Perform(objEnvDtls.txtAppService, "sendkeys", appService);
            common.Perform(objEnvDtls.txtRequestOwner, "click", "");
            common.Perform(objEnvDtls.txtAppEnv, "sendkeys", appEnv);
            common.Perform(objEnvDtls.txtRequestOwner, "click", "");
        }

        public void FillTechnicalDetails(string instanceQty, string pricingTier, string serverAdmin, string password)
        {
            common.smallwait();
            SQLPaas_TechnicalDetails objTechnicalDtls = new SQLPaas_TechnicalDetails();
            common.Perform(objTechnicalDtls.txtDBInstanceQty, "sendkeys", instanceQty);
            common.Perform(objTechnicalDtls.txtDBPricingTier, "sendkeys", pricingTier);
            common.Perform(objTechnicalDtls.txtServerAdmin, "sendkeys", serverAdmin);
            common.Perform(objTechnicalDtls.txtPassword, "sendkeys", password);
            common.Perform(objTechnicalDtls.txtConfirmPassword, "sendkeys", password);
        }
    }
}