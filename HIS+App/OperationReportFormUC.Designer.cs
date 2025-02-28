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
            this.label1 = new System.Windows.Forms.Label();
            this.uiSerialSearchTextBox = new System.Windows.Forms.TextBox();
            this.uiSearchButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiReceptionsGrid = new System.Windows.Forms.DataGridView();
            this.OpDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.uiSerial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiPrv_code = new System.Windows.Forms.TextBox();
            this.uiName = new System.Windows.Forms.TextBox();
            this.uiFamily = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiShowReport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiReceptionsGrid)).BeginInit();
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
            // uiSerialSearchTextBox
            // 
            this.uiSerialSearchTextBox.Location = new System.Drawing.Point(491, 8);
            this.uiSerialSearchTextBox.Name = "uiSerialSearchTextBox";
            this.uiSerialSearchTextBox.Size = new System.Drawing.Size(169, 22);
            this.uiSerialSearchTextBox.TabIndex = 1;
            this.uiSerialSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uiSerialSearchTxt_KeyPress);
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
            this.groupBox1.Controls.Add(this.uiSerial);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.uiPrv_code);
            this.groupBox1.Controls.Add(this.uiName);
            this.groupBox1.Controls.Add(this.uiFamily);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 237);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiReceptionsGrid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 153);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لیست عمل های جراحی";
            // 
            // uiReceptionsGrid
            // 
            this.uiReceptionsGrid.AllowUserToAddRows = false;
            this.uiReceptionsGrid.AllowUserToDeleteRows = false;
            this.uiReceptionsGrid.AllowUserToResizeColumns = false;
            this.uiReceptionsGrid.AllowUserToResizeRows = false;
            this.uiReceptionsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiReceptionsGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.uiReceptionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiReceptionsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OpDateColumn,
            this.StartTimeColumn,
            this.EndTimeColumn});
            this.uiReceptionsGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiReceptionsGrid.GridColor = System.Drawing.SystemColors.Control;
            this.uiReceptionsGrid.Location = new System.Drawing.Point(3, 29);
            this.uiReceptionsGrid.Name = "uiReceptionsGrid";
            this.uiReceptionsGrid.ReadOnly = true;
            this.uiReceptionsGrid.Size = new System.Drawing.Size(733, 121);
            this.uiReceptionsGrid.TabIndex = 7;
            // 
            // OpDateColumn
            // 
            this.OpDateColumn.DataPropertyName = "OpDate";
            this.OpDateColumn.HeaderText = "تاریخ";
            this.OpDateColumn.Name = "OpDateColumn";
            this.OpDateColumn.ReadOnly = true;
            // 
            // StartTimeColumn
            // 
            this.StartTimeColumn.DataPropertyName = "StartTime";
            this.StartTimeColumn.HeaderText = "زمان شروع";
            this.StartTimeColumn.Name = "StartTimeColumn";
            this.StartTimeColumn.ReadOnly = true;
            // 
            // EndTimeColumn
            // 
            this.EndTimeColumn.DataPropertyName = "EndTime";
            this.EndTimeColumn.HeaderText = "زمان پایان";
            this.EndTimeColumn.Name = "EndTimeColumn";
            this.EndTimeColumn.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "سریال:";
            // 
            // uiSerial
            // 
            this.uiSerial.Location = new System.Drawing.Point(224, 20);
            this.uiSerial.Name = "uiSerial";
            this.uiSerial.ReadOnly = true;
            this.uiSerial.Size = new System.Drawing.Size(169, 22);
            this.uiSerial.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(661, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "شماره پرونده:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(661, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "نام:";
            // 
            // uiPrv_code
            // 
            this.uiPrv_code.Location = new System.Drawing.Point(486, 20);
            this.uiPrv_code.Name = "uiPrv_code";
            this.uiPrv_code.ReadOnly = true;
            this.uiPrv_code.Size = new System.Drawing.Size(169, 22);
            this.uiPrv_code.TabIndex = 4;
            // 
            // uiName
            // 
            this.uiName.Location = new System.Drawing.Point(486, 46);
            this.uiName.Name = "uiName";
            this.uiName.ReadOnly = true;
            this.uiName.Size = new System.Drawing.Size(169, 22);
            this.uiName.TabIndex = 3;
            // 
            // uiFamily
            // 
            this.uiFamily.Location = new System.Drawing.Point(224, 46);
            this.uiFamily.Name = "uiFamily";
            this.uiFamily.ReadOnly = true;
            this.uiFamily.Size = new System.Drawing.Size(169, 22);
            this.uiFamily.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 49);
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
            // OperationReportFormUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.uiShowReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uiSearchButton);
            this.Controls.Add(this.uiSerialSearchTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "OperationReportFormUC";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(752, 326);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiReceptionsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiSerialSearchTextBox;
        private System.Windows.Forms.Button uiSearchButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiPrv_code;
        private System.Windows.Forms.TextBox uiName;
        private System.Windows.Forms.TextBox uiFamily;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uiShowReport;
        public System.Windows.Forms.DataGridView uiReceptionsGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiSerial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeColumn;
    }
}
