using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES_DES3_impl_cs
{
    public partial class Main : Form
    {
        private DES myDes = new DES();

        int outputLength; //not used here, DES class returns as number of bytes processed

        DESCryptoServiceProvider desProv = new DESCryptoServiceProvider();
        TripleDESCryptoServiceProvider des3Prov = new TripleDESCryptoServiceProvider();
        byte[] iv = new byte[8]; //blank, not supported by DES class

        byte[] key8; //DES key
        byte[] key16; //Triple DES key
        byte[] input;
        byte[] output;
        public Main()
        {
            InitializeComponent();
        }

        public bool isHexadecimal(string text)
        {
            if (text.Length < 1)
                throw new Exception("Text cannot be empty.");

            char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F' };

            foreach(char symbol in text)
            {
                bool found = false;
                foreach (char hexDigit in hexDigits)
                {
                    if (symbol == hexDigit)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    return false;
            }
            return true;
        }

        private void HopLe()
        {
            if(DESKeyTextBox.Text!=""&& DESKeyTextBox.Text.Length== 16&&isHexadecimal(DESKeyTextBox.Text)
                && DES3KeyTextBox.Text != "" && DES3KeyTextBox.Text.Length == 32 && isHexadecimal(DES3KeyTextBox.Text)
                && InputTextBox.Text != "" && InputTextBox.Text.Length == 64 && isHexadecimal(InputTextBox.Text))
            {
                BenchmarkInstButton.Enabled = true;
                BenchmarkDataButton.Enabled = true;
            }
            else
            {
                BenchmarkInstButton.Enabled = false;
                BenchmarkDataButton.Enabled = false;
            }
        }

        private string GetHexString(byte[] bytes, int len = -1, bool spaces = false)
        {
            if (len == -1)
            {
                len = bytes.Length;
            }

            int i;
            string s = "";
            for (i = 0;i< (len); i++)
            {
                s += bytes[i].ToString("x2");
                if (spaces)
                {
                    s += " ";
                }
            }
            if (spaces)
            {
                s = s.TrimEnd();
            }
            return s;
        }

        private byte[] HexStringToBytes(string hexstring)
        {
            byte[] out_ = new byte[(hexstring.Length / 2)];
            for (int i = 0;i< ((hexstring.Length / 2)); i++)
            {
                out_[i] = Convert.ToByte(hexstring.Substring(i * 2, 2), 16);
            }
            return out_;
        }
        private void SetupBytes()
        {
            /*if((InputTextBox.Text.Length / 2) % 8 != 0)
            {
                throw new Exception("Input length not multiple of 8");
            }
            if (DESKeyTextBox.Text.Length!=8 * 2)
            {
                throw new Exception("DES key length not 8");
            }
                
            if (DES3KeyTextBox.Text.Length!=16 * 2)
            {
                throw new Exception("DES3 key length not 16");
            }*/


            key8 = HexStringToBytes(DESKeyTextBox.Text);
            key16 = HexStringToBytes(DES3KeyTextBox.Text);
            input = HexStringToBytes(InputTextBox.Text);
            output = new byte[input.Length];
        }

        private void EncryptDESButton_Click(object sender, EventArgs e)
        {
            SetupBytes();

            myDes.encrypt_des(key8, input, input.Length, ref output, ref outputLength);
            DESOutputTextbox.Text = GetHexString(output);

            ICryptoTransform netDes = desProv.CreateEncryptor(key8, iv);
            netDes.TransformBlock(input, 0, input.Length, output, 0);
            NETDESOutputTextBox.Text = GetHexString(output);
        }

        private void DecryptDESButton_Click(object sender, EventArgs e)
        {
            SetupBytes();

            myDes.decrypt_des(key8, input, input.Length, ref output, ref outputLength);
            DESOutputTextbox.Text = GetHexString(output);

            ICryptoTransform netDes = desProv.CreateDecryptor(key8, iv);
            netDes.TransformBlock(input, 0, input.Length, output, 0);
            NETDESOutputTextBox.Text = GetHexString(output);
        }

        private void EncryptDES3Button_Click(object sender, EventArgs e)
        {
            SetupBytes();

            myDes.encrypt_3des(key16, input, input.Length, ref output, ref outputLength);
            DESOutputTextbox.Text = GetHexString(output);

            ICryptoTransform netDes = des3Prov.CreateEncryptor(key16, iv);
            netDes.TransformBlock(input, 0, input.Length, output, 0);
            NETDESOutputTextBox.Text = GetHexString(output);
        }

        private void DecryptDES3Button_Click(object sender, EventArgs e)
        {
            SetupBytes();

            myDes.decrypt_3des(key16, input, input.Length, ref output, ref outputLength);
            DESOutputTextbox.Text = GetHexString(output);

            ICryptoTransform netDes = des3Prov.CreateDecryptor(key16, iv);
            netDes.TransformBlock(input, 0, input.Length, output, 0);
            NETDESOutputTextBox.Text = GetHexString(output);
        }

        private void BenchmarkInstButton_Click(object sender, EventArgs e)
        {
            SetupBytes();

            Cursor.Current = Cursors.WaitCursor;

            long desTicks = DateTime.Now.Ticks;
            for (int i = 1; i <= 20000; i++)
            {
                myDes.encrypt_des(key8, input, input.Length, ref output, ref outputLength);
            }

            desTicks = DateTime.Now.Ticks - desTicks;

            long netTicks = DateTime.Now.Ticks;
            ICryptoTransform netDes;
            for (int i = 1;i<= 20000; i++)
            {
                netDes = desProv.CreateEncryptor(key8, iv);
                netDes.TransformBlock(input, 0, input.Length, output, 0);
            }
            netTicks = DateTime.Now.Ticks - netTicks;

            Cursor.Current = Cursors.Default;

            string s = "Instantiation:" + Constants.vbCr;
            s += desTicks + " DES Ticks" + Constants.vbCr + netTicks + " .NET Ticks" + Constants.vbCr + "DES: " + Math.Round((double)(desTicks / netTicks), 2) + "x";
            MessageBox.Show(s);
        }

        private void BenchmarkDataButton_Click(object sender, EventArgs e)
        {
            SetupBytes();
            input = new byte[0x1000000]; //16 megs
            output = new byte[0x1000000];

            Cursor.Current = Cursors.WaitCursor;

            long desTicks = DateTime.Now.Ticks;
            myDes.encrypt_des(key8, input, input.Length, ref output, ref outputLength);
            desTicks = DateTime.Now.Ticks - desTicks;

            long netTicks = DateTime.Now.Ticks;
            ICryptoTransform netDes;
            netDes = desProv.CreateEncryptor(key8, iv);
            netDes.TransformBlock(input, 0, input.Length, output, 0);
            netTicks = DateTime.Now.Ticks - netTicks;

            Cursor.Current = Cursors.Default;

            string s = "Data:" + Constants.vbCr;
            s += desTicks + " DES Ticks" + Constants.vbCr + netTicks + " .NET Ticks" + Constants.vbCr + "DES: " + Math.Round((double)(desTicks / netTicks), 2) + "x";
            MessageBox.Show(s);
        }

        private void DESKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (DESKeyTextBox.Text.Length == 16 && DESKeyTextBox.Text != "" && isHexadecimal(DESKeyTextBox.Text)
                && InputTextBox.Text!="" && InputTextBox.Text.Length == 64 && isHexadecimal(InputTextBox.Text))
            {
                EncryptDESButton.Enabled = true;
                DecryptDESButton.Enabled = true;
            }
            else
            {
                EncryptDESButton.Enabled = false;
                DecryptDESButton.Enabled = false;
            }

            HopLe();
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (DESKeyTextBox.Text.Length == 16 && DESKeyTextBox.Text != "" && isHexadecimal(DESKeyTextBox.Text)
                && InputTextBox.Text != "" && InputTextBox.Text.Length == 64 && isHexadecimal(InputTextBox.Text))
            {
                EncryptDESButton.Enabled = true;
                DecryptDESButton.Enabled = true;
            }
            else
            {
                EncryptDESButton.Enabled = false;
                DecryptDESButton.Enabled = false;
            }

            if (DES3KeyTextBox.Text.Length == 32 && DES3KeyTextBox.Text != "" && isHexadecimal(DES3KeyTextBox.Text)
                && InputTextBox.Text != "" && InputTextBox.Text.Length == 64 && isHexadecimal(InputTextBox.Text))
            {
                EncryptDES3Button.Enabled = true;
                DecryptDES3Button.Enabled = true;
            }
            else
            {
                EncryptDES3Button.Enabled = false;
                DecryptDES3Button.Enabled = false;
            }

            HopLe();
        }

        private void DES3KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (DES3KeyTextBox.Text.Length == 32 && DES3KeyTextBox.Text != "" && isHexadecimal(DES3KeyTextBox.Text)
                && InputTextBox.Text != "" && InputTextBox.Text.Length == 64 && isHexadecimal(InputTextBox.Text))
            {
                EncryptDES3Button.Enabled = true;
                DecryptDES3Button.Enabled = true;
            }
            else
            {
                EncryptDES3Button.Enabled = false;
                DecryptDES3Button.Enabled = false;
            }
            HopLe();
        }
    }
}
