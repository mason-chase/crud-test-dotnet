using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class CrudTestDbContextInitialiser
{
    private readonly ILogger<CrudTestDbContextInitialiser> _logger;
    private readonly CrudTestDbContext _context;

    public CrudTestDbContextInitialiser(ILogger<CrudTestDbContextInitialiser> logger, 
        CrudTestDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }


}
