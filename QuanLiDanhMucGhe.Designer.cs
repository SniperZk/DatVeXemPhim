namespace DatVeXemPhim
{
    partial class QuanLiDanhMucGhe
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
            btnXoa = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnThem = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cbPhong = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            cbLoaiGhe = new System.Windows.Forms.ComboBox();
            txtViTri = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            gbGhe = new System.Windows.Forms.GroupBox();
            dataView = new System.Windows.Forms.DataGridView();
            btnLuu = new System.Windows.Forms.Button();
            btnTaiLai = new System.Windows.Forms.Button();
            btnRong = new System.Windows.Forms.Button();
            btnHangLoat = new System.Windows.Forms.Button();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gbGhe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnXoa
            // 
            btnXoa.Enabled = false;
            btnXoa.Location = new System.Drawing.Point(178, 172);
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
            btnSua.Location = new System.Drawing.Point(97, 172);
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
            btnThem.Location = new System.Drawing.Point(16, 172);
            btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(75, 32);
            btnThem.TabIndex = 22;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new System.Drawing.Point(16, 57);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(634, 107);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin ghế";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(cbPhong, 1, 1);
            tableLayoutPanel1.Controls.Add(label6, 2, 0);
            tableLayoutPanel1.Controls.Add(cbLoaiGhe, 1, 0);
            tableLayoutPanel1.Controls.Add(txtViTri, 3, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(628, 79);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(27, 8);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 20);
            label2.TabIndex = 0;
            label2.Text = "Loại ghế";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 44);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(90, 20);
            label3.TabIndex = 0;
            label3.Text = "Phòng chiếu";
            // 
            // cbPhong
            // 
            cbPhong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cbPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPhong.FormattingEnabled = true;
            cbPhong.Location = new System.Drawing.Point(99, 40);
            cbPhong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbPhong.Name = "cbPhong";
            cbPhong.Size = new System.Drawing.Size(235, 28);
            cbPhong.TabIndex = 2;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(340, 8);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(40, 20);
            label6.TabIndex = 0;
            label6.Text = "Vị trí";
            // 
            // cbLoaiGhe
            // 
            cbLoaiGhe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cbLoaiGhe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbLoaiGhe.FormattingEnabled = true;
            cbLoaiGhe.Location = new System.Drawing.Point(99, 4);
            cbLoaiGhe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbLoaiGhe.Name = "cbLoaiGhe";
            cbLoaiGhe.Size = new System.Drawing.Size(235, 28);
            cbLoaiGhe.TabIndex = 2;
            // 
            // txtViTri
            // 
            txtViTri.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txtViTri.Location = new System.Drawing.Point(386, 4);
            txtViTri.MaxLength = 10;
            txtViTri.Name = "txtViTri";
            txtViTri.Size = new System.Drawing.Size(185, 27);
            txtViTri.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 254);
            label1.Location = new System.Drawing.Point(275, 21);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(288, 29);
            label1.TabIndex = 20;
            label1.Text = "Quản lý danh mục ghế";
            // 
            // gbGhe
            // 
            gbGhe.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbGhe.Controls.Add(dataView);
            gbGhe.Location = new System.Drawing.Point(16, 211);
            gbGhe.Name = "gbGhe";
            gbGhe.Size = new System.Drawing.Size(826, 346);
            gbGhe.TabIndex = 28;
            gbGhe.TabStop = false;
            gbGhe.Text = "Danh mục ghế (0)";
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
            dataView.Name = "dataView";
            dataView.ReadOnly = true;
            dataView.RowHeadersVisible = false;
            dataView.RowHeadersWidth = 51;
            dataView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataView.RowTemplate.Height = 24;
            dataView.RowTemplate.ReadOnly = true;
            dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataView.Size = new System.Drawing.Size(807, 312);
            dataView.TabIndex = 20;
            dataView.CellDoubleClick += dataView_CellDoubleClick;
            dataView.ColumnAdded += dataView_ColumnAdded;
            dataView.SelectionChanged += dataView_SelectionChanged;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnLuu.Location = new System.Drawing.Point(767, 565);
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
            btnTaiLai.Location = new System.Drawing.Point(686, 565);
            btnTaiLai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new System.Drawing.Size(75, 32);
            btnTaiLai.TabIndex = 26;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // btnRong
            // 
            btnRong.Location = new System.Drawing.Point(3, 3);
            btnRong.Name = "btnRong";
            btnRong.Size = new System.Drawing.Size(117, 34);
            btnRong.TabIndex = 29;
            btnRong.Text = "Xoá nhập liệu";
            btnRong.UseVisualStyleBackColor = true;
            btnRong.Click += btnRong_Click;
            // 
            // btnHangLoat
            // 
            btnHangLoat.Location = new System.Drawing.Point(3, 43);
            btnHangLoat.Name = "btnHangLoat";
            btnHangLoat.Size = new System.Drawing.Size(135, 34);
            btnHangLoat.TabIndex = 30;
            btnHangLoat.Text = "Thêm hàng loạt...";
            btnHangLoat.UseVisualStyleBackColor = true;
            btnHangLoat.Click += btnHangLoat_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel3.Controls.Add(btnRong);
            flowLayoutPanel3.Controls.Add(btnHangLoat);
            flowLayoutPanel3.Location = new System.Drawing.Point(656, 81);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new System.Drawing.Size(186, 83);
            flowLayoutPanel3.TabIndex = 31;
            // 
            // QuanLiDanhMucGhe
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(857, 610);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(gbGhe);
            Controls.Add(btnLuu);
            Controls.Add(btnTaiLai);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "QuanLiDanhMucGhe";
            Text = "Quản lý danh mục ghế";
            Load += QuanLiDanhMucGhe_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            gbGhe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtGioHet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtGioChieu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPhong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtNgayChieu;
        private System.Windows.Forms.ComboBox cbLoaiGhe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtViTri;
        private System.Windows.Forms.GroupBox gbGhe;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnRong;
        private System.Windows.Forms.Button btnHangLoat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}