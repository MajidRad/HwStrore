namespace HwStore.Application.Contract.Persistence;

public interface ISpecificationRepository : IGenricRepository<Specification>
{
    Task Update(Specification specification);
    Task<ICollection<Specification>> GetSpecById(int prodId);
}
