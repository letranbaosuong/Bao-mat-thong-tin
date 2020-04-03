using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTapCaesarThayTheDonGian
{
    public partial class frmMain : Form
    {
        public static string chuCaiRo = "abcdefghijklmnopqrstuvwxyz";
        public static string chuCaiDuocMaHoa = "SCJAXUFBQKTPRWEZHVLIGYDNMO";
        public frmMain()
        {
            InitializeComponent();
            txtChuCaiRoCau3.Text = chuCaiRo;
            txtChuCaiDuocMaHoaCau3.Text = chuCaiDuocMaHoa;
        }
        private void txtBanTinRo_TextChanged(object sender, EventArgs e)
        {
            MaHoa();
        }
        private void MaHoa()
        {
            string s = "";
            string banTinRo = txtBanTinRo.Text;
            //banTinRo = banTinRo.Replace(" ", string.Empty);
            banTinRo = banTinRo.Trim().ToUpper();
            //MessageBox.Show(banTinRo);
            for (int i = 0; i < banTinRo.Length; i++)
            {
                char c = banTinRo[i];
                int n = (int)c;

                if (n == 32)
                {
                    s += ' '; // s = s + c 
                }
                else
                {
                    c = (Char)((n - 65 + (int)(nudSoViTri.Value) + 26) % 26 + 65);
                    //c = (Char)(n - 65);
                    s += c; // s = s + c 
                }
            }
            //txtBanTinDuocMaHoa.Text = s;
            txtKetQua.Text = s;
        }

        private void txtBanTinDuocMaHoa_TextChanged(object sender, EventArgs e)
        {
            GiaiMa();
        }

        private void GiaiMa()
        {
            string s = "";
            string banTinDuocMaHoa = txtBanTinDuocMaHoa.Text;
            //banTinDuocMaHoa = banTinDuocMaHoa.Replace(" ", string.Empty);
            banTinDuocMaHoa = banTinDuocMaHoa.Trim().ToUpper();
            for (int i = 0; i < banTinDuocMaHoa.Length; i++)
            {
                char c = banTinDuocMaHoa[i];
                int n = (int)c;

                if (n == 32)
                {
                    s += ' '; // s = s + c 
                }
                else
                {
                    c = (Char)((n - 65 - (int)(nudSoViTri.Value) + 26) % 26 + 65);
                    //c = (Char)(n - 65);
                    s += c; // s = s + c 
                }
            }
            //txtBanTinRo.Text = s;
            txtKetQua.Text = s;
        }

        private void nudSoViTri_ValueChanged(object sender, EventArgs e)
        {
            if (chkGiaiMa.Checked)
            {
                GiaiMa();
            }
            else
            {
                MaHoa();
            }
        }

        private void chkGiaiMa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGiaiMa.Checked)
            {
                txtBanTinRo.Enabled = false;
                txtBanTinDuocMaHoa.Enabled = true;
                txtBanTinRo.Clear();
                txtBanTinDuocMaHoa.Clear();
            }
            else
            {
                txtBanTinRo.Enabled = true;
                txtBanTinDuocMaHoa.Enabled = false;
                txtBanTinRo.Clear();
                txtBanTinDuocMaHoa.Clear();
            }
        }

        private void txtBanTinRoCau3_TextChanged(object sender, EventArgs e)
        {
            string s = "";
            string banTinRoCau3 = txtBanTinRoCau3.Text;
            banTinRoCau3 = banTinRoCau3.Trim().ToLower();
            for (int i = 0; i < banTinRoCau3.Length; i++)
            {
                if ((int)banTinRoCau3[i] == 32)
                {
                    s += ' ';
                }
                for (int j = 0; j < chuCaiRo.Length; j++)
                {
                    if (banTinRoCau3[i] == chuCaiRo[j])
                    {
                        s += chuCaiDuocMaHoa[j];
                    }
                }
            }
            txtKetQuaCau3.Text = s;
        }

        private void txtBanTinDuocMaHoaCau3_TextChanged(object sender, EventArgs e)
        {
            string s = "";
            string banTinDuocMaHoaCau3 = txtBanTinDuocMaHoaCau3.Text;
            banTinDuocMaHoaCau3 = banTinDuocMaHoaCau3.Trim().ToUpper();
            for (int i = 0; i < banTinDuocMaHoaCau3.Length; i++)
            {
                if ((int)banTinDuocMaHoaCau3[i] == 32)
                {
                    s += ' ';
                }
                for (int j = 0; j < chuCaiDuocMaHoa.Length; j++)
                {
                    if (banTinDuocMaHoaCau3[i] == chuCaiDuocMaHoa[j])
                    {
                        s += chuCaiRo[j];
                    }
                }
            }
            txtKetQuaCau3.Text = s;
        }

        private void chkGiaiMaCau3_CheckedChanged(object sender, EventArgs e)
        {
            if (txtChuCaiRoCau3.Text.Length == 26 && txtChuCaiDuocMaHoaCau3.Text.Length == 26)
            {
                if (chkGiaiMaCau3.Checked)
                {
                    txtBanTinRoCau3.Enabled = false;
                    txtBanTinDuocMaHoaCau3.Enabled = true;
                    txtBanTinRoCau3.Clear();
                    txtBanTinDuocMaHoaCau3.Clear();
                }
                else
                {
                    txtBanTinRoCau3.Enabled = true;
                    txtBanTinDuocMaHoaCau3.Enabled = false;
                    txtBanTinRoCau3.Clear();
                    txtBanTinDuocMaHoaCau3.Clear();
                }
            }
            else
            {
                txtBanTinRoCau3.Enabled = false;
                txtBanTinDuocMaHoaCau3.Enabled = false;
            }
        }

        private void btnTinhCau5_Click(object sender, EventArgs e)
        {
            long thuong, sodu, sobichia, sochia;
            sobichia = long.Parse(txtSoBiChiaCau5.Text.Trim().ToString());
            sochia = long.Parse(txtSoChiaCau5.Text.Trim().ToString());
            thuong = sobichia / sochia;
            sodu = sobichia % sochia;
            txtThuongCau5.Text = thuong.ToString();
            txtSoDuCau5.Text = sodu.ToString();
        }

        private void btnKetQuaCau4_Click(object sender, EventArgs e)
        {
            txtTongKiTuCau4.Text = TinhTongSoKiTu(txtChuoiCau4.Text.Trim()).ToString();
            TinhTongSoChuCaiXuatHien(txtChuoiCau4.Text.Trim());
            TinhTongSoCapTrung(txtChuoiCau4.Text.Trim());
        }

        private void TinhTongSoCapTrung(string chuoi)
        {
            chuoi = String.Join("", chuoi.Where(c => !char.IsWhiteSpace(c)));
            chuoi = chuoi.Trim().ToUpper();
            List<string> mangCapTrung = new List<string>();
            List<string> mangTam = new List<string>();
            /*if (chuoi.StartsWith("0x"))
            {
                //return
                MessageBox.Show(chuoi.Skip(2)
                 .Select((x, i) => new { index = i, value = x })
                 .GroupBy(pair => pair.index / 2)
                 .Select(grp => string.Join("", grp.Select(x => x.value)))
                 .Select(x => Convert.ToByte(x, 16))
                 .ToArray().ToString());
            }*/
            int j = 1;
            for (int i = 0; i < chuoi.Length; i++)
            {
                if (j == chuoi.Length)
                {
                    break;
                }
                else
                {
                    string cap = "";
                    cap = cap + chuoi[i] + chuoi[j];
                    mangTam.Add(cap);
                    j++;
                }
            }
            var FreQ = from x in mangTam
                       group x by x into y
                       select y;
            foreach (var ArrEle in FreQ)
            {
                if (ArrEle.Count() > 1)
                {
                    mangCapTrung.Add(ArrEle.Key + ": " + ArrEle.Count());
                }
            }
            txtTongSoCapTrungCau4.Text = mangCapTrung.Count().ToString();
            richTextBoxCapTrungCau4.Text = String.Join("\n", mangCapTrung);
        }

        private void TinhTongSoChuCaiXuatHien(string chuoi)
        {
            chuoi = String.Join("", chuoi.Where(c => !char.IsWhiteSpace(c)));
            chuoi = chuoi.Trim().ToUpper();
            List<string> mangKiTuXuatHien = new List<string>();
            /*chuoi
            .Where(Char.IsLetterOrDigit)
            .GroupBy(c => c)
            .Aggregate((seed, next) =>
            {
                mangKiTuXuatHien.Add(next.Key + ": " + next.Count());
                return seed;
            });
            richTextBoxSoChuCaiCau4.Text = String.Join("\n", mangKiTuXuatHien);
            txtTongSoChuCaiXuatHienCau4.Text = mangKiTuXuatHien.Count().ToString();*/

            var FreQ = from x in chuoi
                       group x by x into y
                       select y;
            foreach (var ArrEle in FreQ)
            {
                mangKiTuXuatHien.Add(ArrEle.Key + ": " + ArrEle.Count());
            }
            richTextBoxSoChuCaiCau4.Text = String.Join("\n", mangKiTuXuatHien);
            txtTongSoChuCaiXuatHienCau4.Text = mangKiTuXuatHien.Count().ToString();
        }

        private int TinhTongSoKiTu(string chuoi)
        {
            chuoi = String.Join("", chuoi.Where(c => !char.IsWhiteSpace(c)));
            /*chuoi = chuoi.Replace("\n", string.Empty);
            chuoi = chuoi.Replace("\t", string.Empty);*/
            return chuoi.Length;
        }

        private void txtChuCaiRoCau3_TextChanged(object sender, EventArgs e)
        {
            if (txtChuCaiRoCau3.Text.Length == 26 && txtChuCaiDuocMaHoaCau3.Text.Length == 26)
            {
                chuCaiRo = txtChuCaiRoCau3.Text.Trim();
                chuCaiDuocMaHoa = txtChuCaiDuocMaHoaCau3.Text.Trim();
                if (chkGiaiMaCau3.Checked)
                {
                    txtBanTinRoCau3.Enabled = false;
                    txtBanTinDuocMaHoaCau3.Enabled = true;
                    txtBanTinRoCau3.Clear();
                    txtBanTinDuocMaHoaCau3.Clear();
                }
                else
                {
                    txtBanTinRoCau3.Enabled = true;
                    txtBanTinDuocMaHoaCau3.Enabled = false;
                    txtBanTinRoCau3.Clear();
                    txtBanTinDuocMaHoaCau3.Clear();
                }
            }
            else
            {
                txtBanTinRoCau3.Enabled = false;
                txtBanTinDuocMaHoaCau3.Enabled = false;
            }
        }

        private void txtChuCaiDuocMaHoaCau3_TextChanged(object sender, EventArgs e)
        {
            if (txtChuCaiRoCau3.Text.Length == 26 && txtChuCaiDuocMaHoaCau3.Text.Length == 26)
            {
                chuCaiRo = txtChuCaiRoCau3.Text.Trim();
                chuCaiDuocMaHoa = txtChuCaiDuocMaHoaCau3.Text.Trim();
                if (chkGiaiMaCau3.Checked)
                {
                    txtBanTinRoCau3.Enabled = false;
                    txtBanTinDuocMaHoaCau3.Enabled = true;
                    txtBanTinRoCau3.Clear();
                    txtBanTinDuocMaHoaCau3.Clear();
                }
                else
                {
                    txtBanTinRoCau3.Enabled = true;
                    txtBanTinDuocMaHoaCau3.Enabled = false;
                    txtBanTinRoCau3.Clear();
                    txtBanTinDuocMaHoaCau3.Clear();
                }
            }
            else
            {
                txtBanTinRoCau3.Enabled = false;
                txtBanTinDuocMaHoaCau3.Enabled = false;
            }
        }
    }
}
