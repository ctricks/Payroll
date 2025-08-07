using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.QUERIES
{
    public class QUsers
    {
        public string LoginUser(string username, string password)
        {
            string query = string.Empty;
                query = "Select * from tblmgb_users where tblmgb_users_username='" + username + "' and tblmgb_users_password= MD5('" + password + "')";
            return query;
        }
    }
}
