using BankActivity;
using System;
using System.Collections.Generic;
namespace BankActivity
{
    enum AccountType
    {
        Ron,
        Euro
    }

    class Program
    {
        static void Main(string[] args)
        {

            Bank myBank = new Bank();
            myBank.BankCode = "XYZ";

            myBank = new Bank();
            myBank.BankCode = "XYZ";

           
            for (int i = 0; i < 3; i++)
            {
                AddNewClient(myBank);
            }

          
            ObtainInterestRate(myBank);

          
            TransferMoney(myBank);

          
            SearchClientAndShowInfo(myBank);

            Console.ReadLine();
        }

        static void AddNewClient(Bank bank)
        {
            Console.WriteLine("Enter client details:");

            Console.Write("CNP: ");
            string cnp = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Client newClient = new Client
            {
                CNP = cnp,
                Name = name,
                Address = address
            };

            Console.Write("Enter the number of accounts for this client (1-5): ");
            int numAccounts = int.Parse(Console.ReadLine());

            if (numAccounts < 1 || numAccounts > 5)
            {
                Console.WriteLine("Invalid number of accounts. Must be between 1 and 5.");
                return;
            }

            for (int i = 0; i < numAccounts; i++)
            {
                Console.WriteLine($"Enter details for account {i + 1}:");

                Console.Write("Account Number: ");
                string accountNumber = Console.ReadLine();

                Console.Write("Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                Console.Write("Account Type (RON/EURO): ");
                string accountType = Console.ReadLine();

                if (accountType.ToUpper() == "RON")
                {
                    BankAccount ronAccount = new RonAccount
                    {
                        AccountNumber = accountNumber,
                        Amount = amount
                    };

                    newClient.Accounts.Add(ronAccount);
                }
                else if (accountType.ToUpper() == "EURO")
                {
                    BankAccount euroAccount = new EuroAccount
                    {
                        AccountNumber = accountNumber,
                        Amount = amount
                    };

                    newClient.Accounts.Add(euroAccount);
                }
                else
                {
                    Console.WriteLine("Invalid account type. Must be RON or EURO.");
                    return;
                }
            }

            bank.AddClient(newClient);

            Console.WriteLine("Client added successfully.");
        }

        static void ObtainInterestRate(Bank bank)
        {
            Console.Write("Enter CNP of the client: ");
            string cnp = Console.ReadLine();

            Client client = bank.SearchClient(cnp);

            if (client != null)
            {
                Console.WriteLine("Select the account number to obtain interest rate:");
                client.ShowAccountInformation();

                Console.Write("Enter the account number: ");
                string accountNumber = Console.ReadLine();

                BankAccount selectedAccount = null;

                foreach (var account in client.Accounts)
                {
                    if (account.AccountNumber == accountNumber)
                    {
                        selectedAccount = account;
                        break;
                    }
                }

                if (selectedAccount != null)
                {
                    if (selectedAccount is EuroAccount)
                    {
                        EuroAccount euroAccount = (EuroAccount)selectedAccount;
                        decimal interestRate = euroAccount.GetInterestRate();
                        Console.WriteLine($"Interest rate for account {accountNumber}: {interestRate:P}");
                    }
                    else
                    {
                        Console.WriteLine("Interest rate is only applicable for EURO accounts.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account number.");
                }
            }
            else
            {
                Console.WriteLine("Client not found.");
            }
        }

        static void TransferMoney(Bank bank)
        {
            Console.Write("Enter CNP of the client: ");
            string cnp = Console.ReadLine();

            Client client = bank.SearchClient(cnp);

            if (client != null)
            {
                Console.WriteLine("Select the account number to transfer money from:");
                client.ShowAccountInformation();

                Console.Write("Enter the source account number: ");
                string sourceAccountNumber = Console.ReadLine();

                Console.Write("Enter the destination account number: ");
                string destinationAccountNumber = Console.ReadLine();

                Console.Write("Enter the amount to transfer: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                BankAccount sourceAccount = null;
                BankAccount destinationAccount = null;

                foreach (var account in client.Accounts)
                {
                    if (account.AccountNumber == sourceAccountNumber)
                    {
                        sourceAccount = account;
                    }
                    else if (account.AccountNumber == destinationAccountNumber)
                    {
                        destinationAccount = account;
                    }
                }

                if (sourceAccount != null && destinationAccount != null)
                {
                    if (sourceAccount is RonAccount)
                    {
                        RonAccount ronAccount = (RonAccount)sourceAccount;

                        try
                        {
                            decimal transferredAmount = ronAccount.TransferMoney(destinationAccount, amount);
                            Console.WriteLine($"Successfully transferred {transferredAmount} from account {sourceAccountNumber} to account {destinationAccountNumber}.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Transfers can only be made from RON accounts.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account numbers.");
                }
            }
            else
            {
                Console.WriteLine("Client not found.");
            }
        }

        static void SearchClientAndShowInfo(Bank bank)
        {
            Console.Write("Enter CNP of the client: ");
            string cnp = Console.ReadLine();

            Client client = bank.SearchClient(cnp);

            if (client != null)
            {
                Console.WriteLine("Client Information:");
                Console.WriteLine($"CNP: {client.CNP}");
                Console.WriteLine($"Name: {client.Name}");
                Console.WriteLine($"Address: {client.Address}");

                Console.WriteLine("Accounts:");
                client.ShowAccountInformation();
            }
            else
            {
                Console.WriteLine("Client not found.");
            }
        }
    }
}




