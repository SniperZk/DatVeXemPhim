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

namespace DatVeXemPhim
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);

        public Login()
        {
            InitializeComponent();
        }
        private void label_DangKi_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerform = new Register();
            registerform.ShowDialog();
            
            Show();
        }

        private void checkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (checkShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Hãy nhập vào ô trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();
                        String selectData = "select * from TAIKHOAN where TENDANGNHAP = @username and MATKHAU = @passwords";
                        using (SqlCommand cmd = new SqlCommand(selectData, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@passwords", txtPassword.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Đăng nhập thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                login((string)table.Rows[0]["ID_TAIKHOAN"]);
                            }
                            else
                            {
                                MessageBox.Show("Nhập không đúng tên đăng nhập / mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không kết nối được server: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txtPassword.ResetText();
            txtUsername.ResetText();
        }

        private void login(string userId)
        {
            Hide();
            var dialog = new ManHinhChinh(userId);
            dialog.ShowDialog();

            if (dialog.shouldExit)
            {
                Application.Exit();
            } else
            {
                txtPassword.ResetText();
                txtUsername.ResetText();
                Show();
            }
        }
    }
}
