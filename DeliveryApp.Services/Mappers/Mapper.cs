using DeliveryApp.Models;
using DeliveryApp.Models.DbEntities;

namespace DeliveryApp.Mappers;

public static class Mapper
{
    public static Order Map(this OrderRequest order)
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