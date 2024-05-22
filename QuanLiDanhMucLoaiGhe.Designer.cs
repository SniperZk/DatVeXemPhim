namespace DatVeXemPhim
{
    partial class QuanLiDanhMucLoaiGhe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            btnLuu = new System.Windows.Forms.Button();
            btnTaiLai = new System.Windows.Forms.Button();
            dataView = new System.Windows.Forms.DataGridView();
            btnXoa = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnThem = new System.Windows.Forms.Button();
            btnRong = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            txtTen = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            gbLoaiGhe = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            groupBox1.SuspendLayout();
            gbLoaiGhe.SuspendLayout();
            SuspendLayout();
            // 
            // btnLuu
            // 
            btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnLuu.Location = new System.Drawing.Point(490, 562);
            btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new System.Drawing.Size(75, 32);
            btnLuu.TabIndex = 27;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnTaiLai.Location = new System.Drawing.Point(409, 562);
            btnTaiLai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new System.Drawing.Size(75, 32);
            btnTaiLai.TabIndex = 26;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // dataView
            // 
            dataView.AllowUserToAddRows = false;
            dataView.AllowUserToDeleteRows = false;
            dataView.AllowUserToResizeRows = false;
            dataView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 254);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView.Location = new System.Drawing.Point(6, 27);
            dataView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dataView.MultiSelect = false;
            dataView.Name = "dataView";
            dataView.ReadOnly = true;
            dataView.RowHeadersVisible = false;
            dataView.RowHeadersWidth = 51;
            dataView.RowTemplate.Height = 24;
            dataView.RowTemplate.ReadOnly = true;
            dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataView.Size = new System.Drawing.Size(542, 343);
            dataView.TabIndex = 25;
            dataView.CellDoubleClick += dataView_CellDoubleClick;
            dataView.SelectionChanged += dataView_SelectionChanged;
            // 
            // btnXoa
            // 
            btnXoa.Enabled = false;
            btnXoa.Location = new System.Drawing.Point(174, 139);
            btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(75, 32);
            btnXoa.TabIndex = 24;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Enabled = false;
            btnSua.Location = new System.Drawing.Point(93, 139);
            btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(75, 32);
            btnSua.TabIndex = 23;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new System.Drawing.Point(12, 139);
            btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(75, 32);
            btnThem.TabIndex = 22;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnRong
            // 
            btnRong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRong.Location = new System.Drawing.Point(409, 89);
            btnRong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRong.Name = "btnRong";
            btnRong.Size = new System.Drawing.Size(111, 32);
            btnRong.TabIndex = 21;
            btnRong.Text = "Xoá nhập liệu";
            btnRong.UseVisualStyleBackColor = true;
            btnRong.Click += btnRong_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtTen);
            groupBox1.Location = new System.Drawing.Point(12, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(391, 70);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin loại ghế";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 30);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(90, 20);
            label2.TabIndex = 2;
            label2.Text = "Tên loại ghế";
            // 
            // txtTen
            // 
            txtTen.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTen.Location = new System.Drawing.Point(102, 27);
            txtTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtTen.MaxLength = 100;
            txtTen.Name = "txtTen";
            txtTen.Size = new System.Drawing.Size(283, 27);
            txtTen.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 254);
            label1.Location = new System.Drawing.Point(128, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(340, 29);
            label1.TabIndex = 19;
            label1.Text = "Quản lý danh mục loại ghế";
            // 
            // gbLoaiGhe
            // 
            gbLoaiGhe.Controls.Add(dataView);
            gbLoaiGhe.Location = new System.Drawing.Point(12, 178);
            gbLoaiGhe.Name = "gbLoaiGhe";
            gbLoaiGhe.Size = new System.Drawing.Size(554, 377);
            gbLoaiGhe.TabIndex = 28;
            gbLoaiGhe.TabStop = false;
            gbLoaiGhe.Text = "Danh mục loại ghế (0)";
            // 
            // QuanLiDanhMucLoaiGhe
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(578, 607);
            Controls.Add(gbLoaiGhe);
            Controls.Add(btnLuu);
            Controls.Add(btnTaiLai);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnRong);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "QuanLiDanhMucLoaiGhe";
            Text = "QuanLiDanhMucLoaiGhe";
            Load += QuanLiDanhMucLoaiGhe_Load;
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbLoaiGhe.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnRong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbLoaiGhe;
    }
}