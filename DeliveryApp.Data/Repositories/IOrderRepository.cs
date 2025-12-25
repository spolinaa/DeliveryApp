using DeliveryApp.Models;
using DeliveryApp.Models.DbEntities;

namespace DeliveryApp.Data.Repositories;

public interface IOrderRepository
{
    Task<Order> AddOrder(Order order);

    Task<IReadOnlyCollection<Order>> GetOrders();

    Task<Order?> GetOrder(int id);
}