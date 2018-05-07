using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class RequestIaas_AppEnvironmentDetailsPage
    {
        public RequestIaas_AppEnvironmentDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listdataclassification = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listhostingloc = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Data Classification')]/following-sibling::div//div//a")]
        public IWebElement ddldataclassification { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Hosting Location')]/following-sibling::div//div//a")]
        public IWebElement ddlhostingloc { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Billing Territory')]/following-sibling::div//div//input[@class='list-picker-value fx-validation fx-textbox fx-editablecontrol']")]
        public IWebElement ddlbillterritory { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='9a535224-9a3d-4583-9adf-b58d396adaf7']")]
        public IWebElement txtchargeCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='7c8981a7-0fd8-4a79-a603-a90308bb3fd0']")]
        public IWebElement txtpartner { get; set; }
    }
}
