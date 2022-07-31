using HwStore.Application.DTOs.Basket;

namespace HwStore.Application.Models.Identity;

public class AuthResponse
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? Token { get; set; }
    public BasketDto_Base? Basket { get; set; }
}
