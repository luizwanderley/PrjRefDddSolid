using PrjRefDddSolid.Domain.Repositories;

namespace PrjRefDddSolid.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly PrjRefDddSolidDbContext _dbContext;

    public UnitOfWork(PrjRefDddSolidDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //executa a(s) querie(s) preparada(s) no banco de dados pelo UserRepository
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
