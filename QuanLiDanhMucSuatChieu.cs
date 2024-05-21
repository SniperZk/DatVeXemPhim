using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DatVeXemPhim.Utils;
using Microsoft.Data.SqlClient;

namespace DatVeXemPhim
{
    public partial class QuanLiDanhMucSuatChieu : Form
    {
        private readonly static string connString = "Initial Catalog=CINEMA_PROJECT;Data Source=LAPTOP-P1DI0588\\SQLEXPRESS;TrustServerCertificate=True;Trusted_Connection=True";
        private DataTable table = new DataTable();
        private DataTable movieTable = new DataTable();
        private DataTable roomTable = new DataTable();
        private SqLiem sqliem;

        public QuanLiDanhMucSuatChieu()
        {
            InitializeComponent();

            sqliem = new SqLiem(@"SELECT
ID_SUATCHIEU AS [Mã suất chiếu],
ID_PHONGCHIEU AS [Mã phòng],
ID_PHIM AS [Mã phim],
NGAYCHIEU AS [Ngày chiếu],
GIOBATDAU AS [Giờ bắt đầu],
GIOKETTHUC AS [Giờ kết thúc]
FROM SUATCHIEU
", connString);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!LinkTing.checkDateTimePickerPair(dtGioChieu, dtGioHet, "Giờ chiếu phải sớm hơn giờ kết thúc."))
            {
                return;
            }
            table.Rows.Add(null, cbPhong.SelectedValue, cbPhim.SelectedValue, dtNgayChieu.Value, LinkTing.toTime(dtGioChieu.Value), LinkTing.toTime(dtGioHet.Value));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!LinkTing.checkDateTimePickerPair(dtGioChieu, dtGioHet, "Giờ chiếu phải sớm hơn giờ kết thúc."))
            {
                return;
            }
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }

            DataRow row = ((DataRowView)dataView.SelectedRows[0].DataBoundItem).Row;
            int colIndex = 1;
            row[colIndex++] = cbPhong.SelectedValue;
            row[colIndex++] = cbPhim.SelectedValue;
            row[colIndex++] = dtNgayChieu.Value.Date;
            row[colIndex++] = LinkTing.toTime(dtGioChieu.Value);
            row[colIndex++] = LinkTing.toTime(dtGioHet.Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LinkTing.deleteDataGridViewSelectedRows(dataView);
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

        private void dataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || (dataView.AllowUserToAddRows && (e.RowIndex + 1 == dataView.RowCount)))
            {
                return;
            }
            DataGridViewRow row = dataView.Rows[e.RowIndex];
            int colIndex = 1;
            cbPhong.SelectedValue = (string)row.Cells[colIndex++].Value;
            cbPhim.SelectedValue = (string)row.Cells[colIndex++].Value;
            dtNgayChieu.Value = (DateTime)row.Cells[colIndex++].Value;
            dtGioChieu.Value = LinkTing.toDate((TimeSpan)row.Cells[colIndex++].Value);
            dtGioHet.Value = LinkTing.toDate((TimeSpan)row.Cells[colIndex++].Value);
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }

        private void QuanLiDanhMucSuatChieu_Load(object sender, EventArgs e)
        {
            try
            {
                sqliem.load(table);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ID_PHONGCHIEU, TENPHONG FROM PHONGCHIEU", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        roomTable = new DataTable();
                        roomTable.Load(reader);
                        cbPhong.DataSource = roomTable;
                        cbPhong.DisplayMember = "TENPHONG";
                        cbPhong.ValueMember = "ID_PHONGCHIEU";
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT ID_PHIM, TENPHIM, NGAYKHOICHIEU, NGAYCHIEUCUOI FROM PHIM", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        movieTable = new DataTable();
                        movieTable.Load(reader);
                        cbPhim.DisplayMember = "TENPHIM";
                        cbPhim.ValueMember = "ID_PHIM";
                        cbPhim.DataSource = movieTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            dataView.DataSource = table;
        }

        private void cbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhim.SelectedValue != null)
            {
                string movieId = (string)cbPhim.SelectedValue;
                var result = from DataRow row in movieTable.Rows where row.Field<string>("ID_PHIM") == movieId select row;
                var iterator = result.GetEnumerator();
                iterator.MoveNext();
                DataRow currRow = iterator.Current;
                DateTime startDate = (DateTime)currRow["NGAYKHOICHIEU"];
                DateTime endDate = (DateTime)currRow["NGAYCHIEUCUOI"];
                if (startDate > dtNgayChieu.MaxDate)
                {
                    dtNgayChieu.MaxDate = endDate;
                    dtNgayChieu.MinDate = startDate;
                }
                else
                {
                    dtNgayChieu.MinDate = startDate;
                    dtNgayChieu.MaxDate = endDate;

                }
            }
        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    {
                        e.Value = LinkTing.displayStringFromTableId(roomTable, e.Value, "ID_PHONGCHIEU", "TENPHONG");
                        e.FormattingApplied = true;
                        break;
                    }
                case 2:
                    {
                        e.Value = LinkTing.displayStringFromTableId(movieTable, e.Value, "ID_PHIM", "TENPHIM");
                        e.FormattingApplied = true;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
