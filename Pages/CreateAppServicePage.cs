using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateAppService
    {
        public CreateAppService()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
      
        [FindsBy(How = How.XPath, Using = "//span[text()='New']")]
        public IWebElement lnkNew { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'icon requests')]")]
        public IWebElement divRequestIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Create Cloud Request')]")]
        public IWebElement divCreateCloudRequest { get; set; }

        [FindsBy(How = How.Id, Using = "search-value")]
        public IWebElement txtOfferingSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='Next']")]
        public IWebElement imgNext { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='Next']")]
        public IWebElement imgBack { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='Complete']")]
        public IWebElement imgComplete { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-filter='Create Application Service']")]
        public IWebElement divCreateAppService { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[@data-filter='Create Application Service Environment']")]
        public IWebElement divCreateAppServiceEnv { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[@data-filter='Create Service Account']")]
        public IWebElement divCreateServiceAccount { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-filter='Decommission Application Environment']")]
        public IWebElement divDecomAppEnv { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-filter='Decommission Application Service']")]
        public IWebElement divDecomAppService { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-filter='Decommission Azure Public Cloud VM']")]
        public IWebElement divDecomAzurePublicCloudVM { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-filter='General Service Request']")]
        public IWebElement divGeneralServiceRequest;

        [FindsBy(How = How.XPath, Using = "//li[@data-filter='Manage Application Environment']")]
        public IWebElement divManageAppEnv { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-filter='Manage Application Service']")]
        public IWebElement divManageAppService { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service Name')]/..//input[2]")]
        public IWebElement testNewAppServiceName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'ApplicationServiceName.ps1')]/..//input[2]")]
        public IWebElement txtAppServiceName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Service')]/..//input[1]")]
        public IWebElement txtApplicationServiceName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Application Owner')]/..//input[2]")]
        public IWebElement txtApplicationOwner { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Technical Contact')]/..//input[2]")]
        public IWebElement txtTechnicalContact { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'TICKET NUMBER')]/..//input[2]")]
        public IWebElement txtNISCAPTICKET { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Line of Service')]/..//input")]
        public IWebElement ddlLOS { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@title,'Advisory')]")]
        public IWebElement ddlLOS_Advisory { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@title,'Assurance')]")]
        public IWebElement ddlLOS_Assurance { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[contains(@title,'IFS')]")]
        public IWebElement ddlLOS_IFS { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@title,'Tax')]")]
        public IWebElement ddlLOS_ATax { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@title,'Successfully registered the request.')]")]
        public IWebElement divRegisterSuccess { get; set; }
    }
}
