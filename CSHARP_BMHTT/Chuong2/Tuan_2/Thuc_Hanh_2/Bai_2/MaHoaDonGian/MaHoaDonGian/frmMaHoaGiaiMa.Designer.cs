namespace MaHoaDonGian
{
    partial class frmMaHoaGiaiMa
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
            this.BoxAlogrithm = new System.Windows.Forms.GroupBox();
            this.rbAES = new System.Windows.Forms.RadioButton();
            this.rbDES = new System.Windows.Forms.RadioButton();
            this.BoxElapsedTime = new System.Windows.Forms.GroupBox();
            this.rbResult = new System.Windows.Forms.RadioButton();
            this.rbContinuous = new System.Windows.Forms.RadioButton();
            this.BoxProgress = new System.Windows.Forms.GroupBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.prbProgress = new System.Windows.Forms.ProgressBar();
            this.BoxFileCrypt = new System.Windows.Forms.GroupBox();
            this.btnFileDecrypt = new System.Windows.Forms.Button();
            this.btnFileEncrypt = new System.Windows.Forms.Button();
            this.lblDesc1 = new System.Windows.Forms.Label();
            this.txtKey_File = new System.Windows.Forms.TextBox();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.txtAlteredFile = new System.Windows.Forms.TextBox();
            this.lblAltered = new System.Windows.Forms.Label();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BoxTextCrypt = new System.Windows.Forms.GroupBox();
            this.lblDesc3 = new System.Windows.Forms.Label();
            this.btnTextDecrypt = new System.Windows.Forms.Button();
            this.btnTextEncrypt = new System.Windows.Forms.Button();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.lblEncrypted = new System.Windows.Forms.Label();
            this.lblDesc2 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.BoxAlogrithm.SuspendLayout();
            this.BoxElapsedTime.SuspendLayout();
            this.BoxProgress.SuspendLayout();
            this.BoxFileCrypt.SuspendLayout();
            this.BoxTextCrypt.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoxAlogrithm
            // 
            this.BoxAlogrithm.Controls.Add(this.rbAES);
            this.BoxAlogrithm.Controls.Add(this.rbDES);
            this.BoxAlogrithm.Location = new System.Drawing.Point(34, 33);
            this.BoxAlogrithm.Name = "BoxAlogrithm";
            this.BoxAlogrithm.Size = new System.Drawing.Size(209, 79);
            this.BoxAlogrithm.TabIndex = 0;
            this.BoxAlogrithm.TabStop = false;
            this.BoxAlogrithm.Text = "Giải thuật mã hóa";
            // 
            // rbAES
            // 
            this.rbAES.AutoSize = true;
            this.rbAES.Location = new System.Drawing.Point(83, 40);
            this.rbAES.Name = "rbAES";
            this.rbAES.Size = new System.Drawing.Size(46, 17);
            this.rbAES.TabIndex = 1;
            this.rbAES.Text = "AES";
            this.rbAES.UseVisualStyleBackColor = true;
            this.rbAES.CheckedChanged += new System.EventHandler(this.rbAES_CheckedChanged);
            // 
            // rbDES
            // 
            this.rbDES.AutoSize = true;
            this.rbDES.Checked = true;
            this.rbDES.Location = new System.Drawing.Point(15, 40);
            this.rbDES.Name = "rbDES";
            this.rbDES.Size = new System.Drawing.Size(47, 17);
            this.rbDES.TabIndex = 0;
            this.rbDES.TabStop = true;
            this.rbDES.Text = "DES";
            this.rbDES.UseVisualStyleBackColor = true;
            this.rbDES.CheckedChanged += new System.EventHandler(this.rbDES_CheckedChanged);
            // 
            // BoxElapsedTime
            // 
            this.BoxElapsedTime.Controls.Add(this.rbResult);
            this.BoxElapsedTime.Controls.Add(this.rbContinuous);
            this.BoxElapsedTime.Location = new System.Drawing.Point(249, 33);
            this.BoxElapsedTime.Name = "BoxElapsedTime";
            this.BoxElapsedTime.Size = new System.Drawing.Size(213, 79);
            this.BoxElapsedTime.TabIndex = 1;
            this.BoxElapsedTime.TabStop = false;
            this.BoxElapsedTime.Text = "Hình thức thời gian trôi qua";
            // 
            // rbResult
            // 
            this.rbResult.AutoSize = true;
            this.rbResult.Location = new System.Drawing.Point(105, 40);
            this.rbResult.Name = "rbResult";
            this.rbResult.Size = new System.Drawing.Size(79, 17);
            this.rbResult.TabIndex = 1;
            this.rbResult.Text = "Chỉ kết quả";
            this.rbResult.UseVisualStyleBackColor = true;
            // 
            // rbContinuous
            // 
            this.rbContinuous.AutoSize = true;
            this.rbContinuous.Checked = true;
            this.rbContinuous.Location = new System.Drawing.Point(7, 40);
            this.rbContinuous.Name = "rbContinuous";
            this.rbContinuous.Size = new System.Drawing.Size(91, 17);
            this.rbContinuous.TabIndex = 0;
            this.rbContinuous.TabStop = true;
            this.rbContinuous.Text = "Liên tục (giây)";
            this.rbContinuous.UseVisualStyleBackColor = true;
            // 
            // BoxProgress
            // 
            this.BoxProgress.Controls.Add(this.lblProgress);
            this.BoxProgress.Controls.Add(this.prbProgress);
            this.BoxProgress.Location = new System.Drawing.Point(34, 118);
            this.BoxProgress.Name = "BoxProgress";
            this.BoxProgress.Size = new System.Drawing.Size(428, 71);
            this.BoxProgress.TabIndex = 2;
            this.BoxProgress.TabStop = false;
            this.BoxProgress.Text = "Tiến độ";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 55);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 1;
            // 
            // prbProgress
            // 
            this.prbProgress.Location = new System.Drawing.Point(15, 20);
            this.prbProgress.Name = "prbProgress";
            this.prbProgress.Size = new System.Drawing.Size(406, 23);
            this.prbProgress.TabIndex = 0;
            // 
            // BoxFileCrypt
            // 
            this.BoxFileCrypt.Controls.Add(this.btnFileDecrypt);
            this.BoxFileCrypt.Controls.Add(this.btnFileEncrypt);
            this.BoxFileCrypt.Controls.Add(this.lblDesc1);
            this.BoxFileCrypt.Controls.Add(this.txtKey_File);
            this.BoxFileCrypt.Controls.Add(this.lblKey1);
            this.BoxFileCrypt.Controls.Add(this.txtAlteredFile);
            this.BoxFileCrypt.Controls.Add(this.lblAltered);
            this.BoxFileCrypt.Controls.Add(this.btnFileSelect);
            this.BoxFileCrypt.Controls.Add(this.txtFile);
            this.BoxFileCrypt.Controls.Add(this.lblFile);
            this.BoxFileCrypt.Location = new System.Drawing.Point(34, 195);
            this.BoxFileCrypt.Name = "BoxFileCrypt";
            this.BoxFileCrypt.Size = new System.Drawing.Size(428, 169);
            this.BoxFileCrypt.TabIndex = 3;
            this.BoxFileCrypt.TabStop = false;
            this.BoxFileCrypt.Text = "Phép mã hóa và phép giải mã";
            // 
            // btnFileDecrypt
            // 
            this.btnFileDecrypt.Location = new System.Drawing.Point(218, 123);
            this.btnFileDecrypt.Name = "btnFileDecrypt";
            this.btnFileDecrypt.Size = new System.Drawing.Size(203, 23);
            this.btnFileDecrypt.TabIndex = 9;
            this.btnFileDecrypt.Text = "Phép giải mã tập tin";
            this.btnFileDecrypt.UseVisualStyleBackColor = true;
            this.btnFileDecrypt.Click += new System.EventHandler(this.btnFileDescrypt_Click);
            // 
            // btnFileEncrypt
            // 
            this.btnFileEncrypt.Location = new System.Drawing.Point(10, 123);
            this.btnFileEncrypt.Name = "btnFileEncrypt";
            this.btnFileEncrypt.Size = new System.Drawing.Size(202, 23);
            this.btnFileEncrypt.TabIndex = 8;
            this.btnFileEncrypt.Text = "Phép mã hóa tập tin";
            this.btnFileEncrypt.UseVisualStyleBackColor = true;
            this.btnFileEncrypt.Click += new System.EventHandler(this.btnFileEncrypt_Click);
            // 
            // lblDesc1
            // 
            this.lblDesc1.AutoSize = true;
            this.lblDesc1.Location = new System.Drawing.Point(53, 107);
            this.lblDesc1.Name = "lblDesc1";
            this.lblDesc1.Size = new System.Drawing.Size(350, 13);
            this.lblDesc1.TabIndex = 7;
            this.lblDesc1.Text = "Khóa chỉ cho phép đối với hệ thập lục phân (VD: 0123456789ABCDEF )";
            // 
            // txtKey_File
            // 
            this.txtKey_File.Location = new System.Drawing.Point(53, 69);
            this.txtKey_File.Name = "txtKey_File";
            this.txtKey_File.Size = new System.Drawing.Size(368, 20);
            this.txtKey_File.TabIndex = 6;
            this.txtKey_File.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_File_KeyPress);
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.Location = new System.Drawing.Point(7, 77);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(32, 13);
            this.lblKey1.TabIndex = 5;
            this.lblKey1.Text = "Khóa";
            // 
            // txtAlteredFile
            // 
            this.txtAlteredFile.Location = new System.Drawing.Point(131, 44);
            this.txtAlteredFile.Name = "txtAlteredFile";
            this.txtAlteredFile.ReadOnly = true;
            this.txtAlteredFile.Size = new System.Drawing.Size(290, 20);
            this.txtAlteredFile.TabIndex = 4;
            // 
            // lblAltered
            // 
            this.lblAltered.AutoSize = true;
            this.lblAltered.Location = new System.Drawing.Point(7, 47);
            this.lblAltered.Name = "lblAltered";
            this.lblAltered.Size = new System.Drawing.Size(115, 13);
            this.lblAltered.TabIndex = 3;
            this.lblAltered.Text = "Tên tập tin đã thay đổi";
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(320, 14);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(101, 23);
            this.btnFileSelect.TabIndex = 2;
            this.btnFileSelect.Text = "Chọn tập tin";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(53, 16);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(260, 20);
            this.txtFile.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(7, 19);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(40, 13);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "Tập tin";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BoxTextCrypt
            // 
            this.BoxTextCrypt.Controls.Add(this.lblDesc3);
            this.BoxTextCrypt.Controls.Add(this.btnTextDecrypt);
            this.BoxTextCrypt.Controls.Add(this.btnTextEncrypt);
            this.BoxTextCrypt.Controls.Add(this.txtEncrypted);
            this.BoxTextCrypt.Controls.Add(this.lblEncrypted);
            this.BoxTextCrypt.Controls.Add(this.lblDesc2);
            this.BoxTextCrypt.Controls.Add(this.txtKey);
            this.BoxTextCrypt.Controls.Add(this.lblKey2);
            this.BoxTextCrypt.Controls.Add(this.txtPlainText);
            this.BoxTextCrypt.Controls.Add(this.lblText);
            this.BoxTextCrypt.Location = new System.Drawing.Point(34, 371);
            this.BoxTextCrypt.Name = "BoxTextCrypt";
            this.BoxTextCrypt.Size = new System.Drawing.Size(428, 296);
            this.BoxTextCrypt.TabIndex = 4;
            this.BoxTextCrypt.TabStop = false;
            this.BoxTextCrypt.Text = "Phép mã hóa và giải mã đối với các văn bản";
            // 
            // lblDesc3
            // 
            this.lblDesc3.AutoSize = true;
            this.lblDesc3.Location = new System.Drawing.Point(292, 244);
            this.lblDesc3.Name = "lblDesc3";
            this.lblDesc3.Size = new System.Drawing.Size(129, 13);
            this.lblDesc3.TabIndex = 9;
            this.lblDesc3.Text = "Chỉ có mẩu tự latinh và số";
            // 
            // btnTextDecrypt
            // 
            this.btnTextDecrypt.Location = new System.Drawing.Point(155, 239);
            this.btnTextDecrypt.Name = "btnTextDecrypt";
            this.btnTextDecrypt.Size = new System.Drawing.Size(131, 23);
            this.btnTextDecrypt.TabIndex = 8;
            this.btnTextDecrypt.Text = "Phép giải mã văn bản";
            this.btnTextDecrypt.UseVisualStyleBackColor = true;
            this.btnTextDecrypt.Click += new System.EventHandler(this.btnTextDecrypt_Click);
            // 
            // btnTextEncrypt
            // 
            this.btnTextEncrypt.Location = new System.Drawing.Point(15, 239);
            this.btnTextEncrypt.Name = "btnTextEncrypt";
            this.btnTextEncrypt.Size = new System.Drawing.Size(133, 23);
            this.btnTextEncrypt.TabIndex = 7;
            this.btnTextEncrypt.Text = "Phép mã hóa văn bản";
            this.btnTextEncrypt.UseVisualStyleBackColor = true;
            this.btnTextEncrypt.Click += new System.EventHandler(this.btnTextEncrypt_Click);
            // 
            // txtEncrypted
            // 
            this.txtEncrypted.Location = new System.Drawing.Point(60, 158);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.Name = "txtEncrypted";
            this.txtEncrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEncrypted.Size = new System.Drawing.Size(361, 75);
            this.txtEncrypted.TabIndex = 6;
            // 
            // lblEncrypted
            // 
            this.lblEncrypted.AutoSize = true;
            this.lblEncrypted.Location = new System.Drawing.Point(57, 141);
            this.lblEncrypted.Name = "lblEncrypted";
            this.lblEncrypted.Size = new System.Drawing.Size(264, 13);
            this.lblEncrypted.TabIndex = 5;
            this.lblEncrypted.Text = "Văn bản kết quả đối với phép mã hóa và phép giải mã";
            // 
            // lblDesc2
            // 
            this.lblDesc2.AutoSize = true;
            this.lblDesc2.Location = new System.Drawing.Point(57, 119);
            this.lblDesc2.Name = "lblDesc2";
            this.lblDesc2.Size = new System.Drawing.Size(350, 13);
            this.lblDesc2.TabIndex = 4;
            this.lblDesc2.Text = "Khóa chỉ cho phép đối với hệ thập lục phân (VD: 0123456789ABCDEF )";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(60, 96);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(361, 20);
            this.txtKey.TabIndex = 3;
            this.txtKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_KeyPress);
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.Location = new System.Drawing.Point(10, 99);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(32, 13);
            this.lblKey2.TabIndex = 2;
            this.lblKey2.Text = "Khóa";
            // 
            // txtPlainText
            // 
            this.txtPlainText.Location = new System.Drawing.Point(60, 17);
            this.txtPlainText.Multiline = true;
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlainText.Size = new System.Drawing.Size(361, 73);
            this.txtPlainText.TabIndex = 1;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(7, 20);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(47, 13);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Văn bản";
            // 
            // frmMaHoaGiaiMa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 684);
            this.Controls.Add(this.BoxTextCrypt);
            this.Controls.Add(this.BoxFileCrypt);
            this.Controls.Add(this.BoxProgress);
            this.Controls.Add(this.BoxElapsedTime);
            this.Controls.Add(this.BoxAlogrithm);
            this.Name = "frmMaHoaGiaiMa";
            this.Text = "Trình mã hóa rất đơn giản bởi WannBe V. 3.141592";
            this.Load += new System.EventHandler(this.frmMaHoaGiaiMa_Load);
            this.BoxAlogrithm.ResumeLayout(false);
            this.BoxAlogrithm.PerformLayout();
            this.BoxElapsedTime.ResumeLayout(false);
            this.BoxElapsedTime.PerformLayout();
            this.BoxProgress.ResumeLayout(false);
            this.BoxProgress.PerformLayout();
            this.BoxFileCrypt.ResumeLayout(false);
            this.BoxFileCrypt.PerformLayout();
            this.BoxTextCrypt.ResumeLayout(false);
            this.BoxTextCrypt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox BoxAlogrithm;
        private System.Windows.Forms.RadioButton rbAES;
        private System.Windows.Forms.RadioButton rbDES;
        private System.Windows.Forms.GroupBox BoxElapsedTime;
        private System.Windows.Forms.RadioButton rbResult;
        private System.Windows.Forms.RadioButton rbContinuous;
        private System.Windows.Forms.GroupBox BoxProgress;
        private System.Windows.Forms.ProgressBar prbProgress;
        private System.Windows.Forms.GroupBox BoxFileCrypt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnFileDecrypt;
        private System.Windows.Forms.Button btnFileEncrypt;
        private System.Windows.Forms.Label lblDesc1;
        private System.Windows.Forms.TextBox txtKey_File;
        private System.Windows.Forms.Label lblKey1;
        private System.Windows.Forms.TextBox txtAlteredFile;
        private System.Windows.Forms.Label lblAltered;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.GroupBox BoxTextCrypt;
        private System.Windows.Forms.TextBox txtPlainText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblDesc2;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblKey2;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.Label lblEncrypted;
        private System.Windows.Forms.Label lblDesc3;
        private System.Windows.Forms.Button btnTextDecrypt;
        private System.Windows.Forms.Button btnTextEncrypt;
    }
}

