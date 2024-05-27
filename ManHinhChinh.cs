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
            else
            {
                sessionId = "";
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
    }
}
