using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Azure_Automation
{
    public class Reusablefunctions : BaseTest
    {
        Commonfunctions common = new Commonfunctions();
        ObjectRepository obj = new ObjectRepository();
        public delegate void DelegatewithNoParameter();
        public delegate void DeleggteWitOneStringParam(string param);
        public delegate void DelegateWithFourStringParam(String param1, String param2, String param3, String Param4);
        public delegate void DelegateWithTwoStringParam(String param1, String param2);
        public delegate void DelegateWithThreeStringParam(String param1, String param2, String param3);
        public delegate void DelegateWithFiveStringParam(String param1, String param2, String param3, String Param4, String Param5);
        public delegate void DelegateWithSixStringParam(String param1, String param2, String param3, String Param4, String Param5, string Param6);
        public delegate void DeleggteWitOneStringOneIntegerParam(string param1, int param2);

        public void TryCatchMethod(string param1, int param2, DeleggteWitOneStringOneIntegerParam method, string passmsg, string failmsg)
        {
            try
            {
                method(param1, param2);
                BaseTest.test.Log(LogStatus.Pass, passmsg);
            }
            catch (Exception e)
            {
                BaseTest.test.Log(LogStatus.Fail, failmsg);
                Assert.Fail();
            }
        }
        public void TryCatchMethod(string param1, String param2, DelegateWithTwoStringParam method, string passmsg, string failmsg)
        {
            try
            {
                method(param1, param2);
                BaseTest.test.Log(LogStatus.Pass, passmsg);
            }
            catch (Exception e)
            {
                BaseTest.test.Log(LogStatus.Fail, failmsg);
                Assert.Fail();
            }
        }

        public void TryCatchMethod(string param1, String param2, String param3, DelegateWithThreeStringParam method, string passmsg, string failmsg)
        {
            try
            {
                method(param1, param2, param3);
                BaseTest.test.Log(LogStatus.Pass, passmsg);
            }
            catch (Exception e)
            {
                BaseTest.test.Log(LogStatus.Fail, failmsg);
                Assert.Fail();
            }
        }
        public void TryCatchMethod(string param1, String param2, String param3, String Param4, DelegateWithFourStringParam method, string passmsg, string failmsg)
        {
            try
            {
                method(param1, param2, param3, Param4);
                BaseTest.test.Log(LogStatus.Pass, passmsg);
            }
            catch (Exception e)
            {
                BaseTest.test.Log(LogStatus.Fail, failmsg);
                Assert.Fail();
            }
        }

        public void TryCatchMethod(string param1, DeleggteWitOneStringParam method, string passmsg, string failmsg)
        {
            try
            {
                method(param1);
                BaseTest.test.Log(LogStatus.Pass, passmsg);
            }
            catch (Exception e)
            {
                BaseTest.test.Log(LogStatus.Fail, failmsg);
                Assert.Fail();
            }
        }

        
        //  public delegate void delegateWithNoParameter();
        public void TryCatchMethod(DelegatewithNoParameter method, string passmsg, string failmsg)
        {
            try
            {
                method();
                BaseTest.test.Log(LogStatus.Pass, passmsg);
            }
            catch (Exception e)
            {
                BaseTest.test.Log(LogStatus.Fail, failmsg);
                Assert.Fail();
                

            }

        }


        public void TryCatchMethod(string param1, String param2, String param3, String Param4, String Param5, string Param6, DelegateWithSixStringParam method, string passmsg, string failmsg)
        {
            try
            {
                method(param1, param2, param3, Param4, Param5, Param6);
                BaseTest.test.Log(LogStatus.Pass, passmsg);
            }
            catch (Exception e)
            {
                BaseTest.test.Log(LogStatus.Fail, failmsg);
                Assert.Fail();
            }
        }

        public void TryCatchMethod(string param1, String param2, String param3, String Param4, String Param5, DelegateWithFiveStringParam method, string passmsg, string failmsg)
        {
            try
            {
                method(param1, param2, param3, Param4, Param5);
                BaseTest.test.Log(LogStatus.Pass, passmsg);
            }
            catch (Exception e)
            {
                BaseTest.test.Log(LogStatus.Fail, failmsg);
                Assert.Fail();
            }
        }

        public void LoginToWAP()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArgument("start-maximized");
            // opt.AddArgument("--headless");
            Properties.driver = new ChromeDriver(opt);
            Properties.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Properties.driver.Navigate().GoToUrl("https://tenant.stagefabric.ad.pwcinternal.com");

            common.ElementOperations("Xpath", "//span[text()='Global IdAM integration STAGE']", "click", "");
            
            common.smallwait();
            common.ElementOperations("Xpath", obj.email_input_xpath,"sendkeys", "AzureTest@pwc.com");

            common.ElementOperations("Xpath", obj.login_input_button_xpath, "click", "");
            common.smallwait();
        }

        #region Click on New button
        public void clickOnNewButton()
        {
            common.ElementOperations("Xpath", obj.new_button_div_xpath, "click", "");
            common.smallwait();
            IWebElement Newheader = Properties.driver.FindElement(By.XPath(obj.new_header_div_xpath));
            if (!(Newheader.Displayed))
            {
                throw new Exception();
            }

        }

        #endregion

        public void clickonNewAzureRequest()
        {
            common.ElementOperations("Xpath", obj.requests_link_menuitem_xpath, "click", "");
            common.ElementOperations("Xpath", obj.requests_createAzure_xpath, "click", "");
        }

        public void moveToNextPage()
        {
            IWebElement nextButton = Properties.driver.FindElement(By.XPath(obj.nextbutton_xpath));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            common.smallwait();
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", nextButton);
            js.ExecuteScript("arguments[0].click()", nextButton);
        }

        public void navigateToGeneralServiceRequest()
        {
            clickonNewAzureRequest();
            common.ElementOperations("Xpath", obj.generalservicerequsts_link_xpath, "click", "");
            moveToNextPage();
        }

        public void navigateToAzureSQLRequest()
        {
            clickonNewAzureRequest();
            common.ElementOperations("Xpath", obj.azuresqlpaas_link_xpath, "click", "");
            moveToNextPage();
        }

        public void navigateToPasswordReset()
        {
            clickonNewAzureRequest();
            common.ElementOperations("Xpath", obj.passwordreset_link_xpath, "click", "");
            moveToNextPage();
        }
        public void completeCreationOfRequest()
        {
            IWebElement completeButton = Properties.driver.FindElement(By.XPath(obj.gsr_complete_button_xpath));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Properties.driver;
            js.ExecuteScript("arguments[0].click()", completeButton);
        }
    }
}