namespace DatVeXemPhim
{
    partial class ChonPhimVaCongChieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChonPhimVaCongChieu));
            label1 = new Label();
            grpLuaChon = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            dtpNgayChieu = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            cboSuatChieu = new ComboBox();
            cboDoTuoi = new ComboBox();
            cboFilm = new ComboBox();
            chkDoTuoi = new CheckBox();
            label6 = new Label();
            label5 = new Label();
            txtGioKetThuc = new TextBox();
            txtGioBatDau = new TextBox();
            grpChucNang = new GroupBox();
            btnDatVe = new Button();
            btnThoat = new Button();
            txtKetQua = new TextBox();
            grpSCDC = new GroupBox();
            pictureBox2 = new PictureBox();
            grpLuaChon.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            grpChucNang.SuspendLayout();
            grpSCDC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.MistyRose;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(27, 9);
            label1.Name = "label1";
            label1.Size = new Size(467, 31);
            label1.TabIndex = 0;
            label1.Text = "CHỨC NĂNG CHỌN PHIM VÀ SUẤT CHIẾU";
            // 
            // grpLuaChon
            // 
            grpLuaChon.Controls.Add(tableLayoutPanel1);
            grpLuaChon.ForeColor = Color.Red;
            grpLuaChon.Location = new Point(27, 58);
            grpLuaChon.Name = "grpLuaChon";
            grpLuaChon.Size = new Size(467, 240);
            grpLuaChon.TabIndex = 1;
            grpLuaChon.TabStop = false;
            grpLuaChon.Text = "LỰA CHỌN";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(dtpNgayChieu, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(cboSuatChieu, 1, 3);
            tableLayoutPanel1.Controls.Add(cboDoTuoi, 1, 1);
            tableLayoutPanel1.Controls.Add(cboFilm, 1, 2);
            tableLayoutPanel1.Controls.Add(chkDoTuoi, 0, 1);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(txtGioKetThuc, 1, 5);
            tableLayoutPanel1.Controls.Add(txtGioBatDau, 1, 4);
            tableLayoutPanel1.Location = new Point(0, 32);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(467, 208);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.TabStop = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.MistyRose;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 0;
            label2.Text = "NGÀY CHIẾU";
            // 
            // dtpNgayChieu
            // 
            dtpNgayChieu.CalendarForeColor = Color.Black;
            dtpNgayChieu.Checked = false;
            dtpNgayChieu.Format = DateTimePickerFormat.Short;
            dtpNgayChieu.Location = new Point(114, 3);
            dtpNgayChieu.Name = "dtpNgayChieu";
            dtpNgayChieu.Size = new Size(144, 27);
            dtpNgayChieu.TabIndex = 1;
            dtpNgayChieu.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            dtpNgayChieu.ValueChanged += dtpNgayChieu_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.MistyRose;
            label4.Location = new Point(3, 101);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 0;
            label4.Text = "SUẤT CHIẾU";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.MistyRose;
            label3.Location = new Point(3, 67);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 0;
            label3.Text = "FILM";
            // 
            // cboSuatChieu
            // 
            cboSuatChieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSuatChieu.FormattingEnabled = true;
            cboSuatChieu.Location = new Point(114, 104);
            cboSuatChieu.Name = "cboSuatChieu";
            cboSuatChieu.Size = new Size(253, 28);
            cboSuatChieu.TabIndex = 2;
            cboSuatChieu.SelectedIndexChanged += cboSuatChieu_SelectedIndexChanged;
            // 
            // cboDoTuoi
            // 
            cboDoTuoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoTuoi.FormattingEnabled = true;
            cboDoTuoi.Location = new Point(114, 36);
            cboDoTuoi.Name = "cboDoTuoi";
            cboDoTuoi.Size = new Size(151, 28);
            cboDoTuoi.TabIndex = 5;
            cboDoTuoi.SelectedIndexChanged += cboDoTuoi_SelectedIndexChanged;
            // 
            // cboFilm
            // 
            cboFilm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilm.FormattingEnabled = true;
            cboFilm.Location = new Point(114, 70);
            cboFilm.Name = "cboFilm";
            cboFilm.Size = new Size(318, 28);
            cboFilm.TabIndex = 2;
            cboFilm.SelectedIndexChanged += cboFilm_SelectedIndexChanged;
            // 
            // chkDoTuoi
            // 
            chkDoTuoi.AutoSize = true;
            chkDoTuoi.BackColor = Color.MistyRose;
            chkDoTuoi.Location = new Point(3, 36);
            chkDoTuoi.Name = "chkDoTuoi";
            chkDoTuoi.Size = new Size(90, 24);
            chkDoTuoi.TabIndex = 6;
            chkDoTuoi.Text = "ĐỘ TUỔI";
            chkDoTuoi.UseVisualStyleBackColor = false;
            chkDoTuoi.CheckedChanged += chkDoTuoi_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.MistyRose;
            label6.Location = new Point(3, 168);
            label6.Name = "label6";
            label6.Size = new Size(105, 20);
            label6.TabIndex = 0;
            label6.Text = "GIỜ KẾT THÚC";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.MistyRose;
            label5.Location = new Point(3, 135);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 0;
            label5.Text = "GIỜ BẮT ĐẦU";
            // 
            // txtGioKetThuc
            // 
            txtGioKetThuc.Location = new Point(114, 171);
            txtGioKetThuc.Name = "txtGioKetThuc";
            txtGioKetThuc.ReadOnly = true;
            txtGioKetThuc.Size = new Size(125, 27);
            txtGioKetThuc.TabIndex = 3;
            txtGioKetThuc.TextAlign = HorizontalAlignment.Center;
            // 
            // txtGioBatDau
            // 
            txtGioBatDau.Location = new Point(114, 138);
            txtGioBatDau.Name = "txtGioBatDau";
            txtGioBatDau.ReadOnly = true;
            txtGioBatDau.Size = new Size(125, 27);
            txtGioBatDau.TabIndex = 3;
            txtGioBatDau.TextAlign = HorizontalAlignment.Center;
            // 
            // grpChucNang
            // 
            grpChucNang.Controls.Add(btnDatVe);
            grpChucNang.Controls.Add(btnThoat);
            grpChucNang.ForeColor = Color.Red;
            grpChucNang.Location = new Point(27, 316);
            grpChucNang.Name = "grpChucNang";
            grpChucNang.Size = new Size(124, 99);
            grpChucNang.TabIndex = 2;
            grpChucNang.TabStop = false;
            grpChucNang.Text = "CHỨC NĂNG";
            // 
            // btnDatVe
            // 
            btnDatVe.BackColor = Color.MistyRose;
            btnDatVe.DialogResult = DialogResult.OK;
            btnDatVe.Location = new Point(6, 26);
            btnDatVe.Name = "btnDatVe";
            btnDatVe.Size = new Size(104, 29);
            btnDatVe.TabIndex = 0;
            btnDatVe.Text = "CHỌN";
            btnDatVe.UseVisualStyleBackColor = false;
            btnDatVe.Click += btnDatVe_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.MistyRose;
            btnThoat.DialogResult = DialogResult.Cancel;
            btnThoat.Location = new Point(6, 61);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(104, 29);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtKetQua
            // 
            txtKetQua.Location = new Point(0, 26);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.Size = new Size(337, 163);
            txtKetQua.TabIndex = 3;
            // 
            // grpSCDC
            // 
            grpSCDC.Controls.Add(txtKetQua);
            grpSCDC.ForeColor = Color.Red;
            grpSCDC.Location = new Point(157, 316);
            grpSCDC.Name = "grpSCDC";
            grpSCDC.Size = new Size(337, 189);
            grpSCDC.TabIndex = 4;
            grpSCDC.TabStop = false;
            grpSCDC.Text = "SUẤT CHIẾU ĐÃ CHỌN";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(27, 421);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(124, 84);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // ChonPhimVaCongChieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Thistle;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(516, 517);
            Controls.Add(pictureBox2);
            Controls.Add(grpSCDC);
            Controls.Add(grpChucNang);
            Controls.Add(grpLuaChon);
            Controls.Add(label1);
            Name = "ChonPhimVaCongChieu";
            Text = "Chọn phim và suất chiếu";
            Load += ChonPhimVaCongChieu_Load;
            grpLuaChon.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            grpChucNang.ResumeLayout(false);
            grpSCDC.ResumeLayout(false);
            grpSCDC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox grpLuaChon;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox grpChucNang;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cboFilm;
        private ComboBox cboSuatChieu;
        private TextBox txtGioBatDau;
        private TextBox txtGioKetThuc;
        private Button btnDatVe;
        private Button btnThoat;
        private DateTimePicker dtpNgayChieu;
        private TextBox txtKetQua;
        private GroupBox grpSCDC;
        private ComboBox cboDoTuoi;
        private CheckBox chkDoTuoi;
        private PictureBox pictureBox2;
    }
}
