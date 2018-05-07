using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Azure_Automation
{
    class OnboardVirtualVMs_AppEnvironmentDetailsPage
    {
        public OnboardVirtualVMs_AppEnvironmentDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Environment Type')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement ddlenvironmentType;

    }
}
