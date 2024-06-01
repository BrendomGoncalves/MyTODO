using Microsoft.EntityFrameworkCore;
using mytodo.data;
using mytodo.domain.Entities;
using mytodo.domain.Services;

namespace mytodo.ioc;

public class MytodoDbContextInitializer
{
    private readonly MytodoDbContext _context;
    private readonly IEncryptionService _encryptionService;

    public MytodoDbContextInitializer(MytodoDbContext context, IEncryptionService encryptionService)
    {
        _context = context;
        _encryptionService = encryptionService;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.EnsureCreatedAsync();
            await _context.Database.MigrateAsync();
        }
        catch(Exception ex)
        {
            throw new Exception("Erro ao inicializar o banco de dados", ex);
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedTest();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao semear o banco de dados", ex);
        }
    }

    private async Task TrySeedTest()
    {
        var userTest = new UserEntity
        {
            Username = "UserTest",
            Email = "user@test.com",
            PasswordHash = _encryptionService.Encrypt("usertest")
        };

        if (!_context.Users.Any())
        {
            _context.Users.Add(userTest);
            await _context.SaveChangesAsync();
        }
        else
        {
            var user = await _context.Users.FirstOrDefaultAsync(usuario => usuario.Username == "UserTest");
            if (user == null)
            {
                _context.Users.Add(userTest);
                await _context.SaveChangesAsync();
            }
        }
    }
}