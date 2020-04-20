namespace BaiDaiSoHuuHan
{
    partial class frmVanhZn
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
            this.lblN = new System.Windows.Forms.Label();
            this.nudN = new System.Windows.Forms.NumericUpDown();
            this.btnCong = new System.Windows.Forms.Button();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnLuyThua = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).BeginInit();
            this.SuspendLayout();
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(12, 23);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(49, 13);
            this.lblN.TabIndex = 0;
            this.lblN.Text = "Cho số n";
            // 
            // nudN
            // 
            this.nudN.Location = new System.Drawing.Point(80, 21);
            this.nudN.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudN.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudN.Name = "nudN";
            this.nudN.Size = new System.Drawing.Size(120, 20);
            this.nudN.TabIndex = 1;
            this.nudN.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnCong
            // 
            this.btnCong.Location = new System.Drawing.Point(15, 59);
            this.btnCong.Name = "btnCong";
            this.btnCong.Size = new System.Drawing.Size(75, 23);
            this.btnCong.TabIndex = 2;
            this.btnCong.Text = "+";
            this.btnCong.UseVisualStyleBackColor = true;
            this.btnCong.Click += new System.EventHandler(this.btnCong_Click);
            // 
            // btnNhan
            // 
            this.btnNhan.Location = new System.Drawing.Point(96, 59);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(75, 23);
            this.btnNhan.TabIndex = 3;
            this.btnNhan.Text = "*";
            this.btnNhan.UseVisualStyleBackColor = true;
            this.btnNhan.Click += new System.EventHandler(this.btnNhan_Click);
            // 
            // btnLuyThua
            // 
            this.btnLuyThua.Location = new System.Drawing.Point(177, 59);
            this.btnLuyThua.Name = "btnLuyThua";
            this.btnLuyThua.Size = new System.Drawing.Size(75, 23);
            this.btnLuyThua.TabIndex = 4;
            this.btnLuyThua.Text = "^";
            this.btnLuyThua.UseVisualStyleBackColor = true;
            this.btnLuyThua.Click += new System.EventHandler(this.btnLuyThua_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(258, 59);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmVanhZn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 117);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuyThua);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.btnCong);
            this.Controls.Add(this.nudN);
            this.Controls.Add(this.lblN);
            this.Name = "frmVanhZn";
            this.Text = "Vành Zn";
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.Button btnCong;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnLuyThua;
        private System.Windows.Forms.Button btnDong;
    }
}