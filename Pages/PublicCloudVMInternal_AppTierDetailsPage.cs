using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class PublicCloudVMInternal_AppTierDetailsPage
    {
        public PublicCloudVMInternal_AppTierDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='App tier: Quantity']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtATQuantity;

        [FindsBy(How = How.XPath, Using = "//label[text()='App tier: Server Type']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtATServerType;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='App tier: Server Type Specification']/following-sibling::textarea")]
        public IWebElement txtATServerTypeSpecification;

    }
}
