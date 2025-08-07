using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.Functions
{
    public class clsHelpers
    {
        IniFile MyIni = new IniFile("Settings.ini");
        public DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                return tbl;
            }
        }
        public ComboBox cmbReference(DataTable dtSource,string DisplayCode)
        { 
            ComboBox cRef = new ComboBox(); 

            cRef.DropDownStyle = ComboBoxStyle.DropDownList;
            cRef.DataSource = dtSource;
            cRef.DisplayMember = DisplayCode;            
            cRef.ValueMember = "ID";
            
            return cRef;
        }
        public void SetIni(string Key, string Section, string Value)
        {
            try
            {
                MyIni.Write(Key, Value, Section);
            }
            catch (Exception)
            {
            }
        }
        public string GetIniValue(string Key,string Section,string DefaultValue)
        {
            string result = DefaultValue;
            result = MyIni.Read(Key,Section);
            if (string.IsNullOrEmpty(result))
            {
                result = DefaultValue;
            }
            return result;
        }
        public List<string> getIniList(string Key,string Section)
        {
            List<string> slistItem = new List<string>();
            string IniValue = MyIni.Read(Key,Section);
            if (IniValue != null || !string.IsNullOrEmpty(IniValue))
            {
                slistItem = IniValue.Split(',').ToList();
            }
            return slistItem;
        }
        public string GetRegex(string Pattern,string value)
        {
            string Result = string.Empty;
            try
            {
                Result = Regex.Match(value, Pattern, RegexOptions.IgnoreCase).Value;
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public string GetEmployeeNumber(string value)
        {
            string Result = "";
            try
            {
                Result = value.Replace("(", "").Replace(")", "");
            }
            catch (Exception)
            {
            }
            return Result;
        }
        public bool GetBool(string Value)
        {
            bool Result = false;
            try
            {
                Result = bool.Parse(Value.Replace("(", "").Replace(")", ""));
            }
            catch (Exception)
            {
            }
            return Result;
        }
        public int GetInteger(string Value)
        {
            int Result = -1;
            try
            {
                Result = int.Parse(Value.Replace("(","").Replace(")",""));
            }
            catch (Exception)
            {
            }
            return Result;
        }
        public DateTime getDate(string Value)
        {
            DateTime dateTime = new DateTime(1901, 01, 01, 0, 0, 0);
            try
            {
                string format = "M/d/yyyy";
                if (!string.IsNullOrEmpty(Value))
                    dateTime = DateTime.ParseExact(Value, format, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {

            }
            return dateTime;
        }
        public TimeSpan getTime(string Value)
        {
            TimeSpan resTime = new TimeSpan(0, 0, 0);
            try
            {
                string format = "M/d/yyyy";
                if (!string.IsNullOrEmpty(Value))
                {
                    DateTime dateTime = DateTime.ParseExact(Value, format, CultureInfo.InvariantCulture);
                    resTime = TimeSpan.Parse(Value);
                }
            }
            catch (Exception ex)
            {

            }
            return resTime;
        }
        public DateTime GetTimeConvert(string Value)
        {
            DateTime dateTime = new DateTime(1901, 01, 01, 0, 0, 0);
            try
            {
               if(!string.IsNullOrEmpty(Value))
                dateTime = DateTime.Parse(DateTime.Parse(Value).ToLongTimeString());
            }
            catch (Exception ex)
            {

            }
            return dateTime;
        }
        public void ControlEnableDisable(TabControl tc,bool status,string defaultValue = "")
        {
            foreach(TabPage tc2 in tc.TabPages)
            {
                if((tc2.TabIndex == 0) || (tc2.TabIndex == 1))
                {
                    foreach (Control ctrl in tc2.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            ctrl.Enabled = status;
                            if(defaultValue != "E")
                                ctrl.Text = defaultValue;
                        }
                        if (ctrl is ComboBox)
                        {
                            ctrl.Enabled = status;
                            if (defaultValue != "E")
                                ctrl.Text = defaultValue;
                        }
                        if(ctrl is CheckBox)
                        {
                            ctrl.Enabled = status;
                            CheckBox cbcheck = (CheckBox)ctrl;
                            cbcheck.Checked = status;
                        }
                        
                        if(ctrl is GroupBox)
                        {
                            foreach (Control ctr in ctrl.Controls)
                            {
                                if (ctr is TextBox)
                                {
                                    ctr.Enabled = status;
                                    if (defaultValue != "E")
                                        ctr.Text = defaultValue;
                                }
                                if (ctr is CheckBox)
                                {
                                    ctr.Enabled = status;
                                    CheckBox cbcheck = (CheckBox)ctr;
                                    cbcheck.Checked = status;
                                }
                                if (ctrl is DataGridView)
                                {
                                    ctrl.Enabled = status;
                                }
                                if(ctr is ComboBox)
                                {
                                    ctrl.Enabled = status;
                                    if (defaultValue != "E")
                                        ctr.Text = defaultValue;
                                }
                            }
                        }
                        if(ctrl is DateTimePicker)
                        {
                            ctrl.Enabled = status;
                            if(defaultValue != "E")
                                ctrl.Text = "1901-01-01";
                        }
                    }
                }
            }
        }
    }
}
