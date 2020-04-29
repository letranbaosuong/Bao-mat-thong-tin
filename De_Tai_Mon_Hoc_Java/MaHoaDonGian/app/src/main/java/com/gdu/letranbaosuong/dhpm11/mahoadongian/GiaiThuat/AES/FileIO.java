package com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat.AES;

public class FileIO {
    public static String FileReadToBinary(String filename) {
        FileStream fs = new FileStream(filename, FileMode.Open);
        System.out.println("File size : " + fs.Length);
        // Read from file 100 bytes per 1 time and transform to binary data.
        int fileLength = (int) fs.Length;
        StringBuilder text = new StringBuilder((int) fs.Length * 8);
        byte[] bytes = new byte[100];
        int startindex = 0;
        // int IsEnd = -1;
        while (fs.Read(bytes, startindex, bytes.length) != 0) {
            // if (IsEnd > 0)
            // {
            // }
            for( byte b : bytes)
            {
                if (text.length() == fileLength * 8) {
                    break;
                }
                text.append(BaseTransform.FromDecimalToBinary(b));
            }
        }
        fs.Close();
        return text.toString();
    }

    public static void WriteBinaryToFile(String filename, String binaryText) {
        // Write binary encrypted or decrypted data to file.
        FileStream fs = new FileStream(filename, FileMode.Create);
        StringBuilder sub_text = new StringBuilder(800);
        byte[] bytes = new byte[100];
        int length = 800;
        for (int i = 0; i <= binaryText.length() / 800; i++) {
            int remain = binaryText.length() - i * 800;
            if (remain < 800) {
                length = remain;
            }
            sub_text.Remove(0, sub_text.length());
            sub_text.append(binaryText.substring(i * 800, length));
            for (int j = 0; j < sub_text.length() / 8; j++) {
                bytes[j] = BaseTransform.FromBinaryToByte(sub_text.toString().substring(j * 8, 8));
                if (remain < 800) {
                    System.out.println(bytes[j].ToString());
                }
            }
            fs.Write(bytes, 0, sub_text.length() / 8);
        }
        System.out.println();
        fs.Close();
    }
}
