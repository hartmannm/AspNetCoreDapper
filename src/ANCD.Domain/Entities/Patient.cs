using ANCD.Domain.Entities.DomainEntities;

namespace ANCD.Domain.Entities
{
    public class Patient : Person, IAggregateRoot
    {
        public DateTime BirthDate { get; private set; }

        public ICollection<MedicalExam> MedicalExams { get; private set; }

        private Patient() : base(null, null, null)
        {
            MedicalExams = new List<MedicalExam>();
        }

        public Patient(string firstName, string lastName, string email, DateTime birthDate)
            : base(firstName, lastName, email)
        {
            BirthDate = birthDate;
            MedicalExams = new List<MedicalExam>();
        }
    }
}
