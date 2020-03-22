using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoaDonGian.GiaiThuat.AES
{
    class BaseTransform
    {
        public static string FromTextToHex(string text)
        {
            StringBuilder hexstring = new StringBuilder(text.Length * 2);
            foreach (char word in text)
            {
                hexstring.Append(String.Format("{0:X}", Convert.ToInt32(word)));
            }
            return hexstring.ToString();
        }
        public static string FromHexToText(string hexstring)
        {
            StringBuilder text = new StringBuilder(hexstring.Length / 2);
            for (int i = 0; i < (hexstring.Length / 2); i++)
            {
                string word = hexstring.Substring(i * 2, 2);
                text.Append((char)Convert.ToInt32(word, 16));
            }
            return text.ToString();
        }
        public static string FromBinaryToText(string binarystring)
        {
            StringBuilder text;
            text = new StringBuilder(binarystring.Length / 8);
            for (int i = 0; i < (binarystring.Length / 8); i++)
            {
                string word = binarystring.Substring(i * 8, 8);
                text.Append((char)Convert.ToInt32(word, 2));
                //text += (char)Convert.ToInt32(word, 16);
            }
            return text.ToString();
        }
        public static string setTextMultipleOf64Bits(string text)
        {
            int maxLength = 0;
            if ((text.Length % 64) != 0)
            {
                maxLength = ((text.Length / 64) + 1) * 64;
            }
            text = text.PadRight(maxLength, '0');
            return text;
        }
        public static string FromDecimalToBinary(int binary)
        {
            if (binary < 0)
            {
                Console.WriteLine("It requires a integer greater than 0.");
                return null;
            }
            string binarystring = "";
            int factor = 128;
            for (int i = 0; i < 8; i++)
            {
                if (binary >= factor)
                {
                    binary -= factor;
                    binarystring += "1";
                }
                else
                {
                    binarystring += "0";
                }
                factor /= 2;
            }
            return binarystring;
        }
        public static byte FromBinaryToByte(string binary)
        {
            byte value = 0;
            int factor = 128;
            for (int i = 0; i < 8; i++)
            {
                if (binary[i] == '1')
                {
                    value += (byte)factor;
                }
                factor /= 2;
            }
            return value;
        }
        public static string FromHexToBinary(string hexstring)
        {
            StringBuilder binarystring = new StringBuilder(hexstring.Length * 4);
            try
            {
                for (int i = 0; i < hexstring.Length; i++)
                {
                    int hex = Convert.ToInt32(hexstring[i].ToString(), 16);
                    int factor = 8;
                    for (int j = 0; j < 4; j++)
                    {
                        if (hex >= factor)
                        {
                            hex -= factor;
                            binarystring.Append("1");
                        }
                        else
                        {
                            binarystring.Append("0");
                        }
                        factor /= 2;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - wrong hexa integer format.");
            }
            return binarystring.ToString();
            }
        public static string FromBinaryToHex(string binarystring)
        {
            StringBuilder hexstring = new StringBuilder(binarystring.Length / 4);
            for (int i = 0; i < binarystring.Length / 4; i++)
            {
                int word = Convert.ToInt32(binarystring.Substring(i * 4, 4), 2);
                hexstring.Append(String.Format("{0:X}", word));
            }
            return hexstring.ToString();
        }
        public static string FromTextToBinary(string text)
        {
            StringBuilder binarystring = new StringBuilder(text.Length * 8);
            foreach (char word in text)
            {
                int binary = (int)word;
                int factor = 128;
                for (int i = 0; i < 8; i++)
                {
                    if (binary >= factor)
                    {
                        binary -= factor;
                        binarystring.Append("1");
                    }
                    else
                    {
                        binarystring.Append("0");
                    }
                    factor /= 2;
                }
            }
            return binarystring.ToString();
        }
        public static string setTextMultipleOf128Bits(string text)
        {
            if ((text.Length % 128) != 0)
            {
                int maxLength = ((text.Length / 128) + 1) * 128;
                text = text.PadRight(maxLength, '0');
            }
            return text;
        }
    }
}
