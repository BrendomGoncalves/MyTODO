namespace mytodo.domain.Services;

public interface IEncryptionService
{
    string Encrypt(string plainText);
    bool Verify(string password, string passwordHash);
}