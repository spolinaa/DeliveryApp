using DeliveryApp.Services.Interfaces;
using DeliveryApp.Models.DTOs.Requests;
using DeliveryApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DeliveryController : ControllerBase
{
    private readonly IDeliveryService _deliveryService;
    private readonly ILogger<DeliveryController> _logger;

    public DeliveryController(IDeliveryService deliveryService, ILogger<DeliveryController> logger)
    {
        _deliveryService = deliveryService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreateOrderRequest createOrder)
    {
        try
        {
            var createdOrder = await _deliveryService.CreateOrder(createOrder);
            return Ok(createdOrder);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Ошибка сохранения заказа");
            return StatusCode(500, "Не удалось сохранить заказ");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Неизвестная ошибка");
            return StatusCode(500, "Внутренняя ошибка сервера");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<Order>>> GetOrders()
    {
        return Ok(await _deliveryService.GetOrders());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        try
        {
            return Ok(await _deliveryService.GetOrder(id));
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogError(ex.Message);
            return NotFound(ex.Message);
        }
    }
}