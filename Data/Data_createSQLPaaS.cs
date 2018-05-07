using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    public class Data_createSQLPaaS
    {
        public string los { get; set; }
        public string envtype { get; set; }
        public string nickname { get; set; }

        public string hostinglocation { get; set;  }
        public string partnerorsponsor { get; set; }
        public string billingterritory { get; set; }
        public string chargecode { get; set; }
        public string consumer { get; set; }
        public string friendlyname { get; set; }
        public string dataclassification { get; set; }
        public string quantity { get; set; }
        public string tier { get; set; }
        public string admin { get; set; }
        public string adminpwd { get; set; }

        public string golivedate { get; set; }
        public Data_createSQLPaaS(Exceldatareader excelConn, string sheetName, int index)
        {
            DataInput resultSet = new DataInput("1", "SQL", index);
            DataTable reqTable = resultSet.InputTable;

            los = reqTable.Rows[index]["los"].ToString();
            envtype = reqTable.Rows[index]["envtype"].ToString();
            nickname = reqTable.Rows[index]["nickname"].ToString();
            hostinglocation = reqTable.Rows[index]["location"].ToString();
            partnerorsponsor = reqTable.Rows[index]["partnerorsponsor"].ToString();
            billingterritory = reqTable.Rows[index]["billingterritory"].ToString();
            chargecode = reqTable.Rows[index]["chargecode"].ToString();
            consumer = reqTable.Rows[index]["consumer"].ToString();
            friendlyname = reqTable.Rows[index]["friendlyname"].ToString();
            dataclassification = reqTable.Rows[index]["dataclassification"].ToString();
            quantity = reqTable.Rows[index]["quantity"].ToString();
            tier = reqTable.Rows[index]["tier"].ToString();
            admin = reqTable.Rows[index]["admin"].ToString();
            adminpwd = reqTable.Rows[index]["adminpwd"].ToString();
            golivedate = reqTable.Rows[index]["golivedate"].ToString();

        }
    }
}
