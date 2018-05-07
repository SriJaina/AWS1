using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Azure_Automation
{
    class CreateAppEnv_TechnicalInformationPage
    {
        public CreateAppEnv_TechnicalInformationPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Deployment Type']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtDeploymentType;

        [FindsBy(How = How.XPath, Using = "//label[text()='Hosting Location']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtHostingLocation;

        [FindsBy(How = How.XPath, Using = "//label[text()='Important Information']/following-sibling::textarea")]
        public IWebElement txtImportantInformation;

        [FindsBy(How = How.XPath, Using = "//label[text()='Web Tier Subnet Size']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtWebTierSubnetSize;

        [FindsBy(How = How.XPath, Using = "//label[text()='APP Tier Subnet Size']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtAppTierSubnetSize;

        [FindsBy(How = How.XPath, Using = "//label[text()='Data Tier Subnet Size']/following-sibling::div/div/input[@type='text']")]
        public IWebElement txtDataTierSubnetSize;
    }
}
