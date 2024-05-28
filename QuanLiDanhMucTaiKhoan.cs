using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DatVeXemPhim.Utils;

namespace DatVeXemPhim
{
    public partial class QuanLiDanhMucTaiKhoan : Form
    {
        private DataTable table = new DataTable();
        private DataTable roleTable = new DataTable();
        private SqLiem sqliem;
        private Faker faker = new Faker();

        public class Account
        {
            public required string role;
            public required string fullName;
            public required string gender;
            public required string sdt;
            public required DateTime dateOfBirth;
            public required string email;
            public required string address;
            public required string username;
            public required string password;
        }

        public QuanLiDanhMucTaiKhoan()
        {
            InitializeComponent();

            sqliem = new SqLiem(@"SELECT
ID_TAIKHOAN AS [Mã tài khoản],
ID_VAITRO AS [Mã vai trò],
HOTEN AS [Họ và tên],
GIOITINH AS [Giới tính],
SDT AS [Số điện thoại],
NGAYSINH AS [Ngày sinh],
EMAIL AS [Địa chỉ email],
DIACHI AS [Địa chỉ],
TENDANGNHAP AS [Tên đăng nhập],
MATKHAU AS [Mật khẩu]
FROM TAIKHOAN", Constants.CONNECTION_STRING);
        }

        private bool checkValidInputs(bool addMode)
        {
            if (!Chung.checkEmptyComboBox(cbVaiTro, "Vui lòng chọn vai trò."))
            {
                return false;
            }
            if (!Chung.checkEmptyTextBox(txtHoTen, "Vui lòng nhập họ và tên."))
            {
                return false;
            }
            if (!txtSdt.MaskCompleted)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                MailAddress mail = new MailAddress(txtEmail.Text);
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email hợp lệ", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Chung.checkEmptyTextBox(txtDiaChi, "Vui lòng nhập địa chỉ."))
            {
                return false;
            }
            if (!Chung.checkEmptyTextBox(txtTenDangNhap, "Vui lòng nhập tên đăng nhập."))
            {
                return false;
            }
            DataRow? row = table.Select($"[Tên đăng nhập] = '{txtTenDangNhap.Text.Trim()}'").FirstOrDefault();
            if (row != null && (addMode || row != ((DataRowView)dataView.SelectedRows[0].DataBoundItem).Row))
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Chung.checkEmptyTextBox(txtMatKhau, "Vui lòng nhập mật khẩu."))
            {
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkValidInputs(true))
            {
                return;
            }

            table.Rows.Add(null, cbVaiTro.SelectedValue, txtHoTen.Text, cbGioiTinh.Text,
                txtSdt.Text, dtNgaySinh.Value.Date, txtEmail.Text, txtDiaChi.Text,
                txtTenDangNhap.Text, txtMatKhau.Text);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count != 1)
            {
                return;
            }
            if (!checkValidInputs(false))
            {
                return;
            }

            Chung.changeSelectedViewRow(dataView, NoParam.Value, cbVaiTro.SelectedValue,
                txtHoTen.Text, cbGioiTinh.Text, txtSdt.Text, dtNgaySinh.Value.Date,
                txtEmail.Text, txtDiaChi.Text, txtTenDangNhap.Text, txtMatKhau.Text);
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
            cbVaiTro.SelectedValue = (string)row.Cells[colIndex++].Value;
            txtHoTen.Text = (string)row.Cells[colIndex++].Value;
            cbGioiTinh.SelectedValue = (string)row.Cells[colIndex++].Value;
            txtSdt.Text = row.Cells[colIndex++].Value.ToString()?.PadLeft(10, '0');
            dtNgaySinh.Value = (DateTime)row.Cells[colIndex++].Value;
            txtEmail.Text = (string)row.Cells[colIndex++].Value;
            txtDiaChi.Text = (string)row.Cells[colIndex++].Value;
            txtTenDangNhap.Text = (string)row.Cells[colIndex++].Value;
            txtMatKhau.Text = (string)row.Cells[colIndex++].Value;
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = dataView.SelectedRows.Count == 1;
            btnXoa.Enabled = dataView.SelectedRows.Count > 0;
        }

        private void loadOtherTables()
        {
            roleTable = sqliem.selectToTable("SELECT ID_VAITRO, TENVAITRO FROM VAITRO");
            cbVaiTro.DisplayMember = "TENVAITRO";
            cbVaiTro.ValueMember = "ID_VAITRO";
            cbVaiTro.DataSource = roleTable;
        }

        private void QuanLiDanhMucTaiKhoan_Load(object sender, EventArgs e)
        {
            using (new WaitGuard(Cursors.AppStarting))
            {
                cbGioiTinh.Items.AddRange(Constants.GENDERS);
                cbGioiTinh.SelectedIndex = 0;

                Chung.bindGroupBoxToTable(gbTaiKhoan, table, "Danh mục tài khoản ({0})");
                Chung.setDoubleBuffered(dataView);

                try
                {
                    sqliem.load(table);
                    loadOtherTables();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                dataView.DataSource = table;
            }
        }

        private void dataView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (dataView.Columns.Count == 10)
            {
                _ = Chung.addFakeColumnToView(dataView, "TENVAITRO", "Tên vai trò", "Mã vai trò");

                var cellTemplate = new DataGridViewAutoUpdateOthersCell() { IdColumnName = "Mã vai trò", Table = roleTable };
                cellTemplate.AddBinding("TENVAITRO");
                dataView.Columns["Mã vai trò"].CellTemplate = cellTemplate;
            }
        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = (e.Value?.ToString()!).PadLeft(10, '0');
                e.FormattingApplied = true;
            }
        }

        private void btnRong_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSdt.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }

        private Account randomAccount()
        {
            string fullName = "";
            string gender = "";
            switch (faker.randInt(11))
            {
                case 0:
                    {
                        fullName = faker.randomFullName();
                        gender = "Khác";
                        break;
                    }
                case >= 1 and <= 5:
                    {
                        fullName = faker.randomFullName(true);
                        gender = "Nam";
                        break;
                    }
                case >= 6 and <= 10:
                    {
                        fullName = faker.randomFullName(false);
                        gender = "Nữ";
                        break;
                    }
            }

            string username = faker.randomPronounceableName(10);
            while (table.Select($"[Tên đăng nhập] = '{username}'").Any())
            {
                username = faker.randomPronounceableName(10);
            }

            return new Account()
            {
                role = (string)roleTable.Select($"TENVAITRO = 'Khách hàng'").FirstOrDefault()![0],
                fullName = fullName,
                gender = gender,
                sdt = faker.randInt(1000000000).ToString()?.PadLeft(10, '0')!,
                dateOfBirth = faker.randomDate(new DateTime(1900, 1, 1), DateTime.Now.Date),
                email = faker.randomEmail(fullName),
                address = faker.randomProvince(),
                username = username,
                password = "123456789"
            };
        }

        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            Account account = randomAccount();
            cbVaiTro.SelectedValue = account.role;
            txtHoTen.Text = account.fullName;
            cbGioiTinh.Text = account.gender;
            txtSdt.Text = account.sdt;
            dtNgaySinh.Value = account.dateOfBirth;
            txtEmail.Text = account.email;
            txtDiaChi.Text = account.address;
            txtTenDangNhap.Text = account.username;
            txtMatKhau.Text = account.password;
        }

        private void btnThemNgauNhien_Click(object sender, EventArgs e)
        {
            Account account = randomAccount();

            table.Rows.Add(null, account.role, account.fullName, account.gender,
                account.sdt, account.dateOfBirth, account.email, account.address,
                account.username, account.password);
        }
    }
}
