using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DatVeXemPhim.Utils;

namespace DatVeXemPhim
{
    public partial class QuanLiDanhMucVe : Form
    {
        private DataTable table = new DataTable();
        private DataTable roomTable = new DataTable();
        private DataTable sessionTable = new DataTable();
        private DataTable seatTable = new DataTable();

        private SqLiem sqliem;

        public QuanLiDanhMucVe()
        {
            InitializeComponent();

            sqliem = new SqLiem(@"SELECT
ID_VE AS [Mã vé],
ID_SUATCHIEU AS [Mã suất chiếu],
ID_GHE AS [Mã ghế],
GIAVE AS [Số tiền],
TRANGTHAI AS [Trạng thái]
FROM VE
", Constants.CONNECTION_STRING);
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.A | Keys.Control | Keys.Alt:
                    {
                        using (new WaitGuard(Cursors.WaitCursor))
                        {
                            table.BeginLoadData();
                            foreach (DataRow row in table.Rows)
                            {
                                row.Delete();
                            }
                            table.EndLoadData();
                            foreach (DataRow session in sessionTable.Rows)
                            {
                                var seat = seatTable.AsEnumerable().First(r =>
                                r.Field<string>("ID_PHONGCHIEU") == session.Field<string>("ID_PHONGCHIEU"));
                                table.Rows.Add(null, (string)session["ID_SUATCHIEU"], (string)seat["ID_GHE"],
                                               80000, "Hoàn tất");
                            }
                            dataView.Invalidate();
                        }
                        return true;
                    }
            }

            return base.ProcessCmdKey(ref message, keys);
        }

