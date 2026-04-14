namespace EnterpriseProject.Domain.Repositories.Enterprise;

public interface IEnterpriseReadRepository
{
    public Task<Entities.Enterprise?> GetByIdAsync(int id);
    public Task<List<Entities.Enterprise>> GetAllAsync();
}
