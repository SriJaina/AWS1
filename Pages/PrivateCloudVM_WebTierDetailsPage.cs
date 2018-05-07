using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class PrivateCloudVM_WebTierDetailsPage
    {
        public PrivateCloudVM_WebTierDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='Web tier: Quantity']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtWTQuantity;

        [FindsBy(How = How.XPath, Using = "//label[text()='Web tier: Server Type']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtWTServerType;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Web tier: Server Type Specification']/following-sibling::textarea")]
        public IWebElement txtWTServerTypeSpecification;
    }
}
