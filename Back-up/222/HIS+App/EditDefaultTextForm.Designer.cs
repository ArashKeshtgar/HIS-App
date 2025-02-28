namespace HISPlus
{
    partial class EditDefaultTextForm
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
            this.uiDoctorNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiKindOfOperationCmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiDefaultText = new System.Windows.Forms.TextBox();
            this.uiSaveButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "پزشک:";
            // 
            // uiDoctorNameTxt
            // 
            this.uiDoctorNameTxt.Location = new System.Drawing.Point(323, 13);
            this.uiDoctorNameTxt.Name = "uiDoctorNameTxt";
            this.uiDoctorNameTxt.ReadOnly = true;
            this.uiDoctorNameTxt.Size = new System.Drawing.Size(174, 22);
            this.uiDoctorNameTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "نوع عمل:";
            // 
            // uiKindOfOperationCmb
            // 
            this.uiKindOfOperationCmb.FormattingEnabled = true;
            this.uiKindOfOperationCmb.Location = new System.Drawing.Point(106, 13);
            this.uiKindOfOperationCmb.Name = "uiKindOfOperationCmb";
            this.uiKindOfOperationCmb.Size = new System.Drawing.Size(161, 22);
            this.uiKindOfOperationCmb.TabIndex = 3;
            this.uiKindOfOperationCmb.SelectedIndexChanged += new System.EventHandler(this.uiKindOfOperationCmb_SelectedIndexChanged);
            this.uiKindOfOperationCmb.SelectedValueChanged += new System.EventHandler(this.uiKindOfOperationCmb_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "شرح عمل پیش فرض:";
            // 
            // uiDefaultText
            // 
            this.uiDefaultText.Location = new System.Drawing.Point(1, 54);
            this.uiDefaultText.Multiline = true;
            this.uiDefaultText.Name = "uiDefaultText";
            this.uiDefaultText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uiDefaultText.Size = new System.Drawing.Size(548, 153);
            this.uiDefaultText.TabIndex = 5;
            // 
            // uiSaveButton
            // 
            this.uiSaveButton.Location = new System.Drawing.Point(474, 213);
            this.uiSaveButton.Name = "uiSaveButton";
            this.uiSaveButton.Size = new System.Drawing.Size(75, 23);
            this.uiSaveButton.TabIndex = 6;
            this.uiSaveButton.Text = "ذخیره";
            this.uiSaveButton.UseVisualStyleBackColor = true;
            this.uiSaveButton.Click += new System.EventHandler(this.uiSaveButton_Click);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Location = new System.Drawing.Point(393, 213);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 7;
            this.uiCancelButton.Text = "انصراف";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // EditDefaultTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 244);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiSaveButton);
            this.Controls.Add(this.uiDefaultText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiKindOfOperationCmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiDoctorNameTxt);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "EditDefaultTextForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ویرایش شرح عمل پیش فرض";
            this.Load += new System.EventHandler(this.EditDefaultTextForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiDoctorNameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uiKindOfOperationCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiDefaultText;
        private System.Windows.Forms.Button uiSaveButton;
        private System.Windows.Forms.Button uiCancelButton;
    }
}