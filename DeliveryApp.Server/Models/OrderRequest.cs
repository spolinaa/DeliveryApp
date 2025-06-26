using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models;

public record OrderRequest
{
    [Required(ErrorMessage = "Данные отправителя обязательны")]
    public Location SenderLocation { get; init; }

    [Required(ErrorMessage = "Данные получателя обязательны")]
    public Location ReceiverLocation { get; init; }

    [Required(ErrorMessage = "Данные груза обязательны")]
    public Cargo Cargo { get; init; }
}