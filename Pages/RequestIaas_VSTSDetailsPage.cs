using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class RequestIaas_VSTSDetailsPage
    {
        public RequestIaas_VSTSDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listvstsact = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li";
        public static string listvstsprotemplate = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'VSTS Account')]/following-sibling::div//div//a")]
        public IWebElement ddlvstsact { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'VSTS Process Template')]/following-sibling::div//div//a")]
        public IWebElement ddlvstsprotemplate { get; set; }
    }
}
