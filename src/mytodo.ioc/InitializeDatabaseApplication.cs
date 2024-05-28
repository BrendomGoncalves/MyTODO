using Microsoft.EntityFrameworkCore;
using mytodo.data;
using mytodo.domain.Entities;
using mytodo.domain.Services;

namespace mytodo.ioc;

public class InitializeDatabaseApplication
{
    private readonly MytodoDbContext _context;
    private readonly IEncryptionService _encryptionService;

    public InitializeDatabaseApplication(MytodoDbContext context, IEncryptionService encryptionService)
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
            // TODO: configurar mensagem de erro
            Console.WriteLine(ex.Message);
            throw;
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
            // TODO: configurar mensagem de erro
            Console.WriteLine(ex.Message);
            throw;
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

        if (!_context.User.Any())
        {
            _context.User.Add(userTest);
            await _context.SaveChangesAsync();
        }
        else
        {
            var user = await _context.User.FirstOrDefaultAsync(usuario => usuario.Username == "UserTest");
            if (user == null)
            {
                _context.User.Add(userTest);
                await _context.SaveChangesAsync();
            }
        }
    }
}