namespace PayrollSystem.Attendance
{
    partial class AttendanceProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenFileDirectory = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnBrwsePD = new System.Windows.Forms.Button();
            this.tbProcessingDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblProcess = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbTimeOut = new System.Windows.Forms.TextBox();
            this.tbTimeIn = new System.Windows.Forms.TextBox();
            this.tbWorkingShift = new System.Windows.Forms.TextBox();
            this.tbEmployeeName = new System.Windows.Forms.TextBox();
            this.tbEmpID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgAttendance = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgEmpList = new System.Windows.Forms.DataGridView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tb_THW = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_TTH = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.tb_TUH = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_Approver = new System.Windows.Forms.TextBox();
            this.cbUploadOnline = new System.Windows.Forms.CheckBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAttendance)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnOpenFileDirectory);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.btnBrwsePD);
            this.groupBox1.Controls.Add(this.tbProcessingDirectory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1578, 830);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnOpenFileDirectory
            // 
            this.btnOpenFileDirectory.Location = new System.Drawing.Point(535, 11);
            this.btnOpenFileDirectory.Name = "btnOpenFileDirectory";
            this.btnOpenFileDirectory.Size = new System.Drawing.Size(108, 23);
            this.btnOpenFileDirectory.TabIndex = 5;
            this.btnOpenFileDirectory.Text = "Open File Directory";
            this.btnOpenFileDirectory.UseVisualStyleBackColor = true;
            this.btnOpenFileDirectory.Click += new System.EventHandler(this.btnOpenFileDirectory_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(931, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(189, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Download Attendance Excel Template";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnBrwsePD
            // 
            this.btnBrwsePD.Location = new System.Drawing.Point(456, 10);
            this.btnBrwsePD.Name = "btnBrwsePD";
            this.btnBrwsePD.Size = new System.Drawing.Size(75, 23);
            this.btnBrwsePD.TabIndex = 3;
            this.btnBrwsePD.Text = "&Browse";
            this.btnBrwsePD.UseVisualStyleBackColor = true;
            this.btnBrwsePD.Click += new System.EventHandler(this.btnBrwsePD_Click);
            // 
            // tbProcessingDirectory
            // 
            this.tbProcessingDirectory.Location = new System.Drawing.Point(102, 12);
            this.tbProcessingDirectory.Name = "tbProcessingDirectory";
            this.tbProcessingDirectory.ReadOnly = true;
            this.tbProcessingDirectory.Size = new System.Drawing.Size(347, 20);
            this.tbProcessingDirectory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Process Directory:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1566, 789);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblProcess);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1558, 763);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Processing";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(103, 11);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(246, 13);
            this.lblProcess.TabIndex = 3;
            this.lblProcess.Text = "(Press \"Process Now\" button to start processing)...";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.tb_TUH);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tb_TTH);
            this.groupBox3.Controls.Add(this.label);
            this.groupBox3.Controls.Add(this.tb_THW);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbTimeOut);
            this.groupBox3.Controls.Add(this.tbTimeIn);
            this.groupBox3.Controls.Add(this.tbWorkingShift);
            this.groupBox3.Controls.Add(this.tbEmployeeName);
            this.groupBox3.Controls.Add(this.tbEmpID);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dgAttendance);
            this.groupBox3.Location = new System.Drawing.Point(437, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1118, 536);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Records";
            // 
            // tbTimeOut
            // 
            this.tbTimeOut.Location = new System.Drawing.Point(118, 474);
            this.tbTimeOut.Name = "tbTimeOut";
            this.tbTimeOut.ReadOnly = true;
            this.tbTimeOut.Size = new System.Drawing.Size(100, 20);
            this.tbTimeOut.TabIndex = 10;
            // 
            // tbTimeIn
            // 
            this.tbTimeIn.Location = new System.Drawing.Point(119, 450);
            this.tbTimeIn.Name = "tbTimeIn";
            this.tbTimeIn.ReadOnly = true;
            this.tbTimeIn.Size = new System.Drawing.Size(100, 20);
            this.tbTimeIn.TabIndex = 9;
            // 
            // tbWorkingShift
            // 
            this.tbWorkingShift.Location = new System.Drawing.Point(118, 426);
            this.tbWorkingShift.Name = "tbWorkingShift";
            this.tbWorkingShift.ReadOnly = true;
            this.tbWorkingShift.Size = new System.Drawing.Size(188, 20);
            this.tbWorkingShift.TabIndex = 8;
            // 
            // tbEmployeeName
            // 
            this.tbEmployeeName.Location = new System.Drawing.Point(118, 401);
            this.tbEmployeeName.Name = "tbEmployeeName";
            this.tbEmployeeName.ReadOnly = true;
            this.tbEmployeeName.Size = new System.Drawing.Size(188, 20);
            this.tbEmployeeName.TabIndex = 7;
            // 
            // tbEmpID
            // 
            this.tbEmpID.Location = new System.Drawing.Point(117, 376);
            this.tbEmpID.Name = "tbEmpID";
            this.tbEmpID.ReadOnly = true;
            this.tbEmpID.Size = new System.Drawing.Size(100, 20);
            this.tbEmpID.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 479);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "End Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 456);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Start Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Working Schedule:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Employee ID:";
            // 
            // dgAttendance
            // 
            this.dgAttendance.AllowUserToAddRows = false;
            this.dgAttendance.AllowUserToDeleteRows = false;
            this.dgAttendance.AllowUserToOrderColumns = true;
            this.dgAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAttendance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAttendance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgAttendance.Location = new System.Drawing.Point(6, 19);
            this.dgAttendance.Name = "dgAttendance";
            this.dgAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgAttendance.Size = new System.Drawing.Size(1109, 352);
            this.dgAttendance.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgEmpList);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(6, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 722);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Found";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Employee List:";
            // 
            // dgEmpList
            // 
            this.dgEmpList.AllowUserToAddRows = false;
            this.dgEmpList.AllowUserToDeleteRows = false;
            this.dgEmpList.AllowUserToResizeColumns = false;
            this.dgEmpList.AllowUserToResizeRows = false;
            this.dgEmpList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgEmpList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmpList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgEmpList.Location = new System.Drawing.Point(6, 182);
            this.dgEmpList.Name = "dgEmpList";
            this.dgEmpList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEmpList.Size = new System.Drawing.Size(413, 534);
            this.dgEmpList.TabIndex = 1;
            this.dgEmpList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmpList_CellContentClick);
            this.dgEmpList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmpList_CellContentDoubleClick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Filename,
            this.EmpCount,
            this.Status});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(413, 129);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // Filename
            // 
            this.Filename.Text = "FileName";
            this.Filename.Width = 218;
            // 
            // EmpCount
            // 
            this.EmpCount.Text = "Emp.Found";
            this.EmpCount.Width = 109;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 80;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Process Now";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1106, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tb_THW
            // 
            this.tb_THW.Location = new System.Drawing.Point(513, 377);
            this.tb_THW.Name = "tb_THW";
            this.tb_THW.ReadOnly = true;
            this.tb_THW.Size = new System.Drawing.Size(100, 20);
            this.tb_THW.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(396, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Total Working Hours:";
            // 
            // tb_TTH
            // 
            this.tb_TTH.Location = new System.Drawing.Point(514, 403);
            this.tb_TTH.Name = "tb_TTH";
            this.tb_TTH.ReadOnly = true;
            this.tb_TTH.Size = new System.Drawing.Size(100, 20);
            this.tb_TTH.TabIndex = 14;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(396, 409);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(114, 13);
            this.label.TabIndex = 13;
            this.label.Text = "Total Tardiness Hours:";
            // 
            // tb_TUH
            // 
            this.tb_TUH.Location = new System.Drawing.Point(514, 432);
            this.tb_TUH.Name = "tb_TUH";
            this.tb_TUH.ReadOnly = true;
            this.tb_TUH.Size = new System.Drawing.Size(100, 20);
            this.tb_TUH.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(396, 438);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Total Undertime Hours:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnProcess);
            this.groupBox4.Controls.Add(this.cbUploadOnline);
            this.groupBox4.Controls.Add(this.tb_Approver);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.tbNotes);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Location = new System.Drawing.Point(644, 378);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(468, 144);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Approval";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(56, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Approved";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(145, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Reject";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Notes:";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(55, 41);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(407, 63);
            this.tbNotes.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(219, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "By:";
            // 
            // tb_Approver
            // 
            this.tb_Approver.Location = new System.Drawing.Point(247, 15);
            this.tb_Approver.Name = "tb_Approver";
            this.tb_Approver.ReadOnly = true;
            this.tb_Approver.Size = new System.Drawing.Size(154, 20);
            this.tb_Approver.TabIndex = 5;
            // 
            // cbUploadOnline
            // 
            this.cbUploadOnline.AutoSize = true;
            this.cbUploadOnline.Location = new System.Drawing.Point(57, 107);
            this.cbUploadOnline.Name = "cbUploadOnline";
            this.cbUploadOnline.Size = new System.Drawing.Size(93, 17);
            this.cbUploadOnline.TabIndex = 6;
            this.cbUploadOnline.Text = "Upload Online";
            this.cbUploadOnline.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(380, 110);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(82, 23);
            this.btnProcess.TabIndex = 7;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // AttendanceProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 864);
            this.Controls.Add(this.groupBox1);
            this.Name = "AttendanceProcessing";
            this.Text = "Attendance Processing";
            this.Load += new System.EventHandler(this.AttendanceProcessing_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAttendance)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpList)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBrwsePD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProcessingDirectory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgAttendance;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Filename;
        private System.Windows.Forms.ColumnHeader EmpCount;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnOpenFileDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgEmpList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTimeOut;
        private System.Windows.Forms.TextBox tbTimeIn;
        private System.Windows.Forms.TextBox tbWorkingShift;
        private System.Windows.Forms.TextBox tbEmployeeName;
        private System.Windows.Forms.TextBox tbEmpID;
        private System.Windows.Forms.TextBox tb_TUH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_TTH;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox tb_THW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tb_Approver;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.CheckBox cbUploadOnline;
    }
}