using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class ManageAppEnv_TechnicalInfoPage
    {
        public ManageAppEnv_TechnicalInfoPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Deployment Type')]/following-sibling::input[@type='text']")]
        public IWebElement txtDeploymentType;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Hosting Location')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtHostingLocation;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Web Tier Subnet Size')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtWebTierSize;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'APP Tier Subnet Size')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtAppTierSize;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Data Tier Subnet Size')]/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtDataTierSize;
    }
}
