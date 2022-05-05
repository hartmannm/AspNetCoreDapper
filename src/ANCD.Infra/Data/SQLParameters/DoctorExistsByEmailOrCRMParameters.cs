namespace ANCD.Infra.Data.SQLParameters
{
    internal sealed record DoctorExistsByEmailOrCRMParameters
    {
        public string Email { get; init; }

        public string CrmUf { get; init; }

        public long CrmNumber { get; init; }

        public DoctorExistsByEmailOrCRMParameters(string email, string crmUf, long crmNumber)
        {
            Email = email;
            CrmUf = crmUf;
            CrmNumber = crmNumber;
        }
    }
}
