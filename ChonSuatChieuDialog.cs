using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatVeXemPhim
{
    public partial class ChonSuatChieuDialog : Form
    {
        private DataTable roomTable = new DataTable();
        private DataTable sessionTable = new DataTable();
        private string sessionId;

        public ChonSuatChieuDialog(DataTable rooms, DataTable sessions, string id)
        {
            InitializeComponent();
            roomTable = rooms;
            sessionTable = sessions;
            sessionId = id;
        }

        private void reloadDatePicker()
        {
            var result = from row in sessionTable.AsEnumerable()
                         where row.Field<string>("ID_PHONGCHIEU") == cbPhong.SelectedValue as string
                         orderby row.Field<DateTime>("NGAYCHIEU") ascending
                         select row;

            dtNgayChieu.MinDate = result.FirstOrDefault() is DataRow dataRow ? (DateTime)dataRow["NGAYCHIEU"] : DateTime.MinValue;
            dtNgayChieu.MaxDate = result.LastOrDefault() is DataRow dataRow2 ? (DateTime)dataRow2["NGAYCHIEU"] : DateTime.MaxValue;
        }

        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadDatePicker();
            reloadSessionComboBox();
        }

        private void reloadSessionComboBox()
        {
            var result = from row in sessionTable.AsEnumerable()
                         where row.Field<string>("ID_PHONGCHIEU") == cbPhong.SelectedValue as string
                         && row.Field<DateTime>("NGAYCHIEU").Date == dtNgayChieu.Value.Date
                         select row;
            if (result.Any())
            {
                cbSuatChieu.DisplayMember = "GIOBATDAU";
                cbSuatChieu.ValueMember = "ID_SUATCHIEU";
                cbSuatChieu.DataSource = result.CopyToDataTable();
            }
            else
            {
                cbSuatChieu.DataSource = null;
                btnChon.Enabled = false;
            }
        }

        private void dtNgayChieu_ValueChanged(object sender, EventArgs e)
        {
            reloadSessionComboBox();
        }

        private void cbSuatChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSuatChieu.SelectedValue != DBNull.Value)
            {
                btnChon.Enabled = true;
            }
        }

        private void ChonSuatChieuDialog_Load(object sender, EventArgs e)
        {
            cbPhong.DisplayMember = "TENPHONG";
            cbPhong.ValueMember = "ID_PHONGCHIEU";
            cbPhong.DataSource = roomTable;

            DataRow? row = sessionTable.Rows.Find(sessionId);
            if (row != null)
            {
                cbPhong.SelectedValue = (string)row["ID_PHONGCHIEU"];
                dtNgayChieu.Value = (DateTime)row["NGAYCHIEU"];
                cbSuatChieu.SelectedValue = sessionId;
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string session()
        {
            return cbSuatChieu.SelectedValue as string ?? "";
        }
    }
}
