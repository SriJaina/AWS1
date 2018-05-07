using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;

namespace Azure_Automation
{
    public class Commonfunctions
    {
        public enum PropertyType
        {
            Id,
            Class,
            Xpath
        }
        public void wait()
        {
            System.Threading.Thread.Sleep(15000);
        }
        public void smallwait()
        {
            System.Threading.Thread.Sleep(5000);
        }
        public void ElementOperations(string FindBy, string FindByValue, string operation, string sendvalue)
        {
            waitForElement(FindBy, FindByValue);
            IWebElement element = null;
            if (FindBy.Equals("Id"))
            {
                element = Properties.driver.FindElement(By.Id(FindByValue));
            }
            else if (FindBy.Equals("Class"))
            {
                element = Properties.driver.FindElement(By.ClassName(FindByValue));
            }
            else if (FindBy.Equals("Xpath"))
            {
                element = Properties.driver.FindElement(By.XPath(FindByValue));
            }
            else if (FindBy.Equals("LinkText"))
            {
                element = Properties.driver.FindElement(By.LinkText(FindByValue));
            }
            Perform(element, operation, sendvalue);

        }
        public void Perform(IWebElement ele, string operation, string sendvalue)
        {

            WebDriverWait wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(10));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Properties.driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(4);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            // fluentWait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            fluentWait.Until<IWebElement>((d) =>
            {
                //IWebElement element = d.FindElement(By.Id("myid"));
                if (ele.Displayed && ele.Enabled && (ele.GetAttribute("aria-disabled") == null))
                {
                    return ele;
                }

                return null;
            });

            smallwait();
            if (operation.Equals("click"))
            {
                ele.Click();
            }
            else if (operation.Equals("sendkeys"))
            {
                ele.Click();

                ele.SendKeys(sendvalue.Replace("(", "{(}"));
            }
            else if (operation.Equals("clear"))
            {
                ele.Clear();
            }
            

        }
        public void waitForElement(string FindBy, string FindByValue)
        {
            var wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(20));
            switch (FindBy)
            {
                case "Id":
                    wait.Until(ExpectedConditions.ElementExists(By.Id(FindByValue)));
                    break;
                case "Class":
                    wait.Until(ExpectedConditions.ElementExists(By.ClassName(FindByValue)));
                    break;
                case "Xpath":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(FindByValue)));

                    wait.Until(ExpectedConditions.ElementExists(By.XPath(FindByValue)));

                    break;
                case "LinkText":
                    wait.Until(ExpectedConditions.ElementExists(By.LinkText(FindByValue)));
                    break;
            }

        }

        public void selectValueFromDropdown(IList<IWebElement> dropdownvalues, string expectedvalue)
        {
            int listCount = dropdownvalues.Count;
            for (int i = 0; i < listCount; i++)
            {
                if (dropdownvalues[i].Text.Contains(expectedvalue))
                {
                    dropdownvalues[i].Click();
                    break;
                }
            }
        }

        public void waitUntilCountChanges(string xpath)
        {
            var wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(30));
            //IWebDriver d = Properties.driver;
            wait.Until(d => d.FindElements(By.XPath(xpath)).Count > 1);

        }
    }
}