namespace DatVeXemPhim
{
    partial class ChonSuatChieuDialog
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
            dtNgayChieu = new System.Windows.Forms.DateTimePicker();
            label5 = new System.Windows.Forms.Label();
            cbSuatChieu = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cbPhong = new System.Windows.Forms.ComboBox();
            btnChon = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // dtNgayChieu
            // 
            dtNgayChieu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtNgayChieu.Location = new System.Drawing.Point(101, 48);
            dtNgayChieu.Name = "dtNgayChieu";
            dtNgayChieu.Size = new System.Drawing.Size(190, 27);
            dtNgayChieu.TabIndex = 2;
            dtNgayChieu.ValueChanged += dtNgayChieu_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(18, 85);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(71, 20);
            label5.TabIndex = 3;
            label5.Text = "Giờ chiếu";
            // 
            // cbSuatChieu
            // 
            cbSuatChieu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbSuatChieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSuatChieu.FormattingEnabled = true;
            cbSuatChieu.Location = new System.Drawing.Point(101, 82);
            cbSuatChieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbSuatChieu.Name = "cbSuatChieu";
            cbSuatChieu.Size = new System.Drawing.Size(190, 28);
            cbSuatChieu.TabIndex = 3;
            cbSuatChieu.SelectedIndexChanged += cbSuatChieu_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 51);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 20);
            label4.TabIndex = 4;
            label4.Text = "Ngày chiếu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(44, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 20);
            label2.TabIndex = 5;
            label2.Text = "Phòng";
            // 
            // cbPhong
            // 
            cbPhong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPhong.FormattingEnabled = true;
            cbPhong.Location = new System.Drawing.Point(101, 13);
            cbPhong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbPhong.Name = "cbPhong";
            cbPhong.Size = new System.Drawing.Size(190, 28);
            cbPhong.TabIndex = 1;
            cbPhong.SelectedIndexChanged += cbPhong_SelectedIndexChanged;
            // 
            // btnChon
            // 
            btnChon.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnChon.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnChon.Location = new System.Drawing.Point(197, 117);
            btnChon.Name = "btnChon";
            btnChon.Size = new System.Drawing.Size(94, 33);
            btnChon.TabIndex = 4;
            btnChon.Text = "Chọn";
            btnChon.UseVisualStyleBackColor = true;
            btnChon.Click += btnChon_Click;
            // 
            // ChonSuatChieuDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(307, 161);
            Controls.Add(btnChon);
            Controls.Add(dtNgayChieu);
            Controls.Add(label5);
            Controls.Add(cbSuatChieu);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(cbPhong);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChonSuatChieuDialog";
            ShowInTaskbar = false;
            Text = "Chọn suất chiếu";
            Load += ChonSuatChieuDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtNgayChieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSuatChieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPhong;
        private System.Windows.Forms.Button btnChon;
    }
}