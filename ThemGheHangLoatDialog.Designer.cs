namespace DatVeXemPhim
{
    partial class ThemGheHangLoatDialog
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
            btnOk = new System.Windows.Forms.Button();
            cbPhong = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cbLoaiGhe = new System.Windows.Forms.ComboBox();
            checkXoa = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(173, 110);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(94, 29);
            btnOk.TabIndex = 8;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // cbPhong
            // 
            cbPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPhong.FormattingEnabled = true;
            cbPhong.Location = new System.Drawing.Point(116, 12);
            cbPhong.Name = "cbPhong";
            cbPhong.Size = new System.Drawing.Size(151, 28);
            cbPhong.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(59, 15);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 20);
            label2.TabIndex = 4;
            label2.Text = "Phòng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(45, 49);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(66, 20);
            label3.TabIndex = 4;
            label3.Text = "Loại ghế";
            // 
            // cbLoaiGhe
            // 
            cbLoaiGhe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbLoaiGhe.FormattingEnabled = true;
            cbLoaiGhe.Location = new System.Drawing.Point(116, 46);
            cbLoaiGhe.Name = "cbLoaiGhe";
            cbLoaiGhe.Size = new System.Drawing.Size(151, 28);
            cbLoaiGhe.TabIndex = 7;
            // 
            // checkXoa
            // 
            checkXoa.AutoSize = true;
            checkXoa.Checked = true;
            checkXoa.CheckState = System.Windows.Forms.CheckState.Checked;
            checkXoa.Location = new System.Drawing.Point(10, 80);
            checkXoa.Name = "checkXoa";
            checkXoa.Size = new System.Drawing.Size(227, 24);
            checkXoa.TabIndex = 9;
            checkXoa.Text = "Xoá tất cả ghế trước khi thêm";
            checkXoa.UseVisualStyleBackColor = true;
            // 
            // ThemGheHangLoatDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(279, 146);
            Controls.Add(checkXoa);
            Controls.Add(btnOk);
            Controls.Add(cbLoaiGhe);
            Controls.Add(label3);
            Controls.Add(cbPhong);
            Controls.Add(label2);
            Name = "ThemGheHangLoatDialog";
            Text = "Thêm ghế hàng loạt";
            Load += ThemGheHangLoatDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLoaiGhe;
        private System.Windows.Forms.CheckBox checkXoa;
    }
}