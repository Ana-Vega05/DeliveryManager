using DeliveryManager.Domain.Entities;

namespace DeliveryManager.Domain.Repositories;

public interface IClientRepository
{
    public void Save(Client client);
    public Client Find(string id);
}
