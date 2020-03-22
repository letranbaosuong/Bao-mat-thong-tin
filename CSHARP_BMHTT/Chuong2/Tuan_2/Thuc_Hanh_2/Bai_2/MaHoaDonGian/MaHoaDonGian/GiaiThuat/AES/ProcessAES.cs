﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoaDonGian.GiaiThuat.AES
{
    class ProcessAES : CommonProcess
    {
        #region Cac bien co
        public event frmMaHoaGiaiMa.ProgressInitHandler InitProgress;
        public event frmMaHoaGiaiMa.ProgressEventHandler IncrementProgress;
        #endregion

        #region Cac ham tao
        public ProcessAES(frmMaHoaGiaiMa.ProgressEventHandler IncProg, frmMaHoaGiaiMa.ProgressInitHandler InitProg)
        {
            this.IncrementProgress = IncProg;
            this.InitProgress = InitProg;
        }
        #endregion
        protected virtual void OnIncrementProgress(ProgressEventArgs e)
        {
            if (IncrementProgress != null)
                IncrementProgress(this, e);
        }
        protected virtual void OnInitProgress(ProgressInitArgs e)
        {
            if (InitProgress != null)
                InitProgress(this, e);
        }
        private string[] CircularLeftShift(string[] row,int count)
        {
            for (int i = 0; i < count; i++)
            {
                string temp = row[0];
                row[0] = row[1];
                row[1] = row[2];
                row[2] = row[3];
                row[3] = temp;
            }
            return row;
        }
        private string[] CircularRightShift(string[] row,int count)
        {
            for (int i = 0; i < count; i++)
            {
                string temp = row[3];
                row[3] = row[2];
                row[2] = row[1];
                row[1] = row[0];
                row[0] = temp;
            }
            return row;
        }
        private string[] RotWord(string[] state)
        {
            return this.CircularLeftShift(state, 1);
        }
        public Keys KeyExpansion(Keys key,bool IsReverse)
        {
            for (int i = 4; i < key.RoundKeys.Count * 4; i++)
            {
                string[] Wi_1 = key.RoundKeys[(i - 1) / 4].getWord((i - 1) % 4);
                Matrix mat_Wi_1 = new Matrix(4, 1);
                mat_Wi_1.setWord(Wi_1, 0);
                if (i % 4 == 0)
                {
                    Wi_1 = this.RotWord(Wi_1);
                    mat_Wi_1.setWord(Wi_1, 0);
                    mat_Wi_1 = this.SubBytes(mat_Wi_1, false);
                    mat_Wi_1 = MatrixMultiplication.XOR(mat_Wi_1, TransformTables.Rcon[(i - 1) / 4]);
                }
                Matrix Wi_4 = new Matrix(4, 1);
                Wi_4.setWord(key.RoundKeys[(i - 4) / 4].getWord((i - 4) % 4), 0);
                Matrix temp = MatrixMultiplication.XOR(mat_Wi_1, Wi_4);
                string[] Wi = temp.getWord(0);
                key.RoundKeys[i / 4].setWord(Wi, i % 4);
            }
            return key;
        }
        public Matrix AddRoundKey(Matrix state, Keys key, int Round)
        {
            // AddRoundKey
            if (Round > key.RoundKeys.Count - 1)
            {
                throw new IndexOutOfRangeException(
                "The round key is must between 0 and 10 in 128 bit AES.");
            }
            return MatrixMultiplication.XOR(state, key.RoundKeys[Round]);
        }
        public Matrix SubBytes(Matrix state,bool IsReverse)
        {
            // SubBytes
            for (int i = 0; i < state.Rows; i++)
            {
                for (int j = 0; j < state.Columns; j++)
                {
                    int row = Convert.ToInt32(state[i, j].Substring(0, 4), 2);
                    int column = Convert.ToInt32(state[i, j].Substring(4, 4), 2);
                    if (IsReverse == false)
                    {
                        state[i, j] = TransformTables.sbox[row, column];
                    }
                    else
                    {
                        state[i, j] = TransformTables.inverse_sbox[row, column];
                    }
                }
            }
            return state;
        }
        public Matrix ShiftRows(Matrix state,bool IsReverse)
        {
            // ShiftRows
            for (int i = 1; i < state.Rows; i++)
            {
                if (IsReverse == false)
                {
                    state.setRow(this.CircularLeftShift(state.getRow(i), i), i);
                }
                else
                {
                    state.setRow(this.CircularRightShift(state.getRow(i), i), i);
                }
            }
            return state;
        }
        public Matrix MixColumns(Matrix state,bool IsReverse)
        {
            // MixColumns
            if (IsReverse == false)
            {
                state = MatrixMultiplication.Multiply(TransformTables.MixColumnFactor, state, true);
            }
            else
            {
                state = MatrixMultiplication.Multiply(TransformTables.Inverse_MixColumFactor, state, true);
            }
            return state;
        }
        public override string EncryptionStart(string PlainText, string CipherKey, bool IsTextBinary)
        {
            // Encryption Process
            StringBuilder binaryText = null;
            if (IsTextBinary == false)
            {
                PlainText = BaseTransform.FromTextToBinary(PlainText);
            }
            else
            {
                //binaryText = PlainText;
            }
            binaryText = new StringBuilder(BaseTransform.setTextMultipleOf128Bits(PlainText));
            StringBuilder EncryptedTextBuilder = new StringBuilder(binaryText.Length);
            // Make All-round keys
            Matrix Matrix_CipherKey = new Matrix(BaseTransform.FromHexToBinary(CipherKey));
            Keys key = new Keys();
            key.setCipherKey(Matrix_CipherKey);
            key = this.KeyExpansion(key, false);
            // Initialize Progress Bar
            OnInitProgress(new ProgressInitArgs(binaryText.Length));
            //Matrix state = new Matrix(4, 4);
            for (int j = 0; j < (binaryText.Length / 128); j++)
            {
                //state.setState(binaryText.ToString().Substring(j * 128, 128));
            Matrix state = new Matrix(binaryText.ToString().Substring(j * 128, 128));
                state = this.AddRoundKey(state, key, 0);
                for (int i = 1; i < 11; i++)
                {
                    if (i == 10)
                    {
                        state = this.SubBytes(state, false);
                        state = this.ShiftRows(state, false);
                        state = this.AddRoundKey(state, key, i);
                    }
                    else
                    {
                        state = this.SubBytes(state, false);
                        state = this.ShiftRows(state, false);
                        state = this.MixColumns(state, false);
                        state = this.AddRoundKey(state, key, i);
                    }
                }
                EncryptedTextBuilder.Append(state.ToString());
                // Increase Progress Bar
                OnIncrementProgress(new ProgressEventArgs(state.ToString().Length));
            }
            return EncryptedTextBuilder.ToString();
        }
        public override string DecryptionStart(string PlainText, string CipherKey, bool IsTextBinary)
        {
            // Decryption Process
            string binaryText = "";
            if (IsTextBinary == false)
            {
                binaryText = BaseTransform.FromTextToBinary(PlainText);
            }
            else
            {
                binaryText = PlainText;
            }
            StringBuilder DecryptedTextBuilder = new StringBuilder(binaryText.Length);

            // Make All-round keys
            Matrix Matrix_CipherKey = new Matrix(BaseTransform.FromHexToBinary(CipherKey));
            Keys key = new Keys();
            key.setCipherKey(Matrix_CipherKey);
            key = this.KeyExpansion(key, false);
            // Initialize Progress Bar
            OnInitProgress(new ProgressInitArgs(binaryText.Length));
            //Matrix state = new Matrix(4, 4);
            for (int j = 0; j < (binaryText.Length / 128); j++)
 {
                //state.setState(binaryText.Substring(j * 128, 128));
                Matrix state = new Matrix(binaryText.Substring(j * 128, 128));
                state = this.AddRoundKey(state, key, 10);
                for (int i = 9; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        state = this.ShiftRows(state, true);
                        state = this.SubBytes(state, true);
                        state = this.AddRoundKey(state, key, i);
                    }
                    else
                    {
                        state = this.ShiftRows(state, true);
                        state = this.SubBytes(state, true);
                        state = this.AddRoundKey(state, key, i);
                        state = this.MixColumns(state, true);
                        //DecryptedTextBuilder.Append(state.ToString());
                    }
                }
                // It's for correct subtracted '0' that have added for set text multiple of 128bit
                if ((j * 128 + 128) == binaryText.Length)
                {
                    StringBuilder last_text = new StringBuilder(state.ToString().TrimEnd('0'));
                    int count = state.ToString().Length - last_text.Length;
                    if ((count % 8) != 0)
                    {
                        count = 8 - (count % 8);
                    }
                    string append_text = "";
                    for (int k = 0; k < count; k++)
                    {
                        append_text += "0";
                    }
                    DecryptedTextBuilder.Append(last_text.ToString() + append_text);
                }
                else
                {
                    DecryptedTextBuilder.Append(state.ToString());
                }
                // Increase Progress Bar
                OnIncrementProgress(new ProgressEventArgs(state.ToString().Length));
            }
            //return DecryptedTextBuilder.ToString().TrimEnd('0');
            return DecryptedTextBuilder.ToString();
        }
    }
}
