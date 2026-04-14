using EnterpriseProject.Domain.Entities;
using EnterpriseProject.Domain.Repositories.SenhaEnterprise;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseProject.Infra.DataAccess.Repositories;

public class SenhaEnterpriseRepository : ISenhaEnterpriseWriteRepository, ISenhaEnterpriseReadRepository
{
    private readonly EnterpriseDbContext _context;
    public SenhaEnterpriseRepository(EnterpriseDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(SenhaEnterprise senhaEnterprise)
    {
        await _context.SenhasEnterprise.AddAsync(senhaEnterprise);
    }

    public async Task<SenhaEnterprise?> GetByEnterpriseIdAsync(int enterpriseId)
    {
        return await _context.SenhasEnterprise.FirstOrDefaultAsync(x => x.EnterpriseId == enterpriseId);
    }

    public void Update(SenhaEnterprise senhaEnterprise)
    {
        _context.SenhasEnterprise.Update(senhaEnterprise);
    }
}
