namespace HISPlus
{
    partial class OperationReportFormUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.uiSerialSearchTxt = new System.Windows.Forms.TextBox();
            this.uiSearchButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiOPGrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.uiSerialTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiPrv_code = new System.Windows.Forms.TextBox();
            this.uiNameTxt = new System.Windows.Forms.TextBox();
            this.uiFamilyTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiShowReport = new System.Windows.Forms.Button();
            this.vJDoctorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_JDoctorTableAdapter = new HISPlus.OproomDataSet1TableAdapters.V_JDoctorTableAdapter();
            this.uiFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiLname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiDocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opFindingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opIndicationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specimenNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specimenYesNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kindOfOperationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postDiagnosisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preDiagnosisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRVCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEndTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bStartTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jHelpCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bMDocCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oproomDataSet1 = new HISPlus.OproomDataSet1();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiOPGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vJDoctorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oproomDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(666, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "سریال:";
            // 
            // uiSerialSearchTxt
            // 
            this.uiSerialSearchTxt.Location = new System.Drawing.Point(491, 8);
            this.uiSerialSearchTxt.Name = "uiSerialSearchTxt";
            this.uiSerialSearchTxt.Size = new System.Drawing.Size(169, 22);
            this.uiSerialSearchTxt.TabIndex = 1;
            this.uiSerialSearchTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uiSerialSearchTxt_KeyPress);
            // 
            // uiSearchButton
            // 
            this.uiSearchButton.Location = new System.Drawing.Point(340, 6);
            this.uiSearchButton.Name = "uiSearchButton";
            this.uiSearchButton.Size = new System.Drawing.Size(145, 25);
            this.uiSearchButton.TabIndex = 2;
            this.uiSearchButton.Text = "جستجو";
            this.uiSearchButton.UseVisualStyleBackColor = true;
            this.uiSearchButton.Click += new System.EventHandler(this.uiSearchButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.uiSerialTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.uiPrv_code);
            this.groupBox1.Controls.Add(this.uiNameTxt);
            this.groupBox1.Controls.Add(this.uiFamilyTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 237);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiOPGrid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 153);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لیست عمل های جراحی";
            // 
            // uiOPGrid
            // 
            this.uiOPGrid.AllowUserToAddRows = false;
            this.uiOPGrid.AllowUserToDeleteRows = false;
            this.uiOPGrid.AllowUserToResizeColumns = false;
            this.uiOPGrid.AllowUserToResizeRows = false;
            this.uiOPGrid.AutoGenerateColumns = false;
            this.uiOPGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.uiOPGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiOPGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uiFName,
            this.uiLname,
            this.uiSerial,
            this.uiDocNumber,
            this.uiDate,
            this.uiStartDate,
            this.uiEndDate,
            this.serialDataGridViewTextBoxColumn,
            this.startTimeDataGridViewTextBoxColumn,
            this.bMDocCodeDataGridViewTextBoxColumn,
            this.jHelpCodeDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.bStartTimeDataGridViewTextBoxColumn,
            this.bEndTimeDataGridViewTextBoxColumn,
            this.roomDataGridViewTextBoxColumn,
            this.opDateDataGridViewTextBoxColumn,
            this.bTypeDataGridViewTextBoxColumn,
            this.pRVCodeDataGridViewTextBoxColumn,
            this.preDiagnosisDataGridViewTextBoxColumn,
            this.postDiagnosisDataGridViewTextBoxColumn,
            this.kindOfOperationDataGridViewTextBoxColumn,
            this.specimenYesNoDataGridViewTextBoxColumn,
            this.specimenNumberDataGridViewTextBoxColumn,
            this.opIndicationDataGridViewTextBoxColumn,
            this.opFindingDataGridViewTextBoxColumn});
            this.uiOPGrid.DataSource = this.vJDoctorBindingSource;
            this.uiOPGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiOPGrid.GridColor = System.Drawing.SystemColors.Control;
            this.uiOPGrid.Location = new System.Drawing.Point(3, 29);
            this.uiOPGrid.Name = "uiOPGrid";
            this.uiOPGrid.ReadOnly = true;
            this.uiOPGrid.Size = new System.Drawing.Size(733, 121);
            this.uiOPGrid.TabIndex = 7;
            this.uiOPGrid.SelectionChanged += new System.EventHandler(this.uiOPGrid_SelectionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "سریال:";
            // 
            // uiSerialTxt
            // 
            this.uiSerialTxt.Location = new System.Drawing.Point(225, 10);
            this.uiSerialTxt.Name = "uiSerialTxt";
            this.uiSerialTxt.ReadOnly = true;
            this.uiSerialTxt.Size = new System.Drawing.Size(169, 22);
            this.uiSerialTxt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(662, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "شماره پرونده:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(662, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "نام:";
            // 
            // uiPrv_code
            // 
            this.uiPrv_code.Location = new System.Drawing.Point(487, 10);
            this.uiPrv_code.Name = "uiPrv_code";
            this.uiPrv_code.ReadOnly = true;
            this.uiPrv_code.Size = new System.Drawing.Size(169, 22);
            this.uiPrv_code.TabIndex = 4;
            // 
            // uiNameTxt
            // 
            this.uiNameTxt.Location = new System.Drawing.Point(487, 36);
            this.uiNameTxt.Name = "uiNameTxt";
            this.uiNameTxt.ReadOnly = true;
            this.uiNameTxt.Size = new System.Drawing.Size(169, 22);
            this.uiNameTxt.TabIndex = 3;
            // 
            // uiFamilyTxt
            // 
            this.uiFamilyTxt.Location = new System.Drawing.Point(225, 36);
            this.uiFamilyTxt.Name = "uiFamilyTxt";
            this.uiFamilyTxt.ReadOnly = true;
            this.uiFamilyTxt.Size = new System.Drawing.Size(169, 22);
            this.uiFamilyTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "نام خانوادگی:";
            // 
            // uiShowReport
            // 
            this.uiShowReport.Location = new System.Drawing.Point(560, 284);
            this.uiShowReport.Name = "uiShowReport";
            this.uiShowReport.Size = new System.Drawing.Size(183, 37);
            this.uiShowReport.TabIndex = 4;
            this.uiShowReport.Text = "نمایش گزارش عمل";
            this.uiShowReport.UseVisualStyleBackColor = true;
            this.uiShowReport.Click += new System.EventHandler(this.uiShowReport_Click);
            // 
            // vJDoctorBindingSource
            // 
            this.vJDoctorBindingSource.DataMember = "V_JDoctor";
            this.vJDoctorBindingSource.DataSource = this.oproomDataSet1;
            // 
            // v_JDoctorTableAdapter
            // 
            this.v_JDoctorTableAdapter.ClearBeforeFill = true;
            // 
            // uiFName
            // 
            this.uiFName.DataPropertyName = "FName";
            this.uiFName.HeaderText = "نام";
            this.uiFName.Name = "uiFName";
            this.uiFName.ReadOnly = true;
            this.uiFName.Visible = false;
            // 
            // uiLname
            // 
            this.uiLname.DataPropertyName = "LName";
            this.uiLname.HeaderText = "نام خانوادگی";
            this.uiLname.Name = "uiLname";
            this.uiLname.ReadOnly = true;
            this.uiLname.Visible = false;
            // 
            // uiSerial
            // 
            this.uiSerial.DataPropertyName = "Serial";
            this.uiSerial.HeaderText = "سریال";
            this.uiSerial.Name = "uiSerial";
            this.uiSerial.ReadOnly = true;
            this.uiSerial.Visible = false;
            // 
            // uiDocNumber
            // 
            this.uiDocNumber.DataPropertyName = "PRV_Code";
            this.uiDocNumber.HeaderText = "شماره پرونده";
            this.uiDocNumber.Name = "uiDocNumber";
            this.uiDocNumber.ReadOnly = true;
            this.uiDocNumber.Visible = false;
            // 
            // uiDate
            // 
            this.uiDate.DataPropertyName = "OpDate";
            this.uiDate.HeaderText = "تاریخ";
            this.uiDate.Name = "uiDate";
            this.uiDate.ReadOnly = true;
            // 
            // uiStartDate
            // 
            this.uiStartDate.DataPropertyName = "StartTime";
            this.uiStartDate.HeaderText = "زمان شروع";
            this.uiStartDate.Name = "uiStartDate";
            this.uiStartDate.ReadOnly = true;
            // 
            // uiEndDate
            // 
            this.uiEndDate.DataPropertyName = "EndTime";
            this.uiEndDate.HeaderText = "زمان پایان";
            this.uiEndDate.Name = "uiEndDate";
            this.uiEndDate.ReadOnly = true;
            // 
            // opFindingDataGridViewTextBoxColumn
            // 
            this.opFindingDataGridViewTextBoxColumn.DataPropertyName = "OpFinding";
            this.opFindingDataGridViewTextBoxColumn.HeaderText = "OpFinding";
            this.opFindingDataGridViewTextBoxColumn.Name = "opFindingDataGridViewTextBoxColumn";
            this.opFindingDataGridViewTextBoxColumn.ReadOnly = true;
            this.opFindingDataGridViewTextBoxColumn.Visible = false;
            // 
            // opIndicationDataGridViewTextBoxColumn
            // 
            this.opIndicationDataGridViewTextBoxColumn.DataPropertyName = "OpIndication";
            this.opIndicationDataGridViewTextBoxColumn.HeaderText = "OpIndication";
            this.opIndicationDataGridViewTextBoxColumn.Name = "opIndicationDataGridViewTextBoxColumn";
            this.opIndicationDataGridViewTextBoxColumn.ReadOnly = true;
            this.opIndicationDataGridViewTextBoxColumn.Visible = false;
            // 
            // specimenNumberDataGridViewTextBoxColumn
            // 
            this.specimenNumberDataGridViewTextBoxColumn.DataPropertyName = "SpecimenNumber";
            this.specimenNumberDataGridViewTextBoxColumn.HeaderText = "SpecimenNumber";
            this.specimenNumberDataGridViewTextBoxColumn.Name = "specimenNumberDataGridViewTextBoxColumn";
            this.specimenNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.specimenNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // specimenYesNoDataGridViewTextBoxColumn
            // 
            this.specimenYesNoDataGridViewTextBoxColumn.DataPropertyName = "SpecimenYesNo";
            this.specimenYesNoDataGridViewTextBoxColumn.HeaderText = "SpecimenYesNo";
            this.specimenYesNoDataGridViewTextBoxColumn.Name = "specimenYesNoDataGridViewTextBoxColumn";
            this.specimenYesNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.specimenYesNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // kindOfOperationDataGridViewTextBoxColumn
            // 
            this.kindOfOperationDataGridViewTextBoxColumn.DataPropertyName = "KindOfOperation";
            this.kindOfOperationDataGridViewTextBoxColumn.HeaderText = "KindOfOperation";
            this.kindOfOperationDataGridViewTextBoxColumn.Name = "kindOfOperationDataGridViewTextBoxColumn";
            this.kindOfOperationDataGridViewTextBoxColumn.ReadOnly = true;
            this.kindOfOperationDataGridViewTextBoxColumn.Visible = false;
            // 
            // postDiagnosisDataGridViewTextBoxColumn
            // 
            this.postDiagnosisDataGridViewTextBoxColumn.DataPropertyName = "PostDiagnosis";
            this.postDiagnosisDataGridViewTextBoxColumn.HeaderText = "PostDiagnosis";
            this.postDiagnosisDataGridViewTextBoxColumn.Name = "postDiagnosisDataGridViewTextBoxColumn";
            this.postDiagnosisDataGridViewTextBoxColumn.ReadOnly = true;
            this.postDiagnosisDataGridViewTextBoxColumn.Visible = false;
            // 
            // preDiagnosisDataGridViewTextBoxColumn
            // 
            this.preDiagnosisDataGridViewTextBoxColumn.DataPropertyName = "PreDiagnosis";
            this.preDiagnosisDataGridViewTextBoxColumn.HeaderText = "PreDiagnosis";
            this.preDiagnosisDataGridViewTextBoxColumn.Name = "preDiagnosisDataGridViewTextBoxColumn";
            this.preDiagnosisDataGridViewTextBoxColumn.ReadOnly = true;
            this.preDiagnosisDataGridViewTextBoxColumn.Visible = false;
            // 
            // pRVCodeDataGridViewTextBoxColumn
            // 
            this.pRVCodeDataGridViewTextBoxColumn.DataPropertyName = "PRV_Code";
            this.pRVCodeDataGridViewTextBoxColumn.HeaderText = "PRV_Code";
            this.pRVCodeDataGridViewTextBoxColumn.Name = "pRVCodeDataGridViewTextBoxColumn";
            this.pRVCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.pRVCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // bTypeDataGridViewTextBoxColumn
            // 
            this.bTypeDataGridViewTextBoxColumn.DataPropertyName = "BType";
            this.bTypeDataGridViewTextBoxColumn.HeaderText = "BType";
            this.bTypeDataGridViewTextBoxColumn.Name = "bTypeDataGridViewTextBoxColumn";
            this.bTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // opDateDataGridViewTextBoxColumn
            // 
            this.opDateDataGridViewTextBoxColumn.DataPropertyName = "OpDate";
            this.opDateDataGridViewTextBoxColumn.HeaderText = "OpDate";
            this.opDateDataGridViewTextBoxColumn.Name = "opDateDataGridViewTextBoxColumn";
            this.opDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.opDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // roomDataGridViewTextBoxColumn
            // 
            this.roomDataGridViewTextBoxColumn.DataPropertyName = "Room";
            this.roomDataGridViewTextBoxColumn.HeaderText = "Room";
            this.roomDataGridViewTextBoxColumn.Name = "roomDataGridViewTextBoxColumn";
            this.roomDataGridViewTextBoxColumn.ReadOnly = true;
            this.roomDataGridViewTextBoxColumn.Visible = false;
            // 
            // bEndTimeDataGridViewTextBoxColumn
            // 
            this.bEndTimeDataGridViewTextBoxColumn.DataPropertyName = "BEndTime";
            this.bEndTimeDataGridViewTextBoxColumn.HeaderText = "BEndTime";
            this.bEndTimeDataGridViewTextBoxColumn.Name = "bEndTimeDataGridViewTextBoxColumn";
            this.bEndTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bEndTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // bStartTimeDataGridViewTextBoxColumn
            // 
            this.bStartTimeDataGridViewTextBoxColumn.DataPropertyName = "BStartTime";
            this.bStartTimeDataGridViewTextBoxColumn.HeaderText = "BStartTime";
            this.bStartTimeDataGridViewTextBoxColumn.Name = "bStartTimeDataGridViewTextBoxColumn";
            this.bStartTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bStartTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            this.ageDataGridViewTextBoxColumn.ReadOnly = true;
            this.ageDataGridViewTextBoxColumn.Visible = false;
            // 
            // jHelpCodeDataGridViewTextBoxColumn
            // 
            this.jHelpCodeDataGridViewTextBoxColumn.DataPropertyName = "JHelp_Code";
            this.jHelpCodeDataGridViewTextBoxColumn.HeaderText = "JHelp_Code";
            this.jHelpCodeDataGridViewTextBoxColumn.Name = "jHelpCodeDataGridViewTextBoxColumn";
            this.jHelpCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.jHelpCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // bMDocCodeDataGridViewTextBoxColumn
            // 
            this.bMDocCodeDataGridViewTextBoxColumn.DataPropertyName = "BMDoc_Code";
            this.bMDocCodeDataGridViewTextBoxColumn.HeaderText = "BMDoc_Code";
            this.bMDocCodeDataGridViewTextBoxColumn.Name = "bMDocCodeDataGridViewTextBoxColumn";
            this.bMDocCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bMDocCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.HeaderText = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.startTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // serialDataGridViewTextBoxColumn
            // 
            this.serialDataGridViewTextBoxColumn.DataPropertyName = "Serial";
            this.serialDataGridViewTextBoxColumn.HeaderText = "Serial";
            this.serialDataGridViewTextBoxColumn.Name = "serialDataGridViewTextBoxColumn";
            this.serialDataGridViewTextBoxColumn.ReadOnly = true;
            this.serialDataGridViewTextBoxColumn.Visible = false;
            // 
            // oproomDataSet1
            // 
            this.oproomDataSet1.DataSetName = "OproomDataSet1";
            this.oproomDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OperationReportFormUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.uiShowReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uiSearchButton);
            this.Controls.Add(this.uiSerialSearchTxt);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "OperationReportFormUC";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(752, 326);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiOPGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vJDoctorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oproomDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiSerialSearchTxt;
        private System.Windows.Forms.Button uiSearchButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiPrv_code;
        private System.Windows.Forms.TextBox uiNameTxt;
        private System.Windows.Forms.TextBox uiFamilyTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uiShowReport;
        public System.Windows.Forms.DataGridView uiOPGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiSerialTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiFName;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiLname;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiDocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiEndDate;
        private System.Windows.Forms.BindingSource vJDoctorBindingSource;
        private OproomDataSet1TableAdapters.V_JDoctorTableAdapter v_JDoctorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bMDocCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jHelpCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bStartTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bEndTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRVCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preDiagnosisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postDiagnosisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kindOfOperationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn specimenYesNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn specimenNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opIndicationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opFindingDataGridViewTextBoxColumn;
        private OproomDataSet1 oproomDataSet1;
    }
}
