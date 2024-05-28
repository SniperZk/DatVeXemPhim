namespace DatVeXemPhim
{
    partial class BaoCaoThongKe
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            ThongKe = new Button();
            dtgv_Cinema = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TenPhim = new ComboBox();
            NgayKhoiChieu = new DateTimePicker();
            NgayChieuCuoi = new DateTimePicker();
            TongDoanhThu = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgv_Cinema).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26F);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(325, 9);
            label1.Name = "label1";
            label1.Size = new Size(364, 60);
            label1.TabIndex = 0;
            label1.Text = "Báo cáo thống kê";
            // 
            // ThongKe
            // 
            ThongKe.Location = new Point(538, 127);
            ThongKe.Name = "ThongKe";
            ThongKe.Size = new Size(169, 70);
            ThongKe.TabIndex = 1;
            ThongKe.Text = "Thống kê";
            ThongKe.UseVisualStyleBackColor = true;
            ThongKe.Click += ThongKe_Click;
            // 
            // dtgv_Cinema
            // 
            dtgv_Cinema.AllowUserToAddRows = false;
            dtgv_Cinema.AllowUserToResizeRows = false;
            dtgv_Cinema.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_Cinema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgv_Cinema.Location = new Point(12, 232);
            dtgv_Cinema.Name = "dtgv_Cinema";
            dtgv_Cinema.ReadOnly = true;
            dtgv_Cinema.RowHeadersVisible = false;
            dtgv_Cinema.RowHeadersWidth = 51;
            dtgv_Cinema.Size = new Size(992, 243);
            dtgv_Cinema.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 4;
            label2.Text = "Tên phim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 129);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 4;
            label3.Text = "Ngày khởi chiếu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 177);
            label4.Name = "label4";
            label4.Size = new Size(115, 20);
            label4.TabIndex = 4;
            label4.Text = "Ngày chiếu cuối";
            // 
            // TenPhim
            // 
            TenPhim.DropDownStyle = ComboBoxStyle.DropDownList;
            TenPhim.FormattingEnabled = true;
            TenPhim.Location = new Point(115, 80);
            TenPhim.Name = "TenPhim";
            TenPhim.Size = new Size(411, 28);
            TenPhim.TabIndex = 5;
            // 
            // NgayKhoiChieu
            // 
            NgayKhoiChieu.Format = DateTimePickerFormat.Short;
            NgayKhoiChieu.Location = new Point(146, 129);
            NgayKhoiChieu.Name = "NgayKhoiChieu";
            NgayKhoiChieu.Size = new Size(159, 27);
            NgayKhoiChieu.TabIndex = 6;
            // 
            // NgayChieuCuoi
            // 
            NgayChieuCuoi.Format = DateTimePickerFormat.Short;
            NgayChieuCuoi.Location = new Point(146, 170);
            NgayChieuCuoi.Name = "NgayChieuCuoi";
            NgayChieuCuoi.Size = new Size(159, 27);
            NgayChieuCuoi.TabIndex = 6;
            // 
            // TongDoanhThu
            // 
            TongDoanhThu.Location = new Point(828, 508);
            TongDoanhThu.Name = "TongDoanhThu";
            TongDoanhThu.ReadOnly = true;
            TongDoanhThu.Size = new Size(125, 27);
            TongDoanhThu.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(671, 515);
            label5.Name = "label5";
            label5.Size = new Size(140, 20);
            label5.TabIndex = 8;
            label5.Text = "TỔNG DOANH THU";
            // 
            // BaoCaoThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 611);
            Controls.Add(label5);
            Controls.Add(TongDoanhThu);
            Controls.Add(NgayChieuCuoi);
            Controls.Add(NgayKhoiChieu);
            Controls.Add(TenPhim);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtgv_Cinema);
            Controls.Add(ThongKe);
            Controls.Add(label1);
            Name = "BaoCaoThongKe";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dtgv_Cinema).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ThongKe;
        private DataGridView dtgv_Cinema;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox TenPhim;
        private DateTimePicker NgayKhoiChieu;
        private DateTimePicker NgayChieuCuoi;
        private TextBox TongDoanhThu;
        private Label label5;
    }
}
