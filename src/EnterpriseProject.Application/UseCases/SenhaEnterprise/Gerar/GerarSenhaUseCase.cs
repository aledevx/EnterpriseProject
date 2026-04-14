using EnterpriseProject.Domain.Repositories;
using EnterpriseProject.Domain.Repositories.SenhaEnterprise;
using EnterpriseProject.Domain.Security.Cryptography;
using System.Security.Cryptography;

namespace EnterpriseProject.Application.UseCases.SenhaEnterprise.Gerar;

public class GerarSenhaUseCase : IGerarSenhaUseCase
{
    private readonly ISenhaEnterpriseWriteRepository _writeRepository;
    private readonly ISenhaEnterpriseReadRepository _readRepository;
    private readonly IPasswordCryptography _passwordCryptography;
    private readonly IUnitOfWork _unitOfWork;
    public GerarSenhaUseCase(ISenhaEnterpriseWriteRepository writeRepository,
        ISenhaEnterpriseReadRepository readRepository,
        IPasswordCryptography passwordCryptography,
        IUnitOfWork unitOfWork)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _passwordCryptography = passwordCryptography;
        _unitOfWork = unitOfWork;
    }
    public async Task<string> ExecuteAsync(int enterpriseId)
    {
        var senha = RandomNumberGenerator.GetInt32(100000, 1000000);
        var senhaHash = _passwordCryptography.Encrypt(senha.ToString());

        var senhaEnterprise = await _readRepository.GetByEnterpriseIdAsync(enterpriseId);

        if (senhaEnterprise is null) 
        {
            var novaSenhaEnterprise = new Domain.Entities.SenhaEnterprise(enterpriseId, senhaHash);
            await _writeRepository.AddAsync(novaSenhaEnterprise);
            await _unitOfWork.Commit();
            return senha.ToString();
        }

        senhaEnterprise.AtualizarSenha(senhaHash);

        _writeRepository.Update(senhaEnterprise);
        await _unitOfWork.Commit();

        return senha.ToString();
    }
}
