namespace ANCD.Application.DTOs
{
    public class MedicalExamDTO
    {
        public Guid Id { get; init; }

        public Guid DoctorId { get; init; }

        public Guid PatientId { get; init; }

        public string Status { get; init; }

        public DateTime Date { get; init; }
    }
}
