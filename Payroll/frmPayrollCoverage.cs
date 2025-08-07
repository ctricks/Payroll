using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.Payroll
{
    public partial class frmPayrollCoverage : Form
    {
        public string Username;
        Database.clsDatabase cdb = new Database.clsDatabase();

        public frmPayrollCoverage()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            DateTime parsedDate = DateTime.ParseExact(comboBox1.Text.ToString(), "MMMM", CultureInfo.InvariantCulture);

            // Construct the first day of the month
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, parsedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, parsedDate.Month);
            DateTime lastDayOfMonth = new DateTime(DateTime.Now.Year, parsedDate.Month, daysInMonth);

            if(firstDayOfMonth > dtpickerStart.MaxDate)
            {
                dtpickerStart.MaxDate = firstDayOfMonth;
            }

            dtpickerStart.MinDate = firstDayOfMonth;
            dtpickerStart.MaxDate = lastDayOfMonth;

            if (firstDayOfMonth > dtpickerEnd.MaxDate)
            {
                dtpickerEnd.MaxDate = firstDayOfMonth;
            }

            dtpickerEnd.MinDate = firstDayOfMonth;
            dtpickerEnd.MaxDate = lastDayOfMonth;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpickerEnd.Value < dtpickerStart.Value)
            {
                MessageBox.Show("Error: Unable to saved.", "End date is invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //string TableName = "tblPSD_PayrollCoverage";
            //string[,] ColumnDetails =
            //{
            //    {"test", "test"},{"test2","test2"}
            //};
            //cdb.setInsertQueryBuilderByColumnValue(TableName, ColumnDetails);
        }
    }
}
