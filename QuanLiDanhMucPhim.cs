using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Reflection;

using DatVeXemPhim.Utils;

namespace DatVeXemPhim
{
    public partial class QuanLiDanhMucPhim : Form
    {
        private readonly static string connString = "Initial Catalog=CINEMA_PROJECT;Data Source=LAPTOP-P1DI0588\\SQLEXPRESS;TrustServerCertificate=True;Trusted_Connection=True";
        private DataTable table = new DataTable();
        private SqLiem sqliem;
        private Faker faker = new Faker();

        public QuanLiDanhMucPhim()
        {
            InitializeComponent();

            sqliem = new SqLiem(@"SELECT
    ID_PHIM AS [Mã phim],
    TENPHIM AS [Tên phim],
    THELOAI AS [Thể loại],
    THOILUONG AS [Thời lượng],
    NGAYKHOICHIEU AS [Ngày khởi chiếu],
    NGAYCHIEUCUOI AS [Ngày chiếu cuối],
    DOTUOI AS [Độ tuổi]
FROM PHIM", connString);
        }

        private void QuanLiDanhMucPhim_Load(object sender, EventArgs e)
        {
            cbTheLoai.Items.AddRange(new string[] { "Hành động", "Tâm lý", "Kinh dị", "Lãng mạn", "Kỳ ảo" });
            cbTheLoai.SelectedIndex = 0;
            cbDoTuoi.Items.AddRange(new string[] { "P", "K", "T13", "T16", "T18" });
            cbDoTuoi.SelectedIndex = 0;

            LinkTing.bindGroupBoxToTable(gbPhim, table, "Danh mục phim ({0})");
            LinkTing.setDoubleBuffered(dataView);
            
            try
            {
                sqliem.load(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            dataView.DataSource = table;
        }

        private void btnRong_Click(object sender, EventArgs e)
        {
            txtTieuDe.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!LinkTing.checkEmptyTextBox(txtTieuDe, "Vui lòng nhập tiêu đề phim."))
            {
                return;
            }
            if (!LinkTing.checkDateTimePickerPair(dtKhoiChieu, dtChieuCuoi, "Ngày khởi chiếu phải sớm hơn ngày chiếu cuối."))
            {
                return;
            }

            table.Rows.Add(null, txtTieuDe.Text, cbTheLoai.Text, LinkTing.toTime(dtThoiLuong.Value), dtKhoiChieu.Value.Date, dtChieuCuoi.Value.Date, cbDoTuoi.Text);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                sqliem.update(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                sqliem.load(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || (dataView.AllowUserToAddRows && (e.RowIndex + 1 == dataView.RowCount)))
            {
                return;
            }
            DataGridViewRow row = dataView.Rows[e.RowIndex];
            int colIndex = 1;
            txtTieuDe.Text = (string)row.Cells[colIndex++].Value;
            cbTheLoai.Text = (string)row.Cells[colIndex++].Value;
            dtThoiLuong.Value = LinkTing.toDate((TimeSpan)row.Cells[colIndex++].Value);
            dtKhoiChieu.Value = (DateTime)row.Cells[colIndex++].Value;
            dtChieuCuoi.Value = (DateTime)row.Cells[colIndex++].Value;
            cbDoTuoi.Text = (string)row.Cells[colIndex++].Value;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!LinkTing.checkEmptyTextBox(txtTieuDe, "Vui lòng nhập tiêu đề phim."))
            {
                return;
            }
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }

            DataRow row = ((DataRowView)dataView.SelectedRows[0].DataBoundItem).Row;
            int colIndex = 1;
            row[colIndex++] = txtTieuDe.Text;
            row[colIndex++] = cbTheLoai.Text;
            row[colIndex++] = LinkTing.toTime(dtThoiLuong.Value);
            row[colIndex++] = dtKhoiChieu.Value;
            row[colIndex++] = dtChieuCuoi.Value;
            row[colIndex++] = cbDoTuoi.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in dataView.SelectedRows)
            {
                var value = selectedRow.Cells[0].Value;
                if (value != DBNull.Value)
                {
                    if (!sqliem.notUsedInTable((string)value, "SUATCHIEU", "ID_PHIM", "Không thể xoá phim này vì đang có {0} suất chiếu phim này."))
                    {
                        continue;
                    }
                }
                ((DataRowView)selectedRow.DataBoundItem).Row.Delete();
            }
        }

        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            cbTheLoai.Text = faker.randomCategory();
            txtTieuDe.Text = faker.randomTitle(cbTheLoai.Text);
            dtThoiLuong.Value = DateTime.Today.Add(faker.randomDuration());
            dtKhoiChieu.Value = faker.randomDate();
            dtChieuCuoi.Value = dtKhoiChieu.Value.AddDays(faker.randInt(31));
            cbDoTuoi.Text = faker.randomRating();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            table.DefaultView.RowFilter = $"[Tên phim] LIKE '%{txtTim.Text}%'";
        }

        private void btnThemNgauNhien_Click(object sender, EventArgs e)
        {
            ThemPhimNgauNhienDialog dialog = new ThemPhimNgauNhienDialog();
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                int rows = dialog.numberOfRows();
                string category = dialog.category();
                bool isRandomCat = string.IsNullOrEmpty(category);
                for (int i = 0; i < rows; i++)
                {
                    if (isRandomCat)
                    {
                        category = faker.randomCategory();
                    }
                    DateTime khoiChieu = faker.randomDate();
                    table.Rows.Add(null, faker.randomTitle(category), category, faker.randomDuration(), khoiChieu.Date, khoiChieu.AddDays(faker.randInt(31)).Date, faker.randomRating());
                }
            }
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }
    }
}
