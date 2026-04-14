using EnterpriseProject.Communication.Responses;

namespace EnterpriseProject.Application.UseCases.Enterprise.GetAll;

public interface IGetAllEnterprisesUseCase
{
    Task<List<ResponseEnterprise>> ExecuteAsync();
}
