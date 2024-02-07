using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Model;
using DeliveryManager.Domain.Model.Queries;
using DeliveryManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveriesController : ControllerBase
{
    private IDeliveryService Services;
    
    public DeliveriesController(IDeliveryService services)
    {
        Services = services;
    }
    
    [HttpPost]
    public IActionResult CreateDelivery(DeliveryRequest delivery)
    {
        Services.RegisterDelivery(delivery);
        return NoContent();
    }

    [HttpGet]
    public IActionResult ConsultAllDeliveries([FromQuery] DeliveriesQuery deliveriesQuery)
    {
        var deliveries = Services.ShowAllDeliveries(deliveriesQuery);
        return Ok(deliveries);
    }

    [HttpGet("{id}")]
    public IActionResult FindDeliveryById(string id)
    {
        var deliveryById = Services.FindDeliveryById(id);
        return Ok(deliveryById);
    }
    
    [HttpPut("{id}/sent")]
    public IActionResult SentDelivery(string id)
    {
        Services.SentDelivery(id);
        return NoContent();

    }
    
    [HttpPut("{id}/complete")]
    public IActionResult CompleteDelivery(string id)
    {
        Services.CompleteDelivery(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDelivery(DeliveryRequest delivery, string id)
    {
        var updateDelivery = Services.UpdateDelivery(delivery, id);
        return Ok(updateDelivery);
    }
}