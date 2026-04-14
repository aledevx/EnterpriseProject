using EnterpriseProject.Communication.Requests;

namespace EnterpriseProject.Application.UseCases.Enterprise.Update;

public interface IUpdateEnterpriseUseCase
{
    Task ExecuteAsync(int id, RequestUpdateEnterprise request);
}
