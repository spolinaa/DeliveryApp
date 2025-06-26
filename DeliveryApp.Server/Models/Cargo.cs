using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models;

public record Cargo
{
    [Required(ErrorMessage = "Вес обязателен")]
    [Range(0.1, 1000, ErrorMessage = "Вес должен быть от 0.1 до 1000 кг")]
    public double Weight { get; init; }

    [Required(ErrorMessage = "Дата забора обязательна")]
    public DateTime PickupDate { get; init; }
}