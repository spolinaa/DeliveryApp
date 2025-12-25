using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models.DTOs.Requests;

public record CreateOrderRequest
{
    [Required(ErrorMessage = "Данные отправителя обязательны")]
    public LocationDto SenderLocation { get; init; }

    [Required(ErrorMessage = "Данные получателя обязательны")]
    public LocationDto ReceiverLocation { get; init; }

    [Required(ErrorMessage = "Данные груза обязательны")]
    public CargoDto Cargo { get; init; }
}