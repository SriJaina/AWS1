using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class PrivateCloudVM_ValidationPage
    {
        public PrivateCloudVM_ValidationPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Form Validation']/following-sibling::textarea")]
        public IWebElement txtFormValidation;

        [FindsBy(How = How.XPath, Using = "//label[text()='Important Information']/following-sibling::textarea")]
        public IWebElement txtImpInfo;

        [FindsBy(How = How.XPath, Using = "//label[text()='Next']/following-sibling::textarea")]
        public IWebElement txtNext;
    }
}
