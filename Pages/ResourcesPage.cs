using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class ResourcesPage
    {
        public ResourcesPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//a[@title='Filter']//img")]
        public IWebElement icnSearch;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'searchcontainer')]//div//input")]
        public IWebElement txtSearchBox;

        [FindsBy(How = How.XPath, Using = "//div[text()='Stop VM']/preceding-sibling::div/div/img")]
        public IWebElement btnStopVM;

        [FindsBy(How = How.XPath, Using = "//div[text()='Start VM']")]
        public IWebElement btnStartVM;
        
    }
}
