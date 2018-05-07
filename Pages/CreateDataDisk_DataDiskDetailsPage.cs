using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateDataDisk_DataDiskDetailsPage
    {
        public CreateDataDisk_DataDiskDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string liststorageaccttype = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listdisksize = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[text()='Storage Account Type']/following-sibling::div//div//a")]
        public IWebElement ddlstorageaccttype { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='DISK SIZE']/following-sibling::div//div//a")]
        public IWebElement ddldisksize { get; set; }
    }
}
