using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.Holidays
{
    public partial class frmHolidays : Form
    {
        public int UserID;
        Functions.clsHelpers chelper = new Functions.clsHelpers();
        Functions.clsHolidayFunctions hol = new Functions.clsHolidayFunctions();
        public frmHolidays()
        {
            InitializeComponent();
        }

        public void HolidaySetup()
        {
            cbYear.DataSource = hol.setupYear();
            cbYear.DisplayMember = "Date";
            cbYear.ValueMember = "Date";
            dgHolidayList.DataSource = hol.dtGetHolidateDetails();
            dgHolidayList.Refresh();            
        }

        private void frmHolidays_Load(object sender, EventArgs e)
        {
            HolidaySetup();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload File for Holiday Entries";
            ofd.Filter = "Excel Files|*.xls;*.xlsx;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                tbFileUpload.Text = ofd.FileName;   
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbFileUpload.Text))
            {
                MessageBox.Show("Error: Cannot continue upload. Invalid File selected", "Upload File is missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult drRes = MessageBox.Show("Are you sure you want to upload this file?", "Note: This will overwrite your existing Holidays", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drRes == DialogResult.Yes)
            {
                bgwInsertExcel.RunWorkerAsync();
            }
        }

        private void lnkHolidayTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dres = MessageBox.Show("Do you want to download the Holiday Template File?", "Download Holidate Template?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dres == DialogResult.Yes)
            {
                hol.DownloadHolidayTemplate();
            }
        }

        private void bgwInsertExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            DataTable dtHolidayUpload = hol.ReadExcelFile(tbFileUpload.Text);
            if (dtHolidayUpload != null)
            {
                int counter = 0;
                int TotalCount = dtHolidayUpload.Rows.Count;
                foreach (DataRow dr in dtHolidayUpload.Rows)
                {
                    lblProgressVal.Text = "Processing " + counter + " of " + TotalCount;

                    string CalendarDate = dr["Holiday Date"].ToString();
                    string HolidayName = dr["Holiday Name"].ToString();
                    string HolType = dr["Holiday Type"].ToString();

                    hol.InsertHolidays(chelper.getDate(CalendarDate),HolidayName,HolType,UserID,"Insert by Upload");

                    int percentComplete = (int)(((double)counter / TotalCount) * 100);
                    bgwInsertExcel.ReportProgress(percentComplete);                    
                    counter++;
                }
                bgwInsertExcel.ReportProgress(100);                
                lblProgressVal.Text = "Processing " + counter + " of " + TotalCount;
            }
        }

        private void bgwInsertExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwInsertExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done Uploading File.");
            HolidaySetup();
        }
    }
}
