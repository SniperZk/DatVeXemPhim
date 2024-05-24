﻿using System;
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
    public partial class QuanLiDanhMucGhe : Form
    {
        private readonly static string connString = "Initial Catalog=CINEMA_PROJECT;Data Source=LAPTOP-P1DI0588\\SQLEXPRESS;TrustServerCertificate=True;Trusted_Connection=True";

        private DataTable table = new DataTable();
        private DataTable roomTable = new DataTable();
        private DataTable seatTypeTable = new DataTable();
        private SqLiem sqliem;

        public QuanLiDanhMucGhe()
        {
            InitializeComponent();

            sqliem = new SqLiem(@"SELECT
ID_GHE AS [Mã ghế],
ID_LOAIGHE AS [Mã loại ghế],
ID_PHONGCHIEU AS [Mã phòng],
VITRI AS [Vị trí],
TRANGTHAI AS [Trạng thái]
FROM GHE", connString);
        }

        private bool checkDuplicateInfo()
        {
            var result = from row in table.AsEnumerable()
                         where row.Field<string>("Mã phòng") == cbPhong.SelectedValue as string
                         && row.Field<string>("Mã loại ghế") == cbLoaiGhe.SelectedValue as string
                         && row.Field<string>("Vị trí") == txtViTri.Text
                         select row;
            if (result.Any())
            {
                MessageBox.Show("Đã có ghế trùng với loại ghế, phòng chiếu và vị trí này.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!LinkTing.checkEmptyTextBox(txtViTri, "Vui lòng nhập vị trí ghế."))
            {
                return;
            }
            if (!checkDuplicateInfo())
            {
                return;
            }

            table.Rows.Add(null, cbLoaiGhe.SelectedValue, cbPhong.SelectedValue, txtViTri.Text, checkTrangThai.Checked);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }
            if (!LinkTing.checkEmptyTextBox(txtViTri, "Vui lòng nhập vị trí ghế."))
            {
                return;
            }
            if (!checkDuplicateInfo())
            {
                return;
            }

            DataRow row = ((DataRowView)dataView.SelectedRows[0].DataBoundItem).Row;
            int colIndex = 1;
            row[colIndex++] = cbLoaiGhe.SelectedValue;
            row[colIndex++] = cbPhong.SelectedValue;
            row[colIndex++] = txtViTri.Text;
            row[colIndex++] = checkTrangThai.Checked;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            table.BeginLoadData();
            foreach (DataGridViewRow row in dataView.SelectedRows)
            {
                ((DataRowView)row.DataBoundItem).Row.Delete();
            }
            table.EndLoadData();
        }

        private void dataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || (dataView.AllowUserToAddRows && (e.RowIndex + 1 == dataView.RowCount)))
            {
                return;
            }
            DataRow row = table.Rows[e.RowIndex];
            int colIndex = 1;
            cbLoaiGhe.SelectedValue = row[colIndex++];
            cbPhong.SelectedValue = row[colIndex++];
            txtViTri.Text = (string)row[colIndex++];
            checkTrangThai.Checked = ((string)row[colIndex++]) == "True";
        }

        private void loadOtherTables()
        {
            roomTable = sqliem.selectToTable("SELECT ID_PHONGCHIEU, TENPHONG FROM PHONGCHIEU");
            cbPhong.DisplayMember = "TENPHONG";
            cbPhong.ValueMember = "ID_PHONGCHIEU";
            cbPhong.DataSource = roomTable;

            seatTypeTable = sqliem.selectToTable("SELECT ID_LOAIGHE, TENLOAIGHE FROM LOAIGHE");
            cbLoaiGhe.DisplayMember = "TENLOAIGHE";
            cbLoaiGhe.ValueMember = "ID_LOAIGHE";
            cbLoaiGhe.DataSource = seatTypeTable;
        }

        private void QuanLiDanhMucGhe_Load(object sender, EventArgs e)
        {
            LinkTing.setDoubleBuffered(dataView);
            LinkTing.bindGroupBoxToTable(gbGhe, table, "Danh mục ghế ({0})");

            try
            {
                sqliem.load(table);
                loadOtherTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            dataView.DataSource = table;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                btnLuu.Enabled = false;
                Cursor = Cursors.WaitCursor;
                int affected = sqliem.update(table);
                loadOtherTables();
                MessageBox.Show($"Cập nhật thành công, đã thao tác lên {affected} dòng dữ liệu.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnLuu.Enabled = true;
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                sqliem.load(table);
                loadOtherTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataView.ColumnCount > 5)
            {
                if (e.ColumnIndex == 4)
                {
                    e.Value = (e.Value?.ToString() == "True") ? "Đã được đặt" : "Còn trống";
                }
            }
        }

        private void btnRong_Click(object sender, EventArgs e)
        {
            txtViTri.Clear();
        }

        private void btnHangLoat_Click(object sender, EventArgs e)
        {
            var dialog = new ThemGheHangLoatDialog(roomTable.Copy(), seatTypeTable.Copy());
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                table.BeginLoadData();
                if (dialog.deleteBeforeInserting())
                {
                    foreach (DataRow row in table.Rows)
                    {
                        row.Delete();
                    }
                }
                DataTable tempTable = table.Clone();
                if (!string.IsNullOrEmpty(dialog.room()))
                {
                    fillSeatsInRoom(tempTable, dialog.room(), dialog.seatType());
                }
                else
                {
                    foreach (DataRow room in roomTable.Rows)
                    {
                        fillSeatsInRoom(tempTable, (string)room["ID_PHONGCHIEU"], dialog.seatType());
                    }
                }
                table.Merge(tempTable, false);
                table.EndLoadData();
            }
        }

        private void fillSeatsInRoom(DataTable table, string roomId, string seatTypeId)
        {
            bool autoSeatType = string.IsNullOrEmpty(seatTypeId);
            string gheThuong = (string)seatTypeTable.Select("TENLOAIGHE = 'Thường'")[0]["ID_LOAIGHE"];
            string gheVip = (string)seatTypeTable.Select("TENLOAIGHE = 'VIP'")[0]["ID_LOAIGHE"];
            string gheCineMax = (string)seatTypeTable.Select("TENLOAIGHE = 'CineMAX'")[0]["ID_LOAIGHE"];

            for (char c = 'A'; c <= 'J'; ++c)
            {
                string seatType;
                if (autoSeatType)
                {
                    if (c >= 'D' && c <= 'G')
                    {
                        seatType = gheVip;
                    }
                    else
                    {
                        seatType = gheThuong;
                    }
                }
                else
                {
                    seatType = seatTypeId;
                }
                for (int i = 1; i <= 12; ++i)
                {
                    string pos = c + i.ToString();
                    if (autoSeatType && (c == 'E') && i >= 3 && i <= 10)
                    {
                        seatType = gheCineMax;
                    }
                    table.Rows.Add(null, seatType, roomId, pos, false);
                }
            }
        }

        private void dataView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if(dataView.Columns.Count == 5)
            {
                DataGridViewColumn column = LinkTing.addFakeColumnToView(dataView, "TENLOAIGHE", "Tên loại ghế", "Mã loại ghế");
                column = LinkTing.addFakeColumnToView(dataView, "TENPHONG", "Tên phòng", "Mã phòng");

                var cellTemplate = new DataGridViewAutoUpdateOthersCell() { IdColumnName = "Mã loại ghế", Table = seatTypeTable };
                cellTemplate.AddBinding("TENLOAIGHE");
                dataView.Columns["Mã loại ghế"].CellTemplate = cellTemplate;

                var cellTemplate2 = new DataGridViewAutoUpdateOthersCell() { IdColumnName = "Mã phòng", Table = roomTable };
                cellTemplate2.AddBinding("TENPHONG");
                dataView.Columns["Mã phòng"].CellTemplate = cellTemplate2;
            }
        }
    }
}