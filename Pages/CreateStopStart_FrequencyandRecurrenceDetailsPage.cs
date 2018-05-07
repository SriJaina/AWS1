using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateStopStart_FrequencyandRecurrenceDetailsPage
    {
        public CreateStopStart_FrequencyandRecurrenceDetailsPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        #region multiple elements
        public static string listfrequency = "//ul[contains(@class,'dropdown_menu') and contains(@style,'display: block; visibility: visible')]/li";
        #endregion

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Frequency')]/following-sibling::div//div//a")]
        public IWebElement ddlfrequency { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='3fbb0e41-dc21-41b7-8bcc-2f332ef5a973']")]
        public IWebElement txtvmstarttime { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='e3ddef01-8fc5-433e-8615-7d7ed61e9ffd']")]
        public IWebElement txtvmstoptime { get; set; }
    }
}
