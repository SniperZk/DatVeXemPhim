using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;
using static DatVeXemPhim.Utils.DataGridViewAutoUpdateOthersCell;

namespace DatVeXemPhim.Utils
{
    public class DataGridViewDummyCell : DataGridViewTextBoxCell
    {
        private object? _dummyValue;
        public object? DummyValue
        {
            get { return _dummyValue; }
            set { _dummyValue = value; }
        }

        public DataGridViewDummyCell() { }

        public override object Clone()
        {
            var cell = (DataGridViewDummyCell)base.Clone();
            cell.DummyValue = DummyValue;
            return cell;
        }

        protected override object GetFormattedValue(object value, int rowIndex,
            ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (DummyValue is DateTime date)
            {
                return base.GetFormattedValue(date.ToString("d"), rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            }
            return base.GetFormattedValue(DummyValue, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
    }

    public class DataGridViewAutoUpdateOthersCell : DataGridViewTextBoxCell
    {
        public struct Binding
        {
            public string ViewColumnName;
            public required string ColumnName;
            public int? ViewColumnIndex;
            public int? ColumnIndex;
        }

        public required DataTable Table;
        public required string IdColumnName;
        public List<Binding> Bindings = [];

        private object? oldValue = null;

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
            Bindings.Add(new Binding { ViewColumnName = displayColName, ColumnName = columnName });
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

            if (value == oldValue)
            {
                return formattedValue;
            }
            else
            {
                oldValue = value;
            }
            
            string idStr = (value != null) ? (string)value : "";
            DataRow? dataRow;
            if (Table.PrimaryKey.Count() > 0)
            {
                dataRow = Table.Rows.Find(idStr);
            }
            else
            {
                dataRow = Chung.enumerateOnce(from DataRow row in Table.Rows where row.Field<string>(IdColumnName) == idStr select row);
            }
            if (dataRow != null)
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    Binding binding = Bindings[i];
                    if (binding.ColumnIndex == null)
                    {
                        binding.ColumnIndex = DataGridView.Columns[binding.ColumnName].Index;
                    }
                    ((DataGridViewDummyCell)DataGridView.Rows[rowIndex].Cells[(int)binding.ColumnIndex]).DummyValue = dataRow[binding.ColumnName];
                }
            }

            return formattedValue;
        }
    }
}
