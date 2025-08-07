using PayrollSystem.Functions;
using PayrollSystem.Holidays;
using PayrollSystem.Payroll;
using PayrollSystem.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class MainForm : Form
    {
        IniFile MyIni = new IniFile("Settings.ini");
        public bool isMSAccess;
        public int UserIDLogin;
        public string UserNameLogin;
        public int RoleID;
        private void InitializedMainForm()
        {
            string MainBackground = MyIni.Read("MainBackground", "ApplicationSettings");
            if (!File.Exists(MainBackground))
            {
                MainBackground = Environment.CurrentDirectory + "\\Resources\\Background.jpg";
            }

            if (File.Exists(MainBackground))
            {
                try
                {
                    this.BackgroundImage = Image.FromFile(MainBackground);
                }
                catch (Exception ex)
                {

                }
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to Log-out User?", "Log-out User?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
                frmLogin login = new frmLogin();                
                login.Show();
            }
        }

        private void exToolStripMenuItem_Click(object sender, EventArgs e)
        {            
                DialogResult drRes = MessageBox.Show("Would you like to close the Payroll Application?", "Close Application?", MessageBoxButtons.YesNo);

                if (drRes == DialogResult.Yes)
                {                    
                    Environment.Exit(0);
                }            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult drRes = MessageBox.Show("Would you like to close the Payroll Application?", "Close Application?", MessageBoxButtons.YesNo);

            if (drRes == DialogResult.Yes)
            {
                Environment.Exit(0);
            }else
            {
                e.Cancel = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializedMainForm();
        }

        private void masterlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee.EmpMasterFile empForm = new Employee.EmpMasterFile();             
            empForm.MdiParent = this;
            empForm.isMsAccess = isMSAccess;
            empForm.Show();
        }

        private void processingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.AttendanceProcessing attendanceProcessing = new Attendance.AttendanceProcessing();   
            attendanceProcessing.MdiParent = this;
            attendanceProcessing.intUserID = UserIDLogin;
            attendanceProcessing.UserName = UserNameLogin;
            attendanceProcessing.Show();
        }

        private void coverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayrollCoverage coverage = new frmPayrollCoverage();
            coverage.Username= UserNameLogin;
            coverage.Show();
        }

        private void systemPreferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!isMSAccess)
            {
                FrmSettings frmSettings = new FrmSettings();
                frmSettings.MdiParent = this;
                frmSettings.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!isMSAccess)
            {
                frmHolidays frmHol = new frmHolidays();
                frmHol.MdiParent = this;
                frmHol.UserID = UserIDLogin;
                frmHol.Show();
            }
        }
    }
}
