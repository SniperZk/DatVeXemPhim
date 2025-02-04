﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Data.SqlClient;

using DatVeXemPhim.Utils;

namespace DatVeXemPhim
{
    public partial class ManHinhChinh : Form
    {
        private SqLiem sqliem = new SqLiem("", Constants.CONNECTION_STRING);

        public bool shouldExit = true;
        public string userId = "admin"; // Chưa đăng nhập thì là xâu rỗng
        string sessionId = ""; // Mã suất chiếu
        List<string> seatIds = []; // Các mã ghế

        public ManHinhChinh(string userId)
        {
            this.userId = userId;
            InitializeComponent();
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

                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT
PH.TENPHIM, PH.THELOAI, PH.THOILUONG, PH.DOTUOI, SC.NGAYCHIEU, SC.GIOBATDAU
FROM SUATCHIEU SC
INNER JOIN PHIM PH
ON SC.ID_PHIM = PH.ID_PHIM
WHERE ID_SUATCHIEU = @Id"))
                    {
                        cmd.Parameters.AddWithValue("@Id", sessionId);
                        var sessionInfo = sqliem.selectFirstToDict(cmd);
                        string text = $@"PHIM: {((string)sessionInfo["TENPHIM"]).ToUpper()} ({sessionInfo["DOTUOI"]})
Thể loại:  {'\t'}{sessionInfo["THELOAI"]}
Thời lượng: {'\t'}{((TimeSpan)sessionInfo["THOILUONG"]).TotalMinutes} phút
Ngày chiếu: {'\t'}{(DateTime)sessionInfo["NGAYCHIEU"]:d}
Suất chiếu: {'\t'}{(TimeSpan)sessionInfo["GIOBATDAU"]}";
                        txtPhim.Text = text;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void setAdminMode(bool adminMode)
        {
            danhMụcToolStripMenuItem.Enabled = adminMode;
            thốngKêToolStripMenuItem.Enabled = adminMode;
        }

        private void loadUser()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT TK.*, VT.TENVAITRO FROM TAIKHOAN TK
INNER JOIN VAITRO VT
ON TK.ID_VAITRO = VT.ID_VAITRO
WHERE TK.ID_TAIKHOAN = @Id"))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    var userInfo = sqliem.selectFirstToDict(cmd);

                    labelGreeting.Text = $"Xin chào {userInfo["HOTEN"]} ({userInfo["TENDANGNHAP"]}).";

                    string roleName = ((string)userInfo["TENVAITRO"]).ToLower();
                    setAdminMode(roleName.Contains("admin") || roleName == "quản trị viên");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            loadUser();
        }

        private void danhMụcTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new QuanLiDanhMucTaiKhoan();
            dialog.ShowDialog();
        }

        private void selectSeats()
        {
            var dialog = new DatGhe(sessionId, userId);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Mua vé thành công. Xem vé đã mua ở mục 'vé của tôi'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhim.Clear();
            }
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

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            var dialog = new LichSuMuaVe(userId);
            dialog.ShowDialog();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new BaoCaoThongKe();
            dialog.ShowDialog();
        }

        private void ManHinhChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && shouldExit)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là muốn thoát chương trình không? Tài khoản của bạn sẽ được đăng xuất trước khi thoát chương trình.", "Xác nhận đóng chương trình", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shouldExit = false;
            Close();
        }
    }
}
