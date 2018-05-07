using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class OnboardAzureVMs_RequestDetailsPage
    {
        public OnboardAzureVMs_RequestDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listAzureSubscription = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listvnet = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listresourceGroup = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service')]/following-sibling::div//div//input[@type='text']")]
        //[FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service')]/following-sibling::div//div//a")]
        public IWebElement ddlappService;

        //[FindsBy(How = How.XPath, Using = "//label[contains(text(),'Azure Subscription')]/following-sibling::div//div//input[@type='text']")]
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Azure Subscription')]/following-sibling::div//div//a")]
        public IWebElement ddlazureSubscription;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'VNET')]/following-sibling::div//div//a")]
        public IWebElement ddlvnet;

        //[FindsBy(How = How.XPath, Using = "//label[contains(text(),'Resource Group')]/following-sibling::div//div//input[@type='text']")]
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Resource Group')]/following-sibling::div//div//a")]
        public IWebElement ddlresourceGroup;


    

    }
}
