using EnterpriseProject.Domain.Entities;
using EnterpriseProject.Domain.Repositories.Enterprise;

using Microsoft.EntityFrameworkCore;

namespace EnterpriseProject.Infra.DataAccess.Repositories;

public class EnterpriseRepository : IEnterpriseWriteRepository, IEnterpriseReadRepository
{
    private readonly EnterpriseDbContext _dbContext;

    public EnterpriseRepository(EnterpriseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Enterprise enterprise)
    {
        await _dbContext.Enterprises.AddAsync(enterprise);
    }

    public async Task<Enterprise?> GetByIdAsync(int id)
    {
        return await _dbContext.Enterprises.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Enterprise>> GetAllAsync()
    {
        return await _dbContext.Enterprises.AsNoTracking().ToListAsync();
    }

    public void Update(Enterprise enterprise)
    {
        _dbContext.Enterprises.Update(enterprise);
    }
}
