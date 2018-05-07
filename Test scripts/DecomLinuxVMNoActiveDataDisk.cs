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
        public void DecomLinuxVMNoActiveDataDisk()
        {
            ExcelMethods em = new ExcelMethods();
            #region data Required
            String[] allSheet = ExcelMethods.getAllSheetName();
            DataSet ds = ExcelMethods.getDataSetForSheet("DecomLinuxVMNoActiveDataDisk");
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
            reuse.TryCatchMethod(appServ, appServEnv, FillDecomLinuxVMNoActiveDataDiskEnvironmentDetails, "User is able to fill details", "User is not able to fill all the details");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to VM Details screen", "Unable to navigate to VM Details screen");
            reuse.TryCatchMethod(servers, FillDecomLinuxVMNoActiveDataDiskEnvironmentDetails, "User is able to fill details", "User is not able to fill all the details");
            reuse.TryCatchMethod(DecomLinuxVMNoActiveDataDiskValidation, "No data disk is displayed", "No data disk is not displayed since the selected VM contains active data disk");
            reuse.TryCatchMethod(ConfirmDecom, "User is able to select Yes", "User is unable to select Yes");
            reuse.TryCatchMethod(reuse.moveToNextPage, "Navigated to next screen", "Unable to navigate to next screen");
            //reuse.TryCatchMethod(clickOnCompleteIcon, "Clicked on complete icon", "Unable to click on complete icon");

        }
        public void FillDecomLinuxVMNoActiveDataDiskEnvironmentDetails(string appServ, string appServEnv)
        {
            System.Threading.Thread.Sleep(3000);
            DecomAzureVM_EnvDetailsPage EnvDetails = new DecomAzureVM_EnvDetailsPage();
            common.Perform(EnvDetails.ddlappServ, "click", "");
            clickElement(DecomAzureVM_EnvDetailsPage.listAppServ, appServ);
            common.Perform(EnvDetails.ddlappServEnv, "click", "");
            clickElement(DecomAzureVM_EnvDetailsPage.listAppServEnv, appServEnv);

        }

        public void FillDecomLinuxVMNoActiveDataDiskEnvironmentDetails(string servers)
        {
            System.Threading.Thread.Sleep(3000);
            DecomAzureVM_VMDetailsPage VmDetails = new DecomAzureVM_VMDetailsPage();

            common.Perform(VmDetails.ddlservers, "click", "");
            clickElement(DecomAzureVM_VMDetailsPage.listservers, servers);
        }

        public void DecomLinuxVMNoActiveDataDiskValidation()
        {
            System.Threading.Thread.Sleep(8000);
            DecomAzureVM_VMDetailsPage VmDetails = new DecomAzureVM_VMDetailsPage();
            string actualmessage = (Properties.driver.FindElement(By.XPath("//textarea[@id='d7ef98ca-18fc-4efb-ad80-f47f91515520']"))).GetAttribute("value");
            if (VmDetails.txtAssociatedDataDisk.Displayed)
            {
                if (actualmessage.Equals("No DataDisk found"))
                {
                    BaseTest.test.Log(LogStatus.Pass, "Selected VM don't contain any active data disks");

                }
                else
                {
                    BaseTest.test.Log(LogStatus.Fail, "Selected VM contains active data disk");
                    NUnit.Framework.Assert.Fail();
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
