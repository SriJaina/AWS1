using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    public partial class ObjectRepository
    {
        public string gsr_los_link_xpath = "//label[text()='Line of Service (LOS)']/..//a";
        public string gsr_los_ddvalues_ul_li_xpath = "//ul[contains(@class,'mcdropdown_menu')][1]/li/div";
        public string gsr_envtype_link_xpath = "//label[text()='Environment Type']/..//a";
        public string gsr_envtype_ddvalues_ul_li_xpath = "//ul[contains(@class,'mcdropdown_menu')][2]/li";
        public string gsr_partnerorsponsor_edit_xpath = "//label[text()='Partner/Sponsor']/../input[@type='text']";
        public string gsr_chargcode_edit_xpath = "//label[text()='Charge Code (WBS Code)']/../input[@type='text']";
        public string gsr_riskorsecurity_textarea_xpath = "//label[text()='Risk/Security Information']/../textarea";
        public string gsr_cloudservices_edit_xpath = "//label[text()='Cloud Services']/../input[@type='text']";
        public string gsr_accessdate_edit_xpath = "//label[text()='When do you need access? (DD/MM/YYYY or DD.MM.YYYY)']/../input[@type='text']";
        public string gsr_golivedate_edit_xpath = "//label[text()='When will your Application Go Live? (DD/MM/YYYY or DD.MM.YYYY)']/../input[@type='text']";
        public string gsr_complete_button_xpath = "//a[@title='Complete']//img[@alt='Complete']";
    }
}
