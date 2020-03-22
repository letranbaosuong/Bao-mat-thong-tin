using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoaDonGian.GiaiThuat
{
    abstract class CommonProcess
    {
        public abstract string EncryptionStart(string text, string key, bool IsTextBinary);
        public abstract string DecryptionStart(string text, string key, bool IsTextBinary);
    }
}
