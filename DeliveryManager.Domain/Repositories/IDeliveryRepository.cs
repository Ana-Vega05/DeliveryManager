using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Model.Queries;

namespace DeliveryManager.Domain.Repositories;

public interface IDeliveryRepository
{
    public void Save(Delivery delivery);
    public Delivery Find(string id);
    public void Update(Delivery delivery);
    public List<Delivery> Find(DeliveriesQuery deliveriesQuery);
    public string GetNextId();
}