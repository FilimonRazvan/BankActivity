using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankActivity
{
    class Client
    {
        public string CNP { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<BankAccount> Accounts { get; set; }

        public Client()
        {
            Accounts = new List<BankAccount>();
        }

        public void ShowAccountInformation()
        {
            foreach (var account in Accounts)
            {
                string accountType = account is RonAccount ? "RON" : "EURO";
                decimal totalAmount = account.GetTotalAmount();
                decimal interestRate = account is EuroAccount ? ((EuroAccount)account).GetInterestRate() : 0;

                Console.WriteLine($"{account.AccountNumber}: [{accountType}] {totalAmount} {interestRate}");
            }
        }
    }
}