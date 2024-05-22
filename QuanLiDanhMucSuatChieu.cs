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
using Microsoft.Data.SqlClient;

namespace DatVeXemPhim
{
    public partial class QuanLiDanhMucSuatChieu : Form
    {
        private readonly static string connString = "Initial Catalog=CINEMA_PROJECT;Data Source=LAPTOP-P1DI0588\\SQLEXPRESS;TrustServerCertificate=True;Trusted_Connection=True";
        private DataTable table = new DataTable();
        private DataTable movieTable = new DataTable();
        private DataTable roomTable = new DataTable();
        private SqLiem sqliem;
        private Faker faker = new Faker();

        public QuanLiDanhMucSuatChieu()
        {
            InitializeComponent();

            sqliem = new SqLiem(@"SELECT
ID_SUATCHIEU AS [Mã suất chiếu],
ID_PHONGCHIEU AS [Mã phòng],
ID_PHIM AS [Mã phim],
NGAYCHIEU AS [Ngày chiếu],
GIOBATDAU AS [Giờ bắt đầu]
FROM SUATCHIEU
", connString);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!LinkTing.checkDateTimePickerPair(dtGioChieu, dtGioHet, "Giờ chiếu phải sớm hơn giờ kết thúc."))
            {
                return;
            }
            table.Rows.Add(null, cbPhong.SelectedValue, cbPhim.SelectedValue, dtNgayChieu.Value, LinkTing.toTime(dtGioChieu.Value));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }

            DataRow row = ((DataRowView)dataView.SelectedRows[0].DataBoundItem).Row;
            int colIndex = 1;
            row[colIndex++] = cbPhong.SelectedValue;
            row[colIndex++] = cbPhim.SelectedValue;
            row[colIndex++] = dtNgayChieu.Value.Date;
            row[colIndex++] = LinkTing.toTime(dtGioChieu.Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LinkTing.deleteDataGridViewSelectedRows(dataView);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                sqliem.load(table);
                loadOtherTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                sqliem.update(table);
                loadOtherTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || (dataView.AllowUserToAddRows && (e.RowIndex + 1 == dataView.RowCount)))
            {
                return;
            }
            DataGridViewRow row = dataView.Rows[e.RowIndex];
            int colIndex = 1;
            cbPhong.SelectedValue = (string)row.Cells[colIndex++].Value;
            cbPhim.SelectedValue = (string)row.Cells[colIndex++].Value;
            dtNgayChieu.Value = (DateTime)row.Cells[colIndex++].Value;
            dtGioChieu.Value = LinkTing.toDate((TimeSpan)row.Cells[colIndex++].Value);
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }

        private void loadOtherTables()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ID_PHONGCHIEU, TENPHONG FROM PHONGCHIEU", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    roomTable = new DataTable();
                    roomTable.Load(reader);
                    cbPhong.DataSource = roomTable;
                    cbPhong.DisplayMember = "TENPHONG";
                    cbPhong.ValueMember = "ID_PHONGCHIEU";
                }

