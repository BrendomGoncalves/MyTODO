namespace mytodo.domain.Services;

public interface IEncryptionService
{
    string Encrypt(string password);
    bool Verify(string password, string passwordHash);
}