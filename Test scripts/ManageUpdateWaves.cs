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
        public void ManageUpdateWaves()
        {
            #region data Required
            ExcelMethods em = new ExcelMethods();
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("ManageUpdateWaves");
            //Resources Tab
            string vmName = ExcelMethods.GetValueOfHeader(ds, "VMName");
            //Update Wave Page
            string updateWave = ExcelMethods.GetValueOfHeader(ds, "UpdateWave");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Manage Update Waves");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToResources, "Navigated to Resources screen", "Unable to naviagte to Resources screen");
            reuse.TryCatchMethod(vmName, selectVM, "Selected VM", "Unable select VM");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            System.Threading.Thread.Sleep(5000);
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(updateWave,FillUpdateWaveDetails, "User is able to edit the details in Update Wave Page", "User is not able to edit the details in Update Wave Page");
            reuse.TryCatchMethod(ConfirmUpdate, "User is able to select Yes", "User is unable to select Yes");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        public void navigateToResources()
        {
            //System.Threading.Thread.Sleep(3000);
            var wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Resources']")));
            ManageUpdateWaves_ResourcesPage resources = new ManageUpdateWaves_ResourcesPage();
            common.Perform(resources.lnkresources, "click", "");

        }

        public void selectVM(String vmName)
        {
            System.Threading.Thread.Sleep(3000);
            ManageUpdateWaves_ResourcesPage resources = new ManageUpdateWaves_ResourcesPage();
            common.Perform(resources.lnksearch, "click", "");
            common.Perform(resources.tabsearch, "sendkeys", vmName);
            string VMXpath = "//em[text()='" + vmName + "']";
            IWebElement vmElement = Properties.driver.FindElement(By.XPath(VMXpath));
            common.Perform(vmElement, "click", "");
            common.Perform(resources.lnkmanageUpdateWave, "click", "");
            System.Threading.Thread.Sleep(10000);


        }

        public void FillUpdateWaveDetails(string updateWave)
        {
            System.Threading.Thread.Sleep(3000);
            ManageUpdateWaves_UpdateWavePage upWave = new ManageUpdateWaves_UpdateWavePage();

            common.Perform(upWave.ddlupdateWave, "click", "");
            clickElement(ManageUpdateWaves_UpdateWavePage.listupdateWave, updateWave);
        }

        public void ConfirmUpdate()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            DecomAppEnv_ConfirmationPage objConfirm = new DecomAppEnv_ConfirmationPage();
            WebDriverWait wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
            common.smallwait(); //common.smallwait(); common.smallwait();
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", objConfirm.btnYes);
            common.Perform(objConfirm.btnYes, "click", "");
            common.smallwait(); common.smallwait();
        }
    }
}
