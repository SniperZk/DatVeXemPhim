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
    public partial class QuanLiDanhMucVaiTro : Form
    {
        private DataTable table = new DataTable();
        private SqLiem sqliem;

        public QuanLiDanhMucVaiTro()
        {
            InitializeComponent();

            sqliem = new SqLiem(@"SELECT
ID_VAITRO AS [Mã vai trò],
TENVAITRO AS [Tên vai trò]
FROM VAITRO", Constants.CONNECTION_STRING);
        }

        private bool checkNotDuplicated()
        {
            var result = from row in table.AsEnumerable()
                         where row.RowState != DataRowState.Deleted
                         && row.Field<string>("Tên vai trò") == txtTen.Text
                         select row;
            if (result.Any())
            {
                MessageBox.Show("Đã có vai trò với tên này rồi.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnRong_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Chung.checkEmptyTextBox(txtTen, "Vui lòng nhập tên vai trò."))
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
            if (!Chung.checkEmptyTextBox(txtTen, "Vui lòng nhập tên vai trò."))
            {
                return;
            }
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }
            if (!checkNotDuplicated())
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
                        if ((count = sqliem.countUsageInTable((string)value, "TAIKHOAN", "ID_VAITRO")) > 0)
                        {
                            MessageBox.Show($"Không thể xoá vai trò này vì có {count} tài khoản thuộc loại này.", "Lỗi xoá dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }
                    ((DataRowView)selectedRow.DataBoundItem).Row.Delete();
                }
            }
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
                    int affected = sqliem.update(table);
                    MessageBox.Show($"Cập nhật thành công, đã thao tác lên {affected} dòng dữ liệu.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLiDanhMucVaiTro_Load(object sender, EventArgs e)
        {
            using (new WaitGuard(Cursors.AppStarting))
            {
                Chung.bindGroupBoxToTable(gbVaiTro, table, "Danh mục vai trò ({0})");
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

        private void dataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || (dataView.AllowUserToAddRows && (e.RowIndex + 1 == dataView.RowCount)))
            {
                return;
            }
            DataGridViewRow row = dataView.Rows[e.RowIndex];
            txtTen.Text = (string)row.Cells[1].Value;
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }
    }
}
