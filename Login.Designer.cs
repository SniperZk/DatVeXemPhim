namespace DatVeXemPhim
{
    partial class Login
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
            label1 = new Label();
            label2 = new Label();
            txtMatKhau = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            butLogin = new Button();
            butClear = new Button();
            checkShowPass = new CheckBox();
            label3 = new Label();
            label_DangKi = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(288, 43);
            label1.Name = "label1";
            label1.Size = new Size(182, 45);
            label1.TabIndex = 0;
            label1.Text = "Đăng nhập";
            label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 173);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập";
            // 
            // txtMatKhau
            // 
            txtMatKhau.AutoSize = true;
            txtMatKhau.Location = new Point(122, 295);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(70, 20);
            txtMatKhau.TabIndex = 2;
            txtMatKhau.Text = "Mật khẩu";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(323, 169);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(238, 27);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(323, 289);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(238, 27);
            txtPassword.TabIndex = 4;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // butLogin
            // 
            butLogin.Location = new Point(122, 399);
            butLogin.Margin = new Padding(3, 4, 3, 4);
            butLogin.Name = "butLogin";
            butLogin.Size = new Size(102, 31);
            butLogin.TabIndex = 5;
            butLogin.Text = "Đăng nhập";
            butLogin.UseVisualStyleBackColor = true;
            butLogin.Click += butLogin_Click;
            // 
            // butClear
            // 
            butClear.Location = new Point(477, 399);
            butClear.Margin = new Padding(3, 4, 3, 4);
            butClear.Name = "butClear";
            butClear.Size = new Size(86, 31);
            butClear.TabIndex = 6;
            butClear.Text = "Clear";
            butClear.UseVisualStyleBackColor = true;
            butClear.Click += butClear_Click;
            // 
            // checkShowPass
            // 
            checkShowPass.AutoSize = true;
            checkShowPass.Location = new Point(605, 295);
            checkShowPass.Margin = new Padding(3, 4, 3, 4);
            checkShowPass.Name = "checkShowPass";
            checkShowPass.Size = new Size(127, 24);
            checkShowPass.TabIndex = 7;
            checkShowPass.Text = "Hiện mật khẩu";
            checkShowPass.UseVisualStyleBackColor = true;
            checkShowPass.CheckedChanged += checkShowPass_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(477, 497);
            label3.Name = "label3";
            label3.Size = new Size(246, 20);
            label3.TabIndex = 8;
            label3.Text = "Nếu không có tài khoản thì hãy vào ";
            // 
            // label_DangKi
            // 
            label_DangKi.AutoSize = true;
            label_DangKi.ForeColor = SystemColors.MenuHighlight;
            label_DangKi.Location = new Point(477, 532);
            label_DangKi.Name = "label_DangKi";
            label_DangKi.Size = new Size(60, 20);
            label_DangKi.TabIndex = 9;
            label_DangKi.Text = "Đăng kí";
            label_DangKi.Click += label_DangKi_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 600);
            Controls.Add(label_DangKi);
            Controls.Add(label3);
            Controls.Add(checkShowPass);
            Controls.Add(butClear);
            Controls.Add(butLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtMatKhau);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label txtMatKhau;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button butLogin;
        private Button butClear;
        private CheckBox checkShowPass;
        private Label label3;
        private Label label_DangKi;
    }
}