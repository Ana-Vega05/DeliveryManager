using DeliveryManager.Domain.Enums;

namespace DeliveryManager.Domain.Model.Queries;

public class DeliveriesQuery
{
    public DeliveryStatus? DeliveryStatus { get; set; }
    public string? OriginCity { get; set; }
    public string? DestinationCity { get; set; }
    public DateTime? ReceptionDate { get;  set; }
    public DateTime? DeliveryDate { get; set; }


}