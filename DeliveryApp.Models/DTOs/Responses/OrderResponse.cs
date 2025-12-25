namespace DeliveryApp.Models.DTOs.Responses;

public record OrderResponse
{
    public int Id { get; init; }
    
    public LocationDto SenderLocation { get; init; }

    public LocationDto ReceiverLocation { get; init; }

    public CargoDto Cargo { get; init; }
}