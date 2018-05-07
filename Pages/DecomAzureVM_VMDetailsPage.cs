using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    class DecomAzureVM_VMDetailsPage
    {
        public DecomAzureVM_VMDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        #region multiple elements
        public static string listservers = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement lblPageHead;

        [FindsBy(How = How.XPath, Using = "//label[text()='VM Data Retention']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtVMDataRetention;

        [FindsBy(How = How.XPath, Using = "//label[text()='Servers']/following-sibling::div//div//a")]
        public IWebElement ddlservers;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Retrieved Resource Group']/following-sibling::input[@type='text']")]
        public IWebElement txtRetrivedResourceGroup;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Retrieved Location']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtRetrivedLocation;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Retrieved Environment Type']/following-sibling::div//div//input[@type='text']")]
        public IWebElement txtRetrievedEnvType;

        //Readonly
        [FindsBy(How = How.XPath, Using = "//label[text()='Archive Storage Account']/following-sibling::input[@type='text']")]
        public IWebElement txtArchiveStorageAccount;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Confirm')]/following-sibling::div/ul/li[text()='Yes']")]
        public IWebElement btnConfirm_Yes;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Confirm')]/following-sibling::div/ul/li[text()='No']")]
        public IWebElement btnConfirm_No;

        [FindsBy(How = How.XPath, Using = "//label[text()='Validation']/following-sibling::input[@type='text']")]
        public IWebElement txtValidation;

        [FindsBy(How = How.XPath, Using = "//textarea[@id='d7ef98ca-18fc-4efb-ad80-f47f91515520']")]
        public IWebElement txtAssociatedDataDisk;



    }
}
