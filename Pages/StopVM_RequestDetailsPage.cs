using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class StopVM_RequestDetailsPage
    {
        public StopVM_RequestDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='Restart Date']/following::div[@class='date-calendar']//span")]
        public IWebElement icnCalender;

        [FindsBy(How = How.XPath, Using = "(//a[contains(@class,'ui-state-default')]/parent::td)[1]")]
        public IWebElement btnRestartDate;

        [FindsBy(How = How.XPath, Using = "//label[text()='Restart Time']/following-sibling::input")]
        public IWebElement txtRestartTime;

        [FindsBy(How = How.XPath, Using = "//li[text()='Yes']//input")]
        public IWebElement btnYes;

        [FindsBy(How = How.XPath, Using = "//li[text()='No']//input")]
        public IWebElement btnNo;
    }
}
