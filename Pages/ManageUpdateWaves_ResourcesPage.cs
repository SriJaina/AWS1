using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class ManageUpdateWaves_ResourcesPage
    {
        public ManageUpdateWaves_ResourcesPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        

        [FindsBy(How = How.XPath, Using = "//a[@href='#Workspaces/ConfigItemsTenantExtension']")]
        public IWebElement lnkresources { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='fx-grid-filter']")]
        public IWebElement lnksearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='fx-grid-searchcontainer']/div/input")]
        public IWebElement tabsearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Manage Update Wave']")]
        public IWebElement lnkmanageUpdateWave { get; set; }

       

    }

}
