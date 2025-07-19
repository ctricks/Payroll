using OfficeOpenXml.Style;
using PayrollSystem.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        public string UserName;

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
            //for upload checkbox 
            bool ForUpload = false;
            bool.TryParse(helpers.GetIniValue("ForUpload", "Online", "False"),out ForUpload);

            cbUploadOnline.Checked = ForUpload;
            cbUploadOnline.Enabled = ForUpload;

        }

        private void clearFields()
        {
            string clearField = string.Empty;
            tbEmpID.Text = clearField;
            tbEmployeeName.Text =   clearField;
            tbWorkingShift.Text = clearField;
            tbTimeIn.Text = clearField;
            tbTimeOut.Text = clearField;    
            tbNotes.Text = clearField;
            tb_THW.Text = clearField;
            tb_TTH.Text = clearField;
            tb_TUH.Text = clearField;
            tbNotes.ReadOnly = true;
            btnProcess.Enabled = false;
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
            if (!Directory.Exists(tbProcessingDirectory.Text))
            {
                MessageBox.Show("Path: " + tbProcessingDirectory.Text, "Error: Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start("explorer.exe",tbProcessingDirectory.Text);            
        }
        public async Task ProcessPayroll()
        {
            CheckForIllegalCrossThreadCalls = false;
            await Task.Run(() =>
            {
                string oldLabel = lblProcess.Text;
                lblProcess.Text = "Checking Directory Path...";
                if (!Directory.Exists(tbProcessingDirectory.Text))
                {
                    lblProcess.Text = "Error Directory Path...";
                    MessageBox.Show("Error: Path Not exists. Please check if first.", "Cannot continue process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblProcess.Text = oldLabel;
                    return;
                }
                lblProcess.Text = "Checking Directory Path...OK";
                ScannedExcelInformation = new List<Functions.clsAttendance.ExcelInformation>();
                lblProcess.Text = "Scanning Directory Path...OK";
                ScannedExcelInformation = attendancehelper.ScanDirectory(tbProcessingDirectory.Text, intUserID);
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
                        List<clsAttendance.ExcelInformation> Excelinfo = attendancehelper.ScanDirectory(ei.ExcelFilePath, intUserID);
                        FileFoundInfo[1] = ScannedExcelInformation[filecounter].AttendanceInfo.Count.ToString();
                        FileFoundInfo[2] = "Done";
                        ListViewItem lvi = new ListViewItem(FileFoundInfo);
                        listView1.Items.Add(lvi);
                        filecounter++;
                    }
                    lblProcess.Text = "Done Processing...: "+ DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearFields();
            listView1.Items.Clear();

            DataTable dtEmplist = new DataTable();
            dtEmplist.Columns.Add("EmployeeNumber");
            dtEmplist.Columns.Add("Employee");
            dtEmplist.Columns.Add("Verify", System.Type.GetType("System.Boolean"));

            dgEmpList.DataSource = dtEmplist;

            DataTable dtEmpAtt = new DataTable();
            dtEmpAtt.Columns.Add("Date");
            dtEmpAtt.Columns.Add("Day");
            dtEmpAtt.Columns.Add("Time IN");
            dtEmpAtt.Columns.Add("Time OUT");
            dtEmpAtt.Columns.Add("Time IN 2");
            dtEmpAtt.Columns.Add("Time OUT 2");
            dtEmpAtt.Columns.Add("Time IN 3");
            dtEmpAtt.Columns.Add("Time OUT 3");
            dtEmpAtt.Columns.Add("Final IN");
            dtEmpAtt.Columns.Add("Final OUT");
            dtEmpAtt.Columns.Add("Work_Hours");
            dtEmpAtt.Columns.Add("Late_Hours");
            dtEmpAtt.Columns.Add("Undertime_Hours");

            dgAttendance.DataSource = dtEmpAtt;
            ProcessPayroll();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string xlsfilename = listView1.SelectedItems[0].Text;
            List<AttendanceInfo>ScannedInfo = ScannedExcelInformation.Find(x=>x.Filename == xlsfilename).AttendanceInfo;
            if (ScannedInfo.Count > 0)
            {
                DataTable dtEmplist = new DataTable();
                dtEmplist.Columns.Add("EmployeeNumber");
                dtEmplist.Columns.Add("Employee");
                dtEmplist.Columns.Add("Verify",System.Type.GetType("System.Boolean"));

                foreach (AttendanceInfo ei in ScannedInfo) 
                {
                    DataRow drow = dtEmplist.NewRow();
                    drow["EmployeeNumber"] = ei.EmpNumber.ToString();
                    drow["Employee"] = ei.EmployeeName; //attendancehelper.GetEmployeeNameByBiometricID(ei);
                    drow["Verify"] = false;
                    dtEmplist.Rows.Add(drow);                    
                }
                dgEmpList.DataSource = dtEmplist;
            }else
            {
                MessageBox.Show("Error: No Employee found on the file. Please check it first", "No Employee found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgEmpList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgEmpList.SelectedRows.Count == 1)
            {
                clearFields();
                string EmployeeID = dgEmpList.SelectedRows[0].Cells[0].Value.ToString();

                string xlsfilename = listView1.SelectedItems[0].Text;
                List<AttendanceInfo> ScannedInfo = ScannedExcelInformation.Find(x => x.Filename == xlsfilename).AttendanceInfo;

                AttendanceInfo AI =  ScannedInfo.Find(x=>x.EmpNumber == EmployeeID);
                

                if (ScannedInfo.Count > 0)
                {                    
                    List<ExcelInfo> xinfo = ScannedInfo.Find(x => x.EmpNumber == EmployeeID).ExcelInfo;
                    
                    if (xinfo != null)
                    {
                        tbEmpID.Text = EmployeeID;
                        tbEmployeeName.Text = string.IsNullOrEmpty(AI.EmployeeName) ? "" : AI.EmployeeName;
                        tbWorkingShift.Text = string.IsNullOrEmpty(AI.WorkShift.WSLabel) ? "" : AI.WorkShift.WSLabel;
                        tbTimeIn.Text = string.IsNullOrEmpty(AI.WorkShift.StartTime.ToString()) ? "" : AI.WorkShift.StartTime.ToString("hh:mm tt");
                        tbTimeOut.Text = string.IsNullOrEmpty(AI.WorkShift.EndTime.ToString()) ? "" : AI.WorkShift.EndTime.ToString("hh:mm tt");

                        DataTable dtEmpAtt = new DataTable();
                        dtEmpAtt.Columns.Add("Date");
                        dtEmpAtt.Columns.Add("Day");
                        dtEmpAtt.Columns.Add("Time IN");
                        dtEmpAtt.Columns.Add("Time OUT");
                        dtEmpAtt.Columns.Add("Time IN 2");
                        dtEmpAtt.Columns.Add("Time OUT 2");
                        dtEmpAtt.Columns.Add("Time IN 3");
                        dtEmpAtt.Columns.Add("Time OUT 3");
                        dtEmpAtt.Columns.Add("Final IN");
                        dtEmpAtt.Columns.Add("Final OUT");
                        dtEmpAtt.Columns.Add("Work_Hours");
                        dtEmpAtt.Columns.Add("Late_Hours");
                        dtEmpAtt.Columns.Add("Undertime_Hours");

                        foreach (ExcelInfo excelInfo in xinfo)
                        {                            
                            
                            DataRow drow = dtEmpAtt.NewRow();
                            drow["Date"] = excelInfo.DateFound;

                            DateTime dtFound = helpers.getDate(excelInfo.DateFound);

                            drow["Day"] =dtFound.DayOfWeek.ToString();
                            drow["Time IN"] = excelInfo.TimeIn_1.ToString("HH:mm:ss") == "00:00:00" ? "": excelInfo.TimeIn_1.ToString("HH:mm:ss");
                            drow["Time OUT"] = excelInfo.TimeIn_2.ToString("HH:mm:ss") == "00:00:00" ? "" : excelInfo.TimeIn_2.ToString("HH:mm:ss");
                            drow["Time IN 2"] = excelInfo.TimeIn_3.ToString("HH:mm:ss") == "00:00:00" ? "" : excelInfo.TimeIn_3.ToString("HH:mm:ss");
                            drow["Time OUT 2"] = excelInfo.TimeIn_4.ToString("HH:mm:ss") == "00:00:00" ? "" : excelInfo.TimeIn_4.ToString("HH:mm:ss");
                            drow["Time IN 3"] = excelInfo.TimeIn_5.ToString("HH:mm:ss") == "00:00:00" ? "" : excelInfo.TimeIn_5.ToString("HH:mm:ss");
                            drow["Time OUT 3"] = excelInfo.TimeIn_6.ToString("HH:mm:ss") == "00:00:00" ? "" : excelInfo.TimeIn_6.ToString("HH:mm:ss");
                            drow["Final IN"] = excelInfo.TimeInFinal.ToString("HH:mm:ss") == "00:00:00" ? "" : excelInfo.TimeInFinal.ToString("HH:mm:ss");
                            drow["Final OUT"] = excelInfo.TimeOutFinal.ToString("HH:mm:ss") == "00:00:00" ? "" : excelInfo.TimeOutFinal.ToString("HH:mm:ss");
                            drow["Work_Hours"] = excelInfo.TotalTimeRow.ToString("HH:mm:ss");                            
                            drow["Late_Hours"] = excelInfo.Late.ToString("HH:mm:ss");
                            drow["Undertime_Hours"] = excelInfo.UnderTime.ToString("HH:mm:ss");

                            dtEmpAtt.Rows.Add(drow);
                        }
                        dgAttendance.DataSource = dtEmpAtt;
                    }
                }
            }
            CheckAttendance();
            tbNotes.ReadOnly = false;
            btnProcess.Enabled = true;
        }

        private void CheckAttendance()
        {
            TimeSpan dtTotalWorkingHours = new TimeSpan();
            TimeSpan dtTotalTardinessHours = new TimeSpan();
            TimeSpan dtTotalUndertimeHours = new TimeSpan();

            foreach (DataGridViewRow drow  in dgAttendance.Rows)
            {
                TimeSpan ts_WorkingHours = TimeSpan.Parse(drow.Cells["Work_Hours"].Value.ToString());
                TimeSpan ts_TardinesHours = TimeSpan.Parse(drow.Cells["Late_Hours"].Value.ToString());
                TimeSpan ts_UndertimeHours = TimeSpan.Parse(drow.Cells["Undertime_Hours"].Value.ToString());

                dtTotalWorkingHours = dtTotalWorkingHours.Add(ts_WorkingHours);
                dtTotalTardinessHours = dtTotalTardinessHours.Add(ts_TardinesHours);
                dtTotalUndertimeHours = dtTotalUndertimeHours.Add(ts_UndertimeHours);

                if (drow.Cells["Work_Hours"].Value.ToString() == "00:00:00")
                {
                    drow.Cells["Work_Hours"].Style.BackColor = Color.Red;
                }
                if (drow.Cells["Late_Hours"].Value.ToString() != "00:00:00")
                {
                    drow.Cells["Late_Hours"].Style.ForeColor = Color.Red;
                }
                if (drow.Cells["Undertime_Hours"].Value.ToString() != "00:00:00")
                {
                    drow.Cells["Undertime_Hours"].Style.ForeColor = Color.Red;
                }
            }

            var totalMinutes = dtTotalWorkingHours.TotalMinutes;
            var totalTardiness = dtTotalTardinessHours.TotalMinutes;
            var totalUndertime = dtTotalUndertimeHours.TotalMinutes;

            var timeWH = TimeSpan.FromMinutes(totalMinutes);
            var timeTH = TimeSpan.FromMinutes(totalTardiness);
            var timeUH = TimeSpan.FromMinutes(totalUndertime);


            tb_THW.Text = (int)timeWH.TotalHours + ":" + timeWH.Minutes;
            tb_TTH.Text = (int)timeTH.TotalHours + ":" + timeTH.Minutes;
            tb_TUH.Text = (int)timeUH.TotalHours + ":" + timeUH.Minutes;
            tb_Approver.Text = UserName;
        }

        private void dgEmpList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmpID.Text))
            {
                MessageBox.Show("Error: Cannot process the payroll. Please check your entries.", "Missing Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
