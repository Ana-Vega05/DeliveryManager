using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Model.Queries;
using DeliveryManager.Domain.Repositories;

namespace DeliveryManager.Infrastructure.Repositories;

public class DeliveryRepository : IDeliveryRepository
{
    private List<Delivery> _list = new List<Delivery>();
    
    public void Save(Delivery delivery)
    {
        string query = $"INSERT INTO delivery (id, origincity, destinationcity, originaddress," +
                       $" destinationaddress, receptiondate, deliverydate, deliverystatus, price) VALUES ({delivery.Id}," +
                       $"{delivery.OriginCity}, {delivery.DestinationCity}, {delivery.OriginAddress}, {delivery.DestinationAddress}," +
                       $"{delivery.ReceptionDate}, {delivery.DeliveryDate}, {delivery.DeliveryStatus}, {delivery.Price})"; 
        _list.Add(delivery);
    }

    public Delivery Find(string id)
    {
        string query = $"SELECT * FROM Delivery WHERE Id = {id}";
        foreach (var delivery in _list)
        {
            if (delivery.Id == id)
            {
                return delivery;
            }
        }

        return null;
    }

    public void Update(Delivery delivery)
    {
        string query =
            $"UPDATE delivery SET origincity = {delivery.OriginCity}, destinationcity = {delivery.DestinationCity}," +
            $"originaddress = {delivery.OriginAddress}, destinationaddress = {delivery.DestinationAddress}" +
            $" WHERE Id = {delivery.Id}";
        Delivery findDelivery = Find(delivery.Id);
        _list.Remove(findDelivery);
        _list.Add(delivery);
    }

    public List<Delivery> Find(DeliveriesQuery deliveriesQuery)
    {
        string query = "SELECT * FROM Delivery WHERE";
        List<Delivery> deliveries = new List<Delivery>();
        deliveries.AddRange(_list);
        
        if (deliveriesQuery.DeliveryStatus != null)
        {
            deliveries = deliveries.Where(delivery => delivery.DeliveryStatus == deliveriesQuery.DeliveryStatus).ToList();
            query += $"Status = '{deliveriesQuery.DeliveryStatus}'";
        }
        if (deliveriesQuery.OriginCity != null)
        {
            deliveries = deliveries.Where(delivery => delivery.OriginCity == deliveriesQuery.OriginCity).ToList();
            query += $"OriginCity = '{deliveriesQuery.OriginCity}'";
        }
        if (deliveriesQuery.DestinationCity != null)
        {
            deliveries = deliveries.Where(delivery => delivery.DestinationCity == deliveriesQuery.DestinationCity).ToList();
            query += $"DestinationCity = '{deliveriesQuery.DestinationCity}'";
        }

        if (deliveriesQuery.ReceptionDate != null)
        {
            deliveries = deliveries.Where(delivery => delivery.ReceptionDate == deliveriesQuery.ReceptionDate).ToList();
            query += $"ReceptionDate = '{deliveriesQuery.ReceptionDate}'";
        }

        if (deliveriesQuery.DeliveryDate != null)
        {
            deliveries = deliveries.Where(delivery => delivery.DeliveryDate == deliveriesQuery.DeliveryDate).ToList();
            query += $"DeliveryDate = '{deliveriesQuery.DeliveryDate}'";
        }
        return deliveries;
    }

    public string GetNextId()
    {
        if (_list.Count == 0)
        {
            return 1.ToString();
        }
        Delivery lastDelivery = _list.OrderBy(delivery => delivery.Id).Last();
        int nextId = int.Parse(lastDelivery.Id) + 1;
        return nextId.ToString();

    }
    
}