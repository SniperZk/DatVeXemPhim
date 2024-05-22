﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace DatVeXemPhim.Utils
{
    public class SqLiem
    {
        private readonly string SelectQuery;
        private readonly string ConnectionString;

        public SqLiem(string selectCommand, string connString)
        {
            SelectQuery = selectCommand;
            ConnectionString = connString;
        }

        public void load(DataTable table)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            using SqlDataAdapter adapter = new SqlDataAdapter(SelectQuery, conn);
            table.Clear();
            adapter.Fill(table);
        }

        public void update(DataTable table)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            using SqlDataAdapter adapter = new SqlDataAdapter(SelectQuery, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            builder.GetUpdateCommand();
            builder.GetDeleteCommand();
            builder.GetInsertCommand();

            adapter.Update(table);
            table.Clear();
            adapter.Fill(table);
        }

        public bool notUsedInTable(string id, string tableName, string tableCol, string template)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {tableName} WHERE {tableCol} = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    var res = cmd.ExecuteScalar();
                    int count = (res != null) ? (int)res : 0;
                    if (count > 0)
                    {
                        MessageBox.Show(string.Format(template, count), "Lỗi xoá dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
