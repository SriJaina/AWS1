using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class DecomAppEnv_AppEnvDetailsPage
    {
        public DecomAppEnv_AppEnvDetailsPage()
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

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Application Environment Validation']/following-sibling::textarea")]
        public IWebElement txtAppEnvValidation;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//p[text()=' Create Cloud Request ']/following-sibling::p[@class='aux-dialogSubHeader']")]
        public IWebElement txtPageHeader;

        
    }
}
