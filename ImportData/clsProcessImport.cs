using PayrollSystem.Database;
using PayrollSystem.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.ImportData
{
    public class clsProcessImport
    {
        clsHelpers helpers = new clsHelpers();
        clsImportSQL SQLStatement = new clsImportSQL();
        clsDatabase cdb = new clsDatabase();
        public bool processImport(DataGridViewRow row,string processCode)
        {
            bool result = false;
            try
            {
                switch(processCode)
                {
                    case "EmployeeRecords":
                        InsertDataToDBEmployee(row);
                        break;
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
        private void InsertDataToDBEmployee(DataGridViewRow drow)
        {
            string empId;
            string empstatus;
            string empLastname;
            string empFirstname;
            string Middlename;
            string address;
            string birthday;
            string civilstatus;
            string gender;
            string telephone;
            string position;
            string department;
            string IOEName;
            string IOEAddress;
            string IOEContact;
            string SSS;
            string HDMF;
            string PHIC;
            string TIN;
            double salary;
            string saltype;
            double salperday;
            DateTime HiredDate;
            DateTime RegularDate;
            DateTime DateEnd;
            string AcctNumber;
            string BankNumber;
            string CardNumber;
            TimeSpan ShiftStart; 
            TimeSpan ShiftEnd;

            empId = drow.Cells["EmployeeId"].Value.ToString();
            empstatus = drow.Cells["EmployeeStatus"].Value.ToString();
            empLastname = drow.Cells["Lastname"].Value.ToString();
            empFirstname = drow.Cells["Firstname"].Value.ToString();
            Middlename = drow.Cells["Middlename"].Value.ToString();
            address = drow.Cells["Address"].Value.ToString();
            birthday  = drow.Cells["Birthday"].Value.ToString();
            civilstatus = drow.Cells["CivilStatus"].Value.ToString();
            gender = drow.Cells["Gender"].Value.ToString();
            telephone = drow.Cells["Telephone"].Value.ToString();
            position = drow.Cells["Position"].Value.ToString();
            department = drow.Cells["Department"].Value.ToString();
            IOEName = drow.Cells["IOE Name"].Value.ToString();
            IOEAddress = drow.Cells["IOE Address"].Value.ToString();
            IOEContact = drow.Cells["IOE Telephone"].Value.ToString();
            SSS = drow.Cells["SSS"].Value.ToString();
            HDMF = drow.Cells["HDMF"].Value.ToString();
            PHIC = drow.Cells["PHIC"].Value.ToString();
            TIN = drow.Cells["TIN"].Value.ToString();
            salary = helpers.getDouble(drow.Cells["SALARY"].Value.ToString());
            saltype = drow.Cells["SALARY TYPE"].Value.ToString();
            salperday = helpers.getDouble(drow.Cells["RATE PER DAY"].Value.ToString());
            HiredDate = helpers.getDate(drow.Cells["Date Hired"].Value.ToString());
            RegularDate = helpers.getDate(drow.Cells["Date Regular"].Value.ToString());
            DateEnd = helpers.getDate(drow.Cells["Date End"].Value.ToString());
            AcctNumber = drow.Cells["AccountNumber"].Value.ToString();
            BankNumber = drow.Cells["Bank Number"].Value.ToString();
            CardNumber = drow.Cells["CardNumber"].Value.ToString();
            ShiftStart = helpers.getTime(drow.Cells["Working Shift Start"].Value.ToString());
            ShiftEnd = helpers.getTime(drow.Cells["Working Shift End"].Value.ToString());

            string SQL = SQLStatement.QueryInsertEmployee(empId, empstatus, empLastname, empFirstname, Middlename,
             address, birthday, civilstatus, gender, telephone, position, department,
             IOEName, IOEAddress, IOEContact, SSS, HDMF, PHIC, TIN, salary, saltype,
             salperday, HiredDate, RegularDate, DateEnd, AcctNumber, BankNumber, CardNumber,
             ShiftStart, ShiftEnd);

            cdb.InsertQuery(SQL);
        }
    }
}
