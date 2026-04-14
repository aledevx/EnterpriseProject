using EnterpriseProject.Application.UseCases.Enterprise.GetAll;
using EnterpriseProject.Application.UseCases.Enterprise.GetById;
using EnterpriseProject.Application.UseCases.Enterprise.Register;
using EnterpriseProject.Application.UseCases.Enterprise.Update;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseProject.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }
    private static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IRegisterEnterpriseUseCase, RegisterEnterpriseUseCase>();
        services.AddScoped<IGetByIdEnterpriseUseCase, GetByIdEnterpriseUseCase>();
        services.AddScoped<IUpdateEnterpriseUseCase, UpdateEnterpriseUseCase>();
        services.AddScoped<IGetAllEnterprisesUseCase, GetAllEnterprisesUseCase>();
    }
}
