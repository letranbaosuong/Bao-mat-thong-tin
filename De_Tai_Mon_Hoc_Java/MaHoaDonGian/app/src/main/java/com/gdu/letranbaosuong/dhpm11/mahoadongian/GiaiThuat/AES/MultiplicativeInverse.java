package com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat.AES;

public class MultiplicativeInverse {
    public static String LeftShift2(String text, int level) {
        // Non-circular left shift
        //string temp = text.Substring(0, count);
        StringBuilder shifted = new StringBuilder(text.length());
        shifted.append(text.substring(1) + "0");
        if (level != 8) {
            for (int i = 0; i <= text.length() - (1 + level); i++) {
                shifted.setCharAt(i, '0');
            }
        }
        return shifted.toString();
    }

    public static String GetInverse(String text1, String text2, String mx, int n) {
        String[] multiplyTable = new String[n];
        if (text1.indexOf('1') > text2.indexOf('1')) {
            String temp = text2;
            text2 = text1;
            text1 = temp;
        }
        multiplyTable[0] = text1;
        for (int i = 1; i < n; i++) {
            multiplyTable[i] = MultiplicativeInverse.LeftShift2(multiplyTable[i - 1], n);
            if (multiplyTable[i - 1].equals('1')) {
                multiplyTable[i] = MultiplicativeInverse.XOR(multiplyTable[i], mx);
            }
        }
        String Mul_Inverse = "";
        for (int i = 0; i < text2.length(); i++) {
            if (text2.charAt(i) == '1') {
                if (Mul_Inverse == "") {
                    Mul_Inverse = multiplyTable[(text2.length() - 1) - i];
                } else {
                    Mul_Inverse = MultiplicativeInverse.XOR(Mul_Inverse, multiplyTable[(text2.length() - 1) - i]);
                }
            }
        }
        if (Mul_Inverse == "") {
            Mul_Inverse = "00000000";
        }
        return Mul_Inverse;
    }

    public static String XOR(String text1, String text2) {
        // XOR Operation
        if (text1.length() != text2.length()) {
            int count = Math.abs(text1.length() - text2.length());
            String temp = "";
            for (int i = 0; i < count; i++) {
                temp += "0";
            }
            if (text1.length() > text2.length()) {
                text2 = temp + text2;
            } else {
                text1 = temp + text1;
            }
        }
        StringBuilder XORed_Text = new StringBuilder(text1.length());
        //string XORed_Text = "";
        for (int i = 0; i < text1.length(); i++) {
            if (text1.charAt(i) != text2.charAt(i)) {
                XORed_Text.append("1");
            } else {
                XORed_Text.append("0");
                //XORed_Text += "0";
            }
        }
        return XORed_Text.toString();
    }
}
