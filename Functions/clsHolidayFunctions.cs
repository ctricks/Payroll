using PayrollSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.Functions
{
    public class clsHolidayFunctions
    {
        clsDatabase cdb = new clsDatabase(); 
        clsHelpers chelpers = new clsHelpers();
        
        public DataTable setupYear()
        {
            DataTable dtResult = new DataTable();
            try
            {
                dtResult = cdb.getDSFromSPSelectHolidays("sp_getHolidayList",DateTime.Now.Year,1).Tables[0];
                
                if (dtResult.Rows.Count == 0)
                { 
                    DataRow drRow = dtResult.NewRow();
                    drRow["Date"] = DateTime.Now.Year;
                    dtResult.Rows.Add(drRow);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,"Error: Loading Holiday Year",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return dtResult;
        }
        public int InsertHolidays(DateTime CalendarDays,string HolidayName,string HolidayType,int UserID,string Remarks)
        {
            int i = 0;
            try
            {
                i = cdb.setHolidays(CalendarDays, HolidayName, HolidayType, UserID, Remarks);
            }
            catch (Exception ex)
            {
                
            }
            return i;
        }
        public DataTable ReadExcelFile(string ExcelFilePath)
        {
            DataTable dtRecords = new DataTable();
            try
            {
                dtRecords = chelpers.GetDataTableFromExcel(ExcelFilePath, true);
            }
            catch (Exception ex)
            {

            }
            return dtRecords;
        }   
        public DataTable dtGetHolidateDetails()
        {
            DataTable dtRes = new DataTable();
            DataColumn dcol1 = new DataColumn("Date");
            DataColumn dcol2 = new DataColumn("Details");
            DataColumn dcol3 = new DataColumn("Type");

            try
            {
                dtRes.Columns.Add(dcol1);
                dtRes.Columns.Add(dcol2);
                dtRes.Columns.Add(dcol3);

                DataSet dsHolidayData = new DataSet();
                dsHolidayData = cdb.getDSFromSPSelectHolidays("sp_getHolidayList",DateTime.Now.Year,0);

                if (dsHolidayData != null)
                {
                    foreach (DataRow dr in dsHolidayData.Tables[0].Rows)
                    {
                        DataRow drData = dtRes.NewRow();
                        drData[0] = dr["Date"].ToString();
                        drData[1] = dr["Holiday"].ToString();
                        drData[2] = dr["Type"].ToString();
                        dtRes.Rows.Add(drData);
                    }
                }
            }
            catch (Exception ex) 
            {

            }
            return dtRes;
        }
        public void DownloadHolidayTemplate()
        {
            string FileHoliday = "HolidaysTemplate.xlsx";
            string HolidayTemplateFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Template",FileHoliday);

            string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads",FileHoliday);

            if (!File.Exists(HolidayTemplateFilePath))
            {
                MessageBox.Show("Error: Holiday Template not found. Please contact your administrator", "Missing Holiday Template file", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if(File.Exists(downloadsFolder))
            {
                File.Delete(downloadsFolder);   
            }

            File.Copy(HolidayTemplateFilePath, downloadsFolder);

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = true;
            processStartInfo.FileName = downloadsFolder;
            Process.Start(processStartInfo);    
        }
    }
}
