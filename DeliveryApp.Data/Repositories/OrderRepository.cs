using DeliveryApp.Models;
using DeliveryApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DeliveryContext _deliveryContext;

    public OrderRepository(DeliveryContext deliveryContext)
    {
        _deliveryContext = deliveryContext;
    }
    
    public async Task<Order> AddOrder(Order order)
    {
        _deliveryContext.Orders.Add(order);
        await _deliveryContext.SaveChangesAsync();
        return order;
    }

    public async Task<IReadOnlyCollection<Order>> GetOrders()
    {
        return (await GetOrdersList()).AsReadOnly();
    }
    
    public async Task<List<Order>> GetOrdersList()
    {
        return await _deliveryContext.Orders
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Order?> GetOrder(int id)
    {
        return await _deliveryContext.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}