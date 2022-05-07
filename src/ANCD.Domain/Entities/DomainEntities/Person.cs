namespace ANCD.Domain.Entities.DomainEntities
{
    public abstract class Person : Entity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Person(string firstName, string lastName, string email) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;  
        }
    }
}
