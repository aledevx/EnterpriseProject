namespace EnterpriseProject.Domain.Repositories.SenhaEnterprise;

public interface ISenhaEnterpriseReadRepository
{
        Task<Entities.SenhaEnterprise?> GetByEnterpriseIdAsync(int enterpriseId);
}
