using FluentMigrator;

namespace PrjRefDddSolid.Infrastructure.Migrations.Versions;

[Migration(DataBaseVersions.TABLE_USERS,"Creating Users table")]
public class Version0000001 : ForwardOnlyMigration
{

    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
            .WithColumn("Name").AsString(250).NotNullable()
            .WithColumn("Email").AsString(250).NotNullable()
            .WithColumn("Password").AsString(2000).NotNullable();
    }
}
