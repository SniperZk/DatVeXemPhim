using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
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
            DataRow? dataRow;
            if (dt.PrimaryKey.Count() > 0)
            {
                dataRow = dt.Rows.Find(idStr);
            } else
            {
                using var iterator = (from DataRow row in dt.Rows where row.Field<string>(idColumn) == idStr select row).GetEnumerator();
                iterator.MoveNext();
                dataRow = iterator.Current;
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
                using var iterator = (from DataRow row in dt.Rows where row.Field<string>(idColumn) == idStr select row).GetEnumerator();
                iterator.MoveNext();
                dataRow = iterator.Current;
            }
            if (dataRow != null)
            {
                dataView.Rows[rowIndex].Cells[nameColumn].Value = dataRow[nameColumn];
            }
        }

        public static DataGridViewColumn addFakeColumnToView(DataGridView dataView, string name, string title, string displayAfter)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            dataView.Columns.Add(column);
            column.Name = name;
            column.HeaderText = title;
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
    }

    public class DataGridViewAutoUpdateOthersCell : DataGridViewTextBoxCell
    {
        public struct Binding
        {
            public string DisplayColumnName = "";
            public required string ColumnName;

            public Binding()
            {
            }
        }

        public required DataTable Table;
        public required string IdColumnName;
        public List<Binding> Bindings = [];

        public DataGridViewAutoUpdateOthersCell() {
        }

        [SetsRequiredMembers]
        public DataGridViewAutoUpdateOthersCell(DataTable dataTable, string idColumnName)
        {
            Table = dataTable;
            IdColumnName = idColumnName;
        }

        public override object Clone()
        {
            var cell = (DataGridViewAutoUpdateOthersCell)base.Clone();
            cell.Table = Table;
            cell.IdColumnName = IdColumnName;
            cell.Bindings = Bindings;
            return cell;
        }

        public void AddBinding(string columnName, string displayColName = "")
        {
            Bindings.Add(new Binding { DisplayColumnName = displayColName, ColumnName = columnName });
        }

        protected override object GetFormattedValue(object value,
            int rowIndex,
            ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            object formattedValue = base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);

            if (DataGridView == null || value == null || value == DBNull.Value)
            {
                return formattedValue;
            }

            string idStr = (value != null) ? (string)value : "";
            DataRow? dataRow;
            if (Table.PrimaryKey.Count() > 0)
            {
                dataRow = Table.Rows.Find(idStr);
            }
            else
            {
                using var iterator = (from DataRow row in Table.Rows where row.Field<string>(IdColumnName) == idStr select row).GetEnumerator();
                iterator.MoveNext();
                dataRow = iterator.Current;
            }
            if (dataRow != null)
            {
                foreach (Binding binding in Bindings)
                {
                    DataGridView.Rows[rowIndex].Cells[binding.ColumnName].Value = dataRow[binding.ColumnName];
                }
            }

            return formattedValue;
        }
    }
}
