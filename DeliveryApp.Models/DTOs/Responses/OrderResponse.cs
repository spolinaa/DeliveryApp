namespace DeliveryApp.Models.DTOs.Responses;

public record OrderResponse
{
    public int Id { get; init; }
    
    public LocationDto SenderLocationDto { get; init; }

    public LocationDto ReceiverLocationDto { get; init; }

    public CargoDto CargoDto { get; init; }
}