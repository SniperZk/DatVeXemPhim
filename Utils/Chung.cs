using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatVeXemPhim.Utils
{
    public class NoParam
    {
        public static readonly NoParam Value = new NoParam();
    }

    public static class Chung
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
            if (comboBox.SelectedValue == DBNull.Value || comboBox.SelectedValue == null)
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
            DataRow? dataRow;
            if (dt.PrimaryKey.Count() > 0)
            {
                dataRow = dt.Rows.Find(idStr);
            } else
            {
                dataRow = enumerateOnce(from DataRow row in dt.Rows where row.Field<string>(idColumn) == idStr select row);
            }
            if (dataRow != null)
            {
                return $"{id} | {dataRow[nameColumn]}";
            } else
            {
                return "";
            }
        }

        public static void updateCellFromTableId(DataTable dt, object? id, string idColumn, string nameColumn, DataGridView dataView, int rowIndex)
        {
            string idStr = (id != null) ? (string)id : "";
            DataRow? dataRow;
            if (dt.PrimaryKey.Count() > 0)
            {
                dataRow = dt.Rows.Find(idStr);
            }
            else
            {
                dataRow = enumerateOnce(from DataRow row in dt.Rows where row.Field<string>(idColumn) == idStr select row);
            }
            if (dataRow != null)
            {
                dataView.Rows[rowIndex].Cells[nameColumn].Value = dataRow[nameColumn];
            }
        }

        public static string formattedStringForViewCell(DataGridView view, int rowIndex, string idColumn, DataTable dt, string targetColumn)
        {
            string idStr = view.Rows[rowIndex].Cells[idColumn].Value as string ?? "";
            DataRow? dataRow = dt.Rows.Find(idStr);
            if (dataRow != null)
            {
                var value = dataRow[targetColumn];
                switch (value)
                {
                    case DateTime date:
                        {
                            return date.ToString("d");
                        }
                    default :
                        {
                            return value.ToString() ?? "";
                        }
                }
            }
            else
            {
                return "";
            }
        }

        public static DataGridViewColumn addFakeColumnToView(DataGridView dataView, string name, string title, string displayAfter, bool useDummyTemplate = true)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            dataView.Columns.Add(column);
            column.Name = name;
            column.HeaderText = title;
            if (useDummyTemplate)
            {
                column.CellTemplate = new DataGridViewDummyCell();
            }
            int index = dataView.Columns[displayAfter].DisplayIndex;

            DataGridViewColumn? nextColumn = null;
            foreach (DataGridViewColumn col in dataView.Columns)
            {
                if (col.DisplayIndex > index)
                {
                    nextColumn = col;
                    break;
                }
            }
            if (nextColumn != null)
            {
                column.DisplayIndex = nextColumn.DisplayIndex;
            }

            return column;
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

        public static void changeDataRow(DataRow row, params object?[] values)
        {
            int i = 0;
            foreach (var value in values)
            {
                if (value is not NoParam)
                {
                    row[i] = value;
                }
                ++i;
            }
        }
        public static void changeSelectedViewRow(DataGridView view, params object?[] values)
        {
            DataRow row = ((DataRowView)view.SelectedRows[0].DataBoundItem).Row;
            changeDataRow(row, values);
        }

        public static T enumerateOnce<T>(IEnumerable<T> enumerable) => enumerateNext(enumerable.GetEnumerator());
        public static T enumerateNext<T>(IEnumerator<T> iterator)
        {
            iterator.MoveNext();
            return iterator.Current;
        }
    }



    public class WaitGuard : IDisposable
    {
        private Button? Button = null;

        public WaitGuard(Cursor cursor, Button? button = null)
        {
            Cursor.Current = cursor;
            Application.UseWaitCursor = true;
            Button = button;
            if (Button != null)
            {
                Button.Enabled = false;
            }
        }

        public void Dispose()
        {
            Cursor.Current = Cursors.Default;
            Application.UseWaitCursor = false;
            if (Button != null)
            {
                Application.DoEvents();
                Button.Enabled = true;
            }
        }
    }
}