                using (SqlCommand cmd = new SqlCommand("SELECT ID_PHIM, TENPHIM, THOILUONG, NGAYKHOICHIEU, NGAYCHIEUCUOI FROM PHIM", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    movieTable = new DataTable();
                    movieTable.Load(reader);
                    cbPhim.DisplayMember = "TENPHIM";
                    cbPhim.ValueMember = "ID_PHIM";
                    cbPhim.DataSource = movieTable;
                }
            }
        }

        private void QuanLiDanhMucSuatChieu_Load(object sender, EventArgs e)
        {
            LinkTing.setDoubleBuffered(dataView);

            try
            {
                sqliem.load(table);
                loadOtherTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            dataView.DataSource = table;
        }

        private void cbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhim.SelectedValue != null)
            {
                string movieId = (string)cbPhim.SelectedValue;
                DataRow row = movieTable.Select($"ID_PHIM = '{movieId}'")[0];
                DateTime startDate = (DateTime)row["NGAYKHOICHIEU"];
                DateTime endDate = (DateTime)row["NGAYCHIEUCUOI"];
                if (startDate > dtNgayChieu.MaxDate)
                {
                    dtNgayChieu.MaxDate = endDate;
                    dtNgayChieu.MinDate = startDate;
                }
                else
                {
                    dtNgayChieu.MinDate = startDate;
                    dtNgayChieu.MaxDate = endDate;

                }
            }
            dtGioChieu_ValueChanged(sender, e);
        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    {
                        e.Value = LinkTing.displayStringFromTableId(roomTable, e.Value, "ID_PHONGCHIEU", "TENPHONG");
                        e.FormattingApplied = true;
                        break;
                    }
                case 2:
                    {
                        e.Value = LinkTing.displayStringFromTableId(movieTable, e.Value, "ID_PHIM", "TENPHIM");
                        e.FormattingApplied = true;
                        break;
                    }
                default:
                    break;
            }
        }

        private void dtGioChieu_ValueChanged(object sender, EventArgs e)
        {
            if (cbPhim.SelectedValue != null)
            {
                string movieId = (string)cbPhim.SelectedValue;
                TimeSpan duration = (TimeSpan)movieTable.Select($"ID_PHIM = '{movieId}'")[0]["THOILUONG"];
                dtGioHet.Value = dtGioChieu.Value.Add(duration);
            }
        }

        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            int roomCount = roomTable.Rows.Count;
            if (roomCount > 0 && movieTable.Rows.Count > 0)
            {
                foreach (int roomI in Enumerable.Range(0, roomCount-1).OrderBy(x => faker.randInt()))
                {
                    DataRow room = roomTable.Rows[roomI];
                    for (int _ = 0; _ < 10; _++)
                    {
                        DataRow movie = faker.randRow(movieTable);
                        string movieId = (string)movie[0];
                        TimeSpan duration = (TimeSpan)movie["THOILUONG"];
                        DateTime startDate = (DateTime)movie["NGAYKHOICHIEU"];
                        DateTime endDate = (DateTime)movie["NGAYCHIEUCUOI"];
                        DateTime date = faker.randomDate(startDate, endDate);
                        var sessionsResult = from row in table.AsEnumerable()
                                             where row.RowState != DataRowState.Deleted
                                             && row.Field<string>("Mã phim") == movieId
                                             && row.Field<DateTime>("Ngày chiếu") == date
                                             select row;
                        if (sessionsResult.Any())
                        {
                            DataRow[] sessions = sessionsResult.ToArray();
                            TimeSpan breakTime = new TimeSpan(0, 15, 0);
                            for (int i = 0; i < sessions.Length; i++)
                            {
                                DataRow session = sessions[i];
                                if (i < sessions.Length - 1)
                                {
                                    TimeSpan currShowTime = session.Field<TimeSpan>("Giờ bắt đầu");
                                    TimeSpan currDuration = (TimeSpan)movieTable.Select($"ID_PHIM = '{(string)session["Mã phim"]}'")[0]["THOILUONG"];
                                    TimeSpan currEndTime = currShowTime + duration;

                                    TimeSpan targetShowTime;
                                    TimeSpan targetEndTime;

                                    if (i != 0)
                                    {
                                        TimeSpan prevShowTime = sessions[i - 1].Field<TimeSpan>("Giờ bắt đầu");
                                        TimeSpan prevDuration = (TimeSpan)movieTable.Select($"ID_PHIM = '{(string)session["Mã phim"]}'")[0]["THOILUONG"];
                                        TimeSpan prevEndTime = prevShowTime + prevDuration;

                                        targetShowTime = currShowTime - breakTime - duration;
                                        if (prevEndTime <= targetShowTime && targetShowTime < TimeSpan.Zero)
                                        {
                                            cbPhong.SelectedValue = room[0];
                                            cbPhim.SelectedValue = movieId;
                                            dtNgayChieu.Value = date;
                                            dtGioChieu.Value = LinkTing.toDate(targetShowTime);
                                            return;
                                        }
                                    }

                                    targetShowTime = currEndTime + breakTime;
                                    targetEndTime = targetShowTime + duration;
                                    TimeSpan nextShowTime = sessions[i + 1].Field<TimeSpan>("Giờ bắt đầu");
                                    if (nextShowTime >= targetEndTime && targetEndTime.Days == 0)
                                    {
                                        cbPhong.SelectedValue = room[0];
                                        cbPhim.SelectedValue = movieId;
                                        dtNgayChieu.Value = date;
                                        dtGioChieu.Value = LinkTing.toDate(targetShowTime);
                                        return;
                                    }
                                }
                            }
                        } else
                        {
                            cbPhong.SelectedValue = room[0];
                            cbPhim.SelectedValue = movieId;
                            dtNgayChieu.Value = date;
                            dtGioChieu.Value = LinkTing.toDate(new TimeSpan(8, 0, 0));
                            return;
                        }
                    }
                }
            }
        }
    }
}
