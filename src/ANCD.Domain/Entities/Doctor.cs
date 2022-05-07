using ANCD.Domain.Entities.DomainEntities;
using ANCD.Domain.Entities.DomainEntities.Enums;

namespace ANCD.Domain.Entities
{
    public class Doctor : Person, IAggregateRoot
    {
        public EUF CRMUf { get; init; }

        public long CRMNumber { get; init; }

        public ICollection<MedicalExam> MedicalExams { get; private set; }

        private Doctor() : base(null, null, null)
        {
            MedicalExams = new List<MedicalExam>();
        }

        public Doctor(string firstName, string lastName, string email, EUF CrmUf, long CrmNumber)
            : base(firstName, lastName, email)
        {
            CRMUf = CrmUf;
            CRMNumber = CrmNumber;
            MedicalExams = new List<MedicalExam>();
        }
    }
}
