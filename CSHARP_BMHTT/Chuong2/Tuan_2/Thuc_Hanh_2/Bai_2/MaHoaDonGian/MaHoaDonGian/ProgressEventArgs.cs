using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoaDonGian
{
    public class ProgressInitArgs : EventArgs
    {
        public int Maximum;
        public ProgressInitArgs(int Max)
        {
            this.Maximum = Max;
        }
    }
    public class ProgressEventArgs : EventArgs
    {
        public int Increment;
        public ProgressEventArgs(int Inc)
        {
            this.Increment = Inc;
        }
    }
}
