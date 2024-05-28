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
    public partial class HoaDon : Form
    {
        SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);
        string masuatchieu = "";
        string makhach = "";
        int t = 0;
        List<string> cacViTri = new List<string>();
        DateTime today = DateTime.Now;

        public HoaDon(string masuatchieu, string makhach, int tien, List<string> cacViTri)
        {
            InitializeComponent();
            this.masuatchieu = masuatchieu;
            this.makhach = makhach;
            this.t = tien;
            this.cacViTri = cacViTri;
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = @"select SC.ID_SUATCHIEU, SC.ID_PHONGCHIEU, SC.ID_PHIM, SC.NGAYCHIEU, SC.GIOBATDAU, PH.TENPHIM, P.TENPHONG
                        from SUATCHIEU SC
                        inner join PHIM PH on SC.ID_PHIM=PH.ID_PHIM
                        inner join PHONGCHIEU P on SC.ID_PHONGCHIEU=P.ID_PHONGCHIEU
                        where ID_SUATCHIEU=@suatchieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@suatchieu", masuatchieu);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                masc.Text = dt.Rows[0][0].ToString();
                phim.Text = dt.Rows[0]["TENPHIM"].ToString();
                ngay.Text = dt.Rows[0]["NGAYCHIEU"].ToString();
                gio.Text = dt.Rows[0]["GIOBATDAU"].ToString();
                phong.Text = dt.Rows[0]["TENPHONG"].ToString();
                ghe.Text = string.Join(", ", cacViTri);
                monye.Text = t.ToString() + " VND";
                makh.Text = makhach.ToString();
                date.Text = today.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xác nhận thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            DialogResult = DialogResult.OK;
            this.Close();
        }
        public DateTime returndate()
        {
            return today;
        }
    }
}
