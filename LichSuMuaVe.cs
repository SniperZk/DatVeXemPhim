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
    public partial class LichSuMuaVe : Form
    {
        private SqLiem sqliem;
        private DataTable table = new DataTable();
        private string userId = "";

        public LichSuMuaVe(string userId)
        {
            this.userId = userId;
            InitializeComponent();

            sqliem = new SqLiem($@"SELECT
HD.ID_HOADON AS [Mã hoá đơn],
HD.NGAYDAT AS [Ngày thanh toán],
PH.TENPHIM AS [Phim],
PC.TENPHONG AS [Phòng],
SC.NGAYCHIEU AS [Ngày chiếu],
SC.GIOBATDAU AS [Suất chiếu],
LG.TENLOAIGHE AS [Loại ghế],
GH.VITRI AS [Ghế],
VE.GIAVE AS [Giá vé]
FROM VE
INNER JOIN CHITIETHOADON CT
ON VE.ID_VE = CT.ID_VE
INNER JOIN HOADON HD
ON CT.ID_HOADON = HD.ID_HOADON
INNER JOIN GHE GH
ON GH.ID_GHE = VE.ID_GHE
INNER JOIN PHONGCHIEU PC
ON PC.ID_PHONGCHIEU = GH.ID_PHONGCHIEU
INNER JOIN LOAIGHE LG
ON LG.ID_LOAIGHE = GH.ID_LOAIGHE
INNER JOIN SUATCHIEU SC
ON VE.ID_SUATCHIEU = SC.ID_SUATCHIEU
INNER JOIN PHIM PH
ON PH.ID_PHIM = SC.ID_PHIM
INNER JOIN TAIKHOAN TK
ON HD.ID_TAIKHOAN = TK.ID_TAIKHOAN
WHERE TK.TENDANGNHAP = '{userId}'
", Constants.CONNECTION_STRING);
        }

        private void LichSuMuaVe_Load(object sender, EventArgs e)
        {
            Chung.setDoubleBuffered(dataView);
            Chung.bindGroupBoxToTable(gbLichSu, table, "Vé đã mua ({0})");

            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            table.DefaultView.RowFilter = $"[Phim] LIKE '%{txtTim.Text}%' OR [Phòng] LIKE '%{txtTim.Text}%' OR [Loại ghế] LIKE '%{txtTim.Text}%'";
        }
    }
}
