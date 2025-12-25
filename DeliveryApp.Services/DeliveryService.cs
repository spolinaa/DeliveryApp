using DeliveryApp.Interfaces;
using DeliveryApp.Mappers;
using DeliveryApp.Models;
using DeliveryApp.Models.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Services;

public class DeliveryService : IDeliveryService
{
    private readonly DeliveryContext _deliveryContext;

    public DeliveryService(DeliveryContext deliveryContext)
    {
        _deliveryContext = deliveryContext;
    }
    
    public async Task<Order> CreateOrder(OrderRequest orderRequest)
    {
        if (orderRequest.SenderLocation == orderRequest.ReceiverLocation)
        {
            throw new ArgumentException("Адреса отправителя и получателя не могут совпадать");
        }

        var order = orderRequest.Map();
        _deliveryContext.Orders.Add(order);
        await _deliveryContext.SaveChangesAsync();
        return order;
    }

    public async Task<IReadOnlyCollection<Order>> GetOrders()
    {
        return (await _deliveryContext.Orders.ToListAsync()).AsReadOnly();
    }

    public async Task<Order> GetOrder(int id)
    {
        var order = await _deliveryContext.Orders.FindAsync(id);
        if (order is null)
            throw new KeyNotFoundException($"Заказ с номером {id} не найден");
        return order;
    }
}