namespace HISPlus
{
    partial class DefaultOpProcedureEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.uiDoctorNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiDefaultText = new System.Windows.Forms.TextBox();
            this.uiSaveButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiOperationCombo = new HISPlus.AutoCompleteComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "پزشک:";
            // 
            // uiDoctorNameTextBox
            // 
            this.uiDoctorNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDoctorNameTextBox.Location = new System.Drawing.Point(323, 13);
            this.uiDoctorNameTextBox.Name = "uiDoctorNameTextBox";
            this.uiDoctorNameTextBox.ReadOnly = true;
            this.uiDoctorNameTextBox.Size = new System.Drawing.Size(166, 22);
            this.uiDoctorNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "نوع عمل:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "شرح پیش فرض:";
            // 
            // uiDefaultText
            // 
            this.uiDefaultText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDefaultText.Location = new System.Drawing.Point(12, 71);
            this.uiDefaultText.Multiline = true;
            this.uiDefaultText.Name = "uiDefaultText";
            this.uiDefaultText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uiDefaultText.Size = new System.Drawing.Size(528, 182);
            this.uiDefaultText.TabIndex = 5;
            // 
            // uiSaveButton
            // 
            this.uiSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSaveButton.Location = new System.Drawing.Point(451, 261);
            this.uiSaveButton.Name = "uiSaveButton";
            this.uiSaveButton.Size = new System.Drawing.Size(89, 30);
            this.uiSaveButton.TabIndex = 6;
            this.uiSaveButton.Text = "ذخیره";
            this.uiSaveButton.UseVisualStyleBackColor = true;
            this.uiSaveButton.Click += new System.EventHandler(this.uiSaveButton_Click);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCancelButton.Location = new System.Drawing.Point(356, 261);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(89, 30);
            this.uiCancelButton.TabIndex = 7;
            this.uiCancelButton.Text = "انصراف";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiOperationCombo
            // 
            this.uiOperationCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOperationCombo.DataSource = null;
            this.uiOperationCombo.DisplayMember = "";
            this.uiOperationCombo.Location = new System.Drawing.Point(12, 13);
            this.uiOperationCombo.Name = "uiOperationCombo";
            this.uiOperationCombo.SelectedValue = null;
            this.uiOperationCombo.Size = new System.Drawing.Size(246, 22);
            this.uiOperationCombo.TabIndex = 8;
            this.uiOperationCombo.ValueMember = "";
            this.uiOperationCombo.ItemsRequested += new System.EventHandler(this.uiOperationCombo_ItemsRequested);
            // 
            // DefaultOpProcedureEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 301);
            this.Controls.Add(this.uiOperationCombo);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiSaveButton);
            this.Controls.Add(this.uiDefaultText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiDoctorNameTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimumSize = new System.Drawing.Size(570, 340);
            this.Name = "DefaultOpProcedureEditForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ویرایش شرح عمل پیش فرض";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiDoctorNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiDefaultText;
        private System.Windows.Forms.Button uiSaveButton;
        private System.Windows.Forms.Button uiCancelButton;
        private AutoCompleteComboBox uiOperationCombo;
    }
}