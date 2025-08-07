namespace PayrollSystem.Holidays
{
    partial class frmHolidays
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
            this.lblProgressVal = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbFileUpload = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkHolidayTemplate = new System.Windows.Forms.LinkLabel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgHolidayList = new System.Windows.Forms.DataGridView();
            this.bgwInsertExcel = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHolidayList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProgressVal);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.cbYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.tbFileUpload);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upload File";
            // 
            // lblProgressVal
            // 
            this.lblProgressVal.AutoSize = true;
            this.lblProgressVal.Location = new System.Drawing.Point(556, 22);
            this.lblProgressVal.Name = "lblProgressVal";
            this.lblProgressVal.Size = new System.Drawing.Size(47, 13);
            this.lblProgressVal.TabIndex = 5;
            this.lblProgressVal.Text = "Ready...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(450, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            this.progressBar1.TabIndex = 4;
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(728, 18);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(88, 21);
            this.cbYear.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year:";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(369, 17);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "&Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(288, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbFileUpload
            // 
            this.tbFileUpload.Location = new System.Drawing.Point(6, 19);
            this.tbFileUpload.Name = "tbFileUpload";
            this.tbFileUpload.Size = new System.Drawing.Size(276, 20);
            this.tbFileUpload.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lnkHolidayTemplate);
            this.groupBox2.Controls.Add(this.tbSearch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgHolidayList);
            this.groupBox2.Location = new System.Drawing.Point(12, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(822, 483);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Year Calendar";
            // 
            // lnkHolidayTemplate
            // 
            this.lnkHolidayTemplate.AutoSize = true;
            this.lnkHolidayTemplate.Location = new System.Drawing.Point(652, 26);
            this.lnkHolidayTemplate.Name = "lnkHolidayTemplate";
            this.lnkHolidayTemplate.Size = new System.Drawing.Size(163, 13);
            this.lnkHolidayTemplate.TabIndex = 3;
            this.lnkHolidayTemplate.TabStop = true;
            this.lnkHolidayTemplate.Text = "Download Holidate Template File";
            this.lnkHolidayTemplate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHolidayTemplate_LinkClicked);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(49, 19);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(233, 20);
            this.tbSearch.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search:";
            // 
            // dgHolidayList
            // 
            this.dgHolidayList.AllowUserToAddRows = false;
            this.dgHolidayList.AllowUserToDeleteRows = false;
            this.dgHolidayList.AllowUserToResizeColumns = false;
            this.dgHolidayList.AllowUserToResizeRows = false;
            this.dgHolidayList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgHolidayList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHolidayList.Location = new System.Drawing.Point(6, 49);
            this.dgHolidayList.Name = "dgHolidayList";
            this.dgHolidayList.Size = new System.Drawing.Size(810, 418);
            this.dgHolidayList.TabIndex = 0;
            // 
            // bgwInsertExcel
            // 
            this.bgwInsertExcel.WorkerReportsProgress = true;
            this.bgwInsertExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwInsertExcel_DoWork);
            this.bgwInsertExcel.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwInsertExcel_ProgressChanged);
            this.bgwInsertExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwInsertExcel_RunWorkerCompleted);
            // 
            // frmHolidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 555);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHolidays";
            this.Text = "Holidays";
            this.Load += new System.EventHandler(this.frmHolidays_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHolidayList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbFileUpload;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgHolidayList;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkHolidayTemplate;
        private System.Windows.Forms.Label lblProgressVal;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgwInsertExcel;
    }
}