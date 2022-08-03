namespace HwStore.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }

        public Product? Product { get; set; }
        public int ProductId { get; set; }
    }
}