using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
   
    class RemovePermissionPage
    {
        public RemovePermissionPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='Application Service']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtAppService;

        [FindsBy(How = How.XPath, Using = "//label[text()='Application Service Environment']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtAppEnv;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Request Owner']/following-sibling::input[@type='text']")]
        public IWebElement txtRequestOwner;

        [FindsBy(How = How.XPath, Using = "//label[text()='Reason for request']/following-sibling::textarea")]
        public IWebElement txtReasonforRequest;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='App Environment Validation']/following-sibling::input")]
        public IWebElement txtAppEnvValidation;
    }
}
