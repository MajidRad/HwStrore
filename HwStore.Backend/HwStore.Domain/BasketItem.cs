namespace HwStore.Domain;

public class BasketItem
{
    public int Id { get; set; }
    public int QuantityInBasket { get; set; }


    public int ProductId { get; set; }
    public Product? Product { get; set; } = null!;

    public int BasketId { get; set; }
    public Basket? Basket { get; set; }

}
