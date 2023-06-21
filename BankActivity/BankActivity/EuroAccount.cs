using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankActivity
{
    class EuroAccount : BankAccount
    {
        public decimal GetTotalAmount()
        {
            return Amount * 4.9m;
        }

        public decimal GetInterestRate()
        {
            if (Amount > 500)
                return 0.01m;
            else
                return 0;
        }
    }
}