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
        private string SelectQuery;
        private string ConnectionString;

        public SqLiem(string selectCommand, string connString)
        {
            SelectQuery = selectCommand;
            ConnectionString = connString;
        }

        public void load(DataTable table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlDataAdapter adapter =  new SqlDataAdapter(SelectQuery, conn))
            {
                table.Clear();
                adapter.Fill(table);
            }
        }

        public void update(DataTable table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(SelectQuery, conn))
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                builder.GetUpdateCommand();
                builder.GetDeleteCommand();
                builder.GetInsertCommand();

                adapter.Update(table);
                //table.Clear();
                //adapter.Fill(table);
            }
        }
    }
}
