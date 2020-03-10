namespace Hamming
{
    partial class frmHamming
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
            this.lbl16KySoHex = new System.Windows.Forms.Label();
            this.lblSoThuNhat = new System.Windows.Forms.Label();
            this.lblSoThuHai = new System.Windows.Forms.Label();
            this.lblSoHex = new System.Windows.Forms.Label();
            this.lblSoNhiPhan = new System.Windows.Forms.Label();
            this.lblTrongSoHamming = new System.Windows.Forms.Label();
            this.lblKhoangCach = new System.Windows.Forms.Label();
            this.txtAHexStr = new System.Windows.Forms.TextBox();
            this.txtBHexStr = new System.Windows.Forms.TextBox();
            this.txtABinStr = new System.Windows.Forms.TextBox();
            this.txtBBinStr = new System.Windows.Forms.TextBox();
            this.txtATrongSo = new System.Windows.Forms.TextBox();
            this.txtBTrongSo = new System.Windows.Forms.TextBox();
            this.txtAxorBHexStr = new System.Windows.Forms.TextBox();
            this.txtAxorBBinStr = new System.Windows.Forms.TextBox();
            this.txtKhoangCach = new System.Windows.Forms.TextBox();
            this.btnTinhToan = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl16KySoHex
            // 
            this.lbl16KySoHex.AutoSize = true;
            this.lbl16KySoHex.Location = new System.Drawing.Point(30, 33);
            this.lbl16KySoHex.Name = "lbl16KySoHex";
            this.lbl16KySoHex.Size = new System.Drawing.Size(69, 13);
            this.lbl16KySoHex.TabIndex = 0;
            this.lbl16KySoHex.Text = "16 ký số Hex";
            // 
            // lblSoThuNhat
            // 
            this.lblSoThuNhat.AutoSize = true;
            this.lblSoThuNhat.Location = new System.Drawing.Point(30, 64);
            this.lblSoThuNhat.Name = "lblSoThuNhat";
            this.lblSoThuNhat.Size = new System.Drawing.Size(14, 13);
            this.lblSoThuNhat.TabIndex = 0;
            this.lblSoThuNhat.Text = "A";
            // 
            // lblSoThuHai
            // 
            this.lblSoThuHai.AutoSize = true;
            this.lblSoThuHai.Location = new System.Drawing.Point(30, 103);
            this.lblSoThuHai.Name = "lblSoThuHai";
            this.lblSoThuHai.Size = new System.Drawing.Size(14, 13);
            this.lblSoThuHai.TabIndex = 0;
            this.lblSoThuHai.Text = "B";
            // 
            // lblSoHex
            // 
            this.lblSoHex.AutoSize = true;
            this.lblSoHex.Location = new System.Drawing.Point(115, 33);
            this.lblSoHex.Name = "lblSoHex";
            this.lblSoHex.Size = new System.Drawing.Size(84, 13);
            this.lblSoHex.TabIndex = 0;
            this.lblSoHex.Text = "Số Hexadecimal";
            // 
            // lblSoNhiPhan
            // 
            this.lblSoNhiPhan.AutoSize = true;
            this.lblSoNhiPhan.Location = new System.Drawing.Point(258, 33);
            this.lblSoNhiPhan.Name = "lblSoNhiPhan";
            this.lblSoNhiPhan.Size = new System.Drawing.Size(64, 13);
            this.lblSoNhiPhan.TabIndex = 0;
            this.lblSoNhiPhan.Text = "Số nhị phân";
            // 
            // lblTrongSoHamming
            // 
            this.lblTrongSoHamming.AutoSize = true;
            this.lblTrongSoHamming.Location = new System.Drawing.Point(786, 33);
            this.lblTrongSoHamming.Name = "lblTrongSoHamming";
            this.lblTrongSoHamming.Size = new System.Drawing.Size(96, 13);
            this.lblTrongSoHamming.TabIndex = 0;
            this.lblTrongSoHamming.Text = "Trọng số Hamming";
            // 
            // lblKhoangCach
            // 
            this.lblKhoangCach.AutoSize = true;
            this.lblKhoangCach.Location = new System.Drawing.Point(776, 138);
            this.lblKhoangCach.Name = "lblKhoangCach";
            this.lblKhoangCach.Size = new System.Drawing.Size(118, 13);
            this.lblKhoangCach.TabIndex = 0;
            this.lblKhoangCach.Text = "Khoảng cách Hamming";
            // 
            // txtAHexStr
            // 
            this.txtAHexStr.Location = new System.Drawing.Point(118, 61);
            this.txtAHexStr.Name = "txtAHexStr";
            this.txtAHexStr.Size = new System.Drawing.Size(126, 20);
            this.txtAHexStr.TabIndex = 1;
            this.txtAHexStr.TextChanged += new System.EventHandler(this.txtHexStr_TextChanged);
            // 
            // txtBHexStr
            // 
            this.txtBHexStr.Location = new System.Drawing.Point(118, 100);
            this.txtBHexStr.Name = "txtBHexStr";
            this.txtBHexStr.Size = new System.Drawing.Size(126, 20);
            this.txtBHexStr.TabIndex = 2;
            this.txtBHexStr.TextChanged += new System.EventHandler(this.txtHexStr_TextChanged);
            // 
            // txtABinStr
            // 
            this.txtABinStr.Location = new System.Drawing.Point(261, 61);
            this.txtABinStr.Name = "txtABinStr";
            this.txtABinStr.ReadOnly = true;
            this.txtABinStr.Size = new System.Drawing.Size(487, 20);
            this.txtABinStr.TabIndex = 3;
            // 
            // txtBBinStr
            // 
            this.txtBBinStr.Location = new System.Drawing.Point(261, 103);
            this.txtBBinStr.Name = "txtBBinStr";
            this.txtBBinStr.ReadOnly = true;
            this.txtBBinStr.Size = new System.Drawing.Size(487, 20);
            this.txtBBinStr.TabIndex = 4;
            // 
            // txtATrongSo
            // 
            this.txtATrongSo.Location = new System.Drawing.Point(775, 61);
            this.txtATrongSo.Name = "txtATrongSo";
            this.txtATrongSo.ReadOnly = true;
            this.txtATrongSo.Size = new System.Drawing.Size(119, 20);
            this.txtATrongSo.TabIndex = 5;
            // 
            // txtBTrongSo
            // 
            this.txtBTrongSo.Location = new System.Drawing.Point(775, 100);
            this.txtBTrongSo.Name = "txtBTrongSo";
            this.txtBTrongSo.ReadOnly = true;
            this.txtBTrongSo.Size = new System.Drawing.Size(119, 20);
            this.txtBTrongSo.TabIndex = 6;
            // 
            // txtAxorBHexStr
            // 
            this.txtAxorBHexStr.Location = new System.Drawing.Point(118, 154);
            this.txtAxorBHexStr.Name = "txtAxorBHexStr";
            this.txtAxorBHexStr.ReadOnly = true;
            this.txtAxorBHexStr.Size = new System.Drawing.Size(126, 20);
            this.txtAxorBHexStr.TabIndex = 2;
            // 
            // txtAxorBBinStr
            // 
            this.txtAxorBBinStr.Location = new System.Drawing.Point(261, 154);
            this.txtAxorBBinStr.Name = "txtAxorBBinStr";
            this.txtAxorBBinStr.ReadOnly = true;
            this.txtAxorBBinStr.Size = new System.Drawing.Size(487, 20);
            this.txtAxorBBinStr.TabIndex = 4;
            // 
            // txtKhoangCach
            // 
            this.txtKhoangCach.Location = new System.Drawing.Point(775, 154);
            this.txtKhoangCach.Name = "txtKhoangCach";
            this.txtKhoangCach.ReadOnly = true;
            this.txtKhoangCach.Size = new System.Drawing.Size(119, 20);
            this.txtKhoangCach.TabIndex = 6;
            // 
            // btnTinhToan
            // 
            this.btnTinhToan.Enabled = false;
            this.btnTinhToan.Location = new System.Drawing.Point(118, 214);
            this.btnTinhToan.Name = "btnTinhToan";
            this.btnTinhToan.Size = new System.Drawing.Size(126, 23);
            this.btnTinhToan.TabIndex = 7;
            this.btnTinhToan.Text = "Tính toán";
            this.btnTinhToan.UseVisualStyleBackColor = true;
            this.btnTinhToan.Click += new System.EventHandler(this.btnTinhToan_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(261, 214);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(126, 23);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hamming.Properties.Resources.AxorB;
            this.pictureBox1.Location = new System.Drawing.Point(33, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 28);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmHamming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 269);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTinhToan);
            this.Controls.Add(this.txtKhoangCach);
            this.Controls.Add(this.txtBTrongSo);
            this.Controls.Add(this.txtATrongSo);
            this.Controls.Add(this.txtAxorBBinStr);
            this.Controls.Add(this.txtBBinStr);
            this.Controls.Add(this.txtABinStr);
            this.Controls.Add(this.txtAxorBHexStr);
            this.Controls.Add(this.txtBHexStr);
            this.Controls.Add(this.txtAHexStr);
            this.Controls.Add(this.lblKhoangCach);
            this.Controls.Add(this.lblSoNhiPhan);
            this.Controls.Add(this.lblSoThuHai);
            this.Controls.Add(this.lblTrongSoHamming);
            this.Controls.Add(this.lblSoHex);
            this.Controls.Add(this.lblSoThuNhat);
            this.Controls.Add(this.lbl16KySoHex);
            this.Name = "frmHamming";
            this.Text = "Bài toán Hamming";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl16KySoHex;
        private System.Windows.Forms.Label lblSoThuNhat;
        private System.Windows.Forms.Label lblSoThuHai;
        private System.Windows.Forms.Label lblSoHex;
        private System.Windows.Forms.Label lblSoNhiPhan;
        private System.Windows.Forms.Label lblTrongSoHamming;
        private System.Windows.Forms.Label lblKhoangCach;
        private System.Windows.Forms.TextBox txtAHexStr;
        private System.Windows.Forms.TextBox txtBHexStr;
        private System.Windows.Forms.TextBox txtABinStr;
        private System.Windows.Forms.TextBox txtBBinStr;
        private System.Windows.Forms.TextBox txtATrongSo;
        private System.Windows.Forms.TextBox txtBTrongSo;
        private System.Windows.Forms.TextBox txtAxorBHexStr;
        private System.Windows.Forms.TextBox txtAxorBBinStr;
        private System.Windows.Forms.TextBox txtKhoangCach;
        private System.Windows.Forms.Button btnTinhToan;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

