namespace HISPlus
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.امکاناتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتگزارشعملجراحیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تنظیماتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تنظیماتصالبهدیتابیسToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.operationReportFormUC1 = new HISPlus.OperationReportFormUC();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.امکاناتToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // امکاناتToolStripMenuItem
            // 
            this.امکاناتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ثبتگزارشعملجراحیToolStripMenuItem,
            this.تنظیماتToolStripMenuItem});
            this.امکاناتToolStripMenuItem.Name = "امکاناتToolStripMenuItem";
            this.امکاناتToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.امکاناتToolStripMenuItem.Text = "امکانات";
            // 
            // ثبتگزارشعملجراحیToolStripMenuItem
            // 
            this.ثبتگزارشعملجراحیToolStripMenuItem.Name = "ثبتگزارشعملجراحیToolStripMenuItem";
            this.ثبتگزارشعملجراحیToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ثبتگزارشعملجراحیToolStripMenuItem.Text = "ثبت گزارش عمل جراحی";
            // 
            // تنظیماتToolStripMenuItem
            // 
            this.تنظیماتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تنظیماتصالبهدیتابیسToolStripMenuItem});
            this.تنظیماتToolStripMenuItem.Name = "تنظیماتToolStripMenuItem";
            this.تنظیماتToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.تنظیماتToolStripMenuItem.Text = "تنظیمات";
            // 
            // تنظیماتصالبهدیتابیسToolStripMenuItem
            // 
            this.تنظیماتصالبهدیتابیسToolStripMenuItem.Name = "تنظیماتصالبهدیتابیسToolStripMenuItem";
            this.تنظیماتصالبهدیتابیسToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.تنظیماتصالبهدیتابیسToolStripMenuItem.Text = "تنظیم اتصال به بانک های اطلاعات";
            this.تنظیماتصالبهدیتابیسToolStripMenuItem.Click += new System.EventHandler(this.تنظیماتصالبهدیتابیسToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.operationReportFormUC1);
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 357);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // operationReportFormUC1
            // 
            this.operationReportFormUC1.BackColor = System.Drawing.SystemColors.Control;
            this.operationReportFormUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationReportFormUC1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.operationReportFormUC1.Location = new System.Drawing.Point(3, 16);
            this.operationReportFormUC1.Name = "operationReportFormUC1";
            this.operationReportFormUC1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.operationReportFormUC1.Size = new System.Drawing.Size(750, 338);
            this.operationReportFormUC1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 383);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم اصلی";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem امکاناتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتگزارشعملجراحیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تنظیماتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تنظیماتصالبهدیتابیسToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private OperationReportFormUC operationReportFormUC1;
    }
}

