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

namespace PayrollSystem.Attendance
{
    public partial class AttendanceProcessing : Form
    {
        Functions.clsHelpers helpers = new Functions.clsHelpers();
        string DefaultPath = Environment.CurrentDirectory + "\\AttendanceProcessing";
        public AttendanceProcessing()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            tbProcessingDirectory.Text = helpers.GetIniValue("ProcessingDirectory", "Attendance", DefaultPath);

            if (!Directory.Exists(DefaultPath))
            {
                Directory.CreateDirectory(DefaultPath);
                tbProcessingDirectory.Text = DefaultPath;
            }
        }

        private void AttendanceProcessing_Load(object sender, EventArgs e)
        {

        }

        private void btnBrwsePD_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();   
            folderBrowserDialog.ShowDialog();

            if (Directory.Exists(folderBrowserDialog.SelectedPath))
            {
                tbProcessingDirectory.Text = folderBrowserDialog.SelectedPath;
                DefaultPath = folderBrowserDialog.SelectedPath;
            }
            else
            {
                MessageBox.Show("Error: Invalid Directory Path.Please ask your administrator", "Payroll System: Attendance Processing Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(!Directory.Exists(DefaultPath))
                {
                    Directory.CreateDirectory(DefaultPath);
                    tbProcessingDirectory.Text = DefaultPath;                    
                }                
            }
            helpers.SetIni("ProcessingDirectory", "Attendance", DefaultPath);
        }
    }
}
