using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.Database
{
    public class clsDatabase
    {
        IniFile MyIni = new IniFile("Settings.ini");

        string ConnectionString;
        string DatabasePath;
        string DatabaseName;

        string setDatabaseName()
        {
            string sDatabaseName = MyIni.Read("Filename", "DatabaseSettings");
            return sDatabaseName;
        }
        string setDatabasePath()
        {
            string sDatabasePath = MyIni.Read("Directory", "DatabaseSettings");
            
            if (!Directory.Exists(sDatabasePath))
            {
                sDatabasePath = Environment.CurrentDirectory;
            }
            return sDatabasePath;
        }

        public string setConnectionString(string DatabaseName)
        {
            DatabasePath = MyIni.Read("Directory", "DatabaseSettings");
            DatabaseName = MyIni.Read("Filename", "DatabaseSettings");
            string DatabaseFilePath = DatabasePath + "\\" + DatabaseName;

            if (!Directory.Exists(DatabasePath))
            {
                DatabasePath = Environment.CurrentDirectory;
                DatabaseFilePath = DatabasePath + "\\" + DatabaseName;
            }

            if (!File.Exists(DatabaseFilePath))
            {
                MessageBox.Show("Database File:" + DatabaseFilePath, "Error: Database file is not found. Please ask your Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


            return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DatabaseFilePath + ";";
        }
        public string setQueryBuilder(string sColumnName, string sTableName, string sCriteria)
        {
            string sResult = string.Empty;

            string UserTable = sTableName;
            string ColumnNames = sColumnName;
            string Criteria = sCriteria;

            string QueryString = "SELECT " + ColumnNames + " from " + UserTable + (string.IsNullOrEmpty(sCriteria) ? "" : " WHERE " + Criteria);

            return QueryString;
        }
        public string setDeleteQueryBuilder(string TableName,string Criteria)
        {
            string sResult = string.Empty;
            sResult = "Delete from [" + TableName + "] where " + Criteria;
            return sResult;
        }
        public string setUpdateQueryBuilder(string TableName,DataTable dtBody,string Criteria)
        {
            string sResult = string.Empty;
            try
            {
                sResult = "Update [" + TableName + "]";
                string sColumnName = string.Empty;

                sColumnName += "SET ";

                if (dtBody.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtBody.Rows)
                    {
                        sColumnName += "[" + dr["ColumnName"] + "] = ";
                        if (dr["isNumeric"].ToString() == "F")
                        {
                            sColumnName += "'" + dr["Value"].ToString() + "',";
                        }
                        else if (dr["isNumeric"].ToString() == "E")
                        {
                            sColumnName += dr["Value"].ToString() + ",";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(dr["Value"].ToString()))
                            {
                                dr["Value"] = "0";
                            }
                            sColumnName += int.Parse(dr["Value"].ToString()).ToString() + ",";
                        }
                    }
                    sColumnName = sColumnName.Substring(0, sColumnName.Length - 1) + " where " + Criteria;

                    sResult += " " + sColumnName;
                }
            }
            catch (Exception e)
            {
            }
            return sResult;
        }
        public string setInsertQueryBuilder(string TableName,DataTable dtBody)
        {
            string sResult = string.Empty;
            try
            {
                sResult = "Insert into [" + TableName + "]";
                string sColumnNames = string.Empty;
                string sValueData = string.Empty;
                if (dtBody.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtBody.Rows)
                    {
                        sColumnNames += "[" + dr["ColumnName"].ToString() + "],";
                        if (dr["isNumeric"].ToString() == "F")
                        {
                            sValueData += "'" + dr["Value"].ToString() + "',";
                        }
                        else if(dr["isNumeric"].ToString() == "E")
                        {
                            sValueData += dr["Value"].ToString() + ",";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(dr["Value"].ToString()))
                            { 
                                dr["Value"] = "0";
                            }
                            sValueData += int.Parse(dr["Value"].ToString()).ToString() + ",";
                        }
                    }
                }
                if(sColumnNames.Substring(sColumnNames.Length-1,1)==",")
                {
                    sColumnNames = sColumnNames.Substring(0,sColumnNames.Length - 1);
                }
                if (sValueData.Substring(sValueData.Length - 1, 1) == ",")
                {
                    sValueData = sValueData.Substring(0, sValueData.Length - 1);
                }
                sResult = sResult + "(" + sColumnNames + ")values(" + sValueData + ")";
            }
            catch (Exception ex)
            {
                throw;
            }
            return sResult; 
        }
        public int getLastRecordID(string TableName)
        {
            int result = 0;
            try
            {
                string Query = setQueryBuilder("TOP 1 ID", TableName, "");
                DataTable dtResult = getRecords(Query); 
                if(dtResult.Rows.Count > 0 )
                {
                    result = (int) dtResult.Rows[0][0] + 1;
                }else
                {
                    result =  1;
                }
            }
            catch(Exception e)
            {
                //MessageBox.Show("Error: " + e.Message, "Error: GetLastRecordID for " + TableName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = 0;
            }
            return result;
        }
        public bool checkDatabaseExists()
        {
            bool result = false;
            DatabaseName = setDatabaseName();
            DatabasePath = setDatabasePath();

            if (!Directory.Exists(DatabasePath))
            {
                DatabasePath = Environment.CurrentDirectory;
            }

            //setConnectionString(DatabaseName);
            try
            {
                result = Directory.Exists(DatabasePath);
                result = File.Exists(DatabasePath + "\\" + DatabaseName);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public DataTable getRecords(string Query)
        {
            DataTable dt = new DataTable(); 
            try
            {
                if(!checkDatabaseExists())
                {
                    return dt;
                }
                string ConnString = setConnectionString(DatabaseName).ToString();  
                using (OleDbConnection dataConnection = new OleDbConnection(ConnString))
                {
                    using (OleDbCommand dataCommand = dataConnection.CreateCommand())
                    {
                        dataCommand.CommandText = Query;
                        dataConnection.Open();                                                
                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = dataCommand;
                        adapter.Fill(dt);                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Payroll System : Database Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            return dt;
        }
        public int insertRecordTable(string Query)
        {
            int result = 0;
            string ConnString = setConnectionString(DatabaseName).ToString();
            var con = new OleDbConnection(ConnString);
            try
            {
                if (!checkDatabaseExists())
                {
                    return result;
                }                              
                var cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = Query;                
                con.Open();
                result = cmd.ExecuteNonQuery();                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Payroll System : Error in Inserting Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return result;
        }
        public int deleteRecordTable(string Query)
        {
            int result = 0;
            string ConnString = setConnectionString(DatabaseName).ToString();
            var con = new OleDbConnection(ConnString);
            try
            {
                if (!checkDatabaseExists())
                {
                    return result;
                }
                var cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = Query;
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Payroll System : Error in Inserting Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return result;
        }
    }
}
