using ANCD.Domain.Entities.DomainEntities;
using ANCD.Domain.Entities.DomainEntities.Enums;
using ANCD.Domain.Entities.ValueObjects;

namespace ANCD.Domain.Entities
{
    public class Doctor : Person, IAggregateRoot
    {
        public CRMRegister CRM { get; private set; }

        public ICollection<MedicalExam> MedicalExams { get; private set; }

        public Doctor(string firstName, string lastName, string email, EUF CRMUF, long CRMNumber)
            : base(firstName, lastName, email)
        {
            CRM = new CRMRegister(CRMUF, CRMNumber);
            MedicalExams = new List<MedicalExam>();
        }
    }
}
