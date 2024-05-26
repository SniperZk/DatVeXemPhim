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
    public partial class ChonPhimVaCongChieu : Form
    {
        SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);
        public string selectedShowtimeId = "";

        public ChonPhimVaCongChieu()
        {
            InitializeComponent();
            CustomizeDateTimePicker();
        }

        private void ChonPhimVaCongChieu_Load(object? sender, EventArgs e)
        {
            cboFilm.Enabled = false;
            cboDoTuoi.Enabled = false;
            cboSuatChieu.Enabled = false;

            dtpNgayChieu.ValueChanged += dtpNgayChieu_ValueChanged;
            cboDoTuoi.SelectedIndexChanged += cboDoTuoi_SelectedIndexChanged;
            cboFilm.SelectedIndexChanged += cboFilm_SelectedIndexChanged;
            cboSuatChieu.SelectedIndexChanged += cboSuatChieu_SelectedIndexChanged;
            chkDoTuoi.CheckedChanged += chkDoTuoi_CheckedChanged;
            btnDatVe.Click += btnDatVe_Click;
        }

        private void dtpNgayChieu_ValueChanged(object? sender, EventArgs e)
        {
            cboDoTuoi.Enabled = false;
            cboDoTuoi.DataSource = null;
            cboDoTuoi.Items.Clear();
            cboDoTuoi.Enabled = false;

            if (chkDoTuoi.Checked)
            {
                LoadDoTuoi();
            }
            else
            {
                LoadMovies();
            }
        }

        private void chkDoTuoi_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkDoTuoi.Checked)
            {
                cboDoTuoi.Enabled = true;
                LoadDoTuoi();
            }
            else
            {
                cboDoTuoi.Enabled = false;
                cboDoTuoi.DataSource = null;
                cboDoTuoi.Items.Clear();
                LoadMovies();
            }
        }

        private void cboDoTuoi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadMovies();
        }

        private void cboFilm_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadShowtimes();
        }

        private void cboSuatChieu_SelectedIndexChanged(object? sender, EventArgs e)
        {
            DisplayShowtimeDetails();
            UpdateSelectedShowtimeId();
        }

        private void UpdateSelectedShowtimeId()
        {
            if (cboSuatChieu.SelectedValue != null)
            {
                selectedShowtimeId = cboSuatChieu.SelectedValue.ToString()!;
            }
        }

        private void LoadDoTuoi()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT DISTINCT DOTUOI FROM PHIM";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                cboDoTuoi.DisplayMember = "DOTUOI";
                cboDoTuoi.ValueMember = "DOTUOI";
                cboDoTuoi.DataSource = dt;
                cboDoTuoi.Enabled = true;

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMovies()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query;
                SqlCommand cmd = new SqlCommand();

                if (chkDoTuoi.Checked && cboDoTuoi.SelectedValue != null)
                {
                    query = @"SELECT ID_PHIM, TENPHIM FROM PHIM PH
                            WHERE DOTUOI = @DoTuoi AND EXISTS (
                            SELECT * FROM SUATCHIEU SC
                            WHERE SC.ID_PHIM = PH.ID_PHIM
                            AND SC.NGAYCHIEU = @NgayChieu
                            )";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DoTuoi", cboDoTuoi.SelectedValue);
                }
                else
                {
                    query = @"SELECT ID_PHIM, TENPHIM FROM PHIM PH
                            WHERE EXISTS (
                            SELECT * FROM SUATCHIEU SC
                            WHERE SC.ID_PHIM = PH.ID_PHIM
                            AND SC.NGAYCHIEU = @NgayChieu
                            )";
                    cmd = new SqlCommand(query, conn);
                }

                cmd.Parameters.AddWithValue("@NgayChieu", dtpNgayChieu.Value.Date);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    cboFilm.DisplayMember = "TENPHIM";
                    cboFilm.ValueMember = "ID_PHIM";
                    cboFilm.DataSource = dt;
                    cboFilm.Enabled = true;
                }
                else
                {
                    cboFilm.DataSource = null;
                    cboFilm.Items.Clear();
                    cboFilm.Enabled = false;
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadShowtimes()
        {
            try
            {
                if (cboFilm.SelectedValue != null)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = "SELECT ID_SUATCHIEU, GIOBATDAU FROM SUATCHIEU WHERE ID_PHIM = @IDPhim AND NGAYCHIEU = @NgayChieu";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDPhim", (string)cboFilm.SelectedValue);
                    cmd.Parameters.AddWithValue("@NgayChieu", dtpNgayChieu.Value.Date);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        cboSuatChieu.DisplayMember = "GIOBATDAU";
                        cboSuatChieu.ValueMember = "ID_SUATCHIEU";
                        cboSuatChieu.DataSource = dt;
                        cboSuatChieu.Enabled = true;
                    }
                    else
                    {
                        cboSuatChieu.DataSource = null;
                        cboSuatChieu.Items.Clear();
                        cboSuatChieu.Enabled = false;

                        txtGioBatDau.Text = "";
                        txtGioKetThuc.Text = "";
                    }

                    reader.Close();
                    conn.Close();
                }
                else
                {
                    cboSuatChieu.DataSource = null;
                    cboSuatChieu.Items.Clear();
                    cboSuatChieu.Enabled = false;

                    txtGioBatDau.Text = "";
                    txtGioKetThuc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayShowtimeDetails()
        {
            if (cboSuatChieu.SelectedValue != null)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = @"SELECT SC.GIOBATDAU AS GIOBATDAU, PH.THOILUONG AS THOILUONG
                                    FROM SUATCHIEU SC
                                    INNER JOIN PHIM PH
                                    ON SC.ID_PHIM = PH.ID_PHIM
                                    WHERE SC.ID_SUATCHIEU = @IDSuatChieu";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDSuatChieu", (string)cboSuatChieu.SelectedValue);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TimeSpan gioBatDau = reader.GetTimeSpan(0);
                        TimeSpan thoiLuong = reader.GetTimeSpan(1);
                        TimeSpan gioKetThuc = gioBatDau + thoiLuong;
                        txtGioBatDau.Text = gioBatDau.ToString();
                        txtGioKetThuc.Text = gioKetThuc.ToString();
                    }

                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDatVe_Click(object? sender, EventArgs e)
        {
            if (chkDoTuoi.Checked && cboDoTuoi.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn độ tuổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDoTuoi.Focus();
                return;
            }

            if (cboFilm.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phim.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFilm.Focus();
                return;
            }

            if (cboSuatChieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn suất chiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSuatChieu.Focus();
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT PH.TENPHIM, PH.THELOAI, PH.DOTUOI, SC.GIOBATDAU, PH.THOILUONG, SC.NGAYCHIEU
                                FROM SUATCHIEU SC
                                INNER JOIN PHIM PH ON SC.ID_PHIM = PH.ID_PHIM
                                WHERE SC.ID_SUATCHIEU = @IDSuatChieu";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDSuatChieu", cboSuatChieu.SelectedValue);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string tenPhim = reader["TENPHIM"].ToString()!;
                    string theLoai = reader["THELOAI"].ToString()!;
                    string doTuoi = reader["DOTUOI"].ToString()!;
                    string gioBatDau = reader["GIOBATDAU"].ToString()!;
                    string thoiLuong = reader["THOILUONG"].ToString()!;
                    string ngayChieu = reader["NGAYCHIEU"].ToString()!;

                    ngayChieu = DateTime.Parse(ngayChieu).ToShortDateString();
                    string ketQua = $"Tên phim: {tenPhim}\r\nThể loại: {theLoai}\r\nĐộ tuổi: {doTuoi}\r\nGiờ bắt đầu: {gioBatDau}\r\nThời lượng: {thoiLuong}\r\nNgày chiếu: {ngayChieu}";
                    txtKetQua.Text = ketQua;
                    MessageBox.Show("Suất chiếu đã được chọn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin về suất chiếu này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Close();
            }
        }

        private List<DateTime> GetAvailableDates()
        {
            List<DateTime> availableDates = new List<DateTime>();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT DISTINCT NGAYCHIEU FROM SUATCHIEU";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    availableDates.Add(reader.GetDateTime(0).Date);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return availableDates;
        }

        private void CustomizeDateTimePicker()
        {
            List<DateTime> availableDates = GetAvailableDates();
            dtpNgayChieu.MinDate = availableDates.Min();
            dtpNgayChieu.MaxDate = availableDates.Max();
            dtpNgayChieu.Value = availableDates.FirstOrDefault(d => d >= DateTime.Today);
        }
    }
}
