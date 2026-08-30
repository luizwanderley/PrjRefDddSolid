using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrjRefDddSolid.Infrastructure.DataAccess;

namespace PrjRefDddSolid.Infrastructure.Migrations;

public class DataBaseMigrations
{

    public static void ExecuteMigrations(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        runner.ListMigrations();

        runner.MigrateUp();
    }

    //public static async Task ExecuteMigrations(IServiceProvider serviceProvider)
    //{
    //    var dbContext = serviceProvider.GetRequiredService<PrjRefDddSolidDbContext>();

    //    await dbContext.Database.MigrateAsync();
    //}
}
