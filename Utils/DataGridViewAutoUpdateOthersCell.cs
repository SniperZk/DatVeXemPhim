using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;

namespace DatVeXemPhim.Utils
{
    public class DataGridViewAutoUpdateOthersCell : DataGridViewTextBoxCell
    {
        public struct Binding
        {
            public string ViewColumnName;
            public required string ColumnName;
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
                foreach (Binding binding in Bindings)
                {
                    DataGridView.Rows[rowIndex].Cells[binding.ColumnName].Value = dataRow[binding.ColumnName];
                }
            }

            return formattedValue;
        }
    }
}
