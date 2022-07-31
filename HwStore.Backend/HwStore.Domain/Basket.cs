namespace HwStore.Domain;

public class Basket
{
    public Basket()
    {
        new List<BasketItem>();
    }
    public int Id { get; set; }
    public string? BuyerId { get; set; } = null!;
    public List<BasketItem>? BasketItems { get; set; }

}
