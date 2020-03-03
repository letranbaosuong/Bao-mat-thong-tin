using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class frmBai2 : Form
    {
        #region Các báo biến
        char[] BangHoanVi = new char[26];
        #endregion

        #region Các hàm tạo
        public frmBai2()
        {
            InitializeComponent();
        }
        #endregion

        #region Các phương thức
        private void TaoBangHoanVi()
        {
            for (int i = 0; i < 26; i++)
                BangHoanVi[i] = (char)(65 + i);
            Random RndObj = new Random(DateTime.Now.Millisecond);
            int SoLan = 20 + RndObj.Next(80);
            for (int n = 0; n < SoLan; n++)
            {
                int n1 = RndObj.Next(26);
                int n2 = RndObj.Next(26);
                char c = BangHoanVi[n1];
                BangHoanVi[n1] = BangHoanVi[n2];
                BangHoanVi[n2] = c;
            }
        }
        private bool KiemTraHopLe(string s)
        {
            bool HopLe = true;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < 'A' || c > 'Z')
                {
                    HopLe = false;
                    break;
                }
            }
            return HopLe;
        }
        private int TimViTri(char c)
        {
            return c - 65;
        }
        private int TimViTriNguoc(char c)
        {
            for (int i = 0; i < 26; i++)
                if (BangHoanVi[i] == c)
                    return i;
            return -1; // Báo sai
        }
        #endregion

        #region Các xử lý
        private void frmBai2_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBanTinRo;
            TaoBangHoanVi();
            string s = "";
            for (int i = 0; i < 26; i++)
                s += BangHoanVi[i];
            MessageBox.Show(s, "Bảng hoán vị ngẫu nhiên");
           
        }
        private void txtBanTinRo_TextChanged(object sender, EventArgs e)
        {
            btnMaHoa.Enabled = KiemTraHopLe(txtBanTinRo.Text);
        }
        private void txtBanTinDuocMaHoa_TextChanged(object sender, EventArgs e)
        {
            btnGiaiMa.Enabled = KiemTraHopLe(txtBanTinDuocMaHoa.Text);
        }
        private void btnMaHoa_Click(object sender, EventArgs e)
        {
            string s = "";
            for (int i = 0; i < txtBanTinRo.Text.Length; i++)
            {
                int vitri = TimViTri(txtBanTinRo.Text[i]);
                s += BangHoanVi[vitri];
            }
            txtBanTinDuocMaHoa.Text = s;
        }
        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            string s = "";
            for (int i = 0; i < txtBanTinRo.Text.Length; i++)
            {
                int vitri = TimViTriNguoc(txtBanTinDuocMaHoa.Text[i]);
                s += (char)(vitri + 65);
            }
            txtBanTinDuocGiaiMa.Text = s;
        }
        #endregion
    }
}
