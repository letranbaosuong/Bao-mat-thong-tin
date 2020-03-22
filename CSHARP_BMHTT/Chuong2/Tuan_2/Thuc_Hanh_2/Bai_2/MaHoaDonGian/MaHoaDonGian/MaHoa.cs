using MaHoaDonGian.GiaiThuat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoaDonGian
{
    public class MaHoa
    {
        CommonProcess cProcess = null;
        public MaHoa(int algorithm_number, frmMaHoaGiaiMa.ProgressEventHandler IncrementProgress, frmMaHoaGiaiMa.ProgressInitHandler InitProgress)
        {
            if (CacGiaiThuat.DES == algorithm_number || CacGiaiThuat.DES_File == algorithm_number)
            {
                cProcess = new GiaiThuat.DES.ProcessDES(IncrementProgress, InitProgress);
            }
            else
            {
                cProcess = new GiaiThuat.AES.ProcessAES(IncrementProgress, InitProgress);
            }
        }
        public void EncryptionStart(string filename, string EncryptedFilename,string key)
        {
            string binarytext = GiaiThuat.AES.FileIO.FileReadToBinary(filename);
            binarytext = this.EncryptionStart(binarytext, key, true);
            GiaiThuat.AES.FileIO.WriteBinaryToFile(EncryptedFilename, binarytext);
        }
        public string EncryptionStart(string text,string key,bool IsBinary)
        {
            return cProcess.EncryptionStart(text, key, IsBinary);
        }
        public void DecryptionStart(string filename, string DecryptedFilename, string key)
        {
            string binarytext = GiaiThuat.AES.FileIO.FileReadToBinary(filename);
            binarytext = this.DecryptionStart(binarytext, key, true);
            GiaiThuat.AES.FileIO.WriteBinaryToFile(DecryptedFilename, binarytext);
        }
        public string DecryptionStart(string text,string key,bool IsBinary)
        {
            return cProcess.DecryptionStart(text, key, IsBinary);
        }
    }
}
