namespace EnterpriseProject.Application.UseCases.SenhaEnterprise.Gerar;

public interface IGerarSenhaUseCase
{
    Task<string> ExecuteAsync(int enterpriseId);
}
