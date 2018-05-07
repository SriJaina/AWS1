using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Azure_Automation
{
    //[TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
        public void CreateAWSEnvironment()

        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("CreateAWSEnvironment");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Request Details page1
            string appServ = ExcelMethods.GetValueOfHeader(ds, "APPLICATIONSERVICE");
            string awsAccount = ExcelMethods.GetValueOfHeader(ds, "AWSACCOUNT");
            string awsVPC = ExcelMethods.GetValueOfHeader(ds, "AWSVPC");
            string awsEnvType = ExcelMethods.GetValueOfHeader(ds, "AWSENVIRONMENTTYPE");
            string timeVariable = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string awsEnvName = "Test" + timeVariable;
            string dataClassification = ExcelMethods.GetValueOfHeader(ds, "DATACLASSIFICATION");
            //Management Roles
            string depManager = ExcelMethods.GetValueOfHeader(ds, "DEPLOYMENTMANAGER");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Create AWS Environment");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected Create AWS Envionment Offering", "Unable select Create AWS Environment Offering");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, awsAccount, awsVPC, awsEnvType, awsEnvName, dataClassification, FillCreateAWSEnvRequestDetails, "Request Details page loaded", "Failed to load Request Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(ConfirmDeployAppTier, "User is able to select Yes to 'DO YOU WANT TO DEPLOY APP TIER?'", "User is not able to select Yes to 'DO YOU WANT TO DEPLOY APP TIER?");
            reuse.TryCatchMethod(ConfirmDeployLoadBal, "User is able to select Yes to 'DO YOU WANT TO DEPLOY INTERNAL LOAD BALANCER?'", "User is not able to select Yes to 'DO YOU WANT TO DEPLOY INTERNAL LOAD BALANCER?");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(depManager, FillDeploymentManagerDetails, "User is able to add deployment managers", "User is unable to add deployment managers");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        public void FillCreateAWSEnvRequestDetails(string appServ, string awsAccount, string awsVPC, string awsEnvType, string awsEnvName, string dataClassification)
        {
            System.Threading.Thread.Sleep(3000);
            CreateAWSEnv_RequestDetails RequestDetails = new CreateAWSEnv_RequestDetails();

            common.Perform(RequestDetails.ddlAppServ, "click", "");
            clickElement(CreateAWSEnv_RequestDetails.listAppServ, appServ);
            common.Perform(RequestDetails.ddlawsAccount, "click", "");
            clickElement(CreateAWSEnv_RequestDetails.listawsAccount, awsAccount);
            common.Perform(RequestDetails.ddlawsVPC, "click", "");
            clickElement(CreateAWSEnv_RequestDetails.listawsVPC, awsVPC);
            common.Perform(RequestDetails.ddlawsEnvType, "click", "");
            clickElement(CreateAWSEnv_RequestDetails.listawsEnvType, awsEnvType);
            //common.Perform(RequestDetails.txtawsEnvName, "click", "");
            common.Perform(RequestDetails.txtawsEnvName, "sendkeys", awsEnvName);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", RequestDetails.ddldataClassification);

            
            common.Perform(RequestDetails.ddldataClassification, "click", "");
            clickElement(CreateAWSEnv_RequestDetails.listdataClassification, dataClassification);

        }

        public void ConfirmDeployAppTier()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            CreateAWSEnv_TechnicalDetailsPage ConfirmApptier = new CreateAWSEnv_TechnicalDetailsPage();
            WebDriverWait wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
            common.smallwait(); //common.smallwait(); common.smallwait();
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", ConfirmApptier.btnYesAppTier);
            common.Perform(ConfirmApptier.btnYesAppTier, "click", "");
            common.smallwait(); common.smallwait();
        }
        public void ConfirmDeployLoadBal()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            CreateAWSEnv_TechnicalDetailsPage ConfirmLB = new CreateAWSEnv_TechnicalDetailsPage();
            WebDriverWait wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
            common.smallwait(); //common.smallwait(); common.smallwait();
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", ConfirmLB.btnYesLoadBal);
            common.Perform(ConfirmLB.btnYesLoadBal, "click", "");
            common.smallwait(); common.smallwait();
            System.Threading.Thread.Sleep(3000);
        }


        /*public void FillDeploymentManagerDetails(string depManager)
        {
            
            System.Threading.Thread.Sleep(5000);
            CreateAWSEnv_ManagementRolesPage RequestDetails = new CreateAWSEnv_ManagementRolesPage();
            
            common.Perform(RequestDetails.txtDepManagers, "senkeys", depManager);



        }*/




    }
}
