namespace HwStore.Application.DTOs.Image;

public class ImageDto_Details : ImageDto_Base
{
    public int ProductId { get; set; }
    public ProductDto_Base? Product { get; set; }
}
