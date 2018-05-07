using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class ManageDataDisk_DataDiskDetailsPage
    {
        public ManageDataDisk_DataDiskDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listdisksize = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        
        [FindsBy(How = How.XPath, Using = "//label[text()='DISK SIZE']/following-sibling::div//div//a")]
        public IWebElement ddldisksize { get; set; }
    }
}
