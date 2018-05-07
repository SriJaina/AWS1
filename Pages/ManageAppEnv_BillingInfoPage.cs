using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class ManageAppEnv_BillingInfoPage
    {
   
        public ManageAppEnv_BillingInfoPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Billing Territory')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtBillingTerritory;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'CHARGE CODE (WBS CODE)')]/following-sibling::input[@type='text']")]
        public IWebElement txtChargeCode;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Partner/Sponsor')]/following-sibling::input[@type='text']")]
        public IWebElement txtPartner;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'HYCS Service Type')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtServiceType;
    }
}
