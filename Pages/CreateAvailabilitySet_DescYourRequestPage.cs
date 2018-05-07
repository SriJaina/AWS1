using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateAvailabilitySet_DescYourRequestPage
    {
        public CreateAvailabilitySet_DescYourRequestPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listAppServ = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li";
        public static string listAppServEnv = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listtier = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[text()='Application Service']/following-sibling::div//div//a")]
        public IWebElement ddlappServ { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service Environment')]/following-sibling::div//div//a")]
        public IWebElement ddlappServEnv { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Tier')]/following-sibling::div//div//a")]
        public IWebElement ddltier { get; set; }
    
}
}
