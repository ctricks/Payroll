using PayrollSystem.Functions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.ImportData
{
    public partial class frmImportData : Form
    {
        public string processCode;
        public string TemplateName;
        DataTable dtImport  = new DataTable();  
        clsHelpers cHelpers = new clsHelpers();

        public frmImportData()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open your excel file here...";
            ofd.Filter = "Excel Files|*.xls;*.xlsx;";
            
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                tbFilename.Text = ofd.FileName;
                ofd.CheckPathExists = true;
                ofd.CheckFileExists = true;
            }    
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if(tbFilename.Text == string.Empty)
            {
                MessageBox.Show("Error: Please select file to import", "Import Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dtImport = cHelpers.GetDataTableFromExcel(tbFilename.Text,true);
            if (dtImport.Rows.Count == 0)
            {
                MessageBox.Show("Error: No Data to import", "Import Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblProgressVal.Text = "Total Rows Found: " + dtImport.Rows.Count;
            //Validation Checking...
            clsValidationChecks valChecks = new clsValidationChecks();
            if(valChecks.CheckForUniqueField("EmployeeId", dtImport))
            {
                dgview.DataSource = dtImport;
                dgview.Refresh();
            }else
            {

            }
        }

        private void lnklblDownloadTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dres = MessageBox.Show("Do you want to download the "+ TemplateName +" File?", "Download Template?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dres == DialogResult.Yes)
            {
                //string FileHoliday = "HolidaysTemplate.xlsx";
                string TemplateFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Template", TemplateName);

                string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads", TemplateName);

                if (!File.Exists(TemplateFilePath))
                {
                    MessageBox.Show("Error: Template not found. Please contact your administrator", "Missing "+ TemplateName + " Template file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (File.Exists(downloadsFolder))
                {
                    File.Delete(downloadsFolder);
                }

                File.Copy(TemplateFilePath, downloadsFolder);

                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.UseShellExecute = true;
                processStartInfo.FileName = downloadsFolder;
                Process.Start(processStartInfo);
            }
        }

        private void frmImportData_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgview.Rows.Count == 0)
            {
                MessageBox.Show("Error: No data to Import. Please check the file", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bgImport.RunWorkerAsync();
        }

        private void bgImport_DoWork(object sender, DoWorkEventArgs e)
        {
            int percent = 0;
            int totalProgress = dgview.Rows.Count;
            int currentProgress = 0;
            foreach (DataGridViewRow row in dgview.Rows)
            {

                clsProcessImport processImport = new clsProcessImport();
                processImport.processImport(row,processCode);
                currentProgress++;
                percent = (currentProgress * 100) / totalProgress;
                bgImport.ReportProgress(percent);
            }
        }

        private void bgImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done saving details.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
