using Microsoft.EntityFrameworkCore;
using PrjRefDddSolid.Domain.Entities;
using PrjRefDddSolid.Domain.Repositories.User;

namespace PrjRefDddSolid.Infrastructure.DataAccess.Repositories;

internal sealed class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    //crio uma instância do DbContext para poder acessar o banco de dados
    private readonly PrjRefDddSolidDbContext _dbContext;

    public UserRepository(PrjRefDddSolidDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        // Adiciona o usuário ao DbSet de usuários do DbContext(prepara a querie para ser executada no banco de dados)
        await _dbContext.Users.AddAsync(user);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email == email && user.Active);
    }
}
