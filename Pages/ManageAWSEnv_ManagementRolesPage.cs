using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{

    class ManageAWSEnv_ManagementRolesPage
    {
        public ManageAWSEnv_ManagementRolesPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }


        //[FindsBy(How = How.XPath, Using = "//label[contains(text(),'Users to be added')]/following-sibling::textarea")]
        [FindsBy(How = How.XPath, Using = "//textarea[@id='064790a1-a6e3-4d1e-987a-c4b20cdbc3f3' and @name='validation[064790a1-a6e3-4d1e-987a-c4b20cdbc3f3]' and @class='input-prompt fx-textbox fx-validation fx-editablecontrol']")]
        public IWebElement txtusersToBeAdded;

    }
}
