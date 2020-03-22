using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoaDonGian.GiaiThuat.AES
{
    class Matrix
    {
        private string[,] matrix;
        private int rows = 0;
        private int columns = 0;
        public Matrix(string text,int r,int c)
        {
            if(text.Length != c * r * 8)
            {
                text = text.PadRight(c * r * 8 - text.Length, '0');
            }
            matrix = new string[r, c];
            int count = 0;
            this.rows = r;
            this.columns = c;
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    matrix[j, i] = text.Substring(count * 8, 8);
                    count++;
                }
            }
        }
        public Matrix(int r,int c) : this("", r, c)
        {

        }
        public Matrix(string text) : this(text, 4, 4)
        {

        }
        public int Rows
        {
            get
            {
                return rows;
            }
        }
        public int Columns
        {
            get
            {
                return columns;
            }
        }
        public string this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                //If it gets hexa decimal transform to binary
                if (value.Length == 2)
                {
                    matrix[i, j] = BaseTransform.FromHexToBinary(value);
                }
                else if (value.Length == 8)
                {
                    matrix[i, j] = value;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder text = new StringBuilder(128);
            if (matrix != null)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        text.Append(matrix[i, j]);
                    }
                }
            }
            return text.ToString();
        }
        public void SetState(string text)
        {
            if (text.Length != columns * rows * 8)
            {
                throw new Exception("It's not equal size to state");
            }
            int count = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[j, i] = text.Substring(count * 8, 8);
                    count++;
                }
            }
        }
        public string[] getRow(int rowindex)
        {
            string[] row = new string[this.columns];
            if (rowindex > this.rows)
            {
                throw new IndexOutOfRangeException("out of row index error.");
            }
            for (int i = 0; i < this.columns; i++)
            {
                row[i] = matrix[rowindex, i];
            }
            return row;
        }
        public void setRow(string[] row,int rowindex)
        {
            if (rowindex > this.rows)
            {
                throw new IndexOutOfRangeException("out of row index error.");
            }
            for (int i = 0; i < this.columns; i++)
            {
                matrix[rowindex, i] = row[i];
            }
        }
        public string[] getWord(int wordindex)
        {
            string[] word = new string[this.rows];
            if (wordindex > this.rows)
            {
                throw new IndexOutOfRangeException("out of column index error.");
            }
            for (int i = 0; i < this.rows; i++)
            {
                word[i] = matrix[i, wordindex];
            }
            return word;
        }
        public void setWord(string[] word,int wordindex)
        {
            if (wordindex > this.rows)
            {
                throw new IndexOutOfRangeException("out of column index error.");
            }
            for (int i = 0; i < this.rows; i++)
            {
                matrix[i, wordindex] = word[i];
            }
        }
    }
    class MatrixMultiplication
    {
        public static Matrix MixColumnsMultiply(Matrix a,Matrix b)
        {
            /* If A is an m-by-n matrix and B is an n-by-p matrix, then their matrix product AB is the m-by-p
            matrix (m rows, p columns) */
            //A - m rows, n columns
            //B - n rows, p columns
            //AB - m rows, p columns
            Matrix c = new Matrix(a.Rows, b.Columns);
            //string temp2 = "";
            for (int j = 0; j < c.Columns; j++)
            {
                //temp.Remove(0, temp.Length);
                for (int i = 0; i < c.Rows; i++)
                {
                    StringBuilder temp = new StringBuilder(32);
                    temp.Append(AES.MultiplicativeInverse.GetInverse(a[i, 0], b[0, j], "00011011", 8));
                    temp.Append(AES.MultiplicativeInverse.GetInverse(a[i, 1], b[1, j], "00011011", 8));
                    temp.Append(AES.MultiplicativeInverse.GetInverse(a[i, 2], b[2, j], "00011011", 8));
                    temp.Append(AES.MultiplicativeInverse.GetInverse(a[i, 3], b[3, j], "00011011", 8));
                    string temp2 = "";
                temp2 = AES.MultiplicativeInverse.XOR(temp.ToString().Substring(0, 8), temp.ToString().Substring(8, 8));
                    temp2 = AES.MultiplicativeInverse.XOR(temp2, temp.ToString().Substring(16, 8));
                    temp2 = AES.MultiplicativeInverse.XOR(temp2, temp.ToString().Substring(24, 8));
                    c[i, j] = temp2;
                }
            }
            //Console.WriteLine(c.ToString());
            return c;
        }
        public static Matrix Multiply(Matrix a,Matrix b,bool IsMixColumns)
        {
            if (IsMixColumns)
            {
                return MatrixMultiplication.MixColumnsMultiply(a, b);
            }
            else
            {
                return null;
            }
        }
        public static Matrix XOR(Matrix a,Matrix b)
        {
            Matrix c = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = MultiplicativeInverse.XOR(a[i, j], b[i, j]);
                }
            }
            return c;
        }
    }
}
