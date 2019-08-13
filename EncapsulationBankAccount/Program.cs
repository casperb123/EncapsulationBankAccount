using System;
using System.Collections.Generic;
using System.Data;

namespace EncapsulationBankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            AccountRepository accountRepository = new AccountRepository();

            List<Account> accounts = accountRepository.GetAccounts();


            //List<Account> accounts = new List<Account>();

            //for (int i = 0; i < 13000; i++)
            //{
            //    decimal bal = rnd.Next(-150000, 0);

            //    Account account = new Account(bal);
            //    accounts.Add(account);
            //}

            //for (int i = 0; i < 130000; i++)
            //{
            //    decimal bal = rnd.Next(0, 1000000);

            //    Account account = new Account(bal);
            //    accounts.Add(account);
            //}

            //for (int i = 0; i < 13611; i++)
            //{
            //    decimal bal = rnd.Next(1000000, int.MaxValue);

            //    Account account = new Account(bal);
            //    accounts.Add(account);
            //}

            //accountRepository.InsertAccounts(accounts);

            Console.ReadKey(true);
        }
    }
}
