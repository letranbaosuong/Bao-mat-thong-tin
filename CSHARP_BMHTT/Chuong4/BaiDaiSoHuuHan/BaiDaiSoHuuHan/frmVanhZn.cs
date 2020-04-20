using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiDaiSoHuuHan
{
    public partial class frmVanhZn : Form
    {
        #region biến
        private char code = 'Z';
        #endregion
        #region các hàm tạo
        public frmVanhZn()
        {
            InitializeComponent();
        }
        #endregion

        private void btnCong_Click(object sender, EventArgs e)
        {
            int n = (int)(nudN.Value);
            frmBangPhepCong frm = new frmBangPhepCong(code, n);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            int n = (int)(nudN.Value);
            frmBangPhepNhan frm = new frmBangPhepNhan(code, n);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnLuyThua_Click(object sender, EventArgs e)
        {
            int n = (int)(nudN.Value);
            frmBangPhepLuyThua frm = new frmBangPhepLuyThua(code, n);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
