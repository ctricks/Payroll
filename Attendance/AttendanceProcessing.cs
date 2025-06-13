using PayrollSystem.Functions;
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
        Functions.clsAttendance attendancehelper = new Functions.clsAttendance();
        Functions.clsHelpers helpers = new Functions.clsHelpers();
        string DefaultPath = Environment.CurrentDirectory + "\\AttendanceProcessing";

        List<Functions.clsAttendance.ExcelInformation> ScannedExcelInformation;

        public int intUserID;

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
            InitializeForm();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string AttendanceFilePath = Environment.CurrentDirectory + "\\Resources\\Template\\";
            string AttendanceFile = "TimeAttendanceExcelTemplate.xlsx";

            if(!File.Exists(AttendanceFilePath + AttendanceFile))
            {
                MessageBox.Show("Path: " + AttendanceFilePath + AttendanceFile, "Error: Excel File not found", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            DialogResult dres = MessageBox.Show("Do you want to download the excel template format?", "Download Attendance Template", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dres == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(AttendanceFilePath + AttendanceFile);
            }
        }

        private void btnOpenFileDirectory_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbProcessingDirectory.Text))
            {
                MessageBox.Show("Path: " + tbProcessingDirectory.Text, "Error: Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(tbProcessingDirectory.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldLabel = lblProcess.Text;
            lblProcess.Text = "Checking Directory Path...";
            if(!Directory.Exists(tbProcessingDirectory.Text))
            {
                lblProcess.Text = "Error Directory Path...";
                MessageBox.Show("Error: Path Not exists. Please check if first.", "Cannot continue process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblProcess.Text = oldLabel;
                return;
            }
            lblProcess.Text = "Checking Directory Path...OK";
            ScannedExcelInformation = new List<Functions.clsAttendance.ExcelInformation>();
            lblProcess.Text = "Scanning Directory Path...OK";
            ScannedExcelInformation = attendancehelper.ScanDirectory(tbProcessingDirectory.Text,intUserID);
            lblProcess.Text = "File Found: " + ScannedExcelInformation.Count;

            listView1.Items.Clear();

            if (ScannedExcelInformation.Count > 0)
            {
                ListViewItem listitem = new ListViewItem();
                int filecounter = 0;
                foreach (clsAttendance.ExcelInformation ei in ScannedExcelInformation)
                {
                    lblProcess.Text = "Processing: " + ei.Filename;
                    string[] FileFoundInfo = new string[3];
                    FileFoundInfo[0] = ei.Filename;                    
                    List<clsAttendance.ExcelInformation>Excelinfo = attendancehelper.ScanDirectory(ei.ExcelFilePath, intUserID);
                    FileFoundInfo[1] = ScannedExcelInformation[filecounter].AttendanceInfo.Count.ToString();
                    FileFoundInfo[2] = "Done";
                    ListViewItem lvi = new ListViewItem(FileFoundInfo);                    
                    listView1.Items.Add(lvi);
                    filecounter++;
                }            
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string xlsfilename = listView1.SelectedItems[0].Text;
            List<AttendanceInfo>ScannedInfo = ScannedExcelInformation.Find(x=>x.Filename == xlsfilename).AttendanceInfo;
            if (ScannedInfo.Count > 0)
            {
                DataTable dtEmplist = new DataTable();
                dtEmplist.Columns.Add("BiometricID");
                dtEmplist.Columns.Add("Employee");
                dtEmplist.Columns.Add("Verify",System.Type.GetType("System.Boolean"));

                foreach (int ei in ScannedInfo.Select(x=>x.BiometricID).Distinct()) 
                {
                    DataRow drow = dtEmplist.NewRow();
                    drow["BiometricID"] = ei.ToString();
                    drow["Employee"] = attendancehelper.GetEmployeeNameByBiometricID(ei);
                    drow["Verify"] = false;
                    dtEmplist.Rows.Add(drow);
                }
                dgEmpList.DataSource = dtEmplist;
            }
        }

        private void dgEmpList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgEmpList.SelectedRows.Count == 1)
            {
                string BioMetricID = dgEmpList.SelectedRows[0].Cells[0].Value.ToString();
                string xlsfilename = listView1.SelectedItems[0].Text;
                List<AttendanceInfo> ScannedInfo = ScannedExcelInformation.Find(x => x.Filename == xlsfilename).AttendanceInfo;
                if (ScannedInfo.Count > 0)
                {
                    List<ExcelInfo> xinfo = ScannedInfo.Find(x => x.BiometricID == int.Parse(BioMetricID)).ExcelInfo;

                    if (xinfo != null)
                    {
                        DataTable dtEmpAtt = new DataTable();
                        dtEmpAtt.Columns.Add("Date");
                        dtEmpAtt.Columns.Add("Day");
                        dtEmpAtt.Columns.Add("Time_1");
                        dtEmpAtt.Columns.Add("Time_2");
                        dtEmpAtt.Columns.Add("Time_3");
                        dtEmpAtt.Columns.Add("Time_4");
                        dtEmpAtt.Columns.Add("Work_Hours");

                        foreach (ExcelInfo excelInfo in xinfo)
                        {
                            DataRow drow = dtEmpAtt.NewRow();
                            drow["Date"] = excelInfo.AttendanceDate.ToString("MM-dd-yyyy");
                            drow["Day"] = excelInfo.AttendanceDate.DayOfWeek.ToString();
                            drow["Time_1"] = excelInfo.TimeIn_1.ToString("HH:mm:ss");
                            drow["Time_2"] = excelInfo.TimeIn_2.ToString("HH:mm:ss");
                            drow["Time_3"] = excelInfo.TimeIn_3.ToString("HH:mm:ss");
                            drow["Time_4"] = excelInfo.TimeIn_4.ToString("HH:mm:ss");
                            drow["Work_Hours"] = excelInfo.TotalTimeRow.ToString("HH:mm:ss"); 

                            dtEmpAtt.Rows.Add(drow);
                        }
                        dgAttendance.DataSource = dtEmpAtt;
                    }
                }
            }            
        }
    }
}
