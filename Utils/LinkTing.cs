using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatVeXemPhim.Utils
{
    public class LinkTing
    {
        public static bool checkEmptyTextBox(TextBox txt, string msg)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show(msg, "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkDateTimePickerPair(DateTimePicker picker1, DateTimePicker picker2, string msg)
        {
            if (picker1.Value > picker2.Value)
            {
                MessageBox.Show(msg, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }


        public static void deleteDataGridViewSelectedRows(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                ((DataRowView)row.DataBoundItem).Row.Delete();
            }
        }

        public static TimeSpan toTime(DateTime date)
        {
            return new TimeSpan(date.Hour, date.Minute, 0);
        }
        public static DateTime toDate(TimeSpan time)
        {
            return DateTime.Now.Date.AddTicks(time.Ticks);
        }

        public static string displayStringFromTableId(DataTable dt, object? id, string idColumn, string nameColumn)
        {
            string idStr = (id != null) ? (string)id : "";
            using var iterator = (from DataRow row in dt.Rows where row.Field<string>(idColumn) == idStr select row).GetEnumerator();
            iterator.MoveNext();
            return $"[{id}] {(string)iterator.Current[nameColumn]}";
        }
    }
}
