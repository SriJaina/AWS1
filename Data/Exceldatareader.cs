using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    public class Exceldatareader
    {
        string ConnectionString;
        public static OleDbConnection ExlConn;
        public Exceldatareader()
        {
            string path = "C:\\Azure_Automation\\Azure_Automation\\Data\\Datasetup.xlsx";
            //  IMEX=1 Can be added in Extended Properties if you want to treat all data as text, but it was causing an issue while writing data to excel...So Removed it.
            ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=\"Excel 12.0 Xml;HDR=YES;READONLY=FALSE\"";
            ExlConn = new OleDbConnection(ConnectionString);
        }
    }
}
