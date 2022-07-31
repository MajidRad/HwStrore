namespace HwStore.Application.DTOs.Product;

public class ProductDto_Details : ProductDto_Base
{

    public CategoryDto_Base? Category { get; set; }

    public BrandDto_Base? Brand { get; set; }

    public IEnumerable<ImageDto_Base>? Images { get; set; }

    public ICollection<SpecificationDto_Base> Specifications { get; set; }
}
