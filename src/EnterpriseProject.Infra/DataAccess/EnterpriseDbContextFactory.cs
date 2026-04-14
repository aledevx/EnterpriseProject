using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnterpriseProject.Infra.DataAccess;

public class EnterpriseDbContextFactory : IDesignTimeDbContextFactory<EnterpriseDbContext>
{
    public EnterpriseDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EnterpriseDbContext>();

        optionsBuilder.UseSqlServer("Data Source=localhost, 1433;Initial Catalog=EnterpriseDb;User Id=sa;Password=q1!w2@e3#r4$;TrustServerCertificate=True;");


        return new EnterpriseDbContext(optionsBuilder.Options);
    }
}
