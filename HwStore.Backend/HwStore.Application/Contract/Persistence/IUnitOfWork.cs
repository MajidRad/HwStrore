namespace HwStore.Application.Contract.Persistence;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IBrandRepository BrandRepository { get; }
    ISpecificationRepository SpecificationRepository { get; }
    IBasketRepository BasketRepository { get; }
    Task SaveAsync();
    void Save();
}
