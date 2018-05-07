using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;
using Excel;
using System.Data;

namespace Azure_Automation
{
    class ExcelMethods
    {
        /// <summary>
		/// Read Data from excel sheet and fill the data into a data table
		/// </summary>
		/// <param name="path">Path of excel sheet</param>
		/// <param name="sheetName">Sheet Name in excel file</param>
		/// <returns>Return data in the form of Data table</returns>
		public static DataTable readData(string path, string sheetName)
        {
            DataTable dt = new DataTable();
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);

            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //Choose one of either 3, 4, or 5
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();

            //4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;

            DataTableCollection dtc = result.Tables;

            dt = new System.Data.DataTable();
            dt = dtc[sheetName];
            result = excelReader.AsDataSet();
            dtc = result.Tables;
            dt = dtc[sheetName];

            return dt;
        }

        public static void OpenDBConnection()
        {
            try
            {
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;
                
                string testFileLoc = projectPath + "Input\\TestData1.xlsx";
                conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + testFileLoc + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;';");
                conn.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not establish connection with Excel WorkBook");
            }

        }
        public static DataSet getDataSetForSheet(String sheetName)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "Select * from [" + sheetName + "$]";
                command.Connection = conn;

                using (OleDbDataAdapter da = new OleDbDataAdapter())
                {
                    da.SelectCommand = command;
                    da.Fill(testData);
                    //conn.Close();
                    return testData;

                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// DataSet to hold Test data
        /// </summary>
        public static DataSet testData = new DataSet();
        public static OleDbConnection conn = null;

        /// <summary>
        /// Loading Test Data in memory
        /// </summary>
        public static  DataSet LoadTestDataDB(string testName)
        {
            try
            {
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;

                string testFileLoc = projectPath + "Input\\TestData.xlsx";
                
                conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + testFileLoc + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;';");
                conn.Open();
               // OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + System.IO.Path.GetFileName(testFileLoc) + "] WHERE TestCase =\"" + testName + "\"", conn);
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "Select * from [" + testName + "$]";
                command.Connection = conn;

                 using (OleDbDataAdapter da = new OleDbDataAdapter())
                {
                    da.SelectCommand = command;
                    da.Fill(testData);
                    //conn.Close();
                    return testData;
                   
                }
               
            }
            catch(Exception e)
            {
                return testData;
            }
        }

        public static String[] getAllSheetName()
        {
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                return null;
            }

            else
            {
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }
                return excelSheets;

            }

        }

        /// <summary>
        /// Method to Get the Test data from the .csv data source
        /// </summary>
        /// <param name="Sno">Test Script Number</param>
        /// <returns>returns a data row</returns>
        public  DataRow GetTestData(string Sno)
        {
            DataSet testData = LoadTestDataDB(Sno);
            //DataRow[] connectionDataRow = testData.Tables[0].Select();
            DataRow[] connectionDataRow = testData.Tables[0].Select();
            DataRow testDataRow = null;
            int count = connectionDataRow.Count();
            for (int i = 0; i < count; i++)
            {
                if (connectionDataRow[i][0].ToString() == Sno)
                {
                    testDataRow = connectionDataRow[i];
                    break;
                }
            }
            return testDataRow;
        }

        public static String GetValueOfHeader(DataSet ds,String headerName)
        {
            String value = null;
            try
            {
                value = ds.Tables[0].Rows[0][headerName].ToString();
            }
            catch(Exception e)
            {
                throw new Exception();
            }
            return value;
        }
    }

  
}
