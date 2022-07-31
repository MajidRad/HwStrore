namespace HwStore.Application.Contract.Persistence;

public interface ICategoryRepository : IGenricRepository<Category>
{
    Task Update(Category category);
}
