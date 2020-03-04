using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class frmBai3 : Form
    {
        #region Các khai báo biến
        char[,] MaTran = new char[8, 8];
        bool KhoaHopLe = false;
        bool BanTinRoHopLe = false;
        int[] KhoaSo = new int[8];
        int[] KhoaSoNguoc = new int[8];
        #endregion

        #region Các hàm tạo
        public frmBai3()
        {
            InitializeComponent();
        }
        #endregion

        #region Các phương thức
        private bool KiemTraHopLe(String s)
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
        private bool KiemTraMaKhoaHopLe()
        {
            if (rbSo.Checked)
            {
                bool[] CacSo = new bool[8];
                if (txtMaKhoa.Text.Length < 8)
                    return false;
                for (int i = 0; i < txtMaKhoa.Text.Length; i++)
                {
                    char c = txtMaKhoa.Text[i];
                    if (c < '1' || c > '8')
                        return false;
                    else CacSo[(int)c - 49] = true;
                }
                for (int i = 0; i < 8; i++)
                    if (!CacSo[i])
                        return false;
                for (int i = 0; i < 8; i++)
                    KhoaSo[i] = txtMaKhoa.Text[i] - 49;
                return true;
            }
            else
            {
                bool[] CacChu = new bool[26];
                if (txtMaKhoa.Text.Length < 8)
                    return false;
                List<char> dsChu = new List<char>();
                for (int i = 0; i < txtMaKhoa.Text.Length; i++)
                {
                    char c = txtMaKhoa.Text[i];
                    if (c < 'A' || c > 'Z')
                        return false;
                    else
                    {
                        if (dsChu.Contains(c))
                            return false;
                        dsChu.Add(c);
                    }
                }
                dsChu.Sort();
                string ss = "";
                for (int i = 0; i < txtMaKhoa.Text.Length; i++)
                {
                    KhoaSo[i] = dsChu.IndexOf(txtMaKhoa.Text[i]);
                    ss += KhoaSo[i].ToString() + " ";
                }
                MessageBox.Show(ss);
                return true;
            }
        }
        private void TaoKhoaSoNguoc()
        {
            for (int i = 0; i < 8; i++)
                KhoaSoNguoc[KhoaSo[i]] = i;
        }
        #endregion

        #region Các xử lý
        private void txtBanTinRo_TextChanged(object sender, EventArgs e)
        {
            BanTinRoHopLe = KiemTraHopLe(txtBanTinRo.Text);
            btnMaHoa.Enabled = KhoaHopLe && BanTinRoHopLe;
        }
        private void txtBanTinDuocMaHoa_TextChanged(object sender, EventArgs e)
        {
            BanTinRoHopLe = KiemTraHopLe(txtBanTinDuocMaHoa.Text);
            btnGiaiMa.Enabled = KhoaHopLe && BanTinRoHopLe;
        }
        private void txtMaKhoa_TextChanged(object sender, EventArgs e)
        {
            KhoaHopLe = KiemTraMaKhoaHopLe();
            btnMaHoa.Enabled = KhoaHopLe && BanTinRoHopLe;
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            KhoaHopLe = KiemTraMaKhoaHopLe();
            btnMaHoa.Enabled = KhoaHopLe && BanTinRoHopLe;
        }
        private void btnMaHoa_Click(object sender, EventArgs e)
        {
            TaoKhoaSoNguoc();

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    int ii = i * 8 + j;
                    if (ii < txtBanTinRo.Text.Length)
                        MaTran[i, j] = txtBanTinRo.Text[ii];
                    else
                        MaTran[i, j] = 'Z';
                }
            // Ghép kết quả
            string s = "";
            if (rbDongVaCot.Checked)
            {
                // Theo dòng và cột
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        s += MaTran[KhoaSo[i], KhoaSo[j]];
                txtBanTinDuocMaHoa.Text = s;
            }
            else
            {
                // Theo đường chéo
                for (int ii=0; ii<15; ii++)
                {
                    if (ii <= 7)
                    {
                        if (ii % 2 == 0)
                        {
                            for (int j = ii; j >= 0; j--)
                                s += MaTran[ii - j, KhoaSoNguoc[j]];
                            // Chéo xuống
                        }
                        else
                        {
                            for (int j = 0; j <= ii; j++)
                                s += MaTran[ii - j, KhoaSoNguoc[j]];
                            // Chéo lên
                        }
                    }
                    else
                    {
                        if (ii % 2 == 0)
                        {
                            for (int j = 7; j >= ii - 7; j--)
                                s += MaTran[ii -j,KhoaSoNguoc[j]];
                            // Chéo xuống
                        }
                        else
                        {
                            for (int j=ii-7; j<=7; j++)
                                s += MaTran[ii - j, KhoaSoNguoc[j]];
                            // Chéo lên
                        }
                    }
                    // MessageBox.Show(s.Length.ToString());
                }
                txtBanTinDuocMaHoa.Text = s;
                // MessageBox.Show(s.Length.ToString());
            }
        }
        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            TaoKhoaSoNguoc();
            if (txtBanTinDuocMaHoa.Text.Length != 64)
            { 
                MessageBox.Show("Không thể giải mã được"); 
                return; 
            }
            if (rbDongVaCot.Checked)
            { 
                // Theo dòng và cột                 
                for (int i = 0; i < 8; i++)                     
                    for (int j = 0; j < 8; j++)                     
                    {                         
                        int ij = i * 8 + j;                         
                        MaTran[KhoaSo[i], KhoaSo[j]] = txtBanTinDuocMaHoa.Text[ij]; 
                    }                            
            } 
            else           
            {  
                // Theo đường chéo     
                int ij = 0;    
                for (int ii = 0; ii < 15; ii++)        
                {                  
                    if (ii <= 7)              
                    {                 
                        if (ii % 2 == 0)          
                        {                          
                            for (int j = ii; j >= 0; j--)       
                                MaTran[ii - j, KhoaSoNguoc[j]] = txtBanTinDuocMaHoa.Text[ij++];  // Chéo xuống     
                        }                        
                        else               
                        {                       
                            for (int j = 0; j <= ii; j++)     
                                MaTran[ii - j, KhoaSoNguoc[j]] = txtBanTinDuocMaHoa.Text[ij++];  // Chéo lên  
                        }              
                    }                   
                    else                  
                    {                     
                        if (ii % 2 == 0)             
                        {                      
                            for (int j = 7; j >= ii - 7; j--)    
                                MaTran[ii - j, KhoaSoNguoc[j]] = txtBanTinDuocMaHoa.Text[ij++]; // Chéo xuống
                        }                 
                        else                
                        {                       
                            for (int j = ii - 7; j <= 7; j++)  
                                MaTran[ii - j, KhoaSoNguoc[j]] = txtBanTinDuocMaHoa.Text[ij++]; // Chéo lên 
                        }                
                    }                 
                    // MessageBox.Show(s.Length.ToString());   
                }         
            }            
            string s = "";       
            for (int i = 0; i < 8; i++)  
                for (int j = 0; j < 8; j++)     
                    s += MaTran[i, j];       
            txtBanTinDuocGiaiMa.Text = s;
        }
        #endregion
    }
}
