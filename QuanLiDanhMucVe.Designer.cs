namespace DatVeXemPhim
{
    partial class QuanLiDanhMucVe
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            groupBox2 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            cbSuatChieu = new ComboBox();
            btnDuyetSuat = new Button();
            label2 = new Label();
            label3 = new Label();
            cbGhe = new ComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            numGia = new NumericUpDown();
            label8 = new Label();
            label4 = new Label();
            label6 = new Label();
            cbTrangThai = new ComboBox();
            label1 = new Label();
            gbGhe = new GroupBox();
            dataView = new DataGridView();
            btnLuu = new Button();
            btnTaiLai = new Button();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numGia).BeginInit();
            gbGhe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            SuspendLayout();
            // 
            // btnXoa
            // 
            btnXoa.Enabled = false;
            btnXoa.Location = new Point(174, 177);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 32);
            btnXoa.TabIndex = 29;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Enabled = false;
            btnSua.Location = new Point(93, 177);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 32);
            btnSua.TabIndex = 28;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(12, 177);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 32);
            btnThem.TabIndex = 27;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox2.Controls.Add(tableLayoutPanel2);
            groupBox2.Location = new Point(12, 57);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(629, 113);
            groupBox2.TabIndex = 33;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin vé";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 1, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(label3, 2, 0);
            tableLayoutPanel2.Controls.Add(cbGhe, 3, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel2.Controls.Add(label4, 2, 1);
            tableLayoutPanel2.Controls.Add(label6, 0, 1);
            tableLayoutPanel2.Controls.Add(cbTrangThai, 3, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 23);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(623, 87);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(cbSuatChieu);
            flowLayoutPanel2.Controls.Add(btnDuyetSuat);
            flowLayoutPanel2.Location = new Point(86, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(296, 40);
            flowLayoutPanel2.TabIndex = 34;
            // 
            // cbSuatChieu
            // 
            cbSuatChieu.Anchor = AnchorStyles.Left;
            cbSuatChieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSuatChieu.FormattingEnabled = true;
            cbSuatChieu.Location = new Point(3, 6);
            cbSuatChieu.Margin = new Padding(3, 4, 3, 4);
            cbSuatChieu.Name = "cbSuatChieu";
            cbSuatChieu.Size = new Size(209, 28);
            cbSuatChieu.TabIndex = 2;
            cbSuatChieu.SelectedIndexChanged += cbSuatChieu_SelectedIndexChanged;
            // 
            // btnDuyetSuat
            // 
            btnDuyetSuat.Location = new Point(218, 4);
            btnDuyetSuat.Margin = new Padding(3, 4, 3, 4);
            btnDuyetSuat.Name = "btnDuyetSuat";
            btnDuyetSuat.Size = new Size(75, 32);
            btnDuyetSuat.TabIndex = 27;
            btnDuyetSuat.Text = "Duyệt";
            btnDuyetSuat.UseVisualStyleBackColor = true;
            btnDuyetSuat.Click += btnDuyetSuat_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(3, 13);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 0;
            label2.Text = "Suất chiếu";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(428, 13);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 0;
            label3.Text = "Ghế";
            // 
            // cbGhe
            // 
            cbGhe.Anchor = AnchorStyles.Left;
            cbGhe.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGhe.FormattingEnabled = true;
            cbGhe.Location = new Point(469, 9);
            cbGhe.Margin = new Padding(3, 4, 3, 4);
            cbGhe.Name = "cbGhe";
            cbGhe.Size = new Size(150, 28);
            cbGhe.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(numGia);
            flowLayoutPanel1.Controls.Add(label8);
            flowLayoutPanel1.Location = new Point(86, 49);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(180, 35);
            flowLayoutPanel1.TabIndex = 34;
            flowLayoutPanel1.WrapContents = false;
            // 
            // numGia
            // 
            numGia.Anchor = AnchorStyles.Left;
            numGia.Increment = new decimal(new int[] { 20000, 0, 0, 0 });
            numGia.Location = new Point(3, 4);
            numGia.Margin = new Padding(3, 4, 3, 4);
            numGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numGia.Name = "numGia";
            numGia.Size = new Size(150, 27);
            numGia.TabIndex = 3;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(159, 7);
            label8.Name = "label8";
            label8.Size = new Size(18, 20);
            label8.TabIndex = 0;
            label8.Text = "₫";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(388, 56);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 0;
            label4.Text = "Trạng thái";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(30, 56);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 0;
            label6.Text = "Giá vé";
            // 
            // cbTrangThai
            // 
            cbTrangThai.Anchor = AnchorStyles.Left;
            cbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Location = new Point(469, 52);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(151, 28);
            cbTrangThai.TabIndex = 35;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 254);
            label1.Location = new Point(399, 22);
            label1.Name = "label1";
            label1.Size = new Size(144, 29);
            label1.TabIndex = 25;
            label1.Text = "Quản lý vé";
            // 
            // gbGhe
            // 
            gbGhe.Controls.Add(dataView);
            gbGhe.Location = new Point(18, 213);
            gbGhe.Name = "gbGhe";
            gbGhe.Size = new Size(888, 371);
            gbGhe.TabIndex = 32;
            gbGhe.TabStop = false;
            gbGhe.Text = "Danh sách vé (0)";
            // 
            // dataView
            // 
            dataView.AllowUserToAddRows = false;
            dataView.AllowUserToDeleteRows = false;
            dataView.AllowUserToResizeRows = false;
            dataView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 254);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView.Location = new Point(7, 27);
            dataView.Margin = new Padding(3, 4, 3, 4);
            dataView.Name = "dataView";
            dataView.ReadOnly = true;
            dataView.RowHeadersVisible = false;
            dataView.RowHeadersWidth = 51;
            dataView.RowTemplate.Height = 24;
            dataView.RowTemplate.ReadOnly = true;
            dataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataView.Size = new Size(875, 337);
            dataView.TabIndex = 20;
            dataView.CellDoubleClick += dataView_CellDoubleClick;
            dataView.CellFormatting += dataView_CellFormatting;
            dataView.ColumnAdded += dataView_ColumnAdded;
            dataView.SelectionChanged += dataView_SelectionChanged;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(831, 591);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 32);
            btnLuu.TabIndex = 31;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(750, 591);
            btnTaiLai.Margin = new Padding(3, 4, 3, 4);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(75, 32);
            btnTaiLai.TabIndex = 30;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // QuanLiDanhMucVe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 636);
            Controls.Add(groupBox2);
            Controls.Add(gbGhe);
            Controls.Add(btnLuu);
            Controls.Add(btnTaiLai);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(label1);
            Name = "QuanLiDanhMucVe";
            Text = "Quản lý danh mục vé";
            Load += QuanLiDanhMucVe_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numGia).EndInit();
            gbGhe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGhe;
        private System.Windows.Forms.ComboBox cbSuatChieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbGhe;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnDuyetSuat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTrangThai;
    }
}