using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    public partial class ObjectRepository
    {
        public string sql_los_ddvalues_xpath = "//ul[contains(@class,'mcdropdown_menu')][4]/li/div";
        public string sql_envtype_ddvalues_ul_li_xpath = "//ul[contains(@class,'mcdropdown_menu')][5]/li";
        public string envnickname_input_xpath = "//label[text()='Environment nickname']//..//input[@type='text']";
        public string hostinglocation_dropdown_arrowlink_xpath = "//label[text()='Hosting Location']//..//input[@type='text']";
        public string hostinglocation_dropdwon_values_xpath = "//ul[contains(@class,'mcdropdown_menu')][6]/li/div";
        public string billingterritory_input_xpath = "//label[text()='Billing territory']/..//input[@type='text']";
        public string billingterritories_dropdown_values_xpath = "//ul[contains(@class,'mcdropdown_menu')][7]/li/div";
        public string consumingcountry_dd_link_xpath = "//label[text()='Consuming Country']//..//input[@type='text']";
        public string consumingcountries_ddvalues_xpath = "//ul[contains(@class,'mcdropdown_menu')][8]/li/div";
        public string friendlyname_input_xpath = "//label[text()='Application Alias/Friendly name']/..//input[@type='text']";
        public string dataclassification_input_xpath = "//label[text()='Data classification']//..//input[@type='text']";
        public string dataclassifications_ddvalues_xapth = "//ul[contains(@class,'mcdropdown_menu')][1]/li/div";
        public string pricingtier_input_xpath = "//label[text()='Database Pricing Tier']/..//input[@type='text']";
        public string pricingtiers_ddvalues_xpath = "//ul[contains(@class,'mcdropdown_menu')][3]/li/div";
        public string serveradmin_input_xpath = "//label[text()='SQL SERVER ADMINISTRATOR']/..//input[@type='text']";
        public string serveradminpwd_input_xpath = "//label[text()='SQL SERVER ADMINISTRATOR PASSWORD']/..//input[@type='password']";
        public string confirmserveradminpwd_input_xpath = "//label[text()='CONFIRM SQL SERVER ADMINISTRATOR PASSWORD']/..//input[@type='password']";
        public string golivedate_input_xpath= "//label[text()='When will your Application Go Live? (DD/MM/YYYY or DD.MM.YYYY)']/../input[@type='text']";

    }
}
