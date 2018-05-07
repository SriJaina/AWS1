using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateAzureLoadBalancer_LoadBalancerDetailsPage
    {
        public CreateAzureLoadBalancer_LoadBalancerDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listavailabilitySet = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listport = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listsessionPersistence = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[text()='Availability Set']/following-sibling::div//div//a")]
        public IWebElement ddlavailabilitySet { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Port')]/following-sibling::div//div//a")]
        public IWebElement ddlport { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Session Persistence')]/following-sibling::div//div//a")]
        public IWebElement ddlsessionPersistence { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea[@id='388ab941-7a85-4f54-8b49-aff65b8c2cd8']")]
        public IWebElement txtvmsToBeAdded { get; set; }
    }
    
}
