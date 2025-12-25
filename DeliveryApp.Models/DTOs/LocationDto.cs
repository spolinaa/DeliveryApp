using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models.DTOs;

public record LocationDto
{
    [Required(ErrorMessage = "Город обязателен")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Название города должно быть от 2 до 100 символов")]
    public string City { get; init; }

    [Required(ErrorMessage = "Адрес обязателен")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "Адрес должен быть от 5 до 200 символов")]
    public string Address { get; init; }
}