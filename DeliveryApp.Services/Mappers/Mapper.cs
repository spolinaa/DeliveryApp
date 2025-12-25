using DeliveryApp.Models.DTOs.Requests;
using DeliveryApp.Models.Entities;

namespace DeliveryApp.Services.Mappers;

public static class Mapper
{
    public static Order Map(this CreateOrderRequest order)
    {
        return new Order
        {
            SenderCity = order.SenderLocation.City,
            SenderAddress = order.SenderLocation.Address,
            ReceiverCity = order.ReceiverLocation.City,
            ReceiverAddress = order.ReceiverLocation.Address,
            CargoWeight = order.Cargo.Weight,
            CargoPickupDate = order.Cargo.PickupDate
        };
    }
}