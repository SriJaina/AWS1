using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
   
    class ManageAWSEnv_BillingInformationPage
    {
        public ManageAWSEnv_BillingInformationPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//label[text()='Billing Territory']")]
        public IWebElement lblBillingInformation;

    }
}
