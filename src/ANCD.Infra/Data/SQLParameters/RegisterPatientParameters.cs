using ANCD.Domain.Entities;

namespace ANCD.Infra.Data.SQLParameters
{
    internal sealed record RegisterPatientParameters
    {
        public string Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public DateTime BirthDate { get; init; }

        public RegisterPatientParameters(Patient patient)
        {
            Id = patient.Id.ToString();
            FirstName = patient.Name.FirstName;
            LastName = patient.Name.LastName;
            Email = patient.Email.Address;
            BirthDate = patient.BirthDate;
        }
    }
}
