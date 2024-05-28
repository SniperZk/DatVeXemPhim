using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DatVeXemPhim
{
    public partial class BaoCaoThongKe : Form
    {
        SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);

        public BaoCaoThongKe()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
                {
                    connection.Open();
                    string query = "SELECT ID_PHIM, TENPHIM FROM PHIM";
                    using SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    TenPhim.DataSource = dt;
                    TenPhim.DisplayMember = "TENPHIM";
                    TenPhim.ValueMember = "ID_PHIM";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThongKe_Click(object sender, EventArgs e)
        {
            if (TenPhim.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tên phim.");
                return;
            }

            string selectedMovie = (string)TenPhim.SelectedValue!;
            DateTime fromDate = NgayKhoiChieu.Value.Date;
            DateTime toDate = NgayChieuCuoi.Value.Date;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = @"SELECT
SC.ID_SUATCHIEU AS [Mã suất chiếu],
SC.NGAYCHIEU AS [Ngày chiếu],
SC.GIOBATDAU AS [Giờ chiếu],
PC.TENPHONG AS [Phòng chiếu],
COUNT(VE.ID_GHE) AS [Số vé bán được],
SUM(VE.GIAVE) AS [Doanh thu]
FROM SUATCHIEU SC
INNER JOIN PHONGCHIEU PC ON PC.ID_PHONGCHIEU = SC.ID_PHONGCHIEU
LEFT JOIN VE ON VE.ID_SUATCHIEU = SC.ID_SUATCHIEU
WHERE SC.ID_PHIM = @MaPhim AND SC.NGAYCHIEU BETWEEN @NgayKhoiChieu AND @NgayChieuCuoi
GROUP BY SC.ID_PHIM, SC.ID_SUATCHIEU, SC.NGAYCHIEU, SC.GIOBATDAU, PC.TENPHONG";
                using SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhim", selectedMovie);
                cmd.Parameters.AddWithValue("@NgayKhoiChieu", fromDate);
                cmd.Parameters.AddWithValue("@NgayChieuCuoi", toDate);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dtgv_Cinema.DataSource = dataTable;
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                TongDoanhThu.Text = dataTable.Compute("SUM([Doanh thu])", "").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
