using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class ManageServiceAccount_OperationPage
    {
        public ManageServiceAccount_OperationPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//p[contains(text(),' Create Azure Request ')])[2]")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='Service Account']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtServiceAccount;

        [FindsBy(How = How.XPath, Using = "//label[text()='Operation']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtOperation;

        //Password Reset
        [FindsBy(How = How.XPath, Using = "//label[text()='Password']/following-sibling::input[@type='password']")]
        public IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//label[text()='Confirm Password']/following-sibling::input[@type='password']")]
        public IWebElement txtConfirmPassword;

        //common
        [FindsBy(How = How.XPath, Using = "//li[text()='Yes']")]
        public IWebElement btnYes;

        [FindsBy(How = How.XPath, Using = "//li[text()='No']")]
        public IWebElement btnNo;

        [FindsBy(How = How.XPath, Using = "//label[text()='Validation']/following-sibling::input[@type='text']")]
        public IWebElement txtValidation;
    }
}
