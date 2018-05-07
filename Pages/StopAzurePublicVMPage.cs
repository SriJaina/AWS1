using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class StopAzurePublicVMPage
    {
        public StopAzurePublicVMPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Stop Azure Public VM']")]
        public IWebElement lblPageHead;
    }
}
