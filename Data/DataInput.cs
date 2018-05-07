using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    public class DataInput
    {
        public DataTable InputTable { get; set; }

        public DataInput(string TestCaseID, string sheetName, int index)
        {
            Exceldatareader.ExlConn.Open();

            OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM ["+sheetName+"$]" , Exceldatareader.ExlConn);
            OleDbDataAdapter objAdapter = new OleDbDataAdapter();
            objAdapter.SelectCommand = objCmdSelect;
            DataSet inputDataSet = new DataSet();
            objAdapter.Fill(inputDataSet);
            InputTable = inputDataSet.Tables[0];

            Exceldatareader.ExlConn.Close();
        }
    }
}
