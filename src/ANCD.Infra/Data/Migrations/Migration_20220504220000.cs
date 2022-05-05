using FluentMigrator;

namespace ANCD.Infra.Data.Migrations
{
    [Migration(20220504220000)]
    public class Migration_20220504220000 : Migration
    {
        public override void Down()
        {
            Delete.UniqueConstraint("IX_Doctors_CrmUf_CrmNumber")
                .FromTable("Doctors");
        }

        public override void Up()
        {
            Create.UniqueConstraint("IX_Doctors_CrmUf_CrmNumber")
                .OnTable("Doctors")
                .Columns("CrmUf", "CrmNumber");
        }
    }
}
