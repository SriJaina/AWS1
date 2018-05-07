using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Data;

namespace Azure_Automation
{
    //[TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
        public void StartVM()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("StartVM");
            string VMName = ExcelMethods.GetValueOfHeader(ds, "VMName");
            #endregion
            BaseTest.test = BaseTest.extent.StartTest("Decommission Service Account");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(VMName, SelectVM, "VM Selected", "Unable to Select VM");
            reuse.TryCatchMethod(ClickStartVM, "Navigated to Start VM Page", "Unable to navigate to Start VM Page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Request Details page", "Unable to navigate to Request Details page");
           reuse.TryCatchMethod( SelectYes, "User is able to select yes to deallocate the VM", "User is able to select yes to deallocate the VM");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }
        public void ClickStartVM()
        {
            common.smallwait();
            ResourcesPage resObj = new ResourcesPage();
            common.Perform(resObj.btnStartVM, "click", "");
            common.smallwait();
        }
        public void SelectYes()
        {
            System.Threading.Thread.Sleep(10000);
            StartVM_RequestDetailsPage reqObj = new StartVM_RequestDetailsPage();
            common.Perform(reqObj.btnYes, "click", "");
            common.smallwait();
        }
    }
}
