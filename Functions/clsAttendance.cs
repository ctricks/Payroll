using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.Style;
using PayrollSystem.Attendance;
using PayrollSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.Functions
{
    public class clsAttendance
    {
        clsDatabase dbHelper = new clsDatabase();   
        public class ExcelInformation
        {
            public string ExcelFilePath { get; set; }
            public string Filename{ get; set; }
            public DateTime DateProcess { get; set; }
            public int UserIDProcess { get; set; }            
            public List<AttendanceInfo> AttendanceInfo { get; set; }
        }

        public string GetEmployeeNameByBiometricID(int BiometricID)
        {
            string strResult = string.Empty;
            try
            {
                string Query = "Select Lastname + ',' + Firstname + ' ' + Middlename from tblPSD_201File where BioID = " + BiometricID;
                DataTable dtResult = dbHelper.getRecords(Query);
                if(dtResult.Rows.Count > 0)
                {
                    strResult = dtResult.Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {

            }
            return strResult;
        }

        public List<ExcelInformation> ScanDirectory(string DirectoryPath,int UserID)
        {
            ExcelInformation excelInformation = new ExcelInformation();
            List<ExcelInformation> XlsResult = new List<ExcelInformation>();
            List<AttendanceInfo> AttendanceInformation = new List<AttendanceInfo>();    
            try
            {
                if (Directory.Exists(DirectoryPath))
                {
                    foreach (string FilenameFound in Directory.GetFiles(DirectoryPath))
                    {
                        FileInfo FileInfo = new FileInfo(FilenameFound);
                        if(FileInfo.Extension == ".xlsx")
                        {
                            excelInformation.Filename = FileInfo.Name;
                            excelInformation.DateProcess = DateTime.Now;
                            excelInformation.ExcelFilePath = FileInfo.FullName;
                            excelInformation.UserIDProcess = UserID;                            
                            AttendanceInformation = GetAttendanceInfo(FileInfo.FullName);
                            excelInformation.AttendanceInfo = AttendanceInformation;
                            XlsResult.Add(excelInformation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Scanning Excel Directory Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }


            return XlsResult;
        }
        private List<AttendanceInfo> GetAttendanceInfo(string ExcelFilepath)
        {
            List<AttendanceInfo>AttendInfo = new List<AttendanceInfo>();

            AttendanceInfo ai = new AttendanceInfo();
            FileInfo fi = new FileInfo(ExcelFilepath);
            
            List<ExcelInfo> Elist = new List<ExcelInfo>();


            Elist = ReadExcel(fi.FullName);

            if (Elist.Count > 0)
            {
                foreach (int E in Elist.Select(y=>y.BiometricID).Distinct().ToList())
                {
                    ai.BiometricID = E;
                    Elist.Find(x => x.BiometricID == ai.BiometricID);
                    ai.SourceFilename = fi.Name;
                    ai.ExcelInfo = Elist;
                    AttendInfo.Add(ai);
                }
            }

            return AttendInfo;
        }
        private List<AttendanceInfo>PrepareEmployeeAttendance(List<ExcelInfo>Elist)
        {
            List<AttendanceInfo> AttendInfo = new List<AttendanceInfo>();
            try
            {

            }
            catch (Exception)
            {

            }
            return AttendInfo;
        }
        private List<ExcelInfo>ReadExcel(string ExcelFilepath)
        {
            List<ExcelInfo>Ei = new List<ExcelInfo>();
            FileInfo fi = new FileInfo(ExcelFilepath);
            ExcelInfo xi = new ExcelInfo();

            using (ExcelPackage package = new ExcelPackage(fi))
            {                
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int colCount = worksheet.Dimension.End.Column;  
                int rowCount = worksheet.Dimension.End.Row;     
                
                for (int row = 1; row <= rowCount; row++)
                {
                    xi = new ExcelInfo();
                    for (int col = 1; col <= colCount; col++)
                    {
                        //Dates
                        if(col == 1 && row >= 2) 
                        {
                            if (worksheet.Cells[row, col].Value == null)
                            {
                                continue;
                            }
                            xi.AttendanceDate = CheckDates(worksheet.Cells[row, col].Value.ToString());
                        }
                        //Biometric
                        if (col == 2 && row >= 2)
                        {
                            if (worksheet.Cells[row, col].Value == null)
                            {
                                continue;
                            }
                            xi.BiometricID = CheckInt(worksheet.Cells[row, col].Value.ToString());
                        }
                        //TimeIN_1
                        if (col == 3 && row >= 2)
                        {
                            if (worksheet.Cells[row, col].Value == null)
                            {
                                continue;
                            }
                            xi.TimeIn_1 = CheckDates(worksheet.Cells[row, col].Value.ToString());
                        }
                        //TimeIN_2
                        if (col == 4 && row >= 2)
                        {
                            if (worksheet.Cells[row, col].Value == null)
                            {
                                continue;
                            }
                            xi.TimeIn_2 = CheckDates(worksheet.Cells[row, col].Value.ToString());
                        }
                        //TimeIN_3
                        if (col == 5 && row >= 2)
                        {
                            if(worksheet.Cells[row, col].Value == null)
                            {
                                continue;
                            }
                            xi.TimeIn_3 = CheckDates(worksheet.Cells[row, col].Value.ToString());
                        }
                        //TimeIN_4
                        if (col == 6 && row >= 2)
                        {
                            if (worksheet.Cells[row, col].Value == null)
                            {
                                continue;
                            }
                            xi.TimeIn_4 = CheckDates(worksheet.Cells[row, col].Value.ToString());
                        }
                    }
                    if (row >= 2)
                    {
                        xi.TotalTimeRow = TotalWorkHours(xi);
                        Ei.Add(xi);
                    }
                }
            }
            return Ei;
        }

        private DateTime CheckDates(string datevalue)
        {
            DateTime dtCheck = new DateTime(1901,01,01,00,00,00);
            try
            {
                dtCheck = DateTime.Parse(datevalue);
            }
            catch (Exception)
            {
            
            }
            return dtCheck;
        }
        private int CheckInt(string IntValue)
        {
            int intCheck = -1;
            try
            {
                intCheck = int.Parse(IntValue);
            }
            catch (Exception)
            {

            }
            return intCheck;            
        }
        private DateTime TotalWorkHours(ExcelInfo xi)
        {
            DateTime dtTotalWorkHours = new DateTime();
            try
            {
                TimeSpan time1 = TimeSpan.Parse(xi.TimeIn_1.ToString("HH:mm:ss"));
                TimeSpan time2 = TimeSpan.Parse(xi.TimeIn_2.ToString("HH:mm:ss"));
                TimeSpan time3 = TimeSpan.Parse(xi.TimeIn_3.ToString("HH:mm:ss"));
                TimeSpan time4 = TimeSpan.Parse(xi.TimeIn_4.ToString("HH:mm:ss"));

                TimeSpan Diff = new TimeSpan();

                if (xi.TimeIn_1 != null && xi.TimeIn_2 != null && time3.ToString() == "00:00:00" && time4.ToString() == "00:00:00")
                {
                    Diff = time2 - time1;
                }else if (xi.TimeIn_3 != null && xi.TimeIn_4 != null && time1.ToString() == "00:00:00" && time2.ToString() == "00:00:00")
                {
                    Diff = time4 - time3;
                }else if (xi.TimeIn_1 != null && xi.TimeIn_4 != null && time2.ToString() == "00:00:00" && time3.ToString() == "00:00:00")
                {
                    Diff = time4 - time1;
                }

                string TotalHours = Diff.ToString(@"hh\:mm\:ss");
                dtTotalWorkHours = DateTime.Parse(TotalHours);
            }
            catch (Exception)
            {
                TimeSpan Diff = TimeSpan.Parse("00:00:00");
                string TotalHours = Diff.ToString(@"hh\:mm\:ss");
                dtTotalWorkHours = DateTime.Parse(TotalHours);
            }
            return dtTotalWorkHours;
        }
    }
}
