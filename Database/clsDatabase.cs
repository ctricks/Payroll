using MySql.Data.MySqlClient;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PayrollSystem.Database
{
    public class clsDatabase
    {
        IniFile MyIni = new IniFile("Settings.ini");
        public bool MsAccess;

        public string myConnectionString;
        string DatabasePath;
        string DatabaseName;

        string MysqlServer;
        string MysqlUsername;
        string MysqlPassword;
        string MysqlPort;
        string MysqlDatabase;

        
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
        
        public bool testConnectionString(string ConnectionString)
        {
            bool result = false;
            try
            {
                ConnectionString = myConnectionString;
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {                    
                    conn.Open();
                    result = true;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Mysql Test DB Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false; 
            }
            return result;
        }
        public string setConnectionString(string DatabaseName = "")
        {
            DatabasePath = MyIni.Read("Directory", "DatabaseSettings");
            DatabaseName = MyIni.Read("Filename", "DatabaseSettings");
            //For DB Server
            MysqlServer = MyIni.Read("Servername", "DatabaseServer");
            MysqlDatabase = MyIni.Read("Databasename", "DatabaseServer");
            MysqlUsername = MyIni.Read("Username", "DatabaseServer");
            MysqlPassword = MyIni.Read("Password", "DatabaseServer");
            MysqlPort = MyIni.Read("Port", "DatabaseServer");

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

            string Connstring = string.Empty;

            if (MsAccess)
            {
                Connstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DatabaseFilePath + ";";
            }
            else
            {
                Connstring = "Server="+MysqlServer+";Database="+MysqlDatabase+";Uid="+MysqlUsername+";Pwd="+MysqlPassword+";Port="+MysqlPort+";";
            }
            myConnectionString = Connstring;
            return Connstring;
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
        public string setInsertQueryBuilderByColumnValue(string TableName, string[,] details)
        {
            string result = string.Empty;
            try
            {
                string ColumnName = string.Empty;

                for(int a = 0;a<=details.Length/2;a++)
                {
                    for (int b = 0; b <= 1; b++)
                    {
                        ColumnName += details[b,a].ToString() + ',';
                    }
                }
            }
            catch (Exception ex)
            {
                result = "Error: " + ex.Message.ToString();
            }
            return result;
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
                string ConnString = myConnectionString; //setConnectionString(DatabaseName).ToString();  
                //using (OleDbConnection dataConnection = new OleDbConnection(ConnString))
                //{
                //    using (OleDbCommand dataCommand = dataConnection.CreateCommand())
                //    {
                //        dataCommand.CommandText = Query;
                //        dataConnection.Open();                                                
                //        OleDbDataAdapter adapter = new OleDbDataAdapter();
                //        adapter.SelectCommand = dataCommand;
                //        adapter.Fill(dt);                        
                //    }
                //}
                using(MySqlConnection conn = new MySqlConnection(ConnString))
                {
                    using(MySqlCommand cmd = new MySqlCommand(Query,conn))
                    {
                        conn.Open();
                        using(MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        if(conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
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

        public int insertRecordTableNoPrompt(string Query,ref string ErrorMessage)
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
                //MessageBox.Show("Error: " + ex.Message, "Payroll System : Error in Inserting Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorMessage = ex.Message;
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
        //Stored Procedure Starts Here
        public int setHolidays(DateTime CalendarDate,string HolidayName, string HolidayType,int UserID, string Remarks)
        {
            int result = 0;
            try
            {
                string MySQLConnectionString = setConnectionString();
                using (MySqlConnection connection = new MySqlConnection(MySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand("sp_setHolidays", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@CalendarDate", MySqlDbType.Date).Value = CalendarDate;
                        command.Parameters.Add("@HolidayName", MySqlDbType.String).Value = HolidayName;
                        command.Parameters.Add("@HolType", MySqlDbType.String).Value = HolidayType;
                        command.Parameters.Add("@UserID", MySqlDbType.Int32).Value = UserID;
                        command.Parameters.Add("@Remarks", MySqlDbType.String).Value = Remarks;
                        connection.Open();
                        result = command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        public DataSet getDSFromSPSelect(string SPName)
        {
            DataSet dsFinal = new DataSet();
            try
            {
                string MySQLConnectionString = setConnectionString();
                using (MySqlConnection connection = new MySqlConnection(MySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(SPName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                        {
                            da.Fill(dsFinal);
                        }                        
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error executing SP: " + SPName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsFinal;
        }
        public DataSet getDSFromSPSelectHolidays(string SPName,int Year,int isDistinct)
        {
            DataSet dsFinal = new DataSet();
            try
            {
                string MySQLConnectionString = setConnectionString();
                using (MySqlConnection connection = new MySqlConnection(MySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(SPName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ForYear", MySqlDbType.Int32).Value = Year;
                        command.Parameters.Add("@isDistinct", MySqlDbType.Int32).Value = isDistinct;

                        connection.Open();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                        {
                            da.Fill(dsFinal);
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error executing SP: " + SPName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsFinal;
        }


        public void ExecuteSPLoginUsers(string SPName,string ConnectionString,string Username, string Password,out int RoleID,out int UserID)
        {
            RoleID = 0;UserID = 0;
            int result = 0;
            try
            {
                string MySQLConnectionString = ConnectionString;
                using (MySqlConnection connection = new MySqlConnection(MySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(SPName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        command.Parameters.AddWithValue("Username", Username);
                        command.Parameters.AddWithValue("PasswordVal", Password);

                        // Add output parameter for the return value
                        MySqlParameter RoleId = new MySqlParameter("@RoleId", MySqlDbType.Int32);
                        RoleId.Direction = ParameterDirection.Output;
                        command.Parameters.Add(RoleId);

                        MySqlParameter UserId = new MySqlParameter("@UserId", MySqlDbType.Int32);
                        UserId.Direction = ParameterDirection.Output;
                        command.Parameters.Add(UserId);

                        connection.Open();
                        command.ExecuteNonQuery(); // Execute the stored procedure

                        // Retrieve the value from the output parameter
                        if (RoleId.Value != DBNull.Value)
                        {
                            RoleID = Convert.ToInt32(RoleId.Value);
                        }
                        if (UserId.Value != DBNull.Value)
                        {
                            UserID = Convert.ToInt32(UserId.Value);
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error executing SP: " + SPName,MessageBoxButtons.OK,MessageBoxIcon.Error);
                UserID = -1;
            }            
        }
    }
}
