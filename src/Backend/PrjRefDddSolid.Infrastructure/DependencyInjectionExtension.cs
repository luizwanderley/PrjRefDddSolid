using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrjRefDddSolid.Domain.Repositories;
using PrjRefDddSolid.Domain.Repositories.User;
using PrjRefDddSolid.Domain.Security.PasswordHashing;
using PrjRefDddSolid.Infrastructure.DataAccess;
using PrjRefDddSolid.Infrastructure.DataAccess.Repositories;
using PrjRefDddSolid.Infrastructure.Security;
using System.Reflection;

namespace PrjRefDddSolid.Infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();

            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<PrjRefDddSolidDbContext>(config =>
            {
                // Configuração do provedor de banco de dados e string de conexão

                var connectionString = configuration.GetConnectionString("DbConnection");

                //O ! é usado para indicar que a variável connectionString não é nula, mesmo que o compilador possa inferir
                //que ela pode ser nula.

                config.UseMySQL(connectionString!);

            });

            services.AddFluentMigratorCore().ConfigureRunner(config =>
            {
                var connectionString = configuration.GetConnectionString("DbConnection");

                config
                .AddMySql5()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("PrjRefDddSolid.Infrastructure"))
                .For.All();

            });
        }
    }
}
