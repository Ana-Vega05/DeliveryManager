using DeliveryManager.Domain.Enums;
using DeliveryManager.Domain.Model;

namespace DeliveryManager.Domain.Entities;

public class Delivery
{
    public string Id { get; private set; }
    public Client Transmitter { get; private set; }
    public Client Receiver { get; private set; }
    public Package Package { get; private set; }
    public string OriginCity { get; private set; }
    public string DestinationCity { get; private set; }
    public string OriginAddress { get; private set; }
    public string DestinationAddress { get; private set; }
    public DateTime ReceptionDate { get; private set; }
    public DateTime DeliveryDate { get; private set; }
    public DeliveryStatus DeliveryStatus { get; private set; }
    public double Price { get; private set; }

    public Delivery(Client transmitter, Client receiver, string originCity, string destinationCity, string originAddress, string destinationAddress, Package package, string id)
    {
        Transmitter = transmitter;
        Receiver = receiver;
        OriginCity = originCity;
        DestinationCity = destinationCity;
        OriginAddress = originAddress;
        DestinationAddress = destinationAddress;
        Package = package;
        Id = id;
        ReceptionDate = DateTime.Now;
        DeliveryStatus = DeliveryStatus.Received;
        Price = Package.CalculatePackagePrice();
        
    }

    public void Deliver()
    {
        if (DeliveryStatus == DeliveryStatus.Sent)
        {
            DeliveryDate = DateTime.Now;
            DeliveryStatus = DeliveryStatus.Delivered;
        }
    }

    public void Sent()
    {
        if (DeliveryStatus == DeliveryStatus.Received)
        {
            DeliveryStatus = DeliveryStatus.Sent;
        }
    }

    public void Update(DeliveryRequest request)
    {
        Transmitter = request.Transmitter;
        Receiver = request.Receiver;
        Package = request.Package;
        OriginCity = request.OriginCity;
        DestinationCity = request.DestinationCity;
        OriginAddress = request.OriginAddress;
        DestinationAddress = request.DestinationAddress;
    }
    
}
