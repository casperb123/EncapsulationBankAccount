using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EncapsulationBankAccount
{
    public class DbAccess
    {
        protected string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EncapsulationBankAccount;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected DataTable ExecuteQuery(string sql)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(sql, con))
            using (SqlDataAdapter dap = new SqlDataAdapter(com))
            {
                dap.Fill(dataTable);
            }

            return dataTable;
        }

        protected int ExecuteNonQuery(string sql)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                con.Open();

                rowsAffected = com.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        protected int ExecuteNonQueryScalar(string sql)
        {
            int number = 0;

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                con.Open();

                number = (int)com.ExecuteScalar();
            }

            return number;
        }

        public void BulkInsert(DataTable dataTable, string destination)
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conString))
            {
                sqlBulkCopy.BulkCopyTimeout = 600;
                sqlBulkCopy.DestinationTableName = destination;
                sqlBulkCopy.WriteToServer(dataTable);
            }
        }
    }
}
