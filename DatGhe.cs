using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace DatVeXemPhim
{
    public partial class DatGhe : Form
    {
        SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);
        List<string> cacViTri = new List<string>();
        string masuatchieu = "";
        string makhach = "";
        string maphongchieu = "";
        int soghe = 0;
        int tien = 0;
        DataTable bangVe = new DataTable();

        public DatGhe(string masuatchieu, string makhach)
        {
            InitializeComponent();
            this.masuatchieu = masuatchieu;
            this.makhach = makhach;
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
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string query = @"select SC.ID_SUATCHIEU, SC.ID_PHIM, P.TENPHIM, P.THELOAI, P.THOILUONG, P.DOTUOI, SC.NGAYCHIEU, SC.GIOBATDAU, SC.ID_PHONGCHIEU, PH.TENPHONG 
                        from SUATCHIEU SC 
                        inner join PHIM P on SC.ID_PHIM=P.ID_PHIM 
                        inner join PHONGCHIEU PH on SC.ID_PHONGCHIEU=PH.ID_PHONGCHIEU
                        where ID_SUATCHIEU=@idSuatChieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idSuatChieu", masuatchieu);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
                string q = @"SELECT ID_TAIKHOAN, HOTEN
                        FROM TAIKHOAN
                        WHERE ID_TAIKHOAN = @maKhachHang";
                SqlCommand sqlCommand = new SqlCommand(q, conn);
                sqlCommand.Parameters.AddWithValue("@maKhachHang", makhach);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                uid.Text = makhach;
                tenkh.Text = dataTable.Rows[0][1].ToString();
                string qry = @"SELECT GHE.*,
                        CAST((CASE WHEN VE.ID_VE IS NULL THEN 0 ELSE 1 END) AS BIT) AS DADUOCDAT
                        FROM GHE
                        LEFT JOIN VE ON VE.ID_GHE = GHE.ID_GHE
                        AND GHE.ID_PHONGCHIEU = @idPhongChieu
                        AND VE.ID_SUATCHIEU = @idSC";
                SqlCommand sqlcmd = new SqlCommand(qry, conn);
                sqlcmd.Parameters.AddWithValue("@idPhongChieu", maphongchieu);
                sqlcmd.Parameters.AddWithValue("@idSC", masuatchieu);
                SqlDataAdapter adt = new SqlDataAdapter(sqlcmd);
                DataTable dt2 = new DataTable();
                adt.Fill(dt2);
                for (int i = 0; i < 120; i++)
                {
                    Label ghe = new Label();
                    ghe.Text = dt2.Rows[i][4].ToString();
                    ghe.AutoSize = false;
                    ghe.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    ghe.Width = 38;
                    ghe.Height = 24;
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
                }
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ghe_Click(object? sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                Label ghe = (Label)sender!;
                if (ghe.BackColor == Color.White)
                {
                    if (soghe >= 5) MessageBox.Show("Chỉ được chọn tối đa 5 ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        ghe.BackColor = Color.GreenYellow;
                        var vitri = ghe.Text;
                        cacViTri.Add(vitri);
                        string query = @"select GHE.*, LG.TENLOAIGHE from GHE inner join LOAIGHE LG on GHE.ID_LOAIGHE = LG.ID_LOAIGHE where VITRI=@vitri and ID_PHONGCHIEU=@mapc";
                        SqlCommand cmd = new SqlCommand(query);
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@vitri", vitri);
                        cmd.Parameters.AddWithValue("@mapc", maphongchieu);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(bangVe);
                        int i = bangVe.Rows.Count-1;
                        DataRow dt = bangVe.Rows[i];
                        if ((string)dt["TENLOAIGHE"] == "Thường") tien += 99000;
                        else if ((string)dt["TENLOAIGHE"] == "VIP") tien += 129000;
                        else if ((string)dt["TENLOAIGHE"] == "CineMAX") tien += 199000;
                        soghe += 1;
                    }
                }
                else if (ghe.BackColor == Color.GreenYellow)
                {
                    ghe.BackColor = Color.White;
                    cacViTri.Remove(ghe.Text);
                    for (int i = bangVe.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow row = bangVe.Rows[i];
                        if ((string)row["VITRI"] == ghe.Text)
                        {
                            if ((string)row["TENLOAIGHE"] == "Thường") tien -= 99000;
                            else if ((string)row["TENLOAIGHE"] == "VIP") tien -= 129000;
                            else if ((string)row["TENLOAIGHE"] == "CineMAX") tien -= 199000;
                            bangVe.Rows.Remove(row);
                        }
                    }
                    soghe -= 1;
                }
                else if (ghe.BackColor == Color.Red) MessageBox.Show("Ghế đã có người đặt, không thể chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                seat.Text = string.Join(", ", cacViTri);
                monye.Text = tien.ToString() + " VND";
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void uid_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (soghe == 0) MessageBox.Show("Vui lòng chọn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                var dialog = new HoaDon(masuatchieu, makhach, tien, cacViTri);
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        DateTime t = dialog.returndate();
                        
                        string qry = @"insert into HOADON output inserted.ID_HOADON values(@taikhoan, @ngay, @tien)";
                        SqlCommand sqlCommand = new SqlCommand(qry, conn);
                        sqlCommand.Parameters.AddWithValue("@taikhoan", makhach);
                        sqlCommand.Parameters.AddWithValue("@ngay", t);
                        sqlCommand.Parameters.AddWithValue("@tien", tien);
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        reader.Read();
                        string mahd = reader.GetString(0);
                        reader.Close();

                        List<string> ticketIds = [];
                        for (int i = 0; i < soghe; i++)
                        {
                            DataRow dr = bangVe.Rows[i];
                            string query = @"insert into VE output inserted.ID_VE values(@suatchieu, @ghe, @giave, @trangthai)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@suatchieu", masuatchieu);
                            cmd.Parameters.AddWithValue("@ghe", dr["ID_GHE"]);
                            if ((string)dr["TENLOAIGHE"] == "Thường") cmd.Parameters.AddWithValue("@giave", 99000);
                            else if ((string)dr["TENLOAIGHE"] == "VIP") cmd.Parameters.AddWithValue("@giave", 129000);
                            else if ((string)dr["TENLOAIGHE"] == "CineMAX") cmd.Parameters.AddWithValue("@giave", 199000);
                            cmd.Parameters.AddWithValue("@trangthai", "Hoàn tất");
                            reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                ticketIds.Add(reader.GetString(0));
                            }
                            reader.Close();
                        }
                        foreach (string ticketId in ticketIds)
                        {
                            string query = @"insert into CHITIETHOADON values(@ve,@hd)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ve", ticketId);
                            cmd.Parameters.AddWithValue("@hd", mahd);
                            cmd.ExecuteNonQuery();
                        }
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Close();
                }
                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
