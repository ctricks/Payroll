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
        bool isEdit = false;

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

            
            Position = cref.getDataTableRefence("tblPSD_Position", "ID,PositionCode");

            DataRow drPos = Position.NewRow();
            drPos["ID"] = 0;
            drPos["PositionCode"] = string.Empty;
            Position.Rows.InsertAt(drPos, 0);

            cmbPosition.DataSource = Position;
            cmbPosition.DisplayMember = "PositionCode";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedIndex = 0;

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

            cmbSalType.DataSource = chelp.getIniList("SalaryType", "Status");
            cmbSalType.SelectedIndex = 0;

            //Position = cref.getDataTableRefence("tblPSD_Position", "ID,PositionCode");
            //Department = cref.getDataTableRefence("tblPSD_Department", "ID,DepartmentCode");

            //cmbPosEntry.DataSource = Position;
            //cmbPosEntry.DisplayMember = "PositionCode";
            //cmbPosEntry.ValueMember = "ID";
            //cmbPosEntry.SelectedIndex = 0;

            //cmbDepEntry.DataSource = Department;
            //cmbDepEntry.DisplayMember = "DepartmentCode";
            //cmbDepEntry.ValueMember = "ID";
            //cmbDepEntry.SelectedIndex = 0;

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

            cmbBoxHelper();
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

            if (isEmployeeExists(tbLastName.Text, tbFirstName.Text, tbMiddleName.Text) && isEdit == false)
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
                dtEmp.Rows.Add("Position", "T", cmbPosEntry.SelectedIndex.ToString());
                dtEmp.Rows.Add("Department", "T", cmbDepEntry.SelectedIndex.ToString());
                dtEmp.Rows.Add("Telephone", "F", tbTelephone.Text.ToString());
                dtEmp.Rows.Add("PEName", "F", tbPEName.Text.ToString());
                dtEmp.Rows.Add("PEAdd", "F", tbPEAdd.Text.ToString());
                dtEmp.Rows.Add("PETel", "F", tbPETelephone.Text.ToString());                
                dtEmp.Rows.Add("SSS", "F", tbSSS.Text.ToString());
                dtEmp.Rows.Add("HDMF", "F", tbPAGIBIG.Text.ToString());
                dtEmp.Rows.Add("PHIC", "F", tbPhilhealth.Text.ToString());
                dtEmp.Rows.Add("TIN", "F", tbTIN.Text.ToString());
                dtEmp.Rows.Add("Salary", "F", tbSalary.Text.ToString());
                dtEmp.Rows.Add("SalaryType", "F", cmbSalType.Text.ToString());
                dtEmp.Rows.Add("RatePerDay", "F", tbRatePerDay.Text.ToString());
                dtEmp.Rows.Add("DateHired", "E", "#" + DateTime.Parse(dtHired.Value.ToShortDateString()).ToString("yyyy-MM-dd HH:mm:ss") + "#");
                dtEmp.Rows.Add("DateRegular", "E", "#" + DateTime.Parse(dtRegular.Value.ToShortDateString()).ToString("yyyy-MM-dd HH:mm:ss") + "#");
                dtEmp.Rows.Add("DateEnd", "E", "#" + DateTime.Parse(dtEndo.Value.ToShortDateString()).ToString("yyyy-MM-dd HH:mm:ss") + "#");
                dtEmp.Rows.Add("AccountNumber", "F", tbAccountNumber.Text.ToString());
                dtEmp.Rows.Add("BankNumber", "F", tbBankNumber.Text.ToString());
                dtEmp.Rows.Add("CardNumber", "F", tbCardNumber.Text.ToString());

                if (cbSameAs.Checked)
                {
                    dtEmp.Rows.Add("PESameAs", "T", "1");
                }
                else
                {
                    dtEmp.Rows.Add("PESameAs", "T", "0");
                }
                string QueryString = string.Empty;
                if (isEdit == false)
                {
                    QueryString = cDB.setInsertQueryBuilder("tblPSD_201File", dtEmp);
                }else
                {
                    QueryString = cDB.setUpdateQueryBuilder("tblPSD_201File", dtEmp,"ID = " + tbRecordID.Text);
                }
                

                string EmployeeName = tbLastName.Text + "," + tbFirstName.Text + " " + (tbMiddleName.Text.Length > 0 ? tbMiddleName.Text.Substring(0, 1) + "." : "");
                if (cDB.insertRecordTable(QueryString) == 1)
                {
                    MessageBox.Show("Employee: " + EmployeeName + " was successfully saved", "Employee Successfully Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DefaultControls();
                }
                cmbBoxHelper();
            }
            isEdit = false;
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

        private void cmbBoxHelper()
        {
            Position = cref.getDataTableRefence("tblPSD_Position", "ID,PositionCode");
            Department = cref.getDataTableRefence("tblPSD_Department", "ID,DepartmentCode");

            cmbPosEntry.DataSource = Position;
            cmbPosEntry.DisplayMember = "PositionCode";
            cmbPosEntry.ValueMember = "ID";
            cmbPosEntry.SelectedIndex = 0;

            cmbDepEntry.DataSource = Department;
            cmbDepEntry.DisplayMember = "DepartmentCode";
            cmbDepEntry.ValueMember = "ID";
            cmbDepEntry.SelectedIndex = 0;
        }

        private void DisplayDetails(int RecordID)
        {
            DataView dvResult = dtEmployeeRecords.DefaultView;
            dvResult.RowFilter = "ID=" + RecordID;
            if (dvResult.Count > 0)
            {
                tbRecordID.Text = dvResult[0][0].ToString();
                tbEmployeeID.Text = dvResult[0][1].ToString();
                tbBioMetricID.Text = dvResult[0][2].ToString();
                cmbEmpStatus.Text = dvResult[0][3].ToString();
                tbLastName.Text = dvResult[0][4].ToString();
                tbFirstName.Text = dvResult[0][5].ToString();
                tbMiddleName.Text = dvResult[0][6].ToString();
                tbAddress.Text = dvResult[0][7].ToString();
                dtBirth.Text = dvResult[0][8].ToString();
                cmbGender.Text = dvResult[0][9].ToString();

                int genderIndex = 0;
                int.TryParse(dvResult[0][10].ToString(), out genderIndex);
                cmbGender.SelectedIndex = genderIndex;

                tbTelephone.Text = dvResult[0][11].ToString();
                int positionIndex = 0;
                int.TryParse(dvResult[0][12].ToString(), out positionIndex);
                cmbPosEntry.SelectedIndex = positionIndex;
                int departmentIndex = 0;
                int.TryParse(dvResult[0][13].ToString(), out departmentIndex);
                cmbDepEntry.SelectedIndex = departmentIndex;

                tbPEName.Text = dvResult[0][14].ToString();
                tbPEAdd.Text = dvResult[0][16].ToString();
                tbPETelephone.Text = dvResult[0][15].ToString();
                cbSameAs.Checked = dvResult[0][17].ToString() == "1" ? true:false;

                tbSSS.Text = dvResult[0][18].ToString();
                tbPAGIBIG.Text = dvResult[0][19].ToString();
                tbPhilhealth.Text = dvResult[0][20].ToString();
                tbTIN.Text = dvResult[0][21].ToString();    
                tbSalary.Text = dvResult[0][22].ToString(); 
                cmbSalType.Text = dvResult[0][23].ToString();
                tbRatePerDay.Text = dvResult[0][24].ToString(); 
                dtHired.Text = dvResult[0][25].ToString();
                dtRegular.Text = dvResult[0][26].ToString();
                dtEndo.Text = dvResult[0][27].ToString();   
                tbAccountNumber.Text = dvResult[0][28].ToString();
                tbBankNumber.Text = dvResult[0][29].ToString();
                tbCardNumber.Text = dvResult[0][30].ToString();

            }
            else
            {
                MessageBox.Show("Error: No employee found. ", "Payroll System : ID=" + RecordID, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            cmbBoxHelper();
            string EmpID = dgEmpList.SelectedRows[0].Cells[0].Value.ToString();
            DisplayDetails(int.Parse(EmpID));
        }

        private void saveRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbDepartment_SelectedValueChanged(object sender, EventArgs e)
        {
                 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //cmbBoxHelper();

            if (string.IsNullOrEmpty(tbRecordID.Text))
            {
                MessageBox.Show("Error: Cannot edit employee details. Please select from your list", "Edit User : Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isEdit = true;
            chelp.ControlEnableDisable(tabControl1, true, "E");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dres = MessageBox.Show("Are you sure you want to Cancel Transaction?", "Cancel Transaction?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dres == DialogResult.Yes)
            {
                InitializedEmpMaster();
                showAll();
                btnEdit.Enabled = true;
            }            
        }
    }
}
