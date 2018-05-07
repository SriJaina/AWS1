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
        public void CreateStopStartSchedule()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("CreateStopStartSchedule");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Schedule Details page1
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string timeVariable = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string schedulename = "Schedule_" + timeVariable;
            //Schedule Details page2
            string timezone = ExcelMethods.GetValueOfHeader(ds, "TimeZone");
            string schstartdate = DateTime.Now.ToString("MM/dd/yyyy");
            DateTime date = DateTime.Now.AddDays(6);
            string schexpirydate = date.ToString("MM/dd/yyyy");
            //Frequency and Recurrence Details page
            string frequency = ExcelMethods.GetValueOfHeader(ds, "Frequency");
            string vmstarttime = DateTime.Now.TimeOfDay.ToString("hh\\:mm");
            TimeSpan span = TimeSpan.FromHours(16);
            DateTime time = DateTime.Today + span;
            string vmstoptime = time.ToString("hh:mm");
            //Status and Validation page
            string schedulestatus = ExcelMethods.GetValueOfHeader(ds, "ScheduleStatus");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Create Stop/Start Schedule");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Create Application Service Environment Offering'", "Unable select  'Create Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, schedulename, FillSchedule1Details, "Schedule Details page1 loaded", "Failed to load Schedule Details page1");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(timezone, schstartdate, schexpirydate, FillSchedule2Details, "Schedule Details page2 loaded", "Failed to load Schedule Details page2");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(frequency, vmstarttime, vmstoptime, FillFreqandRecDetails, "Frequency and Recurrence Details page loaded", "Failed to load Frequency and Recurrence Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(schedulestatus, FillStatusandValidationDetails, "Status and Validation page loaded", "Failed to load Status and Validation page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        [Test]
        [TestMethod]
        public void ManageStopStartSchedule()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("ManageStopStartSchedule");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Manage Schedule Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string schedule= ExcelMethods.GetValueOfHeader(ds, "Schedule");
            //Modify Schedule Information page
            string schstartdate = DateTime.Now.ToString("MM/dd/yyyy");
            DateTime date = DateTime.Now.AddDays(6);
            string schexpirydate = date.ToString("MM/dd/yyyy");

            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Manage Stop/Start Schedule");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Manage Application Service Environment Offering'", "Unable select  'Manage Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, schedule, ManageScheduleDetails, "User is able to edit the details in Manage Schedule Details page", "User is not able to edit the details in  Manage Schedule Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Modify Schedule Information page", "Unable to navigate to Modify Schedule Information Page");
            reuse.TryCatchMethod(schstartdate, schexpirydate, FillModifyScheduleInformation, "Modify Schedule Information page loaded", "Failed to load Modify Schedule Information page");
            System.Threading.Thread.Sleep(3000);
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Frequency and Recurrence Details page", "Unable to navigate to Frequency and Recurrence Details page");
            System.Threading.Thread.Sleep(3000);
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to VMs and Status page", "Unable to navigate to VMs and Status page");
            System.Threading.Thread.Sleep(3000);
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        [Test]
        [TestMethod]
        public void DeleteStopStartSchedule()
        {
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("DeleteStopStartSchedule");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Schedule Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string schedule = ExcelMethods.GetValueOfHeader(ds, "Schedule");
            #endregion
            BaseTest.test = BaseTest.extent.StartTest("Delete Stop/Start Schedule");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Manage Application Service Environment Offering'", "Unable select  'Manage Application Service Environment Offering'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, schedule, FillDelScheduleDetails, "User is able to edit the details in Schedule Details page", "User is not able to edit the details in Manage Schedule Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirmation page", "Unable to navigate to Confirmation page");
            reuse.TryCatchMethod(ConfirmDecom, "User is able to select Yes to Decommission the environment", "User is able to select Yes to Decommission the environment");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Confirm page", "Unable to navigate to Confirm page");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }



        public void FillSchedule1Details(string appServ, string appServEnv, string schedulename)
        {
            System.Threading.Thread.Sleep(3000);
            CreateStopStart_ScheduleDetails ScheduleDetails = new CreateStopStart_ScheduleDetails();

            common.Perform(ScheduleDetails.ddlappServ, "click", "");
            clickElement(CreateStopStart_ScheduleDetails.listAppServ, appServ);
            common.Perform(ScheduleDetails.ddlappServEnv, "click", "");
            clickElement(CreateStopStart_ScheduleDetails.listAppServEnv, appServEnv);
            common.Perform(ScheduleDetails.txtschedulename, "sendkeys", schedulename);
        }
        public void FillSchedule2Details(string timezone, string schstartdate, string schexpirydate)
        {
            System.Threading.Thread.Sleep(3000);
            CreateStopStart_ScheduleDetails ScheduleDetails = new CreateStopStart_ScheduleDetails();
            common.Perform(ScheduleDetails.ddltimezone, "click", "");
            clickElement(CreateStopStart_ScheduleDetails.listtimezone, timezone);
            common.Perform(ScheduleDetails.txtschstartdate, "sendkeys", schstartdate);
            common.Perform(ScheduleDetails.txtschexpirydate, "sendkeys", schexpirydate);
        }
        public void FillFreqandRecDetails(string frequency, string vmstarttime, string vmstoptime)
        {
            System.Threading.Thread.Sleep(3000);
            CreateStopStart_FrequencyandRecurrenceDetailsPage FreqandRec = new CreateStopStart_FrequencyandRecurrenceDetailsPage();
            common.Perform(FreqandRec.ddlfrequency, "click", "");
            clickElement(CreateStopStart_FrequencyandRecurrenceDetailsPage.listfrequency, frequency);
            common.Perform(FreqandRec.txtvmstarttime, "sendkeys", vmstarttime);
            common.Perform(FreqandRec.txtvmstoptime, "sendkeys", vmstoptime);
        }
        public void FillStatusandValidationDetails(string schedulestatus)
        {
            System.Threading.Thread.Sleep(3000);
            CreateStopStart_StatusandValidationPage StatusandVal = new CreateStopStart_StatusandValidationPage();
            common.Perform(StatusandVal.ddlschedulestatus, "click", "");
            clickElement(CreateStopStart_StatusandValidationPage.listschedulestatus, schedulestatus);
            
        }
        public void FillDelScheduleDetails(string appServ, string appServEnv, string schedule)
        {
            System.Threading.Thread.Sleep(3000);
            DeleteStopStart_ScheduleDetails ScheduleDetails = new DeleteStopStart_ScheduleDetails();

            common.Perform(ScheduleDetails.ddlappServ, "click", "");
            clickElement(DeleteStopStart_ScheduleDetails.listAppServ, appServ);
            common.Perform(ScheduleDetails.ddlappServEnv, "click", "");
            clickElement(DeleteStopStart_ScheduleDetails.listAppServEnv, appServEnv);
            common.Perform(ScheduleDetails.ddlschedule, "click", "");
            clickElement(DeleteStopStart_ScheduleDetails.listschedule, schedule);


        }

        public void ManageScheduleDetails(string appServ, string appServEnv, string schedule)
        {
            System.Threading.Thread.Sleep(3000);
            ManageStopStart_ManageSchDetailsPage ScheduleDetails = new ManageStopStart_ManageSchDetailsPage();

            common.Perform(ScheduleDetails.ddlappServ, "click", "");
            clickElement(ManageStopStart_ManageSchDetailsPage.listAppServ, appServ);
            common.Perform(ScheduleDetails.ddlappServEnv, "click", "");
            clickElement(ManageStopStart_ManageSchDetailsPage.listAppServEnv, appServEnv);
            common.Perform(ScheduleDetails.ddlschedule, "click", "");
            clickElement(ManageStopStart_ManageSchDetailsPage.listschedule, schedule);

            
        }

        public void FillModifyScheduleInformation(string schstartdate, string schexpirydate)
        {
            System.Threading.Thread.Sleep(3000);
            ManageStopStart_ModifyScheduleInformationPages ScheduleDetails = new ManageStopStart_ModifyScheduleInformationPages();

            common.Perform(ScheduleDetails.txtschstartdate, "clear", "");
            common.Perform(ScheduleDetails.txtschstartdate, "sendkeys", schstartdate);
            common.Perform(ScheduleDetails.txtschexpirydate, "clear", "");
            common.Perform(ScheduleDetails.txtschexpirydate, "sendkeys", schexpirydate);
        }


    }
}
