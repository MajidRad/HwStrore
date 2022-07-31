namespace HwStore.Application.DTOs.Product;

public interface IProductDto
{

    public string? Name { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
