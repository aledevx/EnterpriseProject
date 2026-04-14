namespace EnterpriseProject.Domain.Repositories.Enterprise;

public interface IEnterpriseWriteRepository
{
    public Task AddAsync(Entities.Enterprise enterprise);
    public void Update(Entities.Enterprise enterprise);
}
