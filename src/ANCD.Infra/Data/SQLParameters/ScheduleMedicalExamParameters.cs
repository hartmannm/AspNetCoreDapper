using ANCD.Domain.Entities;

namespace ANCD.Infra.Data.SQLParameters
{
    public sealed record ScheduleMedicalExamParameters
    {
        public Guid Id { get; init; }

        public DateTime Date { get; init; }

        public Guid DoctorId { get; init; }

        public Guid PatientId { get; init; }

        public string Status { get; init; }

        public ScheduleMedicalExamParameters(MedicalExam exam)
        {
            Id = exam.Id;
            Date = exam.Date;
            DoctorId = exam.DoctorId;
            PatientId = exam.PatientId;
            Status = exam.Status.ToString();
        }
    }
}
