using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using mytodo.domain.Services;

namespace mytodo.ioc.Services;

public class EncryptionService : IEncryptionService
{
    public string Encrypt(string password)
    {
        var salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return $"{Convert.ToBase64String(salt)}:{hashed}";
    }
    
    public bool Verify(string password, string passwordHash)
    {
        var parts = passwordHash.Split(':');
        var salt = Convert.FromBase64String(parts[0]);
        var hash = Convert.FromBase64String(parts[1]);

        var hashed = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8);

        return hashed.SequenceEqual(hash);
    }
}