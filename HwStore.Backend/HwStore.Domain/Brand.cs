namespace HwStore.Domain;

public class Brand
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public IEnumerable<Product>? Products { get; set; }
}
