using EnterpriseProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseProject.Infra.DataAccess;

public class EnterpriseDbContext : DbContext
{
    public EnterpriseDbContext(DbContextOptions<EnterpriseDbContext> options) : base(options)
    {
        
    }

    public DbSet<Enterprise> Enterprises { get; set; }
    public DbSet<SenhaEnterprise> SenhasEnterprise { get; set; }
}
