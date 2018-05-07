using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class CreateServiceAccount_ServiceAccountDetails
    {
        public CreateServiceAccount_ServiceAccountDetails()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='APPLICATION ENVIRONMENT TYPE']/following-sibling::input[@type='text']")]
        public IWebElement txtAppEnvType;

        [FindsBy(How = How.XPath, Using = "//label[text()='TYPE OF ACCOUNT']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtTypeofAccount;

        [FindsBy(How = How.XPath, Using = "//label[text()='SHORT NAME']/following-sibling::input[@type='text']")]
        public IWebElement txtShortName;

        [FindsBy(How = How.XPath, Using = "//label[text()='ENTER PASSWORD']/following-sibling::input[@type='password']")]
        public IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//label[text()='CONFIRM PASSWORD']/following-sibling::input[@type='password']")]
        public IWebElement txtConfirmPassword;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='SERVICE ACCOUNT NAME']/following-sibling::input[@type='text']")]
        public IWebElement txtServiceAccountName;
    }


}
