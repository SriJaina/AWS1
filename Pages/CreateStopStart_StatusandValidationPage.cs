using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateStopStart_StatusandValidationPage
    {
        public CreateStopStart_StatusandValidationPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listschedulestatus = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Schedule Status')]/following-sibling::div//div//a")]
        public IWebElement ddlschedulestatus { get; set; }

    }
}
