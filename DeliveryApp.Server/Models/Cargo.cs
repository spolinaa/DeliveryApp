using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models;

public record Cargo
{
    [Required(ErrorMessage = "��� ����������")]
    [Range(0.1, 1000, ErrorMessage = "��� ������ ���� �� 0.1 �� 1000 ��")]
    public double Weight { get; init; }

    [Required(ErrorMessage = "���� ������ �����������")]
    public DateTime PickupDate { get; init; }
}