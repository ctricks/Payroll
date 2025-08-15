using OfficeOpenXml;
using PayrollSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Functions
{
    public class clsEmployeeRecords
    {
        clsDatabase cdb = new clsDatabase();  
        public DataTable dtGetActiveEmployees(string Columns, string Filter)
        {
            string Query = "SELECT "+ Columns +" FROM tblmgb_employees WHERE "+ Filter +" ORDER BY tblmgb_employees_lastname ASC;";
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = cdb.getRecords(Query);
            }
            catch (Exception ex)
            {
            }
            return dataTable;
        }
    }
}
