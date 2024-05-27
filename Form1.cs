using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace DatVeXemPhim
{
    public partial class Form1 : Form
    {
        //static string comString = @"Data Source=ACER; Initial Catalog=CINEMA_PROJECT; Integrated Security=True; Encrypt=False";
        static string comString = @"Data Source=LAPTOP-P1DI0588\SQLEXPRESS; Initial Catalog=CINEMA_PROJECT; Integrated Security=True; Encrypt=False";
        SqlConnection conn = new SqlConnection(comString);
        List<string> cacViTri = new List<string>();
        private Dictionary<string, string> cacMaGhe = new Dictionary<string, string>();

        private string masuatchieu = "";
        private string maphongchieu = "";

        public Form1(string sessionId)
        {
            masuatchieu = sessionId;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Pen gry = new Pen(Color.Gray, 5);
            Pen gld = new Pen(Color.Goldenrod, 5);
            Pen mg = new Pen(Color.MediumPurple, 5);
            if (e.Row <= 4) e.Graphics.DrawRectangle(gry, e.CellBounds);
            else if (e.Row >= 6 && e.Row <= 8 && e.Column >= 3 && e.Column <= 8) e.Graphics.DrawRectangle(mg, e.CellBounds);
            else e.Graphics.DrawRectangle(gld, e.CellBounds);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = @"select SC.ID_SUATCHIEU, SC.ID_PHIM, P.TENPHIM, P.THELOAI, P.THOILUONG, P.DOTUOI, SC.NGAYCHIEU, SC.GIOBATDAU, SC.ID_PHONGCHIEU, PH.TENPHONG 
                        from SUATCHIEU SC 
                        inner join PHIM P on SC.ID_PHIM=P.ID_PHIM 
                        inner join PHONGCHIEU PH on SC.ID_PHONGCHIEU=PH.ID_PHONGCHIEU
                        where ID_SUATCHIEU=@Id";
                using SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", masuatchieu);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                label1.Text = dt.Rows[0][2].ToString();
                genre.Text = dt.Rows[0][3].ToString();
                len.Text = dt.Rows[0][4].ToString();
                rate.Text = dt.Rows[0][5].ToString();
                room.Text = dt.Rows[0][9].ToString();
                date.Text = ((DateTime)dt.Rows[0][6]).ToString("d");
                time.Text = dt.Rows[0][7].ToString();
                maphongchieu = (string)dt.Rows[0]["ID_PHONGCHIEU"];
                string qry = @"SELECT GHE.*,
CAST((CASE WHEN VE.ID_VE IS NULL THEN 0 ELSE 1 END) AS BIT) AS DADUOCDAT
FROM GHE
LEFT JOIN VE ON VE.ID_GHE = GHE.ID_GHE
AND VE.ID_SUATCHIEU = @IdSuatChieu
WHERE GHE.ID_PHONGCHIEU = @IdPhongChieu";
                using SqlCommand sqlCom = new SqlCommand(qry, conn);
                sqlCom.Parameters.AddWithValue("@IdSuatChieu", masuatchieu);
                sqlCom.Parameters.AddWithValue("@IdPhongChieu", maphongchieu);
                using SqlDataAdapter adt = new SqlDataAdapter(sqlCom);
                DataTable dt2 = new DataTable();
                adt.Fill(dt2);
                for(int i = 0; i < 120; i++)
                {
                    Label ghe = new Label();
                    ghe.Text = dt2.Rows[i][4].ToString();
                    ghe.AutoSize = false;
                    ghe.Dock = DockStyle.Fill;
                    ghe.Width = 32;
                    ghe.Height = 26;
                    ghe.TextAlign = ContentAlignment.MiddleCenter;
                    ghe.BackColor = Color.White;
                    object a = dt2.Rows[i]["DADUOCDAT"];
                    if (dt2.Rows[i]["DADUOCDAT"] is true)
                    {
                        ghe.BackColor = Color.Red;
                        ghe.ForeColor = Color.White;
                    }
                    tableLayoutPanel1.Controls.Add(ghe);
                    ghe.Click += ghe_Click;
                    cacMaGhe[ghe.Text] = (string)dt2.Rows[i]["ID_GHE"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ghe_Click(object? sender, EventArgs e)
        {
            Label ghe = (Label)sender!;
            if (ghe.BackColor == Color.White)
            {
                if (cacViTri.Count >= 5)
                {
                    return;
                }
                ghe.BackColor = Color.GreenYellow;
                cacViTri.Add(ghe.Text);
            }
            else if (ghe.BackColor == Color.GreenYellow)
            {
                ghe.BackColor = Color.White;
                cacViTri.Remove(ghe.Text);
            }
            else if (ghe.BackColor == Color.Red) MessageBox.Show("Ghế đã có người đặt, không thể chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            seat.Text = string.Join(", ", cacViTri);
        }
        private void label33_Click(object sender, EventArgs e)
        {
        }

        private void label33_Paint(object sender, PaintEventArgs e)
        {
            Pen gry = new Pen(Color.Gray, 5);
            e.Graphics.DrawRectangle(gry, 0, 0, 34, 26);
        }

        private void label34_Paint(object sender, PaintEventArgs e)
        {
            Pen gld = new Pen(Color.Goldenrod, 5);
            e.Graphics.DrawRectangle(gld, 0, 0, 34, 26);
        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label35_Paint(object sender, PaintEventArgs e)
        {
            Pen mg = new Pen(Color.MediumPurple, 5);
            e.Graphics.DrawRectangle(mg, 0, 0, 34, 26);
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }
    }
}
