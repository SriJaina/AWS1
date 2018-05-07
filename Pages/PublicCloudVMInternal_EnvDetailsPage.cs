using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class PublicCloudVMInternal_EnvDetailsPage
    {
        public PublicCloudVMInternal_EnvDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='Application Service']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtAppService;

        [FindsBy(How = How.XPath, Using = "//label[text()='Application Environment']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtAppEnv;

        [FindsBy(How = How.XPath, Using = "//label[text()='Request Owner']/following-sibling::input[@type='text']")]
        public IWebElement txtRequestOwner;

        [FindsBy(How = How.XPath, Using = "//label[text()='OS Family']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtOSFamily;
    }
}
