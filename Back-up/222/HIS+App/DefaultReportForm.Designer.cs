namespace HISPlus
{
    partial class DefaultReportForm
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
            this.uiShowButton = new System.Windows.Forms.Button();
            this.uiDoctorCmBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiDefaltTextGrid = new System.Windows.Forms.DataGridView();
            this.KindOperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDefault = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiNewButton = new System.Windows.Forms.Button();
            this.uiEditButton = new System.Windows.Forms.Button();
            this.uiDeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiDefaltTextGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // uiShowButton
            // 
            this.uiShowButton.Location = new System.Drawing.Point(199, 18);
            this.uiShowButton.Name = "uiShowButton";
            this.uiShowButton.Size = new System.Drawing.Size(130, 25);
            this.uiShowButton.TabIndex = 0;
            this.uiShowButton.Text = "نمایش";
            this.uiShowButton.UseVisualStyleBackColor = true;
            this.uiShowButton.Click += new System.EventHandler(this.uiShowButton_Click);
            // 
            // uiDoctorCmBox
            // 
            this.uiDoctorCmBox.FormattingEnabled = true;
            this.uiDoctorCmBox.Location = new System.Drawing.Point(339, 18);
            this.uiDoctorCmBox.Name = "uiDoctorCmBox";
            this.uiDoctorCmBox.Size = new System.Drawing.Size(183, 22);
            this.uiDoctorCmBox.TabIndex = 1;
            this.uiDoctorCmBox.SelectedIndexChanged += new System.EventHandler(this.uiDoctorCmBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "دکتر:";
            // 
            // uiDefaltTextGrid
            // 
            this.uiDefaltTextGrid.AllowUserToAddRows = false;
            this.uiDefaltTextGrid.AllowUserToDeleteRows = false;
            this.uiDefaltTextGrid.AllowUserToResizeRows = false;
            this.uiDefaltTextGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDefaltTextGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.uiDefaltTextGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiDefaltTextGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KindOperation,
            this.DefaultText,
            this.IDDefault,
            this.Doctor});
            this.uiDefaltTextGrid.Location = new System.Drawing.Point(2, 49);
            this.uiDefaltTextGrid.Name = "uiDefaltTextGrid";
            this.uiDefaltTextGrid.ReadOnly = true;
            this.uiDefaltTextGrid.Size = new System.Drawing.Size(568, 150);
            this.uiDefaltTextGrid.TabIndex = 3;
            this.uiDefaltTextGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiDefaltTextGrid_CellContentClick);
            this.uiDefaltTextGrid.SelectionChanged += new System.EventHandler(this.uiDefaltTextGrid_SelectionChanged);
            // 
            // KindOperation
            // 
            this.KindOperation.DataPropertyName = "OperationName";
            this.KindOperation.HeaderText = "نوع عمل";
            this.KindOperation.Name = "KindOperation";
            this.KindOperation.ReadOnly = true;
            // 
            // DefaultText
            // 
            this.DefaultText.DataPropertyName = "DefaultText";
            this.DefaultText.HeaderText = "شرح عمل";
            this.DefaultText.Name = "DefaultText";
            this.DefaultText.ReadOnly = true;
            // 
            // IDDefault
            // 
            this.IDDefault.DataPropertyName = "ID";
            this.IDDefault.HeaderText = "ID";
            this.IDDefault.Name = "IDDefault";
            this.IDDefault.ReadOnly = true;
            this.IDDefault.Visible = false;
            // 
            // Doctor
            // 
            this.Doctor.DataPropertyName = "DoctorName";
            this.Doctor.HeaderText = "دکتر";
            this.Doctor.Name = "Doctor";
            this.Doctor.ReadOnly = true;
            this.Doctor.Visible = false;
            // 
            // uiNewButton
            // 
            this.uiNewButton.Location = new System.Drawing.Point(495, 205);
            this.uiNewButton.Name = "uiNewButton";
            this.uiNewButton.Size = new System.Drawing.Size(75, 23);
            this.uiNewButton.TabIndex = 4;
            this.uiNewButton.Text = "جدید";
            this.uiNewButton.UseVisualStyleBackColor = true;
            this.uiNewButton.Click += new System.EventHandler(this.uiNewButton_Click);
            // 
            // uiEditButton
            // 
            this.uiEditButton.Location = new System.Drawing.Point(418, 205);
            this.uiEditButton.Name = "uiEditButton";
            this.uiEditButton.Size = new System.Drawing.Size(75, 23);
            this.uiEditButton.TabIndex = 5;
            this.uiEditButton.Text = "ویرایش";
            this.uiEditButton.UseVisualStyleBackColor = true;
            this.uiEditButton.Click += new System.EventHandler(this.uiEditButton_Click);
            // 
            // uiDeleteButton
            // 
            this.uiDeleteButton.Location = new System.Drawing.Point(340, 205);
            this.uiDeleteButton.Name = "uiDeleteButton";
            this.uiDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.uiDeleteButton.TabIndex = 6;
            this.uiDeleteButton.Text = "حذف";
            this.uiDeleteButton.UseVisualStyleBackColor = true;
            this.uiDeleteButton.Click += new System.EventHandler(this.uiDeleteButton_Click);
            // 
            // DefaultReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 241);
            this.Controls.Add(this.uiDeleteButton);
            this.Controls.Add(this.uiEditButton);
            this.Controls.Add(this.uiNewButton);
            this.Controls.Add(this.uiDefaltTextGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiDoctorCmBox);
            this.Controls.Add(this.uiShowButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DefaultReportForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "شرح عمل های پیش فرض";
            this.Load += new System.EventHandler(this.DefaultReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiDefaltTextGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uiShowButton;
        private System.Windows.Forms.ComboBox uiDoctorCmBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView uiDefaltTextGrid;
        private System.Windows.Forms.Button uiNewButton;
        private System.Windows.Forms.Button uiEditButton;
        private System.Windows.Forms.Button uiDeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn KindOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultText;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doctor;
    }
}