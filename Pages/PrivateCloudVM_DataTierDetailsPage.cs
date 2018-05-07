using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class PrivateCloudVM_DataTierDetailsPage
    {
        public PrivateCloudVM_DataTierDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='Database tier: Quantity']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtDTQuantity;

        [FindsBy(How = How.XPath, Using = "//label[text()='Database tier: Server Type']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtDTServerType;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Database tier: Server Type Specification']/following-sibling::textarea")]
        public IWebElement txtDTServerTypeSpecification;

        [FindsBy(How = How.XPath, Using = "//label[text()='Database tier: How much storage is needed? [GB]']/following-sibling::input[@type='text']")]
        public IWebElement txtStorageNeeded;
    }
}
