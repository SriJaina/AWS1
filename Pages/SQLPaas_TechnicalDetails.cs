using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class SQLPaas_TechnicalDetails
    {
        public SQLPaas_TechnicalDetails()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='Database Instances: Quantity']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtDBInstanceQty;

        [FindsBy(How = How.XPath, Using = "//label[text()='Database Pricing Tier']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtDBPricingTier;

        [FindsBy(How = How.XPath, Using = "//label[text()='SQL SERVER ADMINISTRATOR']/following-sibling::input[@type='text']")]
        public IWebElement txtServerAdmin;

        [FindsBy(How = How.XPath, Using = "//label[text()='SQL SERVER ADMINISTRATOR PASSWORD']/following-sibling::input")]
        public IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//label[text()='CONFIRM SQL SERVER ADMINISTRATOR PASSWORD']/following-sibling::input")]
        public IWebElement txtConfirmPassword;
    }
}
