namespace EnterpriseProject.Domain.Repositories.SenhaEnterprise;

public interface ISenhaEnterpriseWriteRepository
{
    Task AddAsync(Entities.SenhaEnterprise senhaEnterprise);
    void Update(Entities.SenhaEnterprise senhaEnterprise);
}
