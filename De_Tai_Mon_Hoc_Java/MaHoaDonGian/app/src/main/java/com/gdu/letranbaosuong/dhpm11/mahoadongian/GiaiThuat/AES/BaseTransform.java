package com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat.AES;

import com.gdu.letranbaosuong.dhpm11.mahoadongian.Services.Services;

public class BaseTransform {
    public static String FromTextToHex(String text) {
        StringBuilder hexstring = new StringBuilder(text.length() * 2);
        for (char word : text.toCharArray()) {
            hexstring.append(String.format("{0:X}", Character.getNumericValue(word)));
        }
        return hexstring.toString();
    }

    public static String FromHexToText(String hexstring) {
        StringBuilder text = new StringBuilder(hexstring.length() / 2);
        for (int i = 0; i < (hexstring.length() / 2); i++) {
            String word = hexstring.substring(i * 2, 2);
//            text.append((char)Convert.ToInt32(word, 16));
            text.append((char) Integer.parseInt(word, 16));
        }
        return text.toString();
    }

    public static String FromBinaryToText(String binarystring) {
        StringBuilder text;
        text = new StringBuilder(binarystring.length() / 8);
        for (int i = 0; i < (binarystring.length() / 8); i++) {
            String word = binarystring.substring(i * 8, 8);
            text.append((char) Integer.parseInt(word, 2));
            //text += (char)Convert.ToInt32(word, 16);
        }
        return text.toString();
    }

    public static String setTextMultipleOf64Bits(String text) {
        int maxLength = 0;
        if ((text.length() % 64) != 0) {
            maxLength = ((text.length() / 64) + 1) * 64;
        }
//        text = text.padRight(maxLength, '0');
        text = Services.padRight(text, maxLength);
        return text;
    }

    public static String FromDecimalToBinary(int binary) {
        if (binary < 0) {
            System.out.println("It requires a integer greater than 0.");
            return null;
        }
        String binarystring = "";
        int factor = 128;
        for (int i = 0; i < 8; i++) {
            if (binary >= factor) {
                binary -= factor;
                binarystring += "1";
            } else {
                binarystring += "0";
            }
            factor /= 2;
        }
        return binarystring;
    }

    public static byte FromBinaryToByte(String binary) {
        byte value = 0;
        int factor = 128;
        for (int i = 0; i < 8; i++) {
            if (binary.charAt(i) == '1') {
                value += (byte) factor;
            }
            factor /= 2;
        }
        return value;
    }

    public static String FromHexToBinary(String hexstring) {
        StringBuilder binarystring = new StringBuilder(hexstring.length() * 4);
        try {
            for (int i = 0; i < hexstring.length(); i++) {
                int hex = Integer.parseInt(Character.toString(hexstring.charAt(i)), 16);
                int factor = 8;
                for (int j = 0; j < 4; j++) {
                    if (hex >= factor) {
                        hex -= factor;
                        binarystring.append("1");
                    } else {
                        binarystring.append("0");
                    }
                    factor /= 2;
                }
            }
        } catch (Exception e) {
            System.out.println(e.getMessage() + " - wrong hexa integer format.");
        }
        return binarystring.toString();
    }

    public static String FromBinaryToHex(String binarystring) {
        StringBuilder hexstring = new StringBuilder(binarystring.length() / 4);
        for (int i = 0; i < binarystring.length() / 4; i++) {
            int word = Integer.parseInt(binarystring.substring(i * 4, 4), 2);
            hexstring.append(String.format("{0:X}", word));
        }
        return hexstring.toString();
    }

    public static String FromTextToBinary(String text) {
        StringBuilder binarystring = new StringBuilder(text.length() * 8);
        for (char word : text.toCharArray()) {
            int binary = (int) word;
            int factor = 128;
            for (int i = 0; i < 8; i++) {
                if (binary >= factor) {
                    binary -= factor;
                    binarystring.append("1");
                } else {
                    binarystring.append("0");
                }
                factor /= 2;
            }
        }
        return binarystring.toString();
    }

    public static String setTextMultipleOf128Bits(String text) {
        if ((text.length() % 128) != 0) {
            int maxLength = ((text.length() / 128) + 1) * 128;
//            text = text.PadRight(maxLength, '0');
            text = Services.padRight(text, maxLength);
        }
        return text;
    }
}
