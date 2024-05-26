namespace DatVeXemPhim
{
    partial class QuanLiDanhMucVaiTro
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            gbVaiTro = new GroupBox();
            dataView = new DataGridView();
            btnLuu = new Button();
            btnTaiLai = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            btnRong = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            txtTen = new TextBox();
            label1 = new Label();
            gbVaiTro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // gbVaiTro
            // 
            gbVaiTro.Controls.Add(dataView);
            gbVaiTro.Location = new Point(12, 175);
            gbVaiTro.Name = "gbVaiTro";
            gbVaiTro.Size = new Size(554, 377);
            gbVaiTro.TabIndex = 37;
            gbVaiTro.TabStop = false;
            gbVaiTro.Text = "Danh mục vai trò (0)";
            // 
            // dataView
            // 
            dataView.AllowUserToAddRows = false;
            dataView.AllowUserToDeleteRows = false;
            dataView.AllowUserToResizeRows = false;
            dataView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 254);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView.Location = new Point(6, 27);
            dataView.Margin = new Padding(3, 4, 3, 4);
            dataView.MultiSelect = false;
            dataView.Name = "dataView";
            dataView.ReadOnly = true;
            dataView.RowHeadersVisible = false;
            dataView.RowHeadersWidth = 51;
            dataView.RowTemplate.Height = 24;
            dataView.RowTemplate.ReadOnly = true;
            dataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataView.Size = new Size(542, 343);
            dataView.TabIndex = 25;
            dataView.CellDoubleClick += dataView_CellDoubleClick;
            dataView.SelectionChanged += dataView_SelectionChanged;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuu.Location = new Point(490, 559);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 32);
            btnLuu.TabIndex = 36;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTaiLai.Location = new Point(409, 559);
            btnTaiLai.Margin = new Padding(3, 4, 3, 4);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(75, 32);
            btnTaiLai.TabIndex = 35;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // btnXoa
            // 
            btnXoa.Enabled = false;
            btnXoa.Location = new Point(174, 136);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 32);
            btnXoa.TabIndex = 34;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Enabled = false;
            btnSua.Location = new Point(93, 136);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 32);
            btnSua.TabIndex = 33;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(12, 136);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 32);
            btnThem.TabIndex = 32;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnRong
            // 
            btnRong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRong.Location = new Point(409, 86);
            btnRong.Margin = new Padding(3, 4, 3, 4);
            btnRong.Name = "btnRong";
            btnRong.Size = new Size(111, 32);
            btnRong.TabIndex = 31;
            btnRong.Text = "Xoá nhập liệu";
            btnRong.UseVisualStyleBackColor = true;
            btnRong.Click += btnRong_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtTen);
            groupBox1.Location = new Point(12, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(391, 70);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin vai trò";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(6, 31);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 2;
            label2.Text = "Tên vai trò";
            // 
            // txtTen
            // 
            txtTen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTen.Location = new Point(90, 28);
            txtTen.Margin = new Padding(3, 4, 3, 4);
            txtTen.MaxLength = 100;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(289, 27);
            txtTen.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 254);
            label1.Location = new Point(128, 15);
            label1.Name = "label1";
            label1.Size = new Size(319, 29);
            label1.TabIndex = 29;
            label1.Text = "Quản lý danh mục vai trò";
            // 
            // QuanLiDanhMucVaiTro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 607);
            Controls.Add(gbVaiTro);
            Controls.Add(btnLuu);
            Controls.Add(btnTaiLai);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnRong);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "QuanLiDanhMucVaiTro";
            Text = "Quản lý danh mục vai trò";
            Load += QuanLiDanhMucVaiTro_Load;
            gbVaiTro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbVaiTro;
        private DataGridView dataView;
        private Button btnLuu;
        private Button btnTaiLai;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnRong;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtTen;
        private Label label1;
    }
}