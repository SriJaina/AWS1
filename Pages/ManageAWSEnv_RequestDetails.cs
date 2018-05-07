using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class ManageAWSEnv_RequestDetails
    {
        public ManageAWSEnv_RequestDetails()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        #region multiple elements
        public static string listAppServ = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li";
        public static string listawsAccount = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li";
        public static string listawsVPC = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li";
        public static string listawsEnv = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li";
        public static string listdataClassification = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li";

        #endregion


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service')]/following-sibling::div//div//a")]
        public IWebElement ddlAppServ;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'AWS Account')]/following-sibling::div//div//a")]
        public IWebElement ddlawsAccount;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'AWS VPC')]/following-sibling::div//div//a")]
        public IWebElement ddlawsVPC;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'AWS Environment')]/following-sibling::div//div//a")]
        public IWebElement ddlawsEnv;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Data Classification')]/following-sibling::div//div//a")]
        public IWebElement ddldataClassification;
    }
}
