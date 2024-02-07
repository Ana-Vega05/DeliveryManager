namespace DeliveryManager.Domain.Entities;

public class Package
{
    public string Description { get; set; }
    public double WeightInKg { get; set; }

    private double PriceByKg = 3000;

    public Package(string description, double weightInKg)
    {
        Description = description;
        WeightInKg = weightInKg;
    }

    public double CalculatePackagePrice()
    {
        if (WeightInKg <= 1)
        {
            return PriceByKg;
        }
        return PriceByKg * WeightInKg;
    }
    
}