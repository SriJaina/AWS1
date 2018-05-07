using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    public partial class ObjectRepository
    {
        public string email_input_xpath = "//input[@id='ctl00_phCenter_txtEMAIL']";
        public string login_input_button_xpath = "//input[@id='ctl00_phCenter_btnSubmitx']";
        public string new_button_div_xpath = "//div[contains(@class,'newbutton') and @role='button']/div";
        public string new_header_div_xpath = "//div[contains(@class,'drawermenu-title') and text()='New']";
        public string requests_link_menuitem_xpath = "//div[contains(@class,'menu-itemtext') and text()='Requests']";
        public string requests_createAzure_xpath = "//div[contains(@class,'menu-itemtext') and text()='Create Azure Request']";
        public string generalservicerequsts_link_xpath = "//li[@data-filter='General Service Request']//span";
        public string nextbutton_xpath = "//a[@title='Next']//img[@alt='Next']";
        public string azuresqlpaas_link_xpath = "//li[@data-filter='Request an Azure SQL PaaS Instance']//span";
        public string passwordreset_link_xpath = "//li[@data-filter='PwC Cloud Password Reset']//span";
    }
}
