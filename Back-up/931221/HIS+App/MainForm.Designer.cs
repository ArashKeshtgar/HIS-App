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
            this.uiConfigDbConnectionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiEditOpReportTemplateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiDefoultTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationReportFormUC1 = new HISPlus.OperationReportFormUC();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.امکاناتToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(759, 24);
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
            this.uiConfigDbConnectionsMenuItem,
            this.uiEditOpReportTemplateMenuItem,
            this.uiDefoultTextMenuItem});
            this.تنظیماتToolStripMenuItem.Name = "تنظیماتToolStripMenuItem";
            this.تنظیماتToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.تنظیماتToolStripMenuItem.Text = "تنظیمات";
            // 
            // uiConfigDbConnectionsMenuItem
            // 
            this.uiConfigDbConnectionsMenuItem.Name = "uiConfigDbConnectionsMenuItem";
            this.uiConfigDbConnectionsMenuItem.Size = new System.Drawing.Size(241, 22);
            this.uiConfigDbConnectionsMenuItem.Text = "تنظیم اتصال به بانک های اطلاعات";
            this.uiConfigDbConnectionsMenuItem.Click += new System.EventHandler(this.uiConfigDbConnectionsMenuItem_Click);
            // 
            // uiEditOpReportTemplateMenuItem
            // 
            this.uiEditOpReportTemplateMenuItem.Name = "uiEditOpReportTemplateMenuItem";
            this.uiEditOpReportTemplateMenuItem.Size = new System.Drawing.Size(241, 22);
            this.uiEditOpReportTemplateMenuItem.Text = "ویرایش الگوی گزارش عمل جراحی";
            this.uiEditOpReportTemplateMenuItem.Click += new System.EventHandler(this.uiEditOpReportTemplateMenuItem_Click);
            // 
            // uiDefoultTextMenuItem
            // 
            this.uiDefoultTextMenuItem.Name = "uiDefoultTextMenuItem";
            this.uiDefoultTextMenuItem.Size = new System.Drawing.Size(241, 22);
            this.uiDefoultTextMenuItem.Text = "شرح عمل های پیش فرض";
            this.uiDefoultTextMenuItem.Click += new System.EventHandler(this.uiDefoultTextMenuItem_Click);
            // 
            // operationReportFormUC1
            // 
            this.operationReportFormUC1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operationReportFormUC1.BackColor = System.Drawing.SystemColors.Control;
            this.operationReportFormUC1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.operationReportFormUC1.Location = new System.Drawing.Point(6, 25);
            this.operationReportFormUC1.Name = "operationReportFormUC1";
            this.operationReportFormUC1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.operationReportFormUC1.Size = new System.Drawing.Size(753, 311);
            this.operationReportFormUC1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 342);
            this.Controls.Add(this.operationReportFormUC1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم اصلی";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem امکاناتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتگزارشعملجراحیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تنظیماتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uiConfigDbConnectionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uiEditOpReportTemplateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uiDefoultTextMenuItem;
        private OperationReportFormUC operationReportFormUC1;
    }
}

