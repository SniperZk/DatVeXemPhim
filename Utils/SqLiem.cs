using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

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

        public int update(DataTable table)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            using SqlDataAdapter adapter = new SqlDataAdapter(SelectQuery, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            builder.GetUpdateCommand();
            builder.GetDeleteCommand();
            builder.GetInsertCommand();

            int affected = adapter.Update(table);
            table.Clear();
            adapter.Fill(table);
            return affected;
        }

        public int countUsageInTable(string id, string tableName, string tableCol)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {tableName} WHERE {tableCol} = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    var res = cmd.ExecuteScalar();
                    int count = (res != null) ? (int)res : 0;
                    return count;
                }
            }
        }

        public DataTable selectToTable(string query, bool setPrimaryKey = true)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return selectToTable(cmd, setPrimaryKey);
                }
            }
        }

        public DataTable selectToTable(SqlCommand cmd, bool setPrimaryKey = true)
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                DataTable table = new DataTable();
                table.Load(reader);
                if (setPrimaryKey)
                {
                    table.PrimaryKey = [table.Columns[0]];
                }
                return table;
            }
        }

        public Dictionary<string, object> selectFirstToDict(SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd.Connection = conn;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
                    }
                    else
                    {
                        return new Dictionary<string, object>();
                    }
                }
            }
        }
    }
}
