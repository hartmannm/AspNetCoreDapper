using FluentMigrator;

namespace ANCD.Infra.Data.Migrations
{
    [Migration(20220504210000)]
    public class Migration_20220504210000 : Migration
    {
        public override void Down()
        {
            Delete.Table("Doctors");
        }

        public override void Up()
        {
            Create.Table("Doctors")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("FirstName").AsString(255).NotNullable()
                .WithColumn("LastName").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("CrmUf").AsString(2).NotNullable()
                .WithColumn("CrmNumber").AsInt64().NotNullable();
        }
    }
}
