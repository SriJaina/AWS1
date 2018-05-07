using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Azure_Automation
{
    class DashboardPage
    {
        public DashboardPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//img[@title='All Items']")]
        public IWebElement divAllItems { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@title='Requests']")]
        public IWebElement divRequests { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@title='Activities']")]
        public IWebElement divActivities { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Resources']")]
        public IWebElement divResources { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'__fx-grid')]")]
        public IWebElement tblRequestGrid { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'__fx-grid')]//span[text()='Name']")]
        public IWebElement divNameHeaderColumn { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'__fx-grid')]//span[text()='Type']")]
        public IWebElement divTypeHeaderColumn { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'__fx-grid')]//span[text()='Status']")]
        public IWebElement divStatusHeaderColumn { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'__fx-grid')]//span[text()='Subscription']")]
        public IWebElement divSubscriptionHeaderColumn { get; set; }

        /*[FindsBy(How = How.XPath, Using = "//table[contains(@id,'__fx-grid')]//span[text()='Id']")]
        public IWebElement divIdHeaderColumn;*/
    }
}
