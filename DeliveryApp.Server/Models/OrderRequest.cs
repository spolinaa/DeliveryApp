using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models;

public record OrderRequest
{
    [Required(ErrorMessage = "������ ����������� �����������")]
    public Location SenderLocation { get; init; }

    [Required(ErrorMessage = "������ ���������� �����������")]
    public Location ReceiverLocation { get; init; }

    [Required(ErrorMessage = "������ ����� �����������")]
    public Cargo Cargo { get; init; }
}