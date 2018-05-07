using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class DecomAzureVM_EnvDetailsPage
    {
        public DecomAzureVM_EnvDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        #region multiple elements
        public static string listAppServ = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listAppServEnv = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[text()='Application Service']/following-sibling::div//div//a")]
        public IWebElement ddlappServ { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service Environment')]/following-sibling::div//div//a")]
        public IWebElement ddlappServEnv { get; set; }

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement lblPageHead;

        //[FindsBy(How = How.XPath, Using = "//label[text()='Application Service']/following-sibling::div//div//input[@type='text']")]
        //public IWebElement txtAppService;

        //[FindsBy(How = How.XPath, Using = "//label[text()='Application Service Environment']/following-sibling::div//div//input[@type='text']")]
        //public IWebElement txtAppEnv;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Request Owner']/following-sibling::textarea")]
        public IWebElement txtRequestOwner;
    }
}
