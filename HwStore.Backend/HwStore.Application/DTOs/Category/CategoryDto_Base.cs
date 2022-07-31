namespace HwStore.Application.DTOs.Category;

public class CategoryDto_Base : BaseDto
{
    public string? Name { get; set; }
    public int ParentCategoryId { get; set; }

}
