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
    public class TimeRange
    {
        public TimeSpan Start;
        public TimeSpan Duration;
        public TimeSpan End {
            get
            {
                return Start + Duration;
            }
        }

        public TimeRange() { }

        public TimeRange(DataRow row, DataTable movieTable)
        {
            Start = row.Field<TimeSpan>("Giờ bắt đầu");
            Duration = (TimeSpan)movieTable.Select($"ID_PHIM = '{(string)row["Mã phim"]}'")[0]["THOILUONG"];
        }

        public bool Overlap(TimeRange otherRange)
        {
            if (otherRange.Start >= Start && otherRange.Start <= End)
            {
                return true;
            }
            if (End >= otherRange.Start && End <= otherRange.End)
            {
                return true;
            }
            return false;
        }
    }

    public class Session
    {
        public string roomId = "";
        public string movieId = "";
        public DateTime date;
        public TimeSpan time;
    }



    public partial class QuanLiDanhMucSuatChieu : Form
    {
        private readonly static TimeSpan breakTime = new TimeSpan(0, 15, 0);
        private readonly static TimeSpan startOfDay = new TimeSpan(8, 0, 0);

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
", Constants.CONNECTION_STRING);
        }

        private bool checkInputValid(bool addMode)
        {
            if (!Chung.checkEmptyComboBox(cbPhim, "Vui lòng chọn phim."))
            {
                return false;
            }
            if (!Chung.checkEmptyComboBox(cbPhong, "Vui lòng chọn phòng chiếu."))
            {
                return false;
            }
            if (Chung.toTime(dtGioHet.Value) < Chung.toTime(dtGioChieu.Value))
            {
                MessageBox.Show("Thời gian bắt đầu và kết thúc phải nằm trong cùng một ngày.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtGioChieu.Focus();
                return false;
            }

            TimeRange range = new TimeRange()
            {
                Start = Chung.toTime(dtGioChieu.Value),
                Duration = (TimeSpan)movieTable.Rows.Find(cbPhim.SelectedValue)!["THOILUONG"],
            };
            var result = from row in table.AsEnumerable()
                         where row.RowState != DataRowState.Deleted
                         && row.Field<string>("Mã phòng") == cbPhong.SelectedValue as string
                         && row.Field<DateTime>("Ngày chiếu") == dtNgayChieu.Value
                         select row;
            foreach (DataRow row in result)
            {
                 if (range.Overlap(new TimeRange(row, movieTable)) && (addMode || row != ((DataRowView)dataView.SelectedRows[0].DataBoundItem).Row)) {
                    MessageBox.Show($"Suất chiếu này bị trùng thời gian với suất chiếu lúc {row["Giờ bắt đầu"]} cùng ngày.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtGioChieu.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkInputValid(true))
            {
                return;
            }

            table.Rows.Add(null, cbPhong.SelectedValue, cbPhim.SelectedValue,
                dtNgayChieu.Value, Chung.toTime(dtGioChieu.Value));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }
            if (!checkInputValid(false))
            {
                return;
            }

            Chung.changeSelectedViewRow(dataView, NoParam.Value,
                cbPhong.SelectedValue,cbPhim.SelectedValue,
                dtNgayChieu.Value.Date, Chung.toTime(dtGioChieu.Value));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (new WaitGuard(Cursors.WaitCursor, btnXoa))
            {
                Chung.deleteDataGridViewSelectedRows(dataView);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                using (new WaitGuard(Cursors.WaitCursor, btnTaiLai))
                {
                    sqliem.load(table);
                    loadOtherTables();
                }
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
                using (new WaitGuard(Cursors.WaitCursor, btnLuu))
                {
                    int affected = sqliem.update(table);
                    loadOtherTables();
                    MessageBox.Show($"Cập nhật thành công, đã thao tác lên {affected} dòng dữ liệu.", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            dtGioChieu.Value = Chung.toDate((TimeSpan)row.Cells[colIndex++].Value);
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }

        private void loadOtherTables()
        {
            roomTable = sqliem.selectToTable("SELECT ID_PHONGCHIEU, TENPHONG FROM PHONGCHIEU");
            cbPhong.DataSource = roomTable;
            cbPhong.DisplayMember = "TENPHONG";
            cbPhong.ValueMember = "ID_PHONGCHIEU";

            movieTable = sqliem.selectToTable("SELECT ID_PHIM, TENPHIM, THOILUONG, NGAYKHOICHIEU, NGAYCHIEUCUOI FROM PHIM");
            cbPhim.DisplayMember = "TENPHIM";
            cbPhim.ValueMember = "ID_PHIM";
            cbPhim.DataSource = movieTable;
        }

        private void QuanLiDanhMucSuatChieu_Load(object sender, EventArgs e)
        {
            using (new WaitGuard(Cursors.AppStarting))
            {
                Chung.setDoubleBuffered(dataView);
                Chung.bindGroupBoxToTable(gbSuatChieu, table, "Danh mục suất chiếu ({0})");

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
        }

        private void cbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhim.SelectedValue != null)
            {
                string movieId = (string)cbPhim.SelectedValue;
                DataRow row = movieTable.Rows.Find(movieId)!;
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
                        e.Value = Chung.displayStringFromTableId(roomTable, e.Value, "ID_PHONGCHIEU", "TENPHONG");
                        e.FormattingApplied = true;
                        break;
                    }
                case 2:
                    {
                        e.Value = Chung.displayStringFromTableId(movieTable, e.Value, "ID_PHIM", "TENPHIM");
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
                TimeSpan duration = (TimeSpan)movieTable.Rows.Find(movieId)!["THOILUONG"];
                dtGioHet.Value = dtGioChieu.Value.Add(duration);
            }
        }

        private Session? randomSession()
        {
            int roomCount = roomTable.Rows.Count;
            if (roomCount > 0 && movieTable.Rows.Count > 0)
            {
                foreach (int roomI in faker.randEnumRange(roomCount))
                {
                    DataRow room = roomTable.Rows[roomI];
                    string roomId = (string)room[0];
                    foreach (int movieI in faker.randEnumRange(movieTable.Rows.Count))
                    {
                        DataRow movie = movieTable.Rows[movieI];
                        TimeSpan duration = (TimeSpan)movie["THOILUONG"];
                        DateTime startDate = (DateTime)movie["NGAYKHOICHIEU"];
                        DateTime endDate = (DateTime)movie["NGAYCHIEUCUOI"];
                        DateTime date = faker.randomDate(startDate, endDate);
                        TimeRange? targetRange = null;
                        var sessionsResult = from row in table.AsEnumerable()
                                             where row.RowState != DataRowState.Deleted
                                             && row.Field<string>("Mã phòng") == roomId
                                             && row.Field<DateTime>("Ngày chiếu") == date
                                             orderby row.Field<TimeSpan>("Giờ bắt đầu") ascending
                                             select row;
                        if (sessionsResult.Any())
                        {
                            DataRow[] sessions = sessionsResult.ToArray();
                            TimeRange[] ranges = (from row in sessions.AsEnumerable() select new TimeRange(row, movieTable)).ToArray();

                            for (int i = 0; i < sessions.Length; i++)
                            {
                                DataRow session = sessions[i];
                                TimeRange currRange = ranges[i];

                                TimeRange range = new TimeRange()
                                {
                                    Start = currRange.Start - breakTime - duration,
                                    Duration = duration,
                                };
                                if (i != 0)
                                {
                                    if (!range.Overlap(ranges[i - 1]))
                                    {
                                        targetRange = range;
                                        break;
                                    }
                                }
                                range.Start = currRange.End + breakTime;
                                if (i + 1 < sessions.Length)
                                {
                                    if (!range.Overlap(ranges[i + 1]) && range.End.Days == 0)
                                    {
                                        targetRange = range;
                                        break;
                                    }
                                }
                                else if (range.End.Days == 0)
                                {
                                    targetRange = range;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            targetRange = new TimeRange()
                            {
                                Start = startOfDay,
                                Duration = duration,
                            };
                        }
                        if (targetRange != null)
                        {
                            return new Session()
                            {
                                roomId = roomId,
                                movieId = (string)movie[0],
                                date = date,
                                time = targetRange.Start,
                            };
                        }
                    }
                }
            }
            return null;
        }

        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            if (randomSession() is Session sessValue)
            {
                cbPhong.SelectedValue = sessValue.roomId;
                cbPhim.SelectedValue = sessValue.movieId;
                dtNgayChieu.Value = sessValue.date;
                dtGioChieu.Value = Chung.toDate(sessValue.time);
            }
            else
            {
                MessageBox.Show("Hệ thống không thể xếp suất chiếu ngẫu nhiên.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThemNgauNhien_Click(object sender, EventArgs e)
        {
            if (randomSession() is Session sessValue)
            {
                table.Rows.Add(null, sessValue.roomId, sessValue.movieId, sessValue.date, sessValue.time);
            } else
            {
                MessageBox.Show("Hệ thống không thể xếp suất chiếu ngẫu nhiên.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
