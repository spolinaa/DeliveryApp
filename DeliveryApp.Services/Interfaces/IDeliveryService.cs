using DeliveryApp.Models;
using DeliveryApp.Models.DbEntities;

namespace DeliveryApp.Interfaces;

public interface IDeliveryService
{
    Task<Order> CreateOrder(OrderRequest order);
    
    Task<IReadOnlyCollection<Order>> GetOrders();
    
    Task<Order> GetOrder(int id);
}