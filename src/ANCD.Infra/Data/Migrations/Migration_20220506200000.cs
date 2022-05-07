using FluentMigrator;

namespace ANCD.Infra.Data.Migrations
{
    [Migration(20220506200000)]
    public class Migration_20220506200000 : Migration
    {
        public override void Down()
        {
            Delete.Table("Patients");
        }

        public override void Up()
        {
            Create.Table("Patients")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("FirstName").AsString(255).NotNullable()
                .WithColumn("LastName").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable().Unique()
                .WithColumn("BirthDate").AsDateTime2().NotNullable();
        }
    }
}
