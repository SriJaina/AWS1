using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class ManageAppEnv_ManagementRolesPage
    {
        public ManageAppEnv_ManagementRolesPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Current Deployment Manager(s)')]/following-sibling::textarea")]
        public IWebElement txtCurrentDepManagers;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Add Deployment Manager(s)')]/following-sibling::textarea")]
        public IWebElement txtAddDepManagers;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Remove Deployment Manager(s)')]/following-sibling::textarea")]
        public IWebElement txtRemoveDepManagers;
    }
}
