using EnterpriseProject.Communication.Responses;
using EnterpriseProject.Domain.Repositories.Enterprise;

namespace EnterpriseProject.Application.UseCases.Enterprise.GetById;

public class GetByIdEnterpriseUseCase : IGetByIdEnterpriseUseCase
{
    private readonly IEnterpriseReadRepository _repository;

    public GetByIdEnterpriseUseCase(IEnterpriseReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseEnterprise> ExecuteAsync(int id)
    {
        var enterprise = await _repository.GetByIdAsync(id);

        if (enterprise is null)
        {
            throw new Exception("Empresa não encontrada.");
        }

        return new ResponseEnterprise(enterprise.Id, enterprise.Name, enterprise.Cnpj);
    }
}
