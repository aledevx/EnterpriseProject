using System.ComponentModel.DataAnnotations;

namespace EnterpriseProject.Domain.Entities;

public class SenhaEnterprise
{
    [Key]
    public int Id { get; private set; }
    public int EnterpriseId { get; private set; }
    public string HashSenha { get; private set; } = string.Empty;
    public DateTime DataGeracao { get; private set; }
    public SenhaEnterprise(int enterpriseId, string hashSenha)
    {
        EnterpriseId = enterpriseId;
        HashSenha = hashSenha;
        DataGeracao = DateTime.UtcNow;
    }
    public SenhaEnterprise()
    {
        
    }
    public void AtualizarSenha(string novaHashSenha)
    {
        HashSenha = novaHashSenha;
        DataGeracao = DateTime.UtcNow;
    }
}
