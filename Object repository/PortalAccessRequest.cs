using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
   public partial class ObjectRepository
    {
        public string offeringType = "//li[contains(text(),'General Cloud Requests') or contains(text(),'General')]";
        public string par_link_poratlaccessrequest = "//span[text()='PwC Cloud Portal Access Request']/ancestor::li";
        public string par_btn_next = "//img[@alt='Next']/ancestor::a";
        public string txtValidation = "//label[contains(text(),'Validation')]/following-sibling::textarea";
        public string ddlLoS = "//label[contains(text(),'LINE OF SERVICE (LOS)')]/following-sibling::div//div//a";
        public string listLos = "//ul[contains(@class,'mcdropdown_menu')]//li//div[@title]";
        public string txtRequestOwner = "//label[contains(text(),'REQUEST OWNER')]/following-sibling::input";
        public string txtPartnerSponser = "//label[contains(text(),'PARTNER/SPONSOR')]/following-sibling::input";
        public string txtRequestorTerritory = "//label[contains(text(),'REQUESTER TERRITORY')]/following-sibling::input";
        public string txtReasonForAccess = "//label[contains(text(),'REASON FOR ACCESS')]/following-sibling::input";

        //Confirm page

        public string txtImportantInformation = "//label[contains(text(),'Important Information')]/following-sibling::textarea";
        public string txtPwCCloudPortalAccess = "//label[contains(text(),'PwC Cloud Portal Access')]/following-sibling::textarea";

    }
}
