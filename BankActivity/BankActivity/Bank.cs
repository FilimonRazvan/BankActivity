using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankActivity
{
    class Bank
    {
        public List<Client> Clients { get; set; }
        public string BankCode { get; set; }

        public Bank()
        {
            Clients = new List<Client>();
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public Client SearchClient(string cnp)
        {
            foreach (var client in Clients)
            {
                if (client.CNP == cnp)
                {
                    return client;
                }
            }

            return null;
        }
    }
}