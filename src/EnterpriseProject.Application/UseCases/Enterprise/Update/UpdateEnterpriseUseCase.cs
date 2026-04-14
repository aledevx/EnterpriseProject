using EnterpriseProject.Communication.Requests;
using EnterpriseProject.Domain.Repositories.Enterprise;
using EnterpriseProject.Domain.Repositories;

namespace EnterpriseProject.Application.UseCases.Enterprise.Update;

public class UpdateEnterpriseUseCase : IUpdateEnterpriseUseCase
{
    private readonly IEnterpriseReadRepository _readRepository;
    private readonly IEnterpriseWriteRepository _writeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEnterpriseUseCase(
        IEnterpriseReadRepository readRepository,
        IEnterpriseWriteRepository writeRepository,
        IUnitOfWork unitOfWork)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(int id, RequestUpdateEnterprise request)
    {
        Validate(request);

        var enterprise = await _readRepository.GetByIdAsync(id);

        if (enterprise is null)
        {
            throw new Exception("Empresa não encontrada.");
        }

        enterprise.Name = request.Name;
        enterprise.Cnpj = request.Cnpj;

        _writeRepository.Update(enterprise);
        await _unitOfWork.Commit();
    }

    private void Validate(RequestUpdateEnterprise request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("O nome não pode ser vazio.");
        
        if (string.IsNullOrWhiteSpace(request.Cnpj))
            throw new ArgumentException("O CNPJ não pode ser vazio.");
    }
}
