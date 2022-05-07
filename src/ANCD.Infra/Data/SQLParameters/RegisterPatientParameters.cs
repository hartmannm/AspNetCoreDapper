using ANCD.Domain.Entities;

namespace ANCD.Infra.Data.SQLParameters
{
    internal sealed record RegisterPatientParameters
    {
        public Guid Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public DateTime BirthDate { get; init; }

        public RegisterPatientParameters(Patient patient)
        {
            Id = patient.Id;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            Email = patient.Email;
            BirthDate = patient.BirthDate;
        }
    }
}
