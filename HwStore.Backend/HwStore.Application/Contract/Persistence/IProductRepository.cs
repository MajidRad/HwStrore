namespace HwStore.Application.Contract.Persistence;

public interface IProductRepository : IGenricRepository<Product>
{
    Task<PagedList<Product>> GetProducts(PaginationParams param);
    Task<Product> GetProductWithDetails(int id);
    Task Update(Product Product);
}
