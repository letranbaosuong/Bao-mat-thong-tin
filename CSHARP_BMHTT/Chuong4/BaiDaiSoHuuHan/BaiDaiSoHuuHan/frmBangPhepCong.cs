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
    public partial class frmBangPhepCong : Form
    {
        #region Biến
        private char code = 'Z';
        private int n = 2;
        private const int Row_Start = 10;
        private const int Col_Start = 50;
        private const int Cell_Width = 30;
        private const int Cell_VGap = 5;
        private const int Row_Height = 20;
        private const int Cell_HGap = 2;
        private TextBox txtPhepToan;
        private TextBox[] txtCot;
        private TextBox[] txtDong;
        private TextBox[,] txtCell;
        #endregion
        #region Hàm tạo
        public frmBangPhepCong()
        {
            InitializeComponent();
            TaoBangPhepToan(n);
        }
        public frmBangPhepCong(char c, int n0)
        {
            code = c;
            n = n0;
            InitializeComponent();
            if (n > 20)
                TaoLuoi(n);
            else
                TaoBangPhepToan(n);
        }
        #endregion
        #region Các phương thức
        private void TaoBangPhepToan(int n)
        {
            this.Text = "Bảng phép cộng " + MainForm.Ten(code) + n.ToString();
            TextBox Cell;
            this.SuspendLayout();
            // Phép toán
            Cell = new System.Windows.Forms.TextBox();
            Cell.Location = new System.Drawing.Point(Col_Start, Row_Start);
            Cell.Name = "Cell";
            Cell.Size = new System.Drawing.Size(Cell_Width, 20);
            Cell.ReadOnly = true;
            Cell.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(Cell);
            txtPhepToan = Cell;
            // Các ô hàng đầu tiên
            txtCot = new TextBox[n];
            for (int j = 0; j < n; j++)
            {
                Cell = new System.Windows.Forms.TextBox();
                Cell.Location = new System.Drawing.Point(Col_Start + (Cell_Width + Cell_VGap) * (j + 1), Row_Start);
                Cell.Name = "Cell";
                Cell.Size = new System.Drawing.Size(Cell_Width, 20);
                Cell.ReadOnly = true;
                Cell.TextAlign = HorizontalAlignment.Center;
                this.Controls.Add(Cell);
                txtCot[j] = Cell;
            }
            // Các hàng chi tiết
            txtDong = new TextBox[n];
            txtCell = new TextBox[n, n];
            for (int i = 0; i < n; i++)
            {
                // Ô trên cột đầu tiên
                Cell = new System.Windows.Forms.TextBox();
                Cell.Location = new System.Drawing.Point(Col_Start, Row_Start + (Row_Height + Cell_HGap) * (i + 1));
                Cell.Name = "Cell";
                Cell.Size = new System.Drawing.Size(Cell_Width, 20);
                Cell.ReadOnly = true;
                Cell.TextAlign = HorizontalAlignment.Center;
                this.Controls.Add(Cell);
                txtDong[i] = Cell;
                // Các ô chi tiết
                for (int j = 0; j < n; j++)
                {
                    Cell = new System.Windows.Forms.TextBox();
                    Cell.Location = new System.Drawing.Point(Col_Start + (Cell_Width + Cell_VGap) * (j + 1),
                    Row_Start + (Row_Height + Cell_HGap) * (i + 1));
                    Cell.Name = "Cell";
                    Cell.Size = new System.Drawing.Size(Cell_Width, 20);
                    Cell.ReadOnly = true;
                    Cell.TextAlign = HorizontalAlignment.Center;
                    this.Controls.Add(Cell);
                    txtCell[i, j] = Cell;
                }
            }
            this.AutoScroll = true;

            this.ResumeLayout();
            TinhToan();
        }
        private void TinhToan()
        {
            txtPhepToan.Text = "+";
            // Điền hàng đầu tiên
            for (int j = 0; j < n; j++)
                txtCot[j].Text = j.ToString();
            // Điền các hàng chi tiết
            for (int i = 0; i < n; i++)
            {
                // Điền cột đầu tiên của dòng chi tiết
                txtDong[i].Text = i.ToString();
                // Điền các ô chi tiết
                for (int j = 0; j < n; j++)
                    txtCell[i, j].Text = ((i + j) % n).ToString();
            }
        }
        private void TaoLuoi(int n) {
            this.Text = "Bảng phép cộng " + MainForm.Ten(code) + n.ToString();
            DataGridView dgv = new DataGridView();
            dgv.Location = new System.Drawing.Point(Col_Start, Row_Start);
            dgv.Name = "dgv";
            //dgv.Size = new System.Drawing.Size(Cell_Width, 20);
            dgv.Dock = DockStyle.Fill;
            this.Controls.Add(dgv);
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            DataGridViewTextBoxColumn dgvCol;
            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.Name = "operator";
            dgvCol.HeaderText = "+";
            dgvCol.Width = 50;
            dgv.Columns.Add(dgvCol);
            for (int j = 0; j < n; j++)
            {
                dgvCol = new DataGridViewTextBoxColumn();
                dgvCol.Name = "Col" + j.ToString("0000");
                dgvCol.HeaderText = j.ToString();
                dgvCol.Width = 50;
                dgvCol.FillWeight = 0.01f;
                dgv.Columns.Add(dgvCol);
            }
            for (int i = 0; i < n; i++)
            {
                DataGridViewRow dgvRow = new DataGridViewRow();
                DataGridViewTextBoxCell dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = i.ToString();
                dgvRow.Cells.Add(dgvCell);
                for (int j = 0; j < n; j++)
                {
                    dgvCell = new DataGridViewTextBoxCell();
                    dgvCell.Value = ((i + j) % n).ToString();
                    dgvRow.Cells.Add(dgvCell);
                }
                dgv.Rows.Add(dgvRow);
            }
        }
        #endregion
    }
}
