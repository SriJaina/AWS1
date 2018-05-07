using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class DecomAppEnv_ConfirmationPage
    {
        public DecomAppEnv_ConfirmationPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//li[text()='Yes']")]
        public IWebElement btnYes;

        [FindsBy(How = How.XPath, Using = "//li[text()='No']")]
        public IWebElement btnNo;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Validation')]/following-sibling::input[@readonly]")]
        public IWebElement txtValidation;
    }
}
