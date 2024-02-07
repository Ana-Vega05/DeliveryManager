namespace DeliveryManager.Domain.Entities;

public class Client
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    public Client(string id, string name, string phone)
    {
        Id = id;
        Name = name;
        Phone = phone;
    }
}