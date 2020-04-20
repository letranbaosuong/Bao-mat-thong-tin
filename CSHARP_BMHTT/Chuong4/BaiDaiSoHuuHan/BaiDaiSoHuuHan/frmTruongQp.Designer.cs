namespace BaiDaiSoHuuHan
{
    partial class frmTruongQp
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
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuyThua = new System.Windows.Forms.Button();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnCong = new System.Windows.Forms.Button();
            this.nudP = new System.Windows.Forms.NumericUpDown();
            this.lblP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(258, 45);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuyThua
            // 
            this.btnLuyThua.Location = new System.Drawing.Point(177, 45);
            this.btnLuyThua.Name = "btnLuyThua";
            this.btnLuyThua.Size = new System.Drawing.Size(75, 23);
            this.btnLuyThua.TabIndex = 10;
            this.btnLuyThua.Text = "^";
            this.btnLuyThua.UseVisualStyleBackColor = true;
            this.btnLuyThua.Click += new System.EventHandler(this.btnLuyThua_Click);
            // 
            // btnNhan
            // 
            this.btnNhan.Location = new System.Drawing.Point(96, 45);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(75, 23);
            this.btnNhan.TabIndex = 9;
            this.btnNhan.Text = "*";
            this.btnNhan.UseVisualStyleBackColor = true;
            this.btnNhan.Click += new System.EventHandler(this.btnNhan_Click);
            // 
            // btnCong
            // 
            this.btnCong.Location = new System.Drawing.Point(15, 45);
            this.btnCong.Name = "btnCong";
            this.btnCong.Size = new System.Drawing.Size(75, 23);
            this.btnCong.TabIndex = 8;
            this.btnCong.Text = "+";
            this.btnCong.UseVisualStyleBackColor = true;
            this.btnCong.Click += new System.EventHandler(this.btnCong_Click);
            // 
            // nudP
            // 
            this.nudP.Location = new System.Drawing.Point(80, 7);
            this.nudP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudP.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudP.Name = "nudP";
            this.nudP.Size = new System.Drawing.Size(120, 20);
            this.nudP.TabIndex = 7;
            this.nudP.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudP.ValueChanged += new System.EventHandler(this.nudP_ValueChanged);
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(12, 9);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(49, 13);
            this.lblP.TabIndex = 6;
            this.lblP.Text = "Cho số p";
            // 
            // frmTruongQp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 80);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuyThua);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.btnCong);
            this.Controls.Add(this.nudP);
            this.Controls.Add(this.lblP);
            this.Name = "frmTruongQp";
            this.Text = "Trường Qp";
            ((System.ComponentModel.ISupportInitialize)(this.nudP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuyThua;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnCong;
        private System.Windows.Forms.NumericUpDown nudP;
        private System.Windows.Forms.Label lblP;
    }
}