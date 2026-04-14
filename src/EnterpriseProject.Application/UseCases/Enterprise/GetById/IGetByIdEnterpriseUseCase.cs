using EnterpriseProject.Communication.Responses;

namespace EnterpriseProject.Application.UseCases.Enterprise.GetById;

public interface IGetByIdEnterpriseUseCase
{
    Task<ResponseEnterprise> ExecuteAsync(int id);
}
