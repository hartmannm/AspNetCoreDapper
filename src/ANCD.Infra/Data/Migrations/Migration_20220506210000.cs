using FluentMigrator;

namespace ANCD.Infra.Data.Migrations
{
    [Migration(20220506210000)]
    public class Migration_20220506210000 : Migration
    {
        public override void Down()
        {
            Alter.Table("Doctors")
                .AlterColumn("Email").AsString(255).NotNullable();
        }

        public override void Up()
        {
            Alter.Table("Doctors")
                .AlterColumn("Email").AsString(255).NotNullable().Unique();
        }
    }
}
