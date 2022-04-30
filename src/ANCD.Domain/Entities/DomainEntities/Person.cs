using ANCD.Domain.Entities.DomainEntities.ValueObjects;

namespace ANCD.Domain.Entities.DomainEntities
{
    public abstract class Person : Entity
    {
        public Name Name { get; private set; }

        public Email Email { get; private set; }


        public Person(string firstName, string lastName, string email)
        {
            Name = new Name(firstName: firstName, lastName: lastName);
            Email = new Email(email);
        }
    }
}
