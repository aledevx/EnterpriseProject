namespace EnterpriseProject.Domain.Security.Cryptography;

public interface IPasswordCryptography
{
    string Encrypt(string password);
    bool IsValid(string password, string passwordHash);
}
