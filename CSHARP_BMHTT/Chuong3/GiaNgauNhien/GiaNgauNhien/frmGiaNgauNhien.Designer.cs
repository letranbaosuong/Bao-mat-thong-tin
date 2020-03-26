namespace GiaNgauNhien
{
    partial class frmGiaNgauNhien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbHatGiong = new System.Windows.Forms.GroupBox();
            this.lblLan = new System.Windows.Forms.Label();
            this.nudSoLan = new System.Windows.Forms.NumericUpDown();
            this.nudHatGiongDen = new System.Windows.Forms.NumericUpDown();
            this.nudHatGiongTu = new System.Windows.Forms.NumericUpDown();
            this.lblDen = new System.Windows.Forms.Label();
            this.lblTu = new System.Windows.Forms.Label();
            this.rbThoiGian = new System.Windows.Forms.RadioButton();
            this.rbChiDinh = new System.Windows.Forms.RadioButton();
            this.dgBangSoLan = new System.Windows.Forms.DataGridView();
            this.btnTaoNgauNhien = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.stsStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsTienDo = new System.Windows.Forms.ToolStripProgressBar();
            this.dgcHatGiong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSoLan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbHatGiong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHatGiongDen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHatGiongTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBangSoLan)).BeginInit();
            this.stsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbHatGiong
            // 
            this.gbHatGiong.Controls.Add(this.lblLan);
            this.gbHatGiong.Controls.Add(this.nudSoLan);
            this.gbHatGiong.Controls.Add(this.nudHatGiongDen);
            this.gbHatGiong.Controls.Add(this.nudHatGiongTu);
            this.gbHatGiong.Controls.Add(this.lblDen);
            this.gbHatGiong.Controls.Add(this.lblTu);
            this.gbHatGiong.Controls.Add(this.rbThoiGian);
            this.gbHatGiong.Controls.Add(this.rbChiDinh);
            this.gbHatGiong.Location = new System.Drawing.Point(12, 12);
            this.gbHatGiong.Name = "gbHatGiong";
            this.gbHatGiong.Size = new System.Drawing.Size(374, 97);
            this.gbHatGiong.TabIndex = 0;
            this.gbHatGiong.TabStop = false;
            this.gbHatGiong.Text = "Hạt giống";
            // 
            // lblLan
            // 
            this.lblLan.AutoSize = true;
            this.lblLan.Location = new System.Drawing.Point(291, 65);
            this.lblLan.Name = "lblLan";
            this.lblLan.Size = new System.Drawing.Size(21, 13);
            this.lblLan.TabIndex = 8;
            this.lblLan.Text = "lần";
            // 
            // nudSoLan
            // 
            this.nudSoLan.Enabled = false;
            this.nudSoLan.Location = new System.Drawing.Point(164, 59);
            this.nudSoLan.Name = "nudSoLan";
            this.nudSoLan.Size = new System.Drawing.Size(120, 20);
            this.nudSoLan.TabIndex = 7;
            this.nudSoLan.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudSoLan.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // nudHatGiongDen
            // 
            this.nudHatGiongDen.Location = new System.Drawing.Point(228, 33);
            this.nudHatGiongDen.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudHatGiongDen.Name = "nudHatGiongDen";
            this.nudHatGiongDen.Size = new System.Drawing.Size(120, 20);
            this.nudHatGiongDen.TabIndex = 6;
            this.nudHatGiongDen.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudHatGiongDen.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // nudHatGiongTu
            // 
            this.nudHatGiongTu.Location = new System.Drawing.Point(78, 33);
            this.nudHatGiongTu.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudHatGiongTu.Name = "nudHatGiongTu";
            this.nudHatGiongTu.Size = new System.Drawing.Size(120, 20);
            this.nudHatGiongTu.TabIndex = 5;
            this.nudHatGiongTu.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(225, 16);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(27, 13);
            this.lblDen.TabIndex = 3;
            this.lblDen.Text = "Đến";
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(75, 16);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(20, 13);
            this.lblTu.TabIndex = 2;
            this.lblTu.Text = "Từ";
            // 
            // rbThoiGian
            // 
            this.rbThoiGian.AutoSize = true;
            this.rbThoiGian.Location = new System.Drawing.Point(6, 59);
            this.rbThoiGian.Name = "rbThoiGian";
            this.rbThoiGian.Size = new System.Drawing.Size(93, 17);
            this.rbThoiGian.TabIndex = 1;
            this.rbThoiGian.Text = "Theo thời gian";
            this.rbThoiGian.UseVisualStyleBackColor = true;
            this.rbThoiGian.CheckedChanged += new System.EventHandler(this.rbThoiGian_CheckedChanged);
            // 
            // rbChiDinh
            // 
            this.rbChiDinh.AutoSize = true;
            this.rbChiDinh.Checked = true;
            this.rbChiDinh.Location = new System.Drawing.Point(7, 37);
            this.rbChiDinh.Name = "rbChiDinh";
            this.rbChiDinh.Size = new System.Drawing.Size(64, 17);
            this.rbChiDinh.TabIndex = 0;
            this.rbChiDinh.TabStop = true;
            this.rbChiDinh.Text = "Chỉ định";
            this.rbChiDinh.UseVisualStyleBackColor = true;
            this.rbChiDinh.CheckedChanged += new System.EventHandler(this.rbChiDinh_CheckedChanged);
            // 
            // dgBangSoLan
            // 
            this.dgBangSoLan.AllowUserToAddRows = false;
            this.dgBangSoLan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBangSoLan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcHatGiong,
            this.dgcSoLan});
            this.dgBangSoLan.Location = new System.Drawing.Point(12, 115);
            this.dgBangSoLan.Name = "dgBangSoLan";
            this.dgBangSoLan.Size = new System.Drawing.Size(374, 189);
            this.dgBangSoLan.TabIndex = 1;
            // 
            // btnTaoNgauNhien
            // 
            this.btnTaoNgauNhien.Location = new System.Drawing.Point(12, 310);
            this.btnTaoNgauNhien.Name = "btnTaoNgauNhien";
            this.btnTaoNgauNhien.Size = new System.Drawing.Size(132, 23);
            this.btnTaoNgauNhien.TabIndex = 2;
            this.btnTaoNgauNhien.Text = "Tạo ngẫu nhiên";
            this.btnTaoNgauNhien.UseVisualStyleBackColor = true;
            this.btnTaoNgauNhien.Click += new System.EventHandler(this.btnTaoNgauNhien_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(254, 310);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(132, 23);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // stsStrip
            // 
            this.stsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.stsTienDo});
            this.stsStrip.Location = new System.Drawing.Point(0, 335);
            this.stsStrip.Name = "stsStrip";
            this.stsStrip.Size = new System.Drawing.Size(398, 22);
            this.stsStrip.TabIndex = 4;
            this.stsStrip.Text = "Trạng thái";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel1.Text = "Trạng thái";
            // 
            // stsTienDo
            // 
            this.stsTienDo.AutoSize = false;
            this.stsTienDo.Name = "stsTienDo";
            this.stsTienDo.Size = new System.Drawing.Size(280, 16);
            // 
            // dgcHatGiong
            // 
            this.dgcHatGiong.DataPropertyName = "HatGiong";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcHatGiong.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcHatGiong.HeaderText = "Hạt giống";
            this.dgcHatGiong.Name = "dgcHatGiong";
            // 
            // dgcSoLan
            // 
            this.dgcSoLan.DataPropertyName = "SoLan";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.dgcSoLan.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcSoLan.HeaderText = "Số lần";
            this.dgcSoLan.Name = "dgcSoLan";
            // 
            // frmGiaNgauNhien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 357);
            this.Controls.Add(this.stsStrip);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTaoNgauNhien);
            this.Controls.Add(this.dgBangSoLan);
            this.Controls.Add(this.gbHatGiong);
            this.Name = "frmGiaNgauNhien";
            this.Text = "Bảng Giả Ngẫu nhiên";
            this.Load += new System.EventHandler(this.frmGiaNgauNhien_Load);
            this.gbHatGiong.ResumeLayout(false);
            this.gbHatGiong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHatGiongDen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHatGiongTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBangSoLan)).EndInit();
            this.stsStrip.ResumeLayout(false);
            this.stsStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHatGiong;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.RadioButton rbThoiGian;
        private System.Windows.Forms.RadioButton rbChiDinh;
        private System.Windows.Forms.DataGridView dgBangSoLan;
        private System.Windows.Forms.Button btnTaoNgauNhien;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.StatusStrip stsStrip;
        private System.Windows.Forms.NumericUpDown nudHatGiongDen;
        private System.Windows.Forms.NumericUpDown nudHatGiongTu;
        private System.Windows.Forms.Label lblLan;
        private System.Windows.Forms.NumericUpDown nudSoLan;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar stsTienDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHatGiong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSoLan;
    }
}

