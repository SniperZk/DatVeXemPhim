namespace DatVeXemPhim
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            txtMatKhau = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtConfirm = new TextBox();
            checkShowPass = new CheckBox();
            butRegister = new Button();
            label5 = new Label();
            label_ĐangNhap = new Label();
            label6 = new Label();
            txtSDT = new TextBox();
            label7 = new Label();
            dateNgayThangNamSinh = new DateTimePicker();
            errorProvider = new ErrorProvider(components);
            label8 = new Label();
            txtDiaChi = new TextBox();
            label9 = new Label();
            txtHoten = new TextBox();
            label10 = new Label();
            cbGioiTinh = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(677, 219);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(238, 27);
            txtPassword.TabIndex = 6;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(677, 153);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(238, 27);
            txtUsername.TabIndex = 5;
            // 
            // txtMatKhau
            // 
            txtMatKhau.AutoSize = true;
            txtMatKhau.Location = new Point(521, 222);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(70, 20);
            txtMatKhau.TabIndex = 6;
            txtMatKhau.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(521, 156);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 5;
            label2.Text = "Tên đăng nhập";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(493, 29);
            label1.Name = "label1";
            label1.Size = new Size(132, 39);
            label1.TabIndex = 9;
            label1.Text = "Đăng kí";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 164);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 10;
            label3.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(193, 153);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(238, 27);
            txtEmail.TabIndex = 1;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(521, 300);
            label4.Name = "label4";
            label4.Size = new Size(134, 20);
            label4.TabIndex = 12;
            label4.Text = "Xác nhận mật khẩu";
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(677, 293);
            txtConfirm.Margin = new Padding(3, 4, 3, 4);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(238, 27);
            txtConfirm.TabIndex = 8;
            txtConfirm.TextChanged += txtConfirm_TextChanged;
            txtConfirm.Leave += txtConfirm_Leave;
            // 
            // checkShowPass
            // 
            checkShowPass.AutoSize = true;
            checkShowPass.Location = new Point(921, 219);
            checkShowPass.Margin = new Padding(3, 4, 3, 4);
            checkShowPass.Name = "checkShowPass";
            checkShowPass.Size = new Size(127, 24);
            checkShowPass.TabIndex = 7;
            checkShowPass.Text = "Hiện mật khẩu";
            checkShowPass.UseVisualStyleBackColor = true;
            checkShowPass.CheckedChanged += checkShowPass_CheckedChanged;
            // 
            // butRegister
            // 
            butRegister.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butRegister.Location = new Point(294, 512);
            butRegister.Margin = new Padding(3, 4, 3, 4);
            butRegister.Name = "butRegister";
            butRegister.Size = new Size(125, 40);
            butRegister.TabIndex = 10;
            butRegister.Text = "Đăng kí";
            butRegister.UseVisualStyleBackColor = true;
            butRegister.Click += butRegister_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(511, 524);
            label5.Name = "label5";
            label5.Size = new Size(256, 20);
            label5.TabIndex = 16;
            label5.Text = "Nếu đã có tài khoản thì quay lại phần";
            // 
            // label_ĐangNhap
            // 
            label_ĐangNhap.AutoSize = true;
            label_ĐangNhap.ForeColor = SystemColors.MenuHighlight;
            label_ĐangNhap.Location = new Point(773, 524);
            label_ĐangNhap.Name = "label_ĐangNhap";
            label_ĐangNhap.Size = new Size(82, 20);
            label_ĐangNhap.TabIndex = 17;
            label_ĐangNhap.Text = "Đăng nhập";
            label_ĐangNhap.Click += label_ĐangNhap_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(521, 383);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 18;
            label6.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(677, 379);
            txtSDT.Margin = new Padding(3, 4, 3, 4);
            txtSDT.MaxLength = 10;
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(238, 27);
            txtSDT.TabIndex = 9;
            txtSDT.KeyPress += txtSDT_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 458);
            label7.Name = "label7";
            label7.Size = new Size(153, 20);
            label7.TabIndex = 20;
            label7.Text = "Ngày tháng năm sinh ";
            // 
            // dateNgayThangNamSinh
            // 
            dateNgayThangNamSinh.Location = new Point(193, 453);
            dateNgayThangNamSinh.Margin = new Padding(3, 4, 3, 4);
            dateNgayThangNamSinh.Name = "dateNgayThangNamSinh";
            dateNgayThangNamSinh.Size = new Size(238, 27);
            dateNgayThangNamSinh.TabIndex = 21;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(22, 382);
            label8.Name = "label8";
            label8.Size = new Size(55, 20);
            label8.TabIndex = 22;
            label8.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(193, 380);
            txtDiaChi.Margin = new Padding(3, 4, 3, 4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(238, 27);
            txtDiaChi.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 296);
            label9.Name = "label9";
            label9.Size = new Size(73, 20);
            label9.TabIndex = 24;
            label9.Text = "Họ và tên";
            // 
            // txtHoten
            // 
            txtHoten.Location = new Point(193, 293);
            txtHoten.Margin = new Padding(3, 4, 3, 4);
            txtHoten.Name = "txtHoten";
            txtHoten.Size = new Size(238, 27);
            txtHoten.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(22, 232);
            label10.Name = "label10";
            label10.Size = new Size(65, 20);
            label10.TabIndex = 26;
            label10.Text = "Giới tính";
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.FormattingEnabled = true;
            cbGioiTinh.Location = new Point(193, 229);
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(238, 28);
            cbGioiTinh.TabIndex = 2;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 600);
            Controls.Add(cbGioiTinh);
            Controls.Add(label10);
            Controls.Add(txtHoten);
            Controls.Add(label9);
            Controls.Add(txtDiaChi);
            Controls.Add(label8);
            Controls.Add(dateNgayThangNamSinh);
            Controls.Add(label7);
            Controls.Add(txtSDT);
            Controls.Add(label6);
            Controls.Add(label_ĐangNhap);
            Controls.Add(label5);
            Controls.Add(butRegister);
            Controls.Add(checkShowPass);
            Controls.Add(txtConfirm);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtMatKhau);
            Controls.Add(label2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label txtMatKhau;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtConfirm;
        private CheckBox checkShowPass;
        private Button butRegister;
        private Label label5;
        private Label label_ĐangNhap;
        private Label label6;
        private TextBox txtSDT;
        private Label label7;
        private DateTimePicker dateNgayThangNamSinh;
        private ErrorProvider errorProvider;
        private TextBox txtDiaChi;
        private Label label8;
        private Label label9;
        private TextBox txtHoten;
        private Label label10;
        private ComboBox cbGioiTinh;
    }
}