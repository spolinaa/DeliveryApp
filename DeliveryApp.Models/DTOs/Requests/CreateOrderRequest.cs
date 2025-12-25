using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models;

public record OrderRequest
{
    [Required(ErrorMessage = "Данные отправителя обязательны")]
    public LocationDto SenderLocationDto { get; init; }

    [Required(ErrorMessage = "Данные получателя обязательны")]
    public LocationDto ReceiverLocationDto { get; init; }

    [Required(ErrorMessage = "Данные груза обязательны")]
    public CargoDto CargoDto { get; init; }
}