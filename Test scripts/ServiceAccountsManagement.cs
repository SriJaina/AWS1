using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;

namespace Azure_Automation
{
   // [TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
        public void CreateServiceAccount()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("CreateServiceAccount");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Environment Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationEnvironment");
            //Service Account Details page
            string typeOfAccount = ExcelMethods.GetValueOfHeader(ds, "TypeOfAccount");
            string shortName = ExcelMethods.GetValueOfHeader(ds, "ShortName");
            string password = ExcelMethods.GetValueOfHeader(ds, "Password");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Create Service Account");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Create Application Service Environment Offering'", "Unable select  'Create Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Environment Details page", "Unable to navigate to Environment Details page");
            reuse.TryCatchMethod(appServ, appEnv, SAEnvironmentDetails, "User is able to fill the details in Environment Details page", "User is not able to fill the details in Environment Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Service Account Details page", "Unable to navigate to Service Account Details page");
            reuse.TryCatchMethod(typeOfAccount, shortName, password, ServiceAccountDetails, "User is able to fill the details in Service Account Details page", "User is not able to fill the details in Service Account Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        [Test]
        [TestMethod]
        public void ManageServiceAccount()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("ManageServiceAccount");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Environment Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationEnvironment");
            //Service Account Details page
            string servAcntName = ExcelMethods.GetValueOfHeader(ds, "ServiceAccount");
            string operation = ExcelMethods.GetValueOfHeader(ds, "Operation");
            string password = ExcelMethods.GetValueOfHeader(ds, "Password");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Manage Service Account");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Create Application Service Environment Offering'", "Unable select  'Create Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Environment Details page", "Unable to navigate to Environment Details page");
            reuse.TryCatchMethod(appServ, appEnv, EnvironmentDetails, "User is able to fill the details in Environment Details page", "User is not able to fill the details in Environment Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Operation page", "Unable to navigate to Operation page");
            reuse.TryCatchMethod(servAcntName, operation, SelectServiceAccountAndOperation, "User is able to select Service Account and Operation", "User is not able to select Service Account and Operation");
            reuse.TryCatchMethod(password, ResetPassword, "User is able to fill new password", "User is not able to fill new password");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        [Test]
        [TestMethod]
        public void DecommissionServiceAccount()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("DecommissionServiceAccount");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Environment Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationEnvironment");
            //Service Account Details page
            string servAcntName = ExcelMethods.GetValueOfHeader(ds, "ServiceAccount");
            string operation = ExcelMethods.GetValueOfHeader(ds, "Operation");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Decommission Service Account");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Create Application Service Environment Offering'", "Unable select  'Create Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Environment Details page", "Unable to navigate to Environment Details page");
            reuse.TryCatchMethod(appServ, appEnv, EnvironmentDetails, "User is able to fill the details in Environment Details page", "User is not able to fill the details in Environment Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Operation page", "Unable to navigate to Operation page");
            reuse.TryCatchMethod(servAcntName, operation, SelectServiceAccountAndOperation, "User is able to select Service Account and Operation", "User is not able to select Service Account and Operation");
            reuse.TryCatchMethod(DecomServAcnt, "User is able to fill decommission service account", "User is not able to decommission service account");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }
        public void SAEnvironmentDetails(string appServ, string appEnv)
        {
            common.smallwait();
            CreateServiceAccount_EnvDetailsPage objEnvDtls = new CreateServiceAccount_EnvDetailsPage();
            common.Perform(objEnvDtls.txtAppService, "sendkeys", appServ);
            common.Perform(objEnvDtls.txtRequestOwner, "click", "");
            common.Perform(objEnvDtls.txtAppEnv, "sendkeys", appEnv);
        }

        public void ServiceAccountDetails(string typeOfAccount, string shortName, string password)
        {
            common.smallwait();
            CreateServiceAccount_ServiceAccountDetails objServAcnt = new CreateServiceAccount_ServiceAccountDetails();
            common.Perform(objServAcnt.txtTypeofAccount, "sendkeys", typeOfAccount);
            common.Perform(objServAcnt.txtShortName, "sendkeys", shortName);
            common.Perform(objServAcnt.txtPassword, "sendkeys", password);
            common.Perform(objServAcnt.txtConfirmPassword, "sendkeys", password);
        }

        public void EnvironmentDetails(string appServ, string appEnv)
        {
            common.smallwait();
            ManageServiceAccount_EnvDetailsPage objEnvDtls = new ManageServiceAccount_EnvDetailsPage();
            common.Perform(objEnvDtls.txtAppService, "sendkeys", appServ);
            common.Perform(objEnvDtls.txtRequestOwner, "click", "");
            common.Perform(objEnvDtls.txtAppEnv, "sendkeys", appEnv);
            common.Perform(objEnvDtls.txtRequestOwner, "click", "");
        }

        public void SelectServiceAccountAndOperation(string servaccnt, string operation)
        {
            common.smallwait();
            ManageServiceAccount_OperationPage objOperation = new ManageServiceAccount_OperationPage();
            common.Perform(objOperation.txtServiceAccount, "sendkeys", servaccnt);
            common.Perform(objOperation.txtOperation, "sendkeys", operation);
            common.Perform(objOperation.lblPageHead, "click", "");
        }

        public void ResetPassword(string password)
        {
            common.smallwait();
            ManageServiceAccount_OperationPage objOperation = new ManageServiceAccount_OperationPage();
            common.Perform(objOperation.txtPassword, "sendkeys", password);
            common.Perform(objOperation.txtConfirmPassword, "sendkeys", password);
            common.Perform(objOperation.btnYes, "click", "");
        }

        public void DecomServAcnt()
        {
            common.smallwait();
            ManageServiceAccount_OperationPage objOperation = new ManageServiceAccount_OperationPage();
            common.Perform(objOperation.btnYes, "click", "");
        }
    }
}
