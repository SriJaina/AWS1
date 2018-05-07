using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class RequestIaas_SelSubscription
    {
        public RequestIaas_SelSubscription()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        
       
        [FindsBy(How = How.XPath, Using = "//select[@id='subscriptionSelect']")]
        public IWebElement ddlsubscription { get; set; }
    }
}
