using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaHoaDonGian
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.InvokeRequired) // This shouldn't happen since we are on the same thread
            {
                this.Invoke(new MethodInvoker(CloseForm));
            }
            else
            {
                CloseForm();
            }
        }
        private void StartUp_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.Interval = 2000;
            timer1.Start();
        }
    }
}
