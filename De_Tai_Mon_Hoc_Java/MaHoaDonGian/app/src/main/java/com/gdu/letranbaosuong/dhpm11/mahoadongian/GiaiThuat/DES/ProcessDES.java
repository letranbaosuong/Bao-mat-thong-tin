package com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat.DES;

import com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat.CommonProcess;
import com.gdu.letranbaosuong.dhpm11.mahoadongian.Services.Services;

public class ProcessDES extends CommonProcess {
    public event frmMaHoaGiaiMa.
    ProgressInitHandler InitProgress;
    public event frmMaHoaGiaiMa.
    ProgressEventHandler IncrementProgress;

    public ProcessDES(frmMaHoaGiaiMa.ProgressEventHandler IncProg, frmMaHoaGiaiMa.ProgressInitHandler InitProg) {
        this.IncrementProgress = IncProg;
        this.InitProgress = InitProg;
    }

    protected virtual

    void OnIncrementProgress(ProgressEventArgs e) {
        if (IncrementProgress != null)
            IncrementProgress(this, e);
    }

    protected virtual

    void OnInitProgress(ProgressInitArgs e) {
        if (InitProgress != null)
            InitProgress(this, e);
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

    public String FromTextToHex(String text) {
        String hexstring = "";
        for (char word : text.toCharArray()) {
            hexstring += String.format("{0:X}", Integer.parseInt(Character.toString(word)));
        }
        return hexstring;
    }

    public String FromTextToBinary(String text) {
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

    public String FromHexToBinary(String hexstring) {
        String binarystring = "";
        try {
            for (int i = 0; i < hexstring.length(); i++) {
                int hex = Integer.parseInt(Character.toString(hexstring.charAt(i)), 16);
                int factor = 8;
                for (int j = 0; j < 4; j++) {
                    if (hex >= factor) {
                        hex -= factor;
                        binarystring += "1";
                    } else {
                        binarystring += "0";
                    }
                    factor /= 2;
                }
            }
        } catch (Exception e) {
            System.out.println(e.getMessage() + " - wrong hexa integer format.");
        }
        return binarystring;
    }

    public String DoPermutation(String text, int[] order) {
        StringBuilder PermutatedText = new StringBuilder(order.length);
        for (int i = 0; i < order.length; i++) {
            PermutatedText.append(text.charAt(order[i] - 1));
        }
        return PermutatedText.toString();
    }

    public String DoPermutation(String text, int[][] order) {
        // text chứa chuỗi 6 bit
        // order là mảng 4 dòng 16 cột
        String PermutatedText = "";
        // Bit đầu ghép bit cuối làm số dòng (0-->3)
        int rowIndex = Integer.parseInt(Character.toString(text.charAt(0)) + Character.toString(text.charAt(text.length() - 1)), 2);
        // 4 bit giữa làm số cột (0-->15)
        int colIndex = Integer.parseInt(text.substring(1, 4), 2);
        // Từ 6 bit chuyển thành 4 bit
        PermutatedText = ProcessDES.FromDecimalToBinary(order[rowIndex, colIndex]);
        // Lấy phần tử ở mảng order, với giá trị từ 0 đến 15, chuyển sang chuỗi nhị phân
        return PermutatedText;
    }

    public String SetHalvesKey(boolean IsLeft, String text) {
        if ((text.length() % 8) != 0) {
            System.out.println("The key is not multiple of 8bit.");
            return null;
        }
        int midindex = (text.length() / 2) - 1;
        String result = "";
        if (IsLeft) {
            result = text.substring(0, midindex + 1);
        } else {
            result = text.substring(midindex + 1);
        }
        return result;
    }

    public String SetLeftHalvesKey(String text) {
        return this.SetHalvesKey(true, text);
    }

    public String SetRightHalvesKey(String text) {
        return this.SetHalvesKey(false, text);
    }

    public String LeftShift(String text, int count) {
        // Đẩy vòng sang trái
        if (count < 1) {
            System.out.println("The count of leftshift is must more than 1 time.");
            return null;
        }
        String temp = text.substring(0, count);
        StringBuilder shifted = new StringBuilder(text.length());
        shifted.append(text.substring(count) + temp);
        return shifted.toString();
    }

    public String LeftShift(String text) {
        return this.LeftShift(text, 1);
    }

    public Keys SetAllKeys(String C0, String D0) {
        Keys keys = new Keys();
        keys.Cn[0] = C0;
        keys.Dn[0] = D0;
        for (int i = 1; i < keys.Cn.length; i++) // Thực hiện 16 vòng với i=1..16
        {
            keys.Cn[i] = this.LeftShift(keys.Cn[i - 1], DESData.nrOfShifts[i]);
            keys.Dn[i] = this.LeftShift(keys.Dn[i - 1], DESData.nrOfShifts[i]);
            keys.Kn[i - 1] = this.DoPermutation(keys.Cn[i] + keys.Dn[i], DESData.pc_2);
        }
        return keys;
    }

    public String setTextMultipleOf64Bits(String text) {
        if ((text.length() % 64) != 0) {
            int maxLength = ((text.length() / 64) + 1) * 64;
//            text = text.PadRight(maxLength, '0');
            text = Services.padRight(text, maxLength);
        }
        return text;
    }

    public boolean IsEnough(int i, boolean IsReverse) {
        return IsReverse ? i >= 0 : i < 16;
    }

    public String E_Selection(String Rn_1) {
        String ExpandedText = this.DoPermutation(Rn_1, DESData.pc_e);
        return ExpandedText;
    }

    public String XOR(String text1, String text2) {
        if (text1.length() != text2.length()) {
            System.out.println("Two data blocks for XOR must get same size.");
            return null;
        }
        StringBuilder XORed_Text = new StringBuilder(text1.length());
        for (int i = 0; i < text1.length(); i++) {
            if (text1.charAt(i) != text2.charAt(i)) {
                XORed_Text.append("1");
            } else {
                XORed_Text.append("0");
            }
        }
        return XORed_Text.toString();
    }

    public String sBox_Transform(String text) {
        // Chuyển khóa vòng 48 bit thành kết xuất 32 bit
        StringBuilder TransformedText = new StringBuilder(32);
        for (int i = 0; i < 8; i++) {
            String temp = text.substring(i * 6, 6); // Mỗi lần lấy 6 bit
            // Chuyển thành 4 bit
            TransformedText.append(this.DoPermutation(temp, DESData.sBoxes[i]));
        }
        return TransformedText.toString();
    }

    public String P(String text) {
        String PermutatedText = this.DoPermutation(text, DESData.pc_p);
        return PermutatedText;
    }

    public String f(String Rn_1, String Kn) {
        // Nhận nửa phải 32 bit, và một khóa vòng 48 bit, sinh ra một kết xuất 32 bit
        String E_Rn_1 = this.E_Selection(Rn_1);
        String XOR_Rn_1_Kn = this.XOR(E_Rn_1, Kn);
        String sBoxedText = this.sBox_Transform(XOR_Rn_1_Kn);
        String P_sBoxedText = this.P(sBoxedText);
        return P_sBoxedText;
    }

    public String FinalEncription(String L0, String R0, Keys keys, boolean IsReverse) {
        String Ln = "", Rn = "", Ln_1 = L0, Rn_1 = R0;
        int i = 0;
        if (IsReverse) {
            i = 15;
        }
        while (this.IsEnough(i, IsReverse)) {
            Ln = Rn_1;
            Rn = this.XOR(Ln_1, this.f(Rn_1, keys.Kn[i]));
            //Next Step of L1, R1 is L2 = R1, R2 = L1 + f(R1, K2),
            // hence, value of Step1's Ln, Rn is Rn_1, Ln_1 in Step2.
            Ln_1 = Ln;
            Rn_1 = Rn;
            if (IsReverse == false) i++;
            else i--;
        }
        String R16L16 = Rn + Ln;
        String Encripted_Text = this.DoPermutation(R16L16, DESData.ip_1);
        return Encripted_Text;
    }

    @Override
    public String EncryptionStart(String text, String key, boolean IsTextBinary) {
        // Get 16 sub-keys using key

        String hex_key = this.FromTextToHex(key);
        String binary_key = this.FromHexToBinary(hex_key);
        String key_plus = this.DoPermutation(binary_key, DESData.pc_1);
        String C0 = "", D0 = "";
        C0 = this.SetLeftHalvesKey(key_plus);
        D0 = this.SetRightHalvesKey(key_plus);
        Keys keys = this.SetAllKeys(C0, D0);
        // Encrypt process
        //string hex_text = this.FromTextToHex(text);
        String binaryText = "";
        if (IsTextBinary == false) {
            binaryText = this.FromTextToBinary(text);
        } else {
            binaryText = text;
        }
        binaryText = this.setTextMultipleOf64Bits(binaryText);
        //Initialize Progress Bar
        OnInitProgress(new ProgressInitArgs(binaryText.length()));
        StringBuilder EncryptedTextBuilder = new StringBuilder(binaryText.length());
        for (int i = 0; i < (binaryText.length() / 64); i++) {
            String PermutatedText = this.DoPermutation(binaryText.substring(i * 64, 64), DESData.ip);
            String L0 = "", R0 = "";
            L0 = this.SetLeftHalvesKey(PermutatedText);
            R0 = this.SetRightHalvesKey(PermutatedText);
            String FinalText = this.FinalEncription(L0, R0, keys, false);
            EncryptedTextBuilder.append(FinalText);
            // Increase Progress Bar
            OnIncrementProgress(new ProgressEventArgs(FinalText.length()));
        }
        return EncryptedTextBuilder.toString();
    }

    @Override
    public String DecryptionStart(String text, String key, boolean IsTextBinary) {
        // Get 16 sub-keys using key
        String hex_key = this.FromTextToHex(key);
        String binary_key = this.FromHexToBinary(hex_key);
        String key_plus = this.DoPermutation(binary_key, DESData.pc_1);
        String C0 = "", D0 = "";
        C0 = this.SetLeftHalvesKey(key_plus);
        D0 = this.SetRightHalvesKey(key_plus);
        Keys keys = this.SetAllKeys(C0, D0);
        // Decrypt process
        String binaryText = "";
        if (IsTextBinary == false) {
            binaryText = this.FromTextToBinary(text);
        } else {
            binaryText = text;
        }
        binaryText = this.setTextMultipleOf64Bits(binaryText);
        // Initialize Progress Bar
        OnInitProgress(new ProgressInitArgs(binaryText.length()));
        StringBuilder DecryptedTextBuilder = new StringBuilder(binaryText.length());
        for (int i = 0; i < (binaryText.length() / 64); i++) {
            String PermutatedText = this.DoPermutation(binaryText.substring(i * 64, 64), DESData.ip);
            String L0 = "", R0 = "";
            L0 = this.SetLeftHalvesKey(PermutatedText);
            R0 = this.SetRightHalvesKey(PermutatedText);
            String FinalText = this.FinalEncription(L0, R0, keys, true);
            // It's for correct subtracted '0' that have added for set text multiple of 64bit
            if ((i * 64 + 64) == binaryText.length()) {
                StringBuilder last_text = new StringBuilder(Services.trimEnd(FinalText, "0"));
                int count = FinalText.length() - last_text.length();
                if ((count % 8) != 0) {
                    count = 8 - (count % 8);
                }
                String append_text = "";
                for (int k = 0; k < count; k++) {
                    append_text += "0";
                }
                DecryptedTextBuilder.append(last_text.toString() + append_text);
            } else {
                DecryptedTextBuilder.append(FinalText);
            }
            // Increase Progress Bar
            OnIncrementProgress(new ProgressEventArgs(FinalText.length()));
        }
        return DecryptedTextBuilder.toString();//.TrimEnd('0');
    }
}
