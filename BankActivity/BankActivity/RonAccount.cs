using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankActivity
{
    class RonAccount : BankAccount
    {
        public decimal TransferMoney(BankAccount destinationAccount, decimal amount)
        {
            if (destinationAccount is RonAccount)
            {
                Amount -= amount;
                destinationAccount.Amount += amount;
                return amount;
            }
            else
            {
                throw new InvalidOperationException("Transfers can only be made between RON accounts.");
            }
        }
    }
}