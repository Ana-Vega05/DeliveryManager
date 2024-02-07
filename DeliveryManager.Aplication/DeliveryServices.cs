using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Model;
using DeliveryManager.Domain.Model.Queries;
using DeliveryManager.Domain.Repositories;
using DeliveryManager.Domain.Services;

namespace DeliveryManager.Aplication;

public class DeliveryServices : IDeliveryService
{
    private IDeliveryRepository Repository;

    public DeliveryServices(IDeliveryRepository repository)
    {
        Repository = repository;
    }

    public Delivery FindDeliveryById(string id)
    {
        Delivery findDelivery = Repository.Find(id);
        return findDelivery;
    }

    public void RegisterDelivery(DeliveryRequest delivery)
    {
        string nextId = Repository.GetNextId();
        Delivery createDelivery = new Delivery(delivery.Transmitter, delivery.Receiver, delivery.OriginCity,
            delivery.DestinationCity, delivery.OriginAddress, delivery.OriginAddress, delivery.Package, nextId);
        Repository.Save(createDelivery);
    }

    public void SentDelivery(string id)
    {
        Delivery findDelivery = Repository.Find(id);
        findDelivery.Sent();
        Repository.Update(findDelivery);
    }

    public void CompleteDelivery(string id)
    {
        Delivery findDelivery = Repository.Find(id);
        findDelivery.Deliver();
        Repository.Update(findDelivery);
    }

    public Delivery UpdateDelivery(DeliveryRequest request, string id)
    {
        Delivery findDelivery = Repository.Find(id);
        if (findDelivery == null)
            throw new Exception("What you are looking for doesn't exist");
        
        findDelivery.Update(request);
        Repository.Update(findDelivery);
        return findDelivery;
    }

    public List<Delivery> ShowAllDeliveries(DeliveriesQuery deliveriesQuery)
    {
        return Repository.Find(deliveriesQuery);
    }
    
}