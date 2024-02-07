using DeliveryManager.Domain.Entities;

namespace DeliveryManager.Domain.Model;

public class DeliveryRequest
{
    public Client Transmitter { get; set; }
    public Client Receiver { get; set; }
    public Package Package { get; set; }
    public string OriginCity { get; set; }
    public string DestinationCity { get; set; }
    public string OriginAddress { get; set; }
    public string DestinationAddress { get; set; }
}