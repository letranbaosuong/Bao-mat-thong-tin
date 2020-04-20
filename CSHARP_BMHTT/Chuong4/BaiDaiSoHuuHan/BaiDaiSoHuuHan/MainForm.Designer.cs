namespace BaiDaiSoHuuHan
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuVanh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVanhZn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTruong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTruongQp = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVanh,
            this.mnuTruong});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // mnuVanh
            // 
            this.mnuVanh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVanhZn});
            this.mnuVanh.Name = "mnuVanh";
            this.mnuVanh.Size = new System.Drawing.Size(45, 20);
            this.mnuVanh.Text = "Vành";
            // 
            // mnuVanhZn
            // 
            this.mnuVanhZn.Name = "mnuVanhZn";
            this.mnuVanhZn.Size = new System.Drawing.Size(180, 22);
            this.mnuVanhZn.Text = "Vành Zn";
            this.mnuVanhZn.Click += new System.EventHandler(this.mnuVanhZn_Click);
            // 
            // mnuTruong
            // 
            this.mnuTruong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTruongQp});
            this.mnuTruong.Name = "mnuTruong";
            this.mnuTruong.Size = new System.Drawing.Size(56, 20);
            this.mnuTruong.Text = "Trường";
            // 
            // mnuTruongQp
            // 
            this.mnuTruongQp.Name = "mnuTruongQp";
            this.mnuTruongQp.Size = new System.Drawing.Size(180, 22);
            this.mnuTruongQp.Text = "Trường Qp";
            this.mnuTruongQp.Click += new System.EventHandler(this.mnuTruongQp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Đại số hữu hạn";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuVanh;
        private System.Windows.Forms.ToolStripMenuItem mnuVanhZn;
        private System.Windows.Forms.ToolStripMenuItem mnuTruong;
        private System.Windows.Forms.ToolStripMenuItem mnuTruongQp;
    }
}

