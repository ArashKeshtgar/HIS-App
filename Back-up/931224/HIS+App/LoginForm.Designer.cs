namespace HISPlus
{
    partial class LoginForm
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
            this.uiLoginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiPasswordTxt = new System.Windows.Forms.TextBox();
            this.uiUseNameTxt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLoginButton
            // 
            this.uiLoginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiLoginButton.Location = new System.Drawing.Point(265, 93);
            this.uiLoginButton.Name = "uiLoginButton";
            this.uiLoginButton.Size = new System.Drawing.Size(119, 25);
            this.uiLoginButton.TabIndex = 3;
            this.uiLoginButton.Text = "ورود";
            this.uiLoginButton.UseVisualStyleBackColor = true;
            this.uiLoginButton.Click += new System.EventHandler(this.uiLoginButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "نام کاربری:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "کلمه عبور:";
            // 
            // uiPasswordTxt
            // 
            this.uiPasswordTxt.Location = new System.Drawing.Point(179, 59);
            this.uiPasswordTxt.Name = "uiPasswordTxt";
            this.uiPasswordTxt.PasswordChar = '*';
            this.uiPasswordTxt.Size = new System.Drawing.Size(205, 22);
            this.uiPasswordTxt.TabIndex = 2;
            this.uiPasswordTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uiPasswordTxt_KeyPress);
            // 
            // uiUseNameTxt
            // 
            this.uiUseNameTxt.Location = new System.Drawing.Point(179, 31);
            this.uiUseNameTxt.Name = "uiUseNameTxt";
            this.uiUseNameTxt.Size = new System.Drawing.Size(205, 22);
            this.uiUseNameTxt.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HISPlus.Properties.Resources._1391306164_preferences_system_login;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 106);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 139);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uiUseNameTxt);
            this.Controls.Add(this.uiPasswordTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiLoginButton);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "LoginForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ورود";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uiLoginButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiPasswordTxt;
        private System.Windows.Forms.TextBox uiUseNameTxt;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}