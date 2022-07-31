namespace HwStore.Application.DTOs.Category;

public class CategoryDto_Upsert
{
    public string? Name { get; set; }
    public int ParentCategoryId { get; set; }
}
