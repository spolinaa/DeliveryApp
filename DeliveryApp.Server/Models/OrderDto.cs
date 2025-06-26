namespace DeliveryApp.Models;

public record OrderDto : OrderRequest
{
    public int Id { get; init; }
}