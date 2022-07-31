namespace HwStore.Application.DTOs.Category;

public class CategoryDto_Details : CategoryDto_Base
{
    public IEnumerable<ProductDto_Base>? Products { get; set; }
}
