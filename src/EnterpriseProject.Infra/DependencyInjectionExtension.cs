using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EnterpriseProject.Domain.Repositories.Enterprise;
using EnterpriseProject.Domain.Repositories;
using EnterpriseProject.Infra.DataAccess.Repositories;
using EnterpriseProject.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;
using EnterpriseProject.Domain.Repositories.SenhaEnterprise;
using EnterpriseProject.Domain.Security.Cryptography;
using EnterpriseProject.Infra.Security.Cryptography;

namespace EnterpriseProject.Infra;

public static class DependencyInjectionExtension
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
        AddPasswordEncripter(services);
    }
    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<EnterpriseDbContext>(options =>
            options.UseSqlServer(connectionString));

    }
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEnterpriseWriteRepository, EnterpriseRepository>();
        services.AddScoped<IEnterpriseReadRepository, EnterpriseRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISenhaEnterpriseWriteRepository, SenhaEnterpriseRepository>();
        services.AddScoped<ISenhaEnterpriseReadRepository, SenhaEnterpriseRepository>();
    }
    private static void AddPasswordEncripter(this IServiceCollection services) 
    {
        services.AddScoped<IPasswordCryptography, BCryptNet>();
    }
}
