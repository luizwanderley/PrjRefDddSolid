using Microsoft.EntityFrameworkCore;
using PrjRefDddSolid.Domain.Entities;

namespace PrjRefDddSolid.Infrastructure.DataAccess;

internal class PrjRefDddSolidDbContext : DbContext
{
    //repassa as options para o DbContext(classe mãe) :base(dbContextOptions)

    public PrjRefDddSolidDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public DbSet<User> Users { get; set; }
}
