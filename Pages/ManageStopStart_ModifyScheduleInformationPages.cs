using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class ManageStopStart_ModifyScheduleInformationPages
    {
        public ManageStopStart_ModifyScheduleInformationPages()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        
    
        [FindsBy(How = How.XPath, Using = "//input[@id='2e07e85a-c1f4-4342-8f53-0bdc66c6b70c']")]
        public IWebElement txtschstartdate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='7ffebcb7-98e2-429d-8121-79d35f944923']")]
        public IWebElement txtschexpirydate { get; set; }

    }
}
