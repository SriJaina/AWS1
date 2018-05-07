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
        public void CreateDataDisk()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("CreateDataDisk");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Request Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string virtualmachine = ExcelMethods.GetValueOfHeader(ds, "VirtualMachine");
            //Data Disk Details page
            string storageaccttype = ExcelMethods.GetValueOfHeader(ds, "StorageAccountType");
            string disksize = ExcelMethods.GetValueOfHeader(ds, "DiskSize");
            #endregion


            BaseTest.test = BaseTest.extent.StartTest("Create Data Disk");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected Create Data Disk Offering", "Unable select Create Data Disk Offering");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, virtualmachine, FillCreateDataDiskRequestDetails, "Request Details page loaded", "Failed to load Request Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(storageaccttype, disksize, FillCreateDataDiskDataDiskDetails, "Data Disk Details page loaded", "Failed to load Data Disk Details page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");


        }

        [Test]
        [TestMethod]
        public void ManageDataDisk()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("ManageDataDisk");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Request Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string virtualmachine = ExcelMethods.GetValueOfHeader(ds, "VirtualMachine");
            string datadisk = ExcelMethods.GetValueOfHeader(ds, "DataDisk");
            //Data Disk Details page
            string disksize = ExcelMethods.GetValueOfHeader(ds, "DiskSize");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Manage Data Disk");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected Manage Data Disk Offering", "Unable select Manage Data Disk Offering");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, virtualmachine, datadisk, FillManageDataDiskRequestDetails, "User is able to edit the details in Request Details Page", "User is not able to edit the details in Request Details Page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(disksize, FillManageDataDiskDataDiskDetails, "User is able to edit the details in Data Disk Details Page", "User is not able to edit the details in Data Disk Details Page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        [Test]
        [TestMethod]
        public void DeleteDataDisk()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("DeleteDataDisk");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Request Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            string virtualmachine = ExcelMethods.GetValueOfHeader(ds, "VirtualMachine");
            string datadisk = ExcelMethods.GetValueOfHeader(ds, "DataDisk");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Delete Data Disk");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected Delete Data Disk Offering", "Unable select Delete Data Disk Offering");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(appServ, appServEnv, virtualmachine, datadisk, FillDeleteDataDiskRequestDetails, "User is able to edit the details in Request Details Page", "User is not able to edit the details in Request Details Page");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            reuse.TryCatchMethod(ConfirmDecom, "User is able to select Yes to Delete this data disk", "User is able to select Yes to Delete this data disk");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");
        }

        public void FillCreateDataDiskRequestDetails(string appServ, string appServEnv, string virtualmachine)
        {
            System.Threading.Thread.Sleep(3000);
            CreateDataDisk_RequestDetailsPage RequestDetails = new CreateDataDisk_RequestDetailsPage();

            common.Perform(RequestDetails.ddlappServ, "click", "");
            clickElement(CreateDataDisk_RequestDetailsPage.listAppServ, appServ);
            common.Perform(RequestDetails.ddlappServEnv, "click", "");
            clickElement(CreateDataDisk_RequestDetailsPage.listAppServEnv, appServEnv);
            common.Perform(RequestDetails.ddlvirtualmachine, "click", "");
            clickElement(CreateDataDisk_RequestDetailsPage.listvirtualmachine, virtualmachine);
            System.Threading.Thread.Sleep(8000);
        }
        public void FillCreateDataDiskDataDiskDetails(string storageaccttype, string disksize)
        {
            System.Threading.Thread.Sleep(3000);
            CreateDataDisk_DataDiskDetailsPage DataDiskDetails = new CreateDataDisk_DataDiskDetailsPage();
    
            common.Perform(DataDiskDetails.ddlstorageaccttype, "click", "");
            clickElement(CreateDataDisk_DataDiskDetailsPage.liststorageaccttype, storageaccttype);
            common.Perform(DataDiskDetails.ddldisksize, "click", "");
            clickElement(CreateDataDisk_DataDiskDetailsPage.listdisksize, disksize);
        }

        public void FillManageDataDiskRequestDetails(string appServ, string appServEnv, string virtualmachine, string datadisk)
        {
            System.Threading.Thread.Sleep(3000);
            ManageDataDisk_RequestDetailsPage RequestDetails = new ManageDataDisk_RequestDetailsPage();

            common.Perform(RequestDetails.ddlappServ, "click", "");
            clickElement(ManageDataDisk_RequestDetailsPage.listAppServ, appServ);
            common.Perform(RequestDetails.ddlappServEnv, "click", "");
            clickElement(ManageDataDisk_RequestDetailsPage.listAppServEnv, appServEnv);
            common.Perform(RequestDetails.ddlvirtualmachine, "click", "");
            clickElement(ManageDataDisk_RequestDetailsPage.listvirtualmachine, virtualmachine);
            common.Perform(RequestDetails.ddldatadisk, "click", "");
            clickElement(ManageDataDisk_RequestDetailsPage.listdatadisk, datadisk);
         }

        public void FillManageDataDiskDataDiskDetails(string disksize)
        {
            System.Threading.Thread.Sleep(3000);
            ManageDataDisk_DataDiskDetailsPage DataDiskDetails = new ManageDataDisk_DataDiskDetailsPage();

            common.Perform(DataDiskDetails.ddldisksize, "click", "");
            clickElement(ManageDataDisk_DataDiskDetailsPage.listdisksize, disksize);
        }

        public void FillDeleteDataDiskRequestDetails(string appServ, string appServEnv, string virtualmachine, string datadisk)
        {
            System.Threading.Thread.Sleep(3000);
            DeleteDataDisk_RequestDetailsPage RequestDetails = new DeleteDataDisk_RequestDetailsPage();

            common.Perform(RequestDetails.ddlappServ, "click", "");
            clickElement(DeleteDataDisk_RequestDetailsPage.listAppServ, appServ);
            common.Perform(RequestDetails.ddlappServEnv, "click", "");
            clickElement(DeleteDataDisk_RequestDetailsPage.listAppServEnv, appServEnv);
            common.Perform(RequestDetails.ddlvirtualmachine, "click", "");
            clickElement(DeleteDataDisk_RequestDetailsPage.listvirtualmachine, virtualmachine);
            common.Perform(RequestDetails.ddldatadisk, "click", "");
            clickElement(DeleteDataDisk_RequestDetailsPage.listdatadisk, datadisk);
        }
    }
}
