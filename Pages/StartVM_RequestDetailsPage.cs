using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class StartVM_RequestDetailsPage
    {
        public StartVM_RequestDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//li[text()='Yes']")]
        public IWebElement btnYes;

        [FindsBy(How = How.XPath, Using = "//li[text()='No']")]
        public IWebElement btnNo;
    }
}
