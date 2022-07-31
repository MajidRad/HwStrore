using Microsoft.EntityFrameworkCore;

namespace HwStore.Domain.Order;

[Owned]
public class ProductItemOrdered
{
    public int productId { get; set; }
    public string? Name { get; set; }
    public int pictrureUrl { get; set; }
}
