namespace HwStore.Application.DTOs.Product;

public class ProductDto_Create : IProductDto
{
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public int BrandId { get; set; }
    public int CategoryId { get; set; }
}
