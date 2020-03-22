namespace MaHoaDonGian
{
    partial class StartUp
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
            this.lblDeAn = new System.Windows.Forms.Label();
            this.lblDienGiai = new System.Windows.Forms.Label();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDeAn
            // 
            this.lblDeAn.AutoSize = true;
            this.lblDeAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeAn.Location = new System.Drawing.Point(49, 32);
            this.lblDeAn.Name = "lblDeAn";
            this.lblDeAn.Size = new System.Drawing.Size(309, 29);
            this.lblDeAn.TabIndex = 0;
            this.lblDeAn.Text = "Mã hóa đơn giản V3.141592";
            // 
            // lblDienGiai
            // 
            this.lblDienGiai.AutoSize = true;
            this.lblDienGiai.Location = new System.Drawing.Point(51, 76);
            this.lblDienGiai.Name = "lblDienGiai";
            this.lblDienGiai.Size = new System.Drawing.Size(168, 13);
            this.lblDienGiai.TabIndex = 1;
            this.lblDienGiai.Text = "Các giải thuật mã hóa - DES, AES";
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTacGia.Location = new System.Drawing.Point(225, 126);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(169, 17);
            this.lblTacGia.TabIndex = 2;
            this.lblTacGia.Text = "Theo Lê Trần Bảo Sương";
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 232);
            this.Controls.Add(this.lblTacGia);
            this.Controls.Add(this.lblDienGiai);
            this.Controls.Add(this.lblDeAn);
            this.Name = "StartUp";
            this.Text = "StartUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeAn;
        private System.Windows.Forms.Label lblDienGiai;
        private System.Windows.Forms.Label lblTacGia;
    }
}