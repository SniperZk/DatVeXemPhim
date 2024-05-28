namespace DatVeXemPhim
{
    partial class LichSuMuaVe
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
            label1 = new Label();
            dataView = new DataGridView();
            gbLichSu = new GroupBox();
            btnOK = new Button();
            txtTim = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            gbLichSu.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 254);
            label1.Location = new Point(332, 26);
            label1.Name = "label1";
            label1.Size = new Size(199, 29);
            label1.TabIndex = 26;
            label1.Text = "Lịch sử mua vé";
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
            dataView.Location = new Point(6, 27);
            dataView.Margin = new Padding(3, 4, 3, 4);
            dataView.Name = "dataView";
            dataView.ReadOnly = true;
            dataView.RowHeadersVisible = false;
            dataView.RowHeadersWidth = 51;
            dataView.RowTemplate.Height = 24;
            dataView.RowTemplate.ReadOnly = true;
            dataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataView.Size = new Size(834, 368);
            dataView.TabIndex = 27;
            // 
            // gbLichSu
            // 
            gbLichSu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbLichSu.Controls.Add(dataView);
            gbLichSu.Location = new Point(12, 90);
            gbLichSu.Name = "gbLichSu";
            gbLichSu.Size = new Size(846, 402);
            gbLichSu.TabIndex = 28;
            gbLichSu.TabStop = false;
            gbLichSu.Text = "Lịch sử (0)";
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(764, 501);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 29;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txtTim
            // 
            txtTim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTim.Location = new Point(606, 64);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(252, 27);
            txtTim.TabIndex = 30;
            txtTim.TextChanged += txtTim_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(563, 67);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 31;
            label2.Text = "Tìm:";
            // 
            // LichSuMuaVe
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 542);
            Controls.Add(label2);
            Controls.Add(txtTim);
            Controls.Add(btnOK);
            Controls.Add(gbLichSu);
            Controls.Add(label1);
            Name = "LichSuMuaVe";
            Text = "Lịch sử mua vé";
            Load += LichSuMuaVe_Load;
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            gbLichSu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataView;
        private GroupBox gbLichSu;
        private Button btnOK;
        private TextBox txtTim;
        private Label label2;
    }
}