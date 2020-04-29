namespace DES_DES3_impl_cs
{
    partial class Main
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
            this.Label6 = new System.Windows.Forms.Label();
            this.BenchmarkDataButton = new System.Windows.Forms.Button();
            this.BenchmarkInstButton = new System.Windows.Forms.Button();
            this.DecryptDES3Button = new System.Windows.Forms.Button();
            this.EncryptDES3Button = new System.Windows.Forms.Button();
            this.DecryptDESButton = new System.Windows.Forms.Button();
            this.EncryptDESButton = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.NETDESOutputTextBox = new System.Windows.Forms.TextBox();
            this.DESOutputTextbox = new System.Windows.Forms.TextBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.DES3KeyTextBox = new System.Windows.Forms.TextBox();
            this.DESKeyTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(420, 209);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(90, 13);
            this.Label6.TabIndex = 28;
            this.Label6.Text = "(Everything\'s hex)";
            // 
            // BenchmarkDataButton
            // 
            this.BenchmarkDataButton.Location = new System.Drawing.Point(156, 201);
            this.BenchmarkDataButton.Name = "BenchmarkDataButton";
            this.BenchmarkDataButton.Size = new System.Drawing.Size(96, 23);
            this.BenchmarkDataButton.TabIndex = 27;
            this.BenchmarkDataButton.Text = "Benchmark Data";
            this.BenchmarkDataButton.UseVisualStyleBackColor = true;
            this.BenchmarkDataButton.Click += new System.EventHandler(this.BenchmarkDataButton_Click);
            // 
            // BenchmarkInstButton
            // 
            this.BenchmarkInstButton.Location = new System.Drawing.Point(12, 201);
            this.BenchmarkInstButton.Name = "BenchmarkInstButton";
            this.BenchmarkInstButton.Size = new System.Drawing.Size(136, 23);
            this.BenchmarkInstButton.TabIndex = 26;
            this.BenchmarkInstButton.Text = "Benchmark Instantiation";
            this.BenchmarkInstButton.UseVisualStyleBackColor = true;
            this.BenchmarkInstButton.Click += new System.EventHandler(this.BenchmarkInstButton_Click);
            // 
            // DecryptDES3Button
            // 
            this.DecryptDES3Button.Location = new System.Drawing.Point(404, 89);
            this.DecryptDES3Button.Name = "DecryptDES3Button";
            this.DecryptDES3Button.Size = new System.Drawing.Size(88, 23);
            this.DecryptDES3Button.TabIndex = 23;
            this.DecryptDES3Button.Text = "Decrypt DES3";
            this.DecryptDES3Button.UseVisualStyleBackColor = true;
            this.DecryptDES3Button.Click += new System.EventHandler(this.DecryptDES3Button_Click);
            // 
            // EncryptDES3Button
            // 
            this.EncryptDES3Button.Location = new System.Drawing.Point(316, 89);
            this.EncryptDES3Button.Name = "EncryptDES3Button";
            this.EncryptDES3Button.Size = new System.Drawing.Size(88, 23);
            this.EncryptDES3Button.TabIndex = 22;
            this.EncryptDES3Button.Text = "Encrypt DES3";
            this.EncryptDES3Button.UseVisualStyleBackColor = true;
            this.EncryptDES3Button.Click += new System.EventHandler(this.EncryptDES3Button_Click);
            // 
            // DecryptDESButton
            // 
            this.DecryptDESButton.Location = new System.Drawing.Point(196, 89);
            this.DecryptDESButton.Name = "DecryptDESButton";
            this.DecryptDESButton.Size = new System.Drawing.Size(88, 23);
            this.DecryptDESButton.TabIndex = 21;
            this.DecryptDESButton.Text = "Decrypt DES";
            this.DecryptDESButton.UseVisualStyleBackColor = true;
            this.DecryptDESButton.Click += new System.EventHandler(this.DecryptDESButton_Click);
            // 
            // EncryptDESButton
            // 
            this.EncryptDESButton.Location = new System.Drawing.Point(108, 89);
            this.EncryptDESButton.Name = "EncryptDESButton";
            this.EncryptDESButton.Size = new System.Drawing.Size(88, 23);
            this.EncryptDESButton.TabIndex = 20;
            this.EncryptDESButton.Text = "Encrypt DES";
            this.EncryptDESButton.UseVisualStyleBackColor = true;
            this.EncryptDESButton.Click += new System.EventHandler(this.EncryptDESButton_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(12, 161);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(95, 13);
            this.Label5.TabIndex = 17;
            this.Label5.Text = ".NET DES Output:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(12, 137);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(67, 13);
            this.Label4.TabIndex = 18;
            this.Label4.Text = "DES Output:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 65);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(34, 13);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Input:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 33);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "DES3 Key:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 13);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "DES Key:";
            // 
            // NETDESOutputTextBox
            // 
            this.NETDESOutputTextBox.Location = new System.Drawing.Point(108, 161);
            this.NETDESOutputTextBox.Name = "NETDESOutputTextBox";
            this.NETDESOutputTextBox.ReadOnly = true;
            this.NETDESOutputTextBox.Size = new System.Drawing.Size(400, 20);
            this.NETDESOutputTextBox.TabIndex = 25;
            // 
            // DESOutputTextbox
            // 
            this.DESOutputTextbox.Location = new System.Drawing.Point(108, 137);
            this.DESOutputTextbox.Name = "DESOutputTextbox";
            this.DESOutputTextbox.ReadOnly = true;
            this.DESOutputTextbox.Size = new System.Drawing.Size(400, 20);
            this.DESOutputTextbox.TabIndex = 24;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(108, 65);
            this.InputTextBox.MaxLength = 64;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(400, 20);
            this.InputTextBox.TabIndex = 19;
            this.InputTextBox.Text = "11223344cafebabecafebabecafebabecafebabecafebabecafebabe44332211";
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // DES3KeyTextBox
            // 
            this.DES3KeyTextBox.Location = new System.Drawing.Point(108, 33);
            this.DES3KeyTextBox.MaxLength = 32;
            this.DES3KeyTextBox.Name = "DES3KeyTextBox";
            this.DES3KeyTextBox.Size = new System.Drawing.Size(400, 20);
            this.DES3KeyTextBox.TabIndex = 16;
            this.DES3KeyTextBox.Text = "AA112233445566778899AABBCCDDEEFF";
            this.DES3KeyTextBox.TextChanged += new System.EventHandler(this.DES3KeyTextBox_TextChanged);
            // 
            // DESKeyTextBox
            // 
            this.DESKeyTextBox.Location = new System.Drawing.Point(108, 9);
            this.DESKeyTextBox.MaxLength = 16;
            this.DESKeyTextBox.Name = "DESKeyTextBox";
            this.DESKeyTextBox.Size = new System.Drawing.Size(400, 20);
            this.DESKeyTextBox.TabIndex = 12;
            this.DESKeyTextBox.Text = "AA11223344556677";
            this.DESKeyTextBox.TextChanged += new System.EventHandler(this.DESKeyTextBox_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 232);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.BenchmarkDataButton);
            this.Controls.Add(this.BenchmarkInstButton);
            this.Controls.Add(this.DecryptDES3Button);
            this.Controls.Add(this.EncryptDES3Button);
            this.Controls.Add(this.DecryptDESButton);
            this.Controls.Add(this.EncryptDESButton);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.NETDESOutputTextBox);
            this.Controls.Add(this.DESOutputTextbox);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.DES3KeyTextBox);
            this.Controls.Add(this.DESKeyTextBox);
            this.Name = "Main";
            this.Text = "DES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button BenchmarkDataButton;
        internal System.Windows.Forms.Button BenchmarkInstButton;
        internal System.Windows.Forms.Button DecryptDES3Button;
        internal System.Windows.Forms.Button EncryptDES3Button;
        internal System.Windows.Forms.Button DecryptDESButton;
        internal System.Windows.Forms.Button EncryptDESButton;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox NETDESOutputTextBox;
        internal System.Windows.Forms.TextBox DESOutputTextbox;
        internal System.Windows.Forms.TextBox InputTextBox;
        internal System.Windows.Forms.TextBox DES3KeyTextBox;
        internal System.Windows.Forms.TextBox DESKeyTextBox;
    }
}

