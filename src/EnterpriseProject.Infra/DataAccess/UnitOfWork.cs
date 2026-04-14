using EnterpriseProject.Domain.Repositories;

namespace EnterpriseProject.Infra.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly EnterpriseDbContext _dbContext;

    public UnitOfWork(EnterpriseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
