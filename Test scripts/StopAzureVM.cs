using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Data;
using OpenQA.Selenium;

namespace Azure_Automation
{
    //[TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
        public void StopVM()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("StopVM");
            string VMName = ExcelMethods.GetValueOfHeader(ds, "VMName");
            string stopTime  = DateTime.Now.ToString("HH:mm");
            #endregion
            BaseTest.test = BaseTest.extent.StartTest("Decommission Service Account");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(VMName, SelectVM, "VM Selected", "Unable to Select VM");
            reuse.TryCatchMethod(ClickStopVM, "Navigated to Stop VM Page", "Unable to navigate to Stop VM Page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Request Details page", "Unable to navigate to Request Details page");
            reuse.TryCatchMethod(stopTime,FillDetails, "User is able to fill details in Request Details page", "User is able to fill details in Request Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }
        public void SelectVM(string VMName)
        {
            System.Threading.Thread.Sleep(15000);
            DashboardPage dpObj = new DashboardPage();
            common.Perform(dpObj.divResources, "click", "");
            common.smallwait();
            ResourcesPage resObj = new ResourcesPage();
            common.Perform(resObj.icnSearch, "click", "");
            common.Perform(resObj.txtSearchBox, "sendkeys", VMName);
            common.smallwait();
        }
        public void ClickStopVM()
        {
            ResourcesPage resObj = new ResourcesPage();
            common.Perform(resObj.btnStopVM, "click", "");
            common.smallwait();
        }

        public void FillDetails(string time)
        {
            StopVM_RequestDetailsPage reqObj = new StopVM_RequestDetailsPage();
            common.Perform(reqObj.icnCalender, "click", "");
            common.Perform(reqObj.btnRestartDate, "click", "");
            common.Perform(reqObj.txtRestartTime, "sendkeys", time);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            js.ExecuteScript("arguments[0].click()", reqObj.btnYes);
           
        }
    }
}
