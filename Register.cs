using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Microsoft.Data.SqlClient;
using DatVeXemPhim.Utils;

namespace DatVeXemPhim
{
    public partial class Register : Form
    {
        SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);

        public Register()
        {
            InitializeComponent();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_ĐangNhap_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtEmail.Text == "" || txtMatKhau.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || txtPassword.Text == "" || txtHoten.Text == "")
            {
                MessageBox.Show("Hãy nhập vào ô trống còn thiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtConfirm.Text != txtPassword.Text)
            {
                MessageBox.Show("Mật khẩu không trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirm.Focus();
                return;
            }
            else
            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();
                        String checkUsersname = "select * from TAIKHOAN where TENDANGNHAP = '" + txtUsername.Text.Trim() + "' ";
                        using (SqlCommand checkUsers = new SqlCommand(checkUsersname, conn))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(checkUsers);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(txtUsername.Text + " tên đăng nhập bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string roleId = "";
                                using (SqlCommand cmd = new SqlCommand("SELECT * FROM VAITRO WHERE TENVAITRO LIKE '%Khách hàng%'", conn))
                                {
                                    using (SqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            var roleInfo = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
                                            roleId = (string)roleInfo["ID_VAITRO"];
                                        }
                                    }
                                }

                                String nhapData = "insert into TAIKHOAN values (@MAVAITRO,@HOTEN,@GIOITINH,@SDT,@NGAYSINH,@EMAIL,@DIACHI,@TENDANGNHAP,@MATKHAU)";
                                DateTime date = DateTime.Today;
                                using (SqlCommand cmd = new SqlCommand(nhapData, conn))
                                {
                                    cmd.Parameters.AddWithValue("@MAVAITRO", roleId);
                                    cmd.Parameters.AddWithValue("@HOTEN", txtHoten.Text.Trim());
                                    cmd.Parameters.AddWithValue("@GIOITINH", cbGioiTinh.Text.Trim());
                                    cmd.Parameters.AddWithValue("@TENDANGNHAP", txtUsername.Text.Trim());
                                    cmd.Parameters.AddWithValue("@MATKHAU", txtPassword.Text.Trim());
                                    cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim());
                                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                                    cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text.Trim());
                                    cmd.Parameters.AddWithValue("@NGAYSINH", date);
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //sau khi dang ki xong thi no se chuyen sang form dang nhap
                                    DialogResult = DialogResult.OK;
                                    Close();
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Khong ket noi duoc voi database" + ex, "Loi khong hien thi duoc tin nhan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }

        private void checkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                //txtConfirm.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                //txtConfirm.PasswordChar = '*';
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (checkShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirm.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirm.PasswordChar = '*';
            }
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirm_Leave(object sender, EventArgs e)
        {
            PasswordsMatch();
        }
        private void PasswordsMatch()
        {
            if (txtConfirm.Text != txtPassword.Text)
            {
                errorProvider.SetError(this.txtConfirm, "");
                txtConfirm.Focus();
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            cbGioiTinh.Items.AddRange(Constants.GENDERS);
            cbGioiTinh.SelectedIndex = 0;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            } else
            {
                e.Handled = true;
            }
        }
    }
}
