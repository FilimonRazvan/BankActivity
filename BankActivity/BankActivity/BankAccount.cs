using BankActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankActivity
{
    class BankAccount : ITotalAmount
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public AccountType Type { get; set; }
        public object TotalAmount { get; internal set; }

        internal decimal GetTotalAmount()
        {
            if (Amount > 500)
            {
                return 0.01m; 
            }
            else
            {
                return 0; 
            }
        }
    }
    }
 
