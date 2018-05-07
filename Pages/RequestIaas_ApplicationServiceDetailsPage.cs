using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class RequestIaas_ApplicationServiceDetailsPage
    {
        public RequestIaas_ApplicationServiceDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listlos = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "//input[@id='9e673c23-ec25-4cbb-8be4-2bd84803ff87']")]
        public IWebElement txtappServName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='5cea82e0-669b-4bbe-b405-9d45fdbaf21b']")]
        public IWebElement txtappOwner { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='9c6415e6-51ce-4750-a44f-726bde1751eb']")]
        public IWebElement txttechContact { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Line of Service')]/following-sibling::div//div//a")]
        public IWebElement ddllos { get; set; }
    }
}
