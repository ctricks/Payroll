using PayrollSystem.Database;
using PayrollSystem.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PayrollSystem.Employee
{
    public partial class EmpMasterFile : Form
    {
        DataTable dtEmployeeRecords = new DataTable();

        DataTable Department = new DataTable();
        DataTable Position = new DataTable();
        DataTable Gender = new DataTable();

        clsReferenceTable cref = new clsReferenceTable();
        clsHelpers chelp = new clsHelpers();
        clsDatabase cDB = new clsDatabase();

        private void InitializedEmpMaster()
        {
            Department = cref.getDataTableRefence("tblPSD_Department", "ID,DepartmentCode");

            DataRow drDep = Department.NewRow();
            drDep["ID"] = 0;
            drDep["DepartmentCode"] = string.Empty;
            Department.Rows.InsertAt(drDep, 0);

            cmbDepartment.DataSource = Department;
            cmbDepartment.DisplayMember = "DepartmentCode";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = 0;

            cmbDepEntry.DataSource = Department;
            cmbDepEntry.DisplayMember = "DepartmentCode";
            cmbDepEntry.ValueMember = "ID";
            cmbDepEntry.SelectedIndex = 0;


            Position = cref.getDataTableRefence("tblPSD_Position", "ID,PositionCode");

            DataRow drPos = Position.NewRow();
            drPos["ID"] = 0;
            drPos["PositionCode"] = string.Empty;
            Position.Rows.InsertAt(drPos, 0);

            cmbPosition.DataSource = Position;
            cmbPosition.DisplayMember = "PositionCode";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedIndex = 0;


            cmbPosEntry.DataSource = Position;
            cmbPosEntry.DisplayMember = "PositionCode";
            cmbPosEntry.ValueMember = "ID";
            cmbPosEntry.SelectedIndex = 0;

            Gender = cref.getDataTableRefence("tblPSD_Gender", "ID,GenderCode");

            DataRow drGen = Gender.NewRow();
            drGen["ID"] = 0;
            drGen["GenderCode"] = string.Empty;
            Gender.Rows.InsertAt(drGen, 0);

            cmbGender.DataSource = Gender;
            cmbGender.DisplayMember = "GenderCode";
            cmbGender.ValueMember = "ID";
            cmbGender.SelectedIndex = 0;

            cmbEmpStatus.DataSource = chelp.getIniList("EmployeeStatus", "Status");
            cmbEmpStatus.SelectedIndex = 0;

            cmbCivilStatus.DataSource = chelp.getIniList("CivilStatus", "Status");
            cmbCivilStatus.SelectedIndex = 0;

            DefaultControls();

        }

        private void DefaultControls()
        {
            chelp.ControlEnableDisable(tabControl1, false);
            dtBirth.Enabled = false;
            dgDependents.Enabled = false;
        }

        public EmpMasterFile()
        {
            InitializeComponent();
        }

        private void EmpMasterFile_Load(object sender, EventArgs e)
        {
            InitializedEmpMaster();
            showAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chelp.ControlEnableDisable(tabControl1, true);
            dgDependents.Enabled = true;
            tbRecordID.Text = cDB.getLastRecordID("tblPSD_201File").ToString();
            if (tbRecordID.Text == "0")
            {
                DefaultControls();
            } else
            {
                dtBirth.Enabled = true;
            }
            tbEmployeeID.Focus();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void newRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNew.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmployeeID.Text))
            {
                MessageBox.Show("Error: Cannot save employee details. Please check your entries", "Create User : Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbBioMetricID.Text))
            {
                MessageBox.Show("Error: Cannot save employee details. Please check your entries", "Create User : Invalid Biometric ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isEmployeeExists(tbLastName.Text, tbFirstName.Text, tbMiddleName.Text))
            {
                MessageBox.Show("Error: Cannot save employee details. Please check your entries", "Create User : Employee Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dres = MessageBox.Show("Would you like to save the following employee?", "Save employee : " + tbEmployeeID.Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dres == DialogResult.Yes)
            {
                DataTable dtEmp = new DataTable();
                dtEmp.Columns.Add("ColumnName");
                dtEmp.Columns.Add("isNumeric");
                dtEmp.Columns.Add("Value");

                dtEmp.Rows.Add("EmpID", "T", tbEmployeeID.Text);
                dtEmp.Rows.Add("BioID", "T", tbBioMetricID.Text);
                dtEmp.Rows.Add("EmpStatus", "F", cmbEmpStatus.Text);
                dtEmp.Rows.Add("LastName", "F", tbLastName.Text);
                dtEmp.Rows.Add("FirstName", "F", tbFirstName.Text);
                dtEmp.Rows.Add("MiddleName", "F", tbMiddleName.Text);
                dtEmp.Rows.Add("Address", "F", tbAddress.Text);
                dtEmp.Rows.Add("Birthday", "E", "#" + DateTime.Parse(dtBirth.Value.ToShortDateString()).ToString("yyyy-MM-dd HH:mm:ss") + "#");
                dtEmp.Rows.Add("CivilStatus", "F", cmbCivilStatus.Text);
                dtEmp.Rows.Add("Gender", "T", cmbGender.SelectedValue.ToString());
                dtEmp.Rows.Add("Position", "T", cmbPosition.SelectedValue.ToString());
                dtEmp.Rows.Add("Department", "T", cmbDepartment.SelectedValue.ToString());
                dtEmp.Rows.Add("Telephone", "F", tbTelephone.Text.ToString());
                dtEmp.Rows.Add("PEName", "F", tbPEName.Text.ToString());
                dtEmp.Rows.Add("PEAdd", "F", tbPEAdd.Text.ToString());
                dtEmp.Rows.Add("PETel", "F", tbPETelephone.Text.ToString());

                if (cbSameAs.Checked)
                {
                    dtEmp.Rows.Add("PESameAs", "T", "1");
                }
                else
                {
                    dtEmp.Rows.Add("PESameAs", "T", "0");
                }


                string QueryString = cDB.setInsertQueryBuilder("tblPSD_201File", dtEmp);

                string EmployeeName = tbLastName.Text + "," + tbFirstName.Text + " " + (tbMiddleName.Text.Length > 0 ? tbMiddleName.Text.Substring(0, 1) + "." : "");
                if (cDB.insertRecordTable(QueryString) == 1)
                {
                    MessageBox.Show("Employee: " + EmployeeName + " was successfully inserted", "Employee Successfully Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DefaultControls();
                }
            }
            btnShowAll.PerformClick();
        }

        private DataTable getAllEmployee(string ColumnName = "*", string Criteria = "")
        {
            DataTable dtEmpTable = new DataTable();
            string sQueryGetAllEmployee = "Select " + ColumnName + " from [tblPSD_201File] " + Criteria;
            return dtEmpTable = cDB.getRecords(sQueryGetAllEmployee);
        }

        private bool isEmployeeExists(string LastName, string FirstName, string MiddleName)
        {
            string sQuery = cDB.setQueryBuilder("ID", "tblPSD_201File", " LastName = '" + LastName + "' and FirstName = '" + FirstName + "' and MiddleName='" + MiddleName + "'");
            if (cDB.getRecords(sQuery).Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cbSameAs_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSameAs.Checked)
            {
                tbPEAdd.Text = tbAddress.Text;
            } else
            {
                tbPEAdd.Text = "";
            }
        }

        private void showAll()
        {
            dtEmployeeRecords = getAllEmployee("*", " order by Lastname asc");
            DataTable dtEmployeelist = getAllEmployee("ID,LastName + ',' + FirstName + ' ' + MiddleName as Employee", " order by Lastname asc");
            dgEmpList.DataSource = dtEmployeelist;
            dgEmpList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            lblTotalRecords.Text = "Total Record(s) in Database: " + dtEmployeeRecords.Rows.Count.ToString();
        }

        private void DisplayDetails(int RecordID)
        {

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            showAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgEmpList.SelectedRows.Count != 1 || dgEmpList.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("Error: Please select valid record to delete in the list.", "Payroll System : Unable to delete employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dres = MessageBox.Show("Are you sure you want to delete this employee? ID:" + dgEmpList.SelectedRows[0].Cells[0].Value.ToString(), "Delete Employee: " + dgEmpList.SelectedRows[0].Cells[1].Value.ToString() + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dres == DialogResult.Yes)
            {
                string sQuery = cDB.setDeleteQueryBuilder("tblPSD_201File", "ID=" + dgEmpList.SelectedRows[0].Cells[0].Value.ToString());
                if (cDB.deleteRecordTable(sQuery) == 1)
                {
                    MessageBox.Show("Successfully Deleted!", "Employee ID: " + dgEmpList.SelectedRows[0].Cells[1].Value.ToString(), MessageBoxButtons.OK);
                }else
                {
                    MessageBox.Show("Unable to Delete Record. Please ask administrator", "Unable to delete Employee ID: " + dgEmpList.SelectedRows[0].Cells[1].Value.ToString(), MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            showAll();
        }

        private void editRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void dgEmpList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string EmpID = dgEmpList.SelectedRows[0].Cells[0].Value.ToString();
            MessageBox.Show(EmpID);
        }

        private void saveRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }
    }
}
