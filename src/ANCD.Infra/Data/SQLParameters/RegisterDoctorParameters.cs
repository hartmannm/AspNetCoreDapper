using ANCD.Domain.Entities;

namespace ANCD.Infra.Data.SQLParameters
{
    internal sealed record RegisterDoctorParameters
    {
        public string Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public string CrmUf { get; init; }

        public long CrmNumber { get; init; }

        public RegisterDoctorParameters(Doctor doctor)
        {
            Id = doctor.Id.ToString();
            FirstName = doctor.Name.FirstName;
            LastName = doctor.Name.LastName;
            Email = doctor.Email.Address;
            CrmUf = doctor.CRM.Uf.ToString();
            CrmNumber = doctor.CRM.Number;
        }
    }
}
