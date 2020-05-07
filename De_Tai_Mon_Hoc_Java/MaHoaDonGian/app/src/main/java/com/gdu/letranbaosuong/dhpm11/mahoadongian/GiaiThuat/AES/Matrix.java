package com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat.AES;

import com.gdu.letranbaosuong.dhpm11.mahoadongian.Services.Services;

public class Matrix {
    private String[][] matrix;
    private int rows = 0;
    private int columns = 0;

    public Matrix(String text, int r, int c) {
        if (text.length() != c * r * 8) {
//            text = text.PadRight(c * r * 8 - text.length(), '0');
            text = Services.padRight(text, c * r * 8 - text.length());
        }
        matrix = new String[r][c];
        int count = 0;
        this.rows = r;
        this.columns = c;
        for (int i = 0; i < c; i++) {
            for (int j = 0; j < r; j++) {
                matrix[j][i] = text.substring(count * 8, 8);
                count++;
            }
        }
    }

    public Matrix(int r, int c) {
        String text = "";
        if (text.length() != c * r * 8) {
//            text = text.PadRight(c * r * 8 - text.length(), '0');
            text = Services.padRight(text, c * r * 8 - text.length());
        }
        matrix = new String[r][c];
        int count = 0;
        this.rows = r;
        this.columns = c;
        for (int i = 0; i < c; i++) {
            for (int j = 0; j < r; j++) {
                matrix[j][i] = text.substring(count * 8, 8);
                count++;
            }
        }
    }

    public Matrix(String text) {
        int c = 4, r = 4;
        if (text.length() != c * r * 8) {
//            text = text.PadRight(c * r * 8 - text.length(), '0');
            text = Services.padRight(text, c * r * 8 - text.length());
        }
        matrix = new String[r][c];
        int count = 0;
        this.rows = r;
        this.columns = c;
        for (int i = 0; i < c; i++) {
            for (int j = 0; j < r; j++) {
                matrix[j][i] = text.substring(count * 8, 8);
                count++;
            }
        }
    }

    public int Rows() {
        return rows;
    }

    public int Columns() {
        return columns;
    }

    public String getMatrix(int i, int j) {
        return matrix[i][j];
    }

    public void setMatrix(int i, int j, int[][] value) {
        //If it gets hexa decimal transform to binary
        if (value.toString().length() == 2) {
            matrix[i][j] = BaseTransform.FromHexToBinary(value.toString());
        } else if (value.toString().length() == 8) {
            matrix[i][j] = value.toString();
        }
    }

    public String ToString() {
        StringBuilder text = new StringBuilder(128);
        if (matrix != null) {
            for (int j = 0; j < columns; j++) {
                for (int i = 0; i < rows; i++) {
                    text.append(matrix[i][j]);
                }
            }
        }
        return text.toString();
    }

    public void SetState(String text) {
        if (text.length() != columns * rows * 8) {
//            throw new Exception("It's not equal size to state");
        }
        int count = 0;
        for (int i = 0; i < columns; i++) {
            for (int j = 0; j < rows; j++) {
                matrix[j][i] = text.substring(count * 8, 8);
                count++;
            }
        }
    }

    public String[] getRow(int rowindex) {
        String[] row = new String[this.columns];
        if (rowindex > this.rows) {
//            throw new IndexOutOfRangeException("out of row index error.");
        }
        for (int i = 0; i < this.columns; i++) {
            row[i] = matrix[rowindex][i];
        }
        return row;
    }

    public void setRow(String[] row, int rowindex) {
        if (rowindex > this.rows) {
//            throw new IndexOutOfRangeException("out of row index error.");
        }
        for (int i = 0; i < this.columns; i++) {
            matrix[rowindex][i] = row[i];
        }
    }

    public String[] getWord(int wordindex) {
        String[] word = new String[this.rows];
        if (wordindex > this.rows) {
//            throw new IndexOutOfRangeException("out of column index error.");
        }
        for (int i = 0; i < this.rows; i++) {
            word[i] = matrix[i][wordindex];
        }
        return word;
    }

    public void setWord(String[] word, int wordindex) {
        if (wordindex > this.rows) {
//            throw new IndexOutOfRangeException("out of column index error.");
        }
        for (int i = 0; i < this.rows; i++) {
            matrix[i][wordindex] = word[i];
        }
    }
}
