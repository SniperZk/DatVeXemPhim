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

namespace DatVeXemPhim
{
    public partial class QuanLiDanhMucLoaiGhe : Form
    {
        private readonly static string connString = "Initial Catalog=CINEMA_PROJECT;Data Source=LAPTOP-P1DI0588\\SQLEXPRESS;TrustServerCertificate=True;Trusted_Connection=True";
        private DataTable table = new DataTable();
        private SqLiem sqliem;

        public QuanLiDanhMucLoaiGhe()
        {
            InitializeComponent();

            sqliem = new SqLiem(@"SELECT
ID_LOAIGHE AS [Mã loại ghế],
TENLOAIGHE AS [Tên loại ghế]
FROM LOAIGHE", connString);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!LinkTing.checkEmptyTextBox(txtTen, "Vui lòng nhập tên loại ghế."))
            {
                return;
            }

            table.Rows.Add(null, txtTen.Text);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!LinkTing.checkEmptyTextBox(txtTen, "Vui lòng nhập loại ghế."))
            {
                return;
            }
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }

            DataRow row = ((DataRowView)dataView.SelectedRows[0].DataBoundItem).Row;
            row[1] = txtTen.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LinkTing.deleteDataGridViewSelectedRows(dataView);
        }

        private void btnRong_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
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
            txtTen.Text = (string)row.Cells[1].Value;
        }

        private void QuanLiDanhMucLoaiGhe_Load(object sender, EventArgs e)
        {
            LinkTing.bindGroupBoxToTable(gbLoaiGhe, table, "Danh mục loại ghế ({0})");
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

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }
    }
}
