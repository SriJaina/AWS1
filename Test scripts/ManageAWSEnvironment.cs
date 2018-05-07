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
        public void ManageAWSEnvironment()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("ManageAWSEnvironment");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Request Details page1
            string appServ = ExcelMethods.GetValueOfHeader(ds, "APPLICATIONSERVICE");
            string awsAccount = ExcelMethods.GetValueOfHeader(ds, "AWSACCOUNT");
            string awsVPC = ExcelMethods.GetValueOfHeader(ds, "AWSVPC");
            string awsEnv = ExcelMethods.GetValueOfHeader(ds, "AWSENVIRONMENT");
            
            //Management Roles page
            string usersToBeAdded = ExcelMethods.GetValueOfHeader(ds, "USERSTOBEADDED");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Create AWS Environment");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected Create AWS Envionment Offering", "Unable select Create AWS Environment Offering");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, awsAccount, awsVPC, awsEnv, FillManageAWSEnvRequestDetails, "Request Details page loaded", "Failed to load Request Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(NextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(usersToBeAdded, FillUsersToBeAdded, "User is able to add deployment managers", "User is unable to add deployment managers");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");

        }

        public void FillManageAWSEnvRequestDetails(string appServ, string awsAccount, string awsVPC, string awsEnv )
        {
            System.Threading.Thread.Sleep(3000);
            ManageAWSEnv_RequestDetails RequestDetails = new ManageAWSEnv_RequestDetails();

            common.Perform(RequestDetails.ddlAppServ, "click", "");
            clickElement(ManageAWSEnv_RequestDetails.listAppServ, appServ);
            common.Perform(RequestDetails.ddlawsAccount, "click", "");
            clickElement(ManageAWSEnv_RequestDetails.listawsAccount, awsAccount);
            common.Perform(RequestDetails.ddlawsVPC, "click", "");
            clickElement(ManageAWSEnv_RequestDetails.listawsVPC, awsVPC);
            common.Perform(RequestDetails.ddlawsEnv, "click", "");
            clickElement(ManageAWSEnv_RequestDetails.listawsEnv, awsEnv);
           

        }

        public void FillUsersToBeAdded(string usersToBeAdded)
        {


            IWebElement wb = Properties.driver.FindElement(By.XPath("//label[contains(text(),'Users to be added')]/following-sibling::textarea"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Properties.driver;
            jse.ExecuteScript("arguments[0].value='asutosh.biswal@pwc.com';", wb);

           // IJavaScriptExecutor jse = (IJavaScriptExecutor)Properties.driver;
           // jse.ExecuteScript("document.getElementById('064790a1-a6e3-4d1e-987a-c4b20cdbc3f3').value = usersToBeAdded");





        }

        public void NextPage()
        {
            
            ManageAWSEnv_BillingInformationPage RequestDetails = new ManageAWSEnv_BillingInformationPage();

            while (!RequestDetails.lblBillingInformation.Displayed)
            {
                IWebElement nextButton = Properties.driver.FindElement(By.XPath(obj.nextbutton_xpath));
                IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
                common.smallwait();
                js.ExecuteScript("arguments[0].scrollIntoView(true); ", nextButton);
                js.ExecuteScript("arguments[0].click()", nextButton);
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
