using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class ManageAppEnv_AppEnvDetailsPage
    {
        public ManageAppEnv_AppEnvDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement txtPageHead;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtAppService;

        //Old Env
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service Environment')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtAppEnv;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Request Owner')]/following-sibling::input[@type='text']")]
        public IWebElement txtRequestOwner;

        //New Env
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service Environment Name')]/following-sibling::input[@type='text']")]
        public IWebElement txtAppEnvName;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Environment Type')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtEnvType;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Data Classification')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtDataClassification;
    }
}
