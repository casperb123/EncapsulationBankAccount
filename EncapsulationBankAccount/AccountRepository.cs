using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EncapsulationBankAccount
{
    public class AccountRepository : DbAccess
    {
        public int InsertAccount(Account account)
        {
            return ExecuteNonQueryScalar($"INSERT INTO BankAccounts (Balance, Created) OUTPUT INSERTED.Id VALUES ({account.Balance}, '{account.Created.ToString("yyyy-MM-dd HH:mm:ss")}')");
        }

        public void InsertAccounts(List<Account> accounts)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Balance", typeof(decimal));
            dataTable.Columns.Add("Created", typeof(DateTime));

            accounts.ForEach(x => dataTable.Rows.Add(x.Id, x.Balance, x.Created));

            BulkInsert(dataTable, "BankAccounts");
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            DataTable dataTable = ExecuteQuery("SELECT * FROM BankAccounts");

            foreach (DataRow row in dataTable.Rows)
            {
                Account account = new Account((int)row["Id"], (decimal)row["Balance"], (DateTime)row["Created"]);
                accounts.Add(account);
            }

            return accounts;
        }
    }
}
