using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class SQLPaaS_EnvironmentDetails
    {
        public SQLPaaS_EnvironmentDetails()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='Application Service']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtAppService;

        [FindsBy(How = How.XPath, Using = "//label[text()='Application Service Environment']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtAppEnv;

        [FindsBy(How = How.XPath, Using = "//label[text()='Request Owner']/following-sibling::input[@type='text']")]
        public IWebElement txtRequestOwner;
    }
}
