using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    public class Data_createGSR
    {
        public string los { get; set; }
        public string envType { get; set; }
        public string partnerorsponsor { get; set; }

        public string chargecode { get; set; }

        public string riskorsecurityinfo { get; set; }
        public string cloudservices { get; set; }
        public string accessdate { get; set; }
        public string golivedate { get; set; }

        public Data_createGSR(Exceldatareader excelConn, string sheetName,int index)
        {
            DataInput resultSet = new DataInput("1", "GSR", index);
            DataTable reqTable = resultSet.InputTable;

            los = reqTable.Rows[index]["los"].ToString();
            envType = reqTable.Rows[index]["envType"].ToString();
            partnerorsponsor = reqTable.Rows[index]["partnerorsponsor"].ToString();
            chargecode = reqTable.Rows[index]["chargecode"].ToString();
            riskorsecurityinfo = reqTable.Rows[index]["riskorsecurityinfo"].ToString();
            cloudservices = reqTable.Rows[index]["cloudservices"].ToString();
            accessdate = reqTable.Rows[index]["accessdate"].ToString();
            golivedate = reqTable.Rows[index]["golivedate"].ToString();

        }
    }
}
