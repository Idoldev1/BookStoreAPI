using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace BookStoreAPI.Controllers;


[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IServices _services;

    public OrderController(IServices services)
    {
        _services = services;
    }


    [HttpGet]
    [ProducesResponseType(200)]
    public IActionResult GetOrders()
    {
        var orders = _services.OrderServices.GetAllOrders();
        return Ok(orders);
    }


    [HttpGet("{Id}")]
    [ProducesResponseType(200, Type = typeof(Order))]
    [ProducesResponseType(400)]
    public IActionResult GetOrderById(int Id)
    {
        var order = _services.OrderServices.GetOrder(Id, trackChanges: false);

        return Ok(order);
    }


    [HttpDelete("{id:int}")]
    public IActionResult DeleteOrder(int orderId)
    {
        _services.OrderServices.DeleteOrder(orderId, trackChanges: false);
        
        return NoContent();
    }



    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult AddOrder([FromBody]Order addOrder)
    {
        if (addOrder is null)
                return BadRequest("Invalid details for making order");
        var order = _services.OrderServices.AddOrder(addOrder);

        return CreatedAtRoute("OrderDetails", new { id = order.Id }, order);

    }
}