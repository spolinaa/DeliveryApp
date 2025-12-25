using DeliveryApp.Models.DTOs.Requests;
using DeliveryApp.Models.Entities;

namespace DeliveryApp.Services.Interfaces;

public interface IDeliveryService
{
    Task<Order> CreateOrder(CreateOrderRequest createOrder);
    
    Task<IReadOnlyCollection<Order>> GetOrders();
    
    Task<Order> GetOrder(int id);
}