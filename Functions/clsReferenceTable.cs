using PayrollSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Functions
{
    public class clsReferenceTable
    {
        clsDatabase cDB = new clsDatabase();
        public DataTable getDataTableRefence(string referenceTable,string ColumnNames)
        {
            string dbColumnName = string.IsNullOrEmpty(ColumnNames) != true ? ColumnNames: "*";            
            string dbCriteria = "isActive = Yes";

            string QueryRef = cDB.setQueryBuilder(dbColumnName, referenceTable, dbCriteria);

            DataTable result = cDB.getRecords(QueryRef);

            return result;
        }
    }
}
