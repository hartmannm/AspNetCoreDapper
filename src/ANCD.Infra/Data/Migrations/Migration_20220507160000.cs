using FluentMigrator;

namespace ANCD.Infra.Data.Migrations
{
    [Migration(20220507160000)]
    public class Migration_20220507160000 : Migration
    {
        public override void Down()
        {
            Delete.Table("MedicalExams");
        }

        public override void Up()
        {
            Create.Table("MedicalExams")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Date").AsDateTime2().NotNullable()
                .WithColumn("DoctorId").AsGuid().NotNullable()
                    .ForeignKey("Doctors", "Id")
                .WithColumn("PatientId").AsGuid().NotNullable()
                    .ForeignKey("Patients", "Id")
                .WithColumn("Status").AsString(30).NotNullable();
        }
    }
}
