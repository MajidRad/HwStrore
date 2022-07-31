namespace HwStore.Application.DTOs.Basket;

public class BasketItemDto
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public int Quantity { get; set; }
    public int QuantityInBasket { get; set; }

}
