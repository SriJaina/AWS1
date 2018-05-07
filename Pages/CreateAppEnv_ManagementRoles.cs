using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateAppEnv_ManagementRoles
    {
        public CreateAppEnv_ManagementRoles()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Deployment Manager(s)')]/following-sibling::input")]
        public IWebElement txtDeploymentManager;
    }
}
