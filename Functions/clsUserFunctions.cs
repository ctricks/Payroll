using PayrollSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Functions
{
    public class clsUserFunctions
    {
        clsDatabase cDB = new clsDatabase();
        public bool LoginUsers(string username, string password)
        {
            bool result = false;

            string dbColumnName = "*";
            string dbTableName = "tblPSD_Users";
            string dbCriteria = "Username = '" + username.Trim() + "' and Password = '" + password.Trim() + "' and isActive = YES";

            string QueryUser = cDB.setQueryBuilder(dbColumnName,dbTableName,dbCriteria);

            result = cDB.getRecords(QueryUser).Rows.Count > 0;

            return result;
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
