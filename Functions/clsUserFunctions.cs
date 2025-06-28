using PayrollSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Functions
{
    public class clsUserFunctions
    {
        clsDatabase cDB = new clsDatabase();
        public bool LoginUsers(string username, string password,out int UserIDLogin)
        {
            bool result = false;

            string dbColumnName = "*";
            string dbTableName = "tblPSD_Users";
            string dbCriteria = "Username = '" + username.Trim() + "' and Password = '" + password.Trim() + "' and isActive = YES";

            string QueryUser = cDB.setQueryBuilder(dbColumnName,dbTableName,dbCriteria);

            DataTable dtResult = cDB.getRecords(QueryUser);
            bool validUser = false;
            UserIDLogin = -1;
            if (dtResult.Rows.Count > 0)
            {
                validUser = int.TryParse(dtResult.Rows[0]["id"].ToString(), out UserIDLogin);

                if (validUser)
                {
                    UserIDLogin = int.Parse(dtResult.Rows[0]["id"].ToString());
                }
            } else
            {
                validUser = false;
            }

            return result = validUser;
        }
        public bool validateLoginUsers(string username, string password)
        {
            bool result = true;
            if ((username == null || password == null) || (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)))
            {
                result = false;
            }
            return result;
        }
    }
}
