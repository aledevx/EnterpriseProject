using EnterpriseProject.Communication.Responses;
using EnterpriseProject.Domain.Repositories.Enterprise;

namespace EnterpriseProject.Application.UseCases.Enterprise.GetAll;

public class GetAllEnterprisesUseCase : IGetAllEnterprisesUseCase
{
    private readonly IEnterpriseReadRepository _repository;

    public GetAllEnterprisesUseCase(IEnterpriseReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ResponseEnterprise>> ExecuteAsync()
    {
        var enterprises = await _repository.GetAllAsync();
        
        return enterprises.Select(e => new ResponseEnterprise(e.Id, e.Name, e.Cnpj)).ToList();
    }
}
