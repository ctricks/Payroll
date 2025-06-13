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
            if(!cDatabase.checkDatabaseExists())
            {
                MessageBox.Show("Error: No database found. Please check your administrator", "Payroll System : Database Not Found", MessageBoxButtons.OK,MessageBoxIcon.Error);
                isDatabaseErrror = true;   
                Environment.Exit(0);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int UserIDLogin = -1;
            if(!clsUserFunc.validateLoginUsers(tbUsername.Text, tbPassword.Text))
            {
                MessageBox.Show("Error: Invalid Username or Password", "Payroll System : Please enter your credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!clsUserFunc.LoginUsers(tbUsername.Text,tbPassword.Text,out UserIDLogin))
            {
                MessageBox.Show("Error: Username not found or Invalid Password. Please ask your adminstrator", "Payroll System : Please enter your credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.UserIDLogin =  UserIDLogin;
            mainForm.ShowDialog();
        }
    }
}
