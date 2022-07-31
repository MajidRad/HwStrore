namespace HwStore.Domain.Order;

public class OrderItem
{
    public int Id { get; set; }
    public ProductItemOrdered? ItemOrdered { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

}
