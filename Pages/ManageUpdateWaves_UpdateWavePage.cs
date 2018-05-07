using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{

    class ManageUpdateWaves_UpdateWavePage
    {
        public ManageUpdateWaves_UpdateWavePage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        #region multiple elements
        public static string listupdateWave = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[text()='Update Wave']/following-sibling::div//div//a")]
        public IWebElement ddlupdateWave { get; set; }
    }

 }
