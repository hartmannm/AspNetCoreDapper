namespace ANCD.Application.DTOs
{
    public sealed record PatientDTO
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public string Email { get; init; }

        public DateTime BirthDate { get; init; }
    }
}
