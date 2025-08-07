using PayrollSystem.Database;
using PayrollSystem.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class frmLogin : Form
    {
        clsDatabase cDatabase = new clsDatabase();
        clsUserFunctions clsUserFunc = new clsUserFunctions();
        clsHelpers clsHelpers = new clsHelpers();
        QUERIES.QUsers Qstring = new QUERIES.QUsers();

        bool isMSAccess = false;
        string ConnStr = string.Empty;
        bool isDatabaseErrror = false;
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult drRes = MessageBox.Show("Would you like to close the Payroll Application?", "Close Application?", MessageBoxButtons.YesNo);

                if (drRes == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the form closing
                    return;
                }
                else
                {
                    // Close the entire application
                    Application.Exit();
                }
            }            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {   
            isMSAccess = clsHelpers.GetBool(clsHelpers.GetIniValue("UseMSAccess", "DatabaseSettings", "false"));

            if (!cDatabase.checkDatabaseExists() && isMSAccess)
            {
                MessageBox.Show("Error: No database found. Please check your administrator", "Payroll System : Access Database Not Found", MessageBoxButtons.OK,MessageBoxIcon.Error);
                isDatabaseErrror = true;   
                Environment.Exit(0);
            }
            
            if(!isMSAccess)
            {
                string serverType = clsHelpers.GetIniValue("ServerType", "DatabaseServer", "");
                string DatabaseName = clsHelpers.GetIniValue("DatabaseName", "DatabaseServer" , ""); //DatabaseName
                if(string.IsNullOrEmpty(DatabaseName))
                {
                    MessageBox.Show("Error: No database found. Please check your administrator", "Payroll System : MySQL Database Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isDatabaseErrror = true;
                    Environment.Exit(0);
                }
                if (serverType == "MySQL")
                {                    
                    ConnStr = cDatabase.setConnectionString(DatabaseName);
                    
                    if(!cDatabase.testConnectionString(ConnStr))
                    {
                        isDatabaseErrror = true;
                        Environment.Exit(0);
                    }
                }
            }   
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int UserIDLogin = -1; int RoleId = -1;
            if (!clsUserFunc.validateLoginUsers(tbUsername.Text, tbPassword.Text))
            {
                MessageBox.Show("Error: Invalid Username or Password", "Payroll System : Please enter your credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isMSAccess)
            {
                if (!clsUserFunc.LoginUsers(tbUsername.Text, tbPassword.Text, out UserIDLogin))
                {
                    MessageBox.Show("Error: Username not found or Invalid Password. Please ask your adminstrator", "Payroll System : Please enter your credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }else
            {
                string CheckUserQuery =  Qstring.LoginUser(tbUsername.Text,tbPassword.Text);
                DataTable dtRes = new DataTable();
                dtRes = cDatabase.getRecords(CheckUserQuery);
                if (dtRes.Rows.Count > 0)
                {
                    UserIDLogin = clsHelpers.GetInteger(dtRes.Rows[0][0].ToString());
                    RoleId = clsHelpers.GetInteger(dtRes.Rows[0]["tblmgb_users_role_id"].ToString());
                    if (UserIDLogin == 0)
                    {
                        MessageBox.Show("Error: Invalid Username or Password", "Payroll System : Please enter your credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (UserIDLogin == -1)
                    {
                        return;
                    }                    
                }else
                {
                    MessageBox.Show("Error: Invalid Username or Password", "Payroll System : Please enter your credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.UserIDLogin =  UserIDLogin;
            mainForm.RoleID = RoleId;
            mainForm.isMSAccess = isMSAccess;
            mainForm.UserNameLogin = tbUsername.Text;
            mainForm.ShowDialog();
        }
    }
}
