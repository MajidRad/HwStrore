namespace HwStore.Application.DTOs.Basket;

public class BasketDto_Base : BaseDto
{
    public string? BuyerId { get; set; } = null!;
    public List<BasketItemDto>? BasketItems { get; set; } = new List<BasketItemDto>();
}
