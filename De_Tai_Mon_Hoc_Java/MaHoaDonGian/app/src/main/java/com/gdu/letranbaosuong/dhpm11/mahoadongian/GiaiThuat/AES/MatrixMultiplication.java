package com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat.AES;

public class MatrixMultiplication
{
    public static Matrix MixColumnsMultiply(Matrix a,Matrix b)
    {
            /* If A is an m-by-n matrix and B is an n-by-p matrix, then their matrix product AB is the m-by-p
            matrix (m rows, p columns) */
        //A - m rows, n columns
        //B - n rows, p columns
        //AB - m rows, p columns
        Matrix c = new Matrix(a.Rows(), b.Columns());
        //string temp2 = "";
        for (int j = 0; j < c.Columns(); j++)
        {
            //temp.Remove(0, temp.Length);
            for (int i = 0; i < c.Rows(); i++)
            {
                StringBuilder temp = new StringBuilder(32);
                temp.append(MultiplicativeInverse.GetInverse(a[i, 0], b[0, j], "00011011", 8));
                temp.append(MultiplicativeInverse.GetInverse(a[i, 1], b[1, j], "00011011", 8));
                temp.append(MultiplicativeInverse.GetInverse(a[i, 2], b[2, j], "00011011", 8));
                temp.append(MultiplicativeInverse.GetInverse(a[i, 3], b[3, j], "00011011", 8));
                String temp2 = "";
                temp2 = MultiplicativeInverse.XOR(temp.toString().substring(0, 8), temp.toString().substring(8, 8));
                temp2 = MultiplicativeInverse.XOR(temp2, temp.toString().substring(16, 8));
                temp2 = MultiplicativeInverse.XOR(temp2, temp.toString().substring(24, 8));
                c[i][ j] = temp2;
            }
        }
        //Console.WriteLine(c.ToString());
        return c;
    }
    public static Matrix Multiply(Matrix a,Matrix b,boolean IsMixColumns)
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
        Matrix c = new Matrix();
        for (int i = 0; i < a.Rows(); i++)
        {
            for (int j = 0; j < a.Columns(); j++)
            {
                c[i][ j] = MultiplicativeInverse.XOR(a.toString(), b.toString());
            }
        }
        return c;
    }
}
