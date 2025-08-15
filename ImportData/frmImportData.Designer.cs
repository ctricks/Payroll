namespace PayrollSystem.ImportData
{
    partial class frmImportData
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
            this.lnklblDownloadTemplate = new System.Windows.Forms.LinkLabel();
            this.lblProgressVal = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.bgImport = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lnklblDownloadTemplate);
            this.groupBox1.Controls.Add(this.lblProgressVal);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.tbFilename);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1164, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upload File Here";
            // 
            // lnklblDownloadTemplate
            // 
            this.lnklblDownloadTemplate.AutoSize = true;
            this.lnklblDownloadTemplate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnklblDownloadTemplate.Location = new System.Drawing.Point(1032, 18);
            this.lnklblDownloadTemplate.Name = "lnklblDownloadTemplate";
            this.lnklblDownloadTemplate.Size = new System.Drawing.Size(129, 16);
            this.lnklblDownloadTemplate.TabIndex = 6;
            this.lnklblDownloadTemplate.TabStop = true;
            this.lnklblDownloadTemplate.Text = "Download Template";
            this.lnklblDownloadTemplate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblDownloadTemplate_LinkClicked);
            // 
            // lblProgressVal
            // 
            this.lblProgressVal.AutoSize = true;
            this.lblProgressVal.Location = new System.Drawing.Point(400, 59);
            this.lblProgressVal.Name = "lblProgressVal";
            this.lblProgressVal.Size = new System.Drawing.Size(57, 16);
            this.lblProgressVal.TabIndex = 5;
            this.lblProgressVal.Text = "Ready...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(99, 59);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(291, 19);
            this.progressBar1.TabIndex = 4;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(696, 22);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 25);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(615, 21);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 26);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(99, 25);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(510, 22);
            this.tbFilename.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filename:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgview);
            this.groupBox2.Location = new System.Drawing.Point(10, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1164, 386);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Details";
            // 
            // dgview
            // 
            this.dgview.AllowUserToAddRows = false;
            this.dgview.AllowUserToDeleteRows = false;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgview.Location = new System.Drawing.Point(3, 18);
            this.dgview.Name = "dgview";
            this.dgview.RowHeadersWidth = 51;
            this.dgview.RowTemplate.Height = 24;
            this.dgview.Size = new System.Drawing.Size(1158, 365);
            this.dgview.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1096, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bgImport
            // 
            this.bgImport.WorkerReportsProgress = true;
            this.bgImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgImport_DoWork);
            this.bgImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgImport_RunWorkerCompleted);
            // 
            // frmImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 549);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmImportData";
            this.Text = "Import Data";
            this.Load += new System.EventHandler(this.frmImportData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblProgressVal;
        private System.Windows.Forms.DataGridView dgview;
        private System.Windows.Forms.Button btnSave;
        private System.ComponentModel.BackgroundWorker bgImport;
        private System.Windows.Forms.LinkLabel lnklblDownloadTemplate;
    }
}