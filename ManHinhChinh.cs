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

namespace DatVeXemPhim
{
    public partial class ManHinhChinh : Form
    {
        string userId = ""; // Chưa đăng nhập thì là xâu rỗng
        string sessionId = ""; // Mã suất chiếu
        string seatId = ""; // Mã ghế

        public ManHinhChinh()
        {
            InitializeComponent();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhMụcPhimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new QuanLiDanhMucPhim();
            dialog.ShowDialog();
        }

        private void danhMụcPhòngChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new QuanLiDanhMucPhong();
            dialog.ShowDialog();
        }

        private void danhMụcSuấtChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new QuanLiDanhMucSuatChieu();
            dialog.ShowDialog();
        }

        private void danhMụcLoạiGhếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new QuanLiDanhMucLoaiGhe();
            dialog.ShowDialog();
        }

        private void danhMụcGhếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new QuanLiDanhMucGhe();
            dialog.ShowDialog();
        }

        private void danhMụcVéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new QuanLiDanhMucVe();
            dialog.ShowDialog();
        }

        private void selectSession()
        {
            var dialog = new ChonPhimVaCongChieu(sessionId);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                sessionId = dialog.selectedShowtimeId;
            }

            updateSessionInfo();

            if (result == DialogResult.OK)
            {
                selectSeats();
            }
        }

        private void updateSessionInfo()
        {
            txtPhim.Clear();
            if (!string.IsNullOrEmpty(sessionId))
            {
                btnChonGhe.Enabled = true;
                chọnGhếThanhToánToolStripMenuItem.Enabled = true;

                using (SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(@"SELECT
PH.TENPHIM, PH.THELOAI, PH.THOILUONG, PH.DOTUOI, SC.NGAYCHIEU, SC.GIOBATDAU
FROM SUATCHIEU SC
INNER JOIN PHIM PH
ON SC.ID_PHIM = PH.ID_PHIM
WHERE ID_SUATCHIEU = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", sessionId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var sessionInfo = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
                                string text = $@"PHIM: {((string)sessionInfo["TENPHIM"]).ToUpper()} ({sessionInfo["DOTUOI"]})
Thể loại:  {'\t'}{sessionInfo["THELOAI"]}
Thời lượng: {'\t'}{((TimeSpan)sessionInfo["THOILUONG"]).TotalMinutes} phút
Ngày chiếu: {'\t'}{(DateTime)sessionInfo["NGAYCHIEU"]:d}
Suất chiếu: {'\t'}{(TimeSpan)sessionInfo["GIOBATDAU"]}";
                                txtPhim.Text = text;
                            }
                        }
                    }
                }
            }
            else
            {
                btnChonGhe.Enabled = false;
                chọnGhếThanhToánToolStripMenuItem.Enabled = false;
            }
        }

        private void chọnPhimSuấtChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectSession();
        }

        private void btnChonPhim_Click(object sender, EventArgs e)
        {
            selectSession();
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {

        }

        private void danhMụcTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new QuanLiDanhMucTaiKhoan();
            dialog.ShowDialog();
        }

        private void selectSeats()
        {
            var dialog = new Form1(sessionId);
            dialog.ShowDialog();
        }

        private void btnChonGhe_Click(object sender, EventArgs e)
        {
            selectSeats();
        }

        private void chọnGhếThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectSeats();
        }

        private void danhMụcVaiTròToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new QuanLiDanhMucVaiTro();
            dialog.ShowDialog();
        }
    }
}
