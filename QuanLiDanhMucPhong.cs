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
    public partial class QuanLiDanhMucPhong : Form
    {
        private DataTable table = new DataTable();
        private SqLiem sqliem;

        public QuanLiDanhMucPhong()
        {
            InitializeComponent();

            sqliem = new SqLiem(@"SELECT
ID_PHONGCHIEU AS [Mã phòng],
TENPHONG AS [Tên phòng]
FROM PHONGCHIEU", Constants.CONNECTION_STRING);
        }

        private void btnRong_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
        }

        private bool checkNotDuplicated()
        {
            var result = from row in table.AsEnumerable()
                         where row.RowState != DataRowState.Deleted
                         && row.Field<string>("Tên phòng") == txtTen.Text
                         select row;
            if (result.Any())
            {
                MessageBox.Show("Đã có phòng với tên này rồi.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return false;
            } else
            {
                return true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Chung.checkEmptyTextBox(txtTen, "Vui lòng nhập tên phòng."))
            {
                return;
            }
            if (!checkNotDuplicated())
            {
                return;
            }

            table.Rows.Add(null, txtTen.Text);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!Chung.checkEmptyTextBox(txtTen, "Vui lòng nhập tên phòng."))
            {
                return;
            }
            if (!checkNotDuplicated())
            {
                return;
            }
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }

            Chung.changeSelectedViewRow(dataView, NoParam.Value, txtTen.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (new WaitGuard(Cursors.WaitCursor, btnXoa))
            {
                foreach (DataGridViewRow selectedRow in dataView.SelectedRows)
                {
                    var value = selectedRow.Cells[0].Value;
                    if (value != DBNull.Value)
                    {
                        int count;
                        if ((count = sqliem.countUsageInTable((string)value, "SUATCHIEU", "ID_PHONGCHIEU")) > 0)
                        {
                            MessageBox.Show($"Không thể xoá phim này vì có {count} suất chiếu ở phòng này.", "Lỗi xoá dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }
                    ((DataRowView)selectedRow.DataBoundItem).Row.Delete();
                }
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

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                using (new WaitGuard(Cursors.WaitCursor, btnTaiLai))
                {
                    sqliem.load(table);
                }
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
                using (new WaitGuard(Cursors.WaitCursor, btnLuu))
                {
                    sqliem.update(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLiDanhMucPhong_Load(object sender, EventArgs e)
        {
            using (new WaitGuard(Cursors.AppStarting))
            {
                Chung.bindGroupBoxToTable(gbPhong, table, "Danh mục phòng ({0})");
                Chung.setDoubleBuffered(dataView);

                try
                {
                    sqliem.load(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                dataView.DataSource = table;
            }
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }
    }
}
