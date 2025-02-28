namespace HISPlus
{
    partial class DBConnectionSettingForm
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
            this.uiOpRoomConnectionTest = new System.Windows.Forms.Button();
            this.uiOpRoomConnectionString = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiHisPlusConnectionTest = new System.Windows.Forms.Button();
            this.uiHISPlusConnectionString = new System.Windows.Forms.TextBox();
            this.uiSaveButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiOpRoomConnectionTest);
            this.groupBox1.Controls.Add(this.uiOpRoomConnectionString);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "متن اتصال به دیتابیس OpRoom";
            // 
            // uiOpRoomConnectionTest
            // 
            this.uiOpRoomConnectionTest.Location = new System.Drawing.Point(6, 97);
            this.uiOpRoomConnectionTest.Name = "uiOpRoomConnectionTest";
            this.uiOpRoomConnectionTest.Size = new System.Drawing.Size(133, 33);
            this.uiOpRoomConnectionTest.TabIndex = 1;
            this.uiOpRoomConnectionTest.Text = "تست اتصال";
            this.uiOpRoomConnectionTest.UseVisualStyleBackColor = true;
            this.uiOpRoomConnectionTest.Click += new System.EventHandler(this.uiOpRoomConnectionTest_Click);
            // 
            // uiOpRoomConnectionString
            // 
            this.uiOpRoomConnectionString.Location = new System.Drawing.Point(6, 29);
            this.uiOpRoomConnectionString.Multiline = true;
            this.uiOpRoomConnectionString.Name = "uiOpRoomConnectionString";
            this.uiOpRoomConnectionString.Size = new System.Drawing.Size(562, 63);
            this.uiOpRoomConnectionString.TabIndex = 0;
            this.uiOpRoomConnectionString.Text = "Data Source=.;Initial Catalog=oproom;Integrated Security=True";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiHisPlusConnectionTest);
            this.groupBox2.Controls.Add(this.uiHISPlusConnectionString);
            this.groupBox2.Location = new System.Drawing.Point(6, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 139);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "متن اتصال به دیتابیس +HIS";
            // 
            // uiHisPlusConnectionTest
            // 
            this.uiHisPlusConnectionTest.Location = new System.Drawing.Point(3, 100);
            this.uiHisPlusConnectionTest.Name = "uiHisPlusConnectionTest";
            this.uiHisPlusConnectionTest.Size = new System.Drawing.Size(127, 33);
            this.uiHisPlusConnectionTest.TabIndex = 2;
            this.uiHisPlusConnectionTest.Text = "تست اتصال";
            this.uiHisPlusConnectionTest.UseVisualStyleBackColor = true;
            this.uiHisPlusConnectionTest.Click += new System.EventHandler(this.uiHisPlusConnectionTest_Click);
            // 
            // uiHISPlusConnectionString
            // 
            this.uiHISPlusConnectionString.Location = new System.Drawing.Point(3, 30);
            this.uiHISPlusConnectionString.Multiline = true;
            this.uiHISPlusConnectionString.Name = "uiHISPlusConnectionString";
            this.uiHISPlusConnectionString.Size = new System.Drawing.Size(565, 64);
            this.uiHISPlusConnectionString.TabIndex = 1;
            // 
            // uiSaveButton
            // 
            this.uiSaveButton.Location = new System.Drawing.Point(467, 319);
            this.uiSaveButton.Name = "uiSaveButton";
            this.uiSaveButton.Size = new System.Drawing.Size(113, 36);
            this.uiSaveButton.TabIndex = 3;
            this.uiSaveButton.Text = "ثبت تغییرات";
            this.uiSaveButton.UseVisualStyleBackColor = true;
            this.uiSaveButton.Click += new System.EventHandler(this.uiSaveButton_Click);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(348, 319);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(113, 36);
            this.uiCancelButton.TabIndex = 4;
            this.uiCancelButton.Text = "انصراف";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // DBConnectionSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uiCancelButton;
            this.ClientSize = new System.Drawing.Size(589, 365);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiSaveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DBConnectionSettingForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تنظیم اتصال به بانک های اطلاعات ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiOpRoomConnectionTest;
        private System.Windows.Forms.TextBox uiOpRoomConnectionString;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button uiHisPlusConnectionTest;
        private System.Windows.Forms.TextBox uiHISPlusConnectionString;
        private System.Windows.Forms.Button uiSaveButton;
        private System.Windows.Forms.Button uiCancelButton;
    }
}