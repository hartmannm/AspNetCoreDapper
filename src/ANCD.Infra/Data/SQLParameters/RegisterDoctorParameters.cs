using ANCD.Domain.Entities;

namespace ANCD.Infra.Data.SQLParameters
{
    internal sealed record RegisterDoctorParameters
    {
        public Guid Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public string CrmUf { get; init; }

        public long CrmNumber { get; init; }

        public RegisterDoctorParameters(Doctor doctor)
        {
            Id = doctor.Id;
            FirstName = doctor.FirstName;
            LastName = doctor.LastName;
            Email = doctor.Email;
            CrmUf = doctor.CRMUf.ToString();
            CrmNumber = doctor.CRMNumber;
        }
    }
}
