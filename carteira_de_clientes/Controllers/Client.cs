using System;
using System.Collections.Generic;

namespace carteira_de_clientes
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Client()
        {
            
        }

        public Client(int id, string name, string address, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }
    }

    public class ClientManager
    {
        private List<Client> clients;

        public ClientManager()
        {
            clients = new List<Client>();
        }

        // Create a new client
        public void CreateClient(Client client)
        {
            clients.Add(client);
        }

        // Read all clients
        public List<Client> GetAllClients()
        {
            return clients;
        }

        // Read a client by ID
        public Client GetClientById(int id)
        {
            return clients.Find(client => client.Id == id);
        }

        // Update a client
        public void UpdateClient(int id, Client updatedClient)
        {
            Client client = clients.Find(client => client.Id == id);
            if (client != null)
            {
                client.Name = updatedClient.Name;
                client.Address = updatedClient.Address;
                client.Phone = updatedClient.Phone;
            }
        }

        // Delete a client
        public void DeleteClient(int id)
        {
            Client client = clients.Find(client => client.Id == id);
            if (client != null)
            {
                clients.Remove(client);
            }
        }
    }

   
}
