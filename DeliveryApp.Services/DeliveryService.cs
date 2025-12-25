using DeliveryApp.Data.Repositories;
using DeliveryApp.Services.Interfaces;
using DeliveryApp.Services.Mappers;
using DeliveryApp.Models.Entities;
using DeliveryApp.Models.DTOs.Requests;

namespace DeliveryApp.Services;

public class DeliveryService : IDeliveryService
{
    private readonly IOrderRepository _orders;
    
    public DeliveryService(IOrderRepository orderRepository)
    {
        _orders = orderRepository;
    }
    
    public async Task<Order> CreateOrder(CreateOrderRequest orderRequest)
    {
        if (orderRequest.SenderLocation == orderRequest.ReceiverLocation)
        {
            throw new ArgumentException("Адреса отправителя и получателя не могут совпадать");
        }

        var order = orderRequest.Map();
        return await _orders.AddOrder(order);
    }

    public async Task<IReadOnlyCollection<Order>> GetOrders()
    {
        return await _orders.GetOrders();
    }

    public async Task<Order> GetOrder(int id)
    {
        var order = await _orders.GetOrder(id);
        if (order is null)
            throw new KeyNotFoundException($"Заказ с номером {id} не найден");
        return order;
    }
}