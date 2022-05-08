namespace ANCD.Application.DTOs
{
    public class MedicalExamDTO
    {
        public Guid Id { get; init; }

        public string Status { get; init; }

        public DateTime Date { get; init; }

        public DoctorDTO Doctor { get; init; }

        public PatientDTO Patient { get; init; }
    }
}
