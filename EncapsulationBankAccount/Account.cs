using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationBankAccount
{
    public class Account
    {
        private int id;
        private decimal balance;
        private DateTime created;

        public Account(decimal balance)
        {
            Id = 0;
            Balance = balance;
            Created = DateTime.Now;
        }

        public Account(int id, decimal balance, DateTime created) : this(balance)
        {
            Id = id;
            Created = created;
        }

        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (balance + value > 99999999999 || balance - value < -99999999999)
                {
                    throw new ArgumentException("The balance has to be between -999.999.999,99 and 999.999.999,99");
                }

                balance = value;
            }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0 || amount > 25000)
            {
                throw new ArgumentException("The amount has to bee between 0 and 25.000");
            }

            Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public int GetDaysSinceCreated()
        {
            return (DateTime.Now - Created).Days;
        }
    }
}
