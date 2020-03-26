using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaNgauNhien
{
    public partial class frmGiaNgauNhien : Form
    {
        private DataSet dsBangSoLan = new DataSet();
        private DataTable dtBangSoLan = new DataTable();
        public frmGiaNgauNhien()
        {
            InitializeComponent();
        }
        private long TimSoLan(int HatGiong)
        {
            Random RndObj = new Random(HatGiong);
            int SoNgauNhienDauTien = RndObj.Next();
            int SoNgauNhien;
            long SoLan = 0;
            do
            {
                SoNgauNhien = RndObj.Next();
                SoLan++;
            } while (SoNgauNhien != SoNgauNhienDauTien);
            return SoLan;
        }
        private void ThemVaoBang(int HatGiong,long SoLan)
        {
            dtBangSoLan.Rows.Add(HatGiong, SoLan);
        }
        private void KiemHopLe()
        {
            btnTaoNgauNhien.Enabled = rbChiDinh.Checked && (nudHatGiongTu.Value <= nudHatGiongDen.Value)|| rbThoiGian.Checked && nudSoLan.Value > 0;
        }

        private void frmGiaNgauNhien_Load(object sender, EventArgs e)
        {
            dtBangSoLan.Columns.Add(new DataColumn("HatGiong", System.Type.GetType("System.Int32")));
            dtBangSoLan.Columns.Add(new DataColumn("SoLan", System.Type.GetType("System.Decimal")));
            dtBangSoLan.TableName = "BangSo";
            dsBangSoLan.Tables.Add(dtBangSoLan);
            dgBangSoLan.DataSource = dsBangSoLan.Tables["BangSo"]; // dtBangSoLan;
        }

        private void rbChiDinh_CheckedChanged(object sender, EventArgs e)
        {
            nudHatGiongTu.Enabled = true;
            nudHatGiongDen.Enabled = true;
            nudSoLan.Enabled = false;
            KiemHopLe();
        }

        private void rbThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            nudHatGiongTu.Enabled = false;
            nudHatGiongDen.Enabled = false;
            nudSoLan.Enabled = true;
            KiemHopLe();
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            KiemHopLe();
        }

        private void btnTaoNgauNhien_Click(object sender, EventArgs e)
        {
            btnTaoNgauNhien.Enabled = false;
            stsStrip.Items[0].Text = "Đang tính toán ...";
            stsTienDo.Value = 0;
            if (rbChiDinh.Checked)
            {
                int HatGiongTu = (int)nudHatGiongTu.Value;
                int HatGiongDen = (int)nudHatGiongDen.Value;
                dtBangSoLan.Rows.Clear();
                Application.DoEvents();
                stsTienDo.Step = 100 / (HatGiongDen - HatGiongTu + 1);
                for (int HatGiong = HatGiongTu; HatGiong <= HatGiongDen; HatGiong++)
                {
                    stsTienDo.Value = (HatGiong - HatGiongTu + 1) * 100 / (HatGiongDen - HatGiongTu + 1);
                    long SoLan = TimSoLan(HatGiong);
                    ThemVaoBang(HatGiong, SoLan);
                    Application.DoEvents();
                }
            }
            else
            {
                dtBangSoLan.Rows.Clear();
                Application.DoEvents();
                int SoLanChay = (int)nudSoLan.Value;
                stsTienDo.Step = 100 / SoLanChay;
                for (int lan = 0; lan < (int)nudSoLan.Value; lan++)
                {
                    stsTienDo.Value = (lan + 1) * 100 / SoLanChay;
                    int HatGiong = (int)DateTime.Now.Millisecond;
                    long SoLan = TimSoLan(HatGiong);
                    ThemVaoBang(HatGiong, SoLan);
                    Application.DoEvents();
                }
            }
            stsTienDo.Value = 100;
            stsStrip.Items[0].Text = "Đã tính xong";
            btnTaoNgauNhien.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
