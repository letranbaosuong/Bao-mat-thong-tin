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
    public partial class frmTruongQp : Form
    {
        #region Biến
        private char code = 'Q';
        #endregion
        #region Hàm tạo
        public frmTruongQp()
        {
            InitializeComponent();
        }
        #endregion
        #region Các phương thức
        private bool IsPrime(int n)
        {
            int a = 2;
            while (a * a <= n)
            {
                if (n % a == 0) return false;
                a++;
            }
            return true;
        }
        #endregion

        private void nudP_ValueChanged(object sender, EventArgs e)
        {
            bool HopLe = IsPrime((int)nudP.Value);
            btnCong.Enabled = btnNhan.Enabled = btnLuyThua.Enabled = HopLe;
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            int n = (int)(nudP.Value);
            frmBangPhepCong frm = new frmBangPhepCong(code, n);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            int n = (int)(nudP.Value);
            frmBangPhepNhan frm = new frmBangPhepNhan(code, n);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnLuyThua_Click(object sender, EventArgs e)
        {
            int n = (int)(nudP.Value);
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
