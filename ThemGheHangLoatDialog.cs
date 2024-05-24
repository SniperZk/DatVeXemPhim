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
    public partial class ThemGheHangLoatDialog : Form
    {
        private DataTable roomTable;
        private DataTable seatTypeTable;

        public ThemGheHangLoatDialog(DataTable roomTable, DataTable seatTypeTable)
        {
            InitializeComponent();
            this.roomTable = roomTable;
            this.seatTypeTable = seatTypeTable;
        }

        private void ThemGheHangLoatDialog_Load(object sender, EventArgs e)
        {
            DataRow row = roomTable.NewRow();
            row.ItemArray = ["", "(tất cả)"];
            roomTable.Rows.InsertAt(row, 0);
            cbPhong.DisplayMember = "TENPHONG";
            cbPhong.ValueMember = "ID_PHONGCHIEU";
            cbPhong.DataSource = roomTable;

            row = seatTypeTable.NewRow();
            row.ItemArray = ["", "(tự động)"];
            seatTypeTable.Rows.InsertAt(row, 0);
            cbLoaiGhe.DisplayMember = "TENLOAIGHE";
            cbLoaiGhe.ValueMember = "ID_LOAIGHE";
            cbLoaiGhe.DataSource = seatTypeTable;
        }

        public string room()
        {
            return cbPhong.SelectedValue as string ?? "";
        }
        public string seatType()
        {
            return cbLoaiGhe.SelectedValue as string ?? "";
        }
        public bool deleteBeforeInserting()
        {
            return checkXoa.Checked;
        }
    }
}
