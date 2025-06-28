using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Utilities;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.Functions
{
    public class clsAttendance
    {
        clsDatabase dbHelper = new clsDatabase();  
        clsHelpers helper = new clsHelpers();
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
                        if(FileInfo.Extension == ".csv" || FileInfo.Extension == ".xlsx" || FileInfo.Extension == ".xls")
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

            if(fi.Extension.ToString() == ".xlsx" || fi.Extension.ToString() == ".xlsx")
            {
                Elist = ReadExcel(fi.FullName);
            }else if(fi.Extension.ToString() == ".csv")
            {
                Elist = ReadCSV(fi.FullName); 
            }

            var EmpFound = Elist.GroupBy(o => o.EmployeeNumber).Select(g => g.First()).ToList();

            if (EmpFound.Count > 0)
            {
                foreach (ExcelInfo E in EmpFound)
                {
                    ai = new AttendanceInfo();
                    ai.EmpNumber = E.EmployeeNumber;
                    ai.EmployeeName = E.EmployeeName;
                    ai.SourceFilename = fi.Name;
                    ai.ExcelInfo = Elist.Where(x=>x.EmployeeNumber == E.EmployeeNumber).ToList();
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
        private List<ExcelInfo>ReadCSV(string CSVFilePath)
        {
            List<ExcelInfo> Ei = new List<ExcelInfo>();
            try
            {   
                FileInfo fi = new FileInfo(CSVFilePath);
                ExcelInfo xi = new ExcelInfo();

                string[] FileContent = File.ReadAllLines(fi.FullName);

                if (FileContent[FileContent.Count() - 1].ToString() != ",,,,,,")
                {
                    //Append to last line
                    File.AppendAllText(fi.FullName, ",,,,,,");
                }
                FileContent = File.ReadAllLines(fi.FullName);

                List<EmployeeDetails> employeeDetail = new List<EmployeeDetails>();



                bool isEmpFound = false;
                int isIntegerFound = -1;

                if (FileContent.Count() > 0)
                {
                    ExcelInfo ei = new ExcelInfo();
                    string EmployeeNumber = string.Empty;
                    string EmployeeName = string.Empty;
                    foreach (string fileline in FileContent)
                    {
                        string LineContent = fileline;

                        if (fileline.Substring(0, 1) == "\"" && fileline != ",,,,,,")
                        {
                            isEmpFound = true;
                            EmployeeDetails empData = new EmployeeDetails();
                            string EmpPattern = "\\((\\d+)\\)";
                            EmployeeNumber = helper.GetEmployeeNumber(helper.GetRegex(EmpPattern, LineContent));
                            string EmpNamePattern = "\\\"\\S.+\\,.+\\(";
                            EmployeeName = helper.GetRegex(EmpNamePattern, LineContent).Replace("\"", "").Replace("(", "");
                            employeeDetail.Add(empData);
                            continue;
                        }
                        if (isEmpFound)
                        {
                            isIntegerFound = helper.GetInteger(LineContent.Substring(0, 1));
                            if (isIntegerFound > 0)
                            {
                                string[] timeDetails = LineContent.Split(',');
                                string DateFound = timeDetails[0].Split(' ')[0].ToString();
                                ei.DateFound = DateFound;
                                ei.EmployeeNumber = EmployeeNumber;
                                ei.EmployeeName = EmployeeName;
                                ei.TimeIn_1_Found = timeDetails[1].ToString();
                                ei.TimeIn_1 = helper.GetTimeConvert(ei.TimeIn_1_Found);
                                ei.TimeIn_2_Found = timeDetails[2].ToString();
                                ei.TimeIn_2 = helper.GetTimeConvert(ei.TimeIn_2_Found);
                                ei.TimeIn_3_Found = timeDetails[3].ToString();
                                ei.TimeIn_3 = helper.GetTimeConvert(ei.TimeIn_3_Found);
                                ei.TimeIn_4_Found = timeDetails[4].ToString();
                                ei.TimeIn_4 = helper.GetTimeConvert(ei.TimeIn_4_Found);
                                ei.TimeIn_5_Found = timeDetails[5].ToString();
                                ei.TimeIn_5 = helper.GetTimeConvert(ei.TimeIn_5_Found);
                                ei.TimeIn_6_Found = timeDetails[6].ToString();
                                ei.TimeIn_6 = helper.GetTimeConvert(ei.TimeIn_6_Found);
                                Ei.Add(ei);
                                ei = new ExcelInfo();
                            }
                        }
                        if (LineContent.Substring(0, 1) == ",")
                        {
                            isEmpFound = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(),"Error Reading Document. Please check",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return Ei;
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
