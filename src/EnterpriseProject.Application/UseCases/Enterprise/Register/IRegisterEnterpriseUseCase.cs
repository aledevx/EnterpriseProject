using EnterpriseProject.Communication.Requests;
using EnterpriseProject.Communication.Responses;

namespace EnterpriseProject.Application.UseCases.Enterprise.Register;

public interface IRegisterEnterpriseUseCase
{
    Task<ResponseEnterprise> ExecuteAsync(RequestRegisterEnterprise request);
}