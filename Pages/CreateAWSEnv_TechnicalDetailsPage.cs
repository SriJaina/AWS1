using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Azure_Automation
{
   
    class CreateAWSEnv_TechnicalDetailsPage
    {
        public CreateAWSEnv_TechnicalDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Do you want to deploy APP TIER?')]/following-sibling::div/ul/li")]
        public IWebElement btnYesAppTier;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'internal Load Balancer')]/following-sibling::div/ul/li")]
        public IWebElement btnYesLoadBal;

    }
}

