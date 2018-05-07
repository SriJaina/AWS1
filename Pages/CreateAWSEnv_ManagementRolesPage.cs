using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateAWSEnv_ManagementRolesPage
    {
        public CreateAWSEnv_ManagementRolesPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Deployment Managers')]/following-sibling::textarea")]
        public IWebElement txtDepManagers;

    }
}
