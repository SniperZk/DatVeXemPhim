namespace DatVeXemPhim
{
    partial class ThemPhimNgauNhienDialog
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
            label1 = new System.Windows.Forms.Label();
            cbTheLoai = new System.Windows.Forms.ComboBox();
            numHang = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)numHang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Số hàng thêm";
            // 
            // cbTheLoai
            // 
            cbTheLoai.FormattingEnabled = true;
            cbTheLoai.Location = new System.Drawing.Point(118, 45);
            cbTheLoai.Name = "cbTheLoai";
            cbTheLoai.Size = new System.Drawing.Size(151, 28);
            cbTheLoai.TabIndex = 2;
            // 
            // numHang
            // 
            numHang.Location = new System.Drawing.Point(119, 12);
            numHang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numHang.Name = "numHang";
            numHang.Size = new System.Drawing.Size(150, 27);
            numHang.TabIndex = 1;
            numHang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(50, 48);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 20);
            label2.TabIndex = 0;
            label2.Text = "Thể loại";
            // 
            // btnOk
            // 
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(175, 79);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(94, 29);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // ThemPhimNgauNhienDialog
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(281, 120);
            Controls.Add(btnOk);
            Controls.Add(numHang);
            Controls.Add(cbTheLoai);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ThemPhimNgauNhienDialog";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            Text = "Tuỳ chọn thêm";
            Load += RandomMoviesDialog_Load;
            ((System.ComponentModel.ISupportInitialize)numHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTheLoai;
        private System.Windows.Forms.NumericUpDown numHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
    }
}