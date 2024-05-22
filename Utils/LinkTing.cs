using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

        public static bool checkEmptyComboBox(ComboBox comboBox, string msg)
        {
            if (string.IsNullOrWhiteSpace(comboBox.Text))
            {
                MessageBox.Show(msg, "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox.Focus();
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

        public static void bindGroupBoxToTable(GroupBox groupBox, DataTable dt, string template)
        {
            var textUpdateFunc = () =>
            {
                groupBox.Text = string.Format(template, dt.Select("true").Length);
            };

            dt.RowDeleted += (sender, e) => textUpdateFunc();
            dt.TableNewRow += (sender, e) => textUpdateFunc();
            dt.RowChanged += (sender, e) => textUpdateFunc();
        }

        public static void setDoubleBuffered(DataGridView view)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, view,[true]);
        }
    }
}
