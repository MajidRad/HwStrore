namespace HwStore.Application.Contract.Persistence;

public interface IBrandRepository : IGenricRepository<Brand>
{
    Task Update(Brand brand);
}
