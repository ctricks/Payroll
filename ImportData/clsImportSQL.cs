using PayrollSystem.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayrollSystem.ImportData
{
    public class clsImportSQL
    {
        public string QueryInsertEmployee(string empId, string empstatus, string empLastname, string empFirstname, string Middlename,
            string address, string birthday, string civilstatus, string gender, string telephone,string position,string department,
            string IOEName,string IOEAddress,string IOEContact,string SSS,string HDMF,string PHIC,string TIN,double salary,string saltype,
            double salperday,DateTime HiredDate, DateTime RegularDate,DateTime DateEnd,string AcctNumber,string BankNumber,string CardNumber,
            TimeSpan ShiftStart, TimeSpan ShiftEnd)
        {
            string Query = "INSERT INTO tblmgb_employees\r\n" +
                "(`tblmgb_employees_employee_id`,`tblmgb_employees_status`,`tblmgb_employees_lastname`,`tblmgb_employees_firstname`"+
                ",`tblmgb_employees_middlename`,\r\n`tblmgb_employees_address`,`tblmgb_employees_birthday`,`tblmgb_employees_civilstatus`"+
                ",`tblmgb_employees_gender`,`tblmgb_employees_telephone`,\r\n`tblmgb_employees_position`,`tblmgb_employees_department`,"+
                "`tblmgb_employees_IOE_name`,`tblmgb_employees_IOE_address`,`tblmgb_employees_IOE_contact`,`tblmgb_employees_SSS`,"+
                "`tblmgb_employees_HDMF`,`tblmgb_employees_PHIC`,`tblmgb_employees_TIN`,`tblmgb_employees_SALARY`,`tblmgb_employees_SALType`,"+
                "`tblmgb_employees_SALPERDAY`,\r\n`tblmgb_employees_HiredDate`,`tblmgb_employees_RegularDate`,`tblmgb_employees_DateEnd`,"+
                "`tblmgb_employees_AccountNumber`,\r\n`tblmgb_employees_BankNumber`,`tblmgb_employees_CardNumber`,`tblmgb_employees_WStart`," +
                "`tblmgb_employees_WEnd`)\r\nVALUES (\r\n" + "'"+ empId +"','" + empstatus + "','"+empLastname+"','"+empFirstname+"','"+Middlename+"'"+
                ",'"+ address +"','"+ birthday +"','"+ civilstatus +"',"+"'"+ gender +"','"+telephone+"',\r\n'"+position+"','"+department+"',"+
                "'"+ IOEName +"','"+IOEAddress+"','"+ IOEContact +"','"+SSS+"','"+HDMF+"'," + "'"+PHIC+"','"+TIN+"','"+salary+"','"+saltype+"','"+salperday+"',"+
                "'"+HiredDate+"','"+ RegularDate +"','" +DateEnd+ "','"+AcctNumber+"',\r\n'"+ BankNumber +"','"+CardNumber+"','"+ShiftStart+"','"+ShiftEnd+"');";
           
            return Query;
        }
    }
}
