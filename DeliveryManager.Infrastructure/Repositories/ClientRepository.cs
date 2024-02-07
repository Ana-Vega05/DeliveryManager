using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Repositories;

namespace DeliveryManager.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private List<Client> _list = new List<Client>();
    
    public void Save(Client client)
    {
        _list.Add(client);
    }

    public Client Find(string id)
    {
        foreach (var client in _list)
        {
            if (client.Id == id)
            {
                return client;
            } 
        }

        return null;
    }
}

