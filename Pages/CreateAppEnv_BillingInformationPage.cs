using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class CreateAppEnv_BillingInformationPage
    {
        public CreateAppEnv_BillingInformationPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements

        #endregion
        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Billing Territory')]/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtBillingTerritory;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'CHARGE CODE (WBS CODE)')]/following-sibling::input")]
        public IWebElement txtChargeCode;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Partner/Sponsor')]/following-sibling::input")]
        public IWebElement txtPartner;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'HYCS Service Type')]/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtEnvManagedOrSelfManaged;
        
        ////label[contains(text(),'Is This Environment Managed or Self-Managed?')]/following-sibling::div/div/input[@type='text']
        

    }
}
