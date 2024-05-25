using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatVeXemPhim
{
    public partial class ThemPhimNgauNhienDialog : Form
    {
        public ThemPhimNgauNhienDialog()
        {
            InitializeComponent();
        }

        private void RandomMoviesDialog_Load(object sender, EventArgs e)
        {
            cbTheLoai.Items.AddRange( ["(ngẫu nhiên)", ..Constants.CATEGORIES]);
            cbTheLoai.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        public int numberOfRows()
        {
            return (int)numHang.Value;
        }

        public string category()
        {
            return (cbTheLoai.SelectedIndex == 0) ? "" : cbTheLoai.Text;
        }
    }
}
