using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class CreateAppEnv_ApplicationEnvironmentDetailsPage
    {
        public CreateAppEnv_ApplicationEnvironmentDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        #region multiple elements
        public static string ddls = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li";
        public static string listDataClassification = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listEnvironmentType = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion
        //[FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add Deliverable')]")]
        // public IWebElement lnkAddDeliverable { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement txtPageHead;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service')]/following-sibling::div//div//a")]
        public IWebElement ddlApplicationService;

       // [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li")]
       // public List<IWebElement> listApplicationServices; 

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Request Owner')]/following-sibling::input")]
        public IWebElement txtRequestOwner;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service Environment Name')]/following-sibling::input")]
        public IWebElement txtApplicationServiceEnvironmentName;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Environment Type')]/following-sibling::div//div//a")]
        public IWebElement ddlEnvironmentType;

       

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Data Classification')]/following-sibling::div/div/a")]
        public IWebElement ddlDataClassification;

        
    }
}