        private bool checkValidInput(bool addMode)
        {
            if (!Chung.checkEmptyComboBox(cbSuatChieu, "Vui lòng chọn suất chiếu."))
            {
                return false;
            }
            if (!Chung.checkEmptyComboBox(cbGhe, "Vui lòng chọn ghế."))
            {
                return false;
            }
            var result = from row in table.AsEnumerable()
                         where row.RowState != DataRowState.Deleted
                         && row.Field<string>("Mã suất chiếu") == cbSuatChieu.SelectedValue as string
                         && row.Field<string>("Mã ghế") == cbGhe.SelectedValue as string
                         select row;
            var dataRow = result.FirstOrDefault();
            if (dataRow != null && (addMode || dataRow != ((DataRowView)dataView.SelectedRows[0].DataBoundItem).Row))
            {
                MessageBox.Show("Ghế này ở suất chiếu này đã có vé đặt rồi.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkValidInput(true))
            {
                return;
            }

            table.Rows.Add(null, cbSuatChieu.SelectedValue, cbGhe.SelectedValue,
                numGia.Value, cbTrangThai.Text);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }
            if (!checkValidInput(false))
            {
                return;
            }

            Chung.changeSelectedViewRow(dataView, NoParam.Value, cbSuatChieu.SelectedValue,
                cbGhe.SelectedValue, numGia.Value, cbTrangThai.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (new WaitGuard(Cursors.WaitCursor, btnXoa))
            {
                Chung.deleteDataGridViewSelectedRows(dataView);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                using (new WaitGuard(Cursors.WaitCursor, btnTaiLai))
                {
                    sqliem.load(table);
                    loadOtherTables();
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
                    loadOtherTables();
                    MessageBox.Show($"Cập nhật thành công, đã thao tác lên {affected} dòng dữ liệu.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            cbSuatChieu.SelectedValue = (string)row.Cells[colIndex++].Value;
            cbGhe.SelectedValue = (string)row.Cells[colIndex++].Value;
            numGia.Value = (int)row.Cells[colIndex++].Value;
            cbTrangThai.Text = (string)row.Cells[colIndex++].Value;
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }

        private void loadOtherTables()
        {
            roomTable = sqliem.selectToTable("SELECT ID_PHONGCHIEU, TENPHONG FROM PHONGCHIEU");

            seatTable = sqliem.selectToTable(@"SELECT
GH.ID_GHE AS ID_GHE, LG.TENLOAIGHE AS TENLOAIGHE,
GH.ID_PHONGCHIEU AS ID_PHONGCHIEU, GH.VITRI AS VITRI
FROM GHE GH
INNER JOIN LOAIGHE LG
ON GH.ID_LOAIGHE = LG.ID_LOAIGHE");
            cbGhe.DisplayMember = "VITRI";
            cbGhe.ValueMember = "ID_GHE";

            sessionTable = sqliem.selectToTable("SELECT ID_SUATCHIEU, ID_PHONGCHIEU, NGAYCHIEU, GIOBATDAU FROM SUATCHIEU");
            cbSuatChieu.DisplayMember = "ID_SUATCHIEU";
            cbSuatChieu.ValueMember = "ID_SUATCHIEU";
            cbSuatChieu.DataSource = sessionTable;
        }

        private void QuanLiDanhMucVe_Load(object sender, EventArgs e)
        {
            using (new WaitGuard(Cursors.AppStarting))
            {
                Chung.setDoubleBuffered(dataView);
                Chung.bindGroupBoxToTable(gbGhe, table, "Danh sách vé ({0})");

                cbTrangThai.Items.AddRange(Constants.TICKET_STATES);
                cbTrangThai.SelectedIndex = 0;

                try
                {
                    sqliem.load(table);
                    loadOtherTables();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }

                dataView.DataSource = table;
            }
        }

        private void reloadSeatComboBox()
        {
            string roomId = (string)sessionTable.Rows.Find(cbSuatChieu.SelectedValue as string)!["ID_PHONGCHIEU"];
            var result = from row in seatTable.AsEnumerable()
                         where row.Field<string>("ID_PHONGCHIEU") == roomId
                         select row;
            if (result.Any())
            {
                cbGhe.DataSource = result.CopyToDataTable();
            }
            else
            {
                cbGhe.DataSource = null;
            }
        }

        private void cbSuatChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadSeatComboBox();
        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5:
                    {
                        string idStr = dataView.Rows[e.RowIndex].Cells["Mã suất chiếu"].Value as string ?? "";
                        DataRow? dataRow = sessionTable.Rows.Find(idStr);
                        if (dataRow != null)
                        {
                            dataRow = roomTable.Rows.Find(dataRow["ID_PHONGCHIEU"]);
                            if (dataRow != null)
                            {
                                e.Value = dataRow["TENPHONG"];
                                e.FormattingApplied = true;
                            }
                        }
                        break;
                    }
            }
        }

        private void btnDuyetSuat_Click(object sender, EventArgs e)
        {
            var dialog = new ChonSuatChieuDialog(roomTable, sessionTable, cbSuatChieu.SelectedValue as string ?? "");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                cbSuatChieu.SelectedValue = dialog.session();
            }
        }

        private void dataView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (dataView.Columns.Count == 5)
            {
                DataGridViewColumn column = Chung.addFakeColumnToView(dataView, "TENPHONG", "Tên phòng", "Mã suất chiếu");
                column = Chung.addFakeColumnToView(dataView, "NGAYCHIEU", "Ngày chiếu", column.Name);
                column = Chung.addFakeColumnToView(dataView, "GIOBATDAU", "Giờ chiếu", column.Name);
                column = Chung.addFakeColumnToView(dataView, "TENLOAIGHE", "Tên loại ghế", "Mã ghế");
                column = Chung.addFakeColumnToView(dataView, "VITRI", "Vị trí ghế", column.Name);

                var cellTemplate = new DataGridViewAutoUpdateOthersCell() { IdColumnName = "Mã suất chiếu", Table = sessionTable };
                cellTemplate.AddBinding("NGAYCHIEU");
                cellTemplate.AddBinding("GIOBATDAU");
                dataView.Columns["Mã suất chiếu"].CellTemplate = cellTemplate;

                cellTemplate = new DataGridViewAutoUpdateOthersCell() { IdColumnName = "Mã ghế", Table = seatTable };
                cellTemplate.AddBinding("TENLOAIGHE");
                cellTemplate.AddBinding("VITRI");
                dataView.Columns["Mã ghế"].CellTemplate = cellTemplate;

            }
        }
    }
}
