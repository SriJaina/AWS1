using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateStopStart_ScheduleDetails
    {
        public CreateStopStart_ScheduleDetails()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listAppServ = "//ul[contains(@class,'dropdown_menu') and contains(@style,'visible')]/li";
        public static string listAppServEnv = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        public static string listtimezone = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service')]/following-sibling::div//div//a")]
        public IWebElement ddlappServ { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service Environment')]/following-sibling::div//div//a")]
        public IWebElement ddlappServEnv { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='c95a75e5-4489-4b6e-a0ac-888932e300ed']")]
        public IWebElement txtschedulename { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Time Zone')]/following-sibling::div//div//a")]
        public IWebElement ddltimezone { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='cfd75f2d-bbc1-413a-b9db-51af3ae06f36']")]
        public IWebElement txtschstartdate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='a416d4bb-e085-4f11-9973-fd7d618baca3']")]
        public IWebElement txtschexpirydate { get; set; }



    }
}
