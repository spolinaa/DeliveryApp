using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models;

public record Location
{
    [Required(ErrorMessage = "����� ����������")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "�������� ������ ������ ���� �� 2 �� 100 ��������")]
    public string City { get; init; }

    [Required(ErrorMessage = "����� ����������")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "����� ������ ���� �� 5 �� 200 ��������")]
    [RegularExpression(@"^[�-��-߸�0-9\s\/\-\.\,]+$", ErrorMessage = "����� �������� ������������ �������")]
    public string Address { get; init; }
}