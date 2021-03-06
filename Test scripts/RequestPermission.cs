﻿using System;
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
        public void RequestPermssion()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("RequestPermission");

            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            string appServName = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string envName = ExcelMethods.GetValueOfHeader(ds, "ApplicationEnvironment");
            string reason = ExcelMethods.GetValueOfHeader(ds, "Reason");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Create Application Service");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Request Permission to deploy resource on application environment'", "Unable select  'Request Permission to deploy resource on application environment'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Request Details screen", "Unable to navigate to Request Details screen");
            reuse.TryCatchMethod(appServName, envName, reason, RequestPermissionDetails, "User is able to fill details", "User is not able to fill all the details");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm screen", "Unable to navigate to Cpnfirm screen");
            reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        public void RequestPermissionDetails(string appServ, string appEnv, string reason)
        {
            common.smallwait();
            RequestPermissionPage reqObj = new RequestPermissionPage();
            common.Perform(reqObj.txtAppService, "sendkeys", appServ);
            common.Perform(reqObj.txtRequestOwner, "click", "");
            common.Perform(reqObj.txtAppEnv, "sendkeys", appEnv);
            common.Perform(reqObj.txtReasonforRequest, "sendkeys", reason);
        }
    }
}
