using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using RelevantCodes.ExtentReports;

namespace Azure_Automation
{
    //[TestClass]
    public partial class TestClass
    {
        [Test]
        [TestMethod]
        public void DecomWindowsVMActiveDataDisk()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("DecomWindowsVMActiveDataDisk");
            string offeringName = ExcelMethods.GetValueOfHeader(ds, "OfferingName");
            //Environment Details page
            string appServ = ExcelMethods.GetValueOfHeader(ds, "ApplicationService");
            string appServEnv = ExcelMethods.GetValueOfHeader(ds, "ApplicationServiceEnvironment");
            //VM Details page
            string servers = ExcelMethods.GetValueOfHeader(ds, "Servers");
            #endregion

            BaseTest.test = BaseTest.extent.StartTest("Decommission Azure Public Cloud VM");
            reuse.TryCatchMethod(reuse.LoginToWAP, "Logged in successfully", "Unable to login");
            reuse.TryCatchMethod(navigateToChooseOffering, "Navigated to Choose offering screen", "Unable to naviagte to Choose Offerings screen");
            reuse.TryCatchMethod(offeringName, SelectOfferings, "Selected 'Decommission Azure Public Cloud VM'", "Unable select  'Decommission Azure Public Cloud VM'");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to Environment Details screen", "Unable to navigate to Environment Details screen");
            reuse.TryCatchMethod(appServ, appServEnv, FillDecomWindowsVMActiveDataDiskEnvironmentDetails, "User is able to fill details", "User is not able to fill all the details");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to VM Details screen", "Unable to navigate to VM Details screen");
            reuse.TryCatchMethod(servers, FillDecomWindowsVMActiveDataDiskVMDetails, "User is able to fill details", "User is not able to fill all the details");
            reuse.TryCatchMethod(DecomWindowsVMActiveDataDiskValidation, "Available Data Disks are displayed", "Available data disks are not displayed");
            reuse.TryCatchMethod(ConfirmDecom, "User is able to select Yes", "User is unable to select Yes");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");

        }
        public void FillDecomWindowsVMActiveDataDiskEnvironmentDetails(string appServ, string appServEnv)
        {
            System.Threading.Thread.Sleep(3000);
            DecomAzureVM_EnvDetailsPage EnvDetails = new DecomAzureVM_EnvDetailsPage();
            common.Perform(EnvDetails.ddlappServ, "click", "");
            clickElement(DecomAzureVM_EnvDetailsPage.listAppServ, appServ);
            common.Perform(EnvDetails.ddlappServEnv, "click", "");
            clickElement(DecomAzureVM_EnvDetailsPage.listAppServEnv, appServEnv);

        }

        public void FillDecomWindowsVMActiveDataDiskVMDetails(string servers)
        {
            System.Threading.Thread.Sleep(3000);
            DecomAzureVM_VMDetailsPage VmDetails = new DecomAzureVM_VMDetailsPage();

            common.Perform(VmDetails.ddlservers, "click", "");
            clickElement(DecomAzureVM_VMDetailsPage.listservers, servers);
        }

        public void DecomWindowsVMActiveDataDiskValidation()
        {
            System.Threading.Thread.Sleep(8000);
            string actualmessage = (Properties.driver.FindElement(By.XPath("//textarea[@id='d7ef98ca-18fc-4efb-ad80-f47f91515520']"))).GetAttribute("value");
            DecomAzureVM_VMDetailsPage VmDetails = new DecomAzureVM_VMDetailsPage();
           
            if (VmDetails.txtAssociatedDataDisk.Displayed)
            {
                if (actualmessage.Equals("No DataDisk found"))
                {
                    BaseTest.test.Log(LogStatus.Fail, "Active Data Disks for the selected VM are not displayed");
                    NUnit.Framework.Assert.Fail();

                }
                else
                {
                    BaseTest.test.Log(LogStatus.Pass, actualmessage);

                }

            }
            else
            {
                BaseTest.test.Log(LogStatus.Fail, "Associated Data Disk field is not displayed");
                NUnit.Framework.Assert.Fail();

            }


        }
       





    }
}
