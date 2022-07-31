namespace HwStore.Application.DTOs.Brand;

public class BrandDto_Detail : BaseDto
{
    public string? Name { get; set; }

    public IEnumerable<ProductDto_Base>? Products { get; set; }
}
