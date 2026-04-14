using EnterpriseProject.Communication.Requests;
using EnterpriseProject.Communication.Responses;
using EnterpriseProject.Domain.Repositories.Enterprise;
using EnterpriseProject.Domain.Repositories;

namespace EnterpriseProject.Application.UseCases.Enterprise.Register;

public class RegisterEnterpriseUseCase : IRegisterEnterpriseUseCase
{
    private readonly IEnterpriseWriteRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterEnterpriseUseCase(IEnterpriseWriteRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseEnterprise> ExecuteAsync(RequestRegisterEnterprise request)
    {
        Validate(request);

        var enterprise = new Domain.Entities.Enterprise
        {
            Name = request.Name,
            Cnpj = request.Cnpj,
            CreateAt = DateTime.UtcNow,
            Active = true
        };

        await _repository.AddAsync(enterprise);
        await _unitOfWork.Commit();

        return new ResponseEnterprise(enterprise.Id, enterprise.Name, enterprise.Cnpj);
    }

    private void Validate(RequestRegisterEnterprise request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("O nome não pode ser vazio.");
        
        if (string.IsNullOrWhiteSpace(request.Cnpj))
            throw new ArgumentException("O CNPJ não pode ser vazio.");
    }
}