using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Enums;
using DeliveryManager.Domain.Model;
using DeliveryManager.Domain.Model.Queries;

namespace DeliveryManager.Domain.Services;

public interface IDeliveryService
{
    public Delivery FindDeliveryById(string id);
    public void RegisterDelivery(DeliveryRequest delivery);
    public void SentDelivery(string id);
    public void CompleteDelivery(string id);
    public Delivery UpdateDelivery(DeliveryRequest request, string id);

    public List<Delivery> ShowAllDeliveries(DeliveriesQuery deliveriesQuery);
}