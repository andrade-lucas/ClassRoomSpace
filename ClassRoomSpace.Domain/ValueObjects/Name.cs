using FluentValidator;
using FluentValidator.Validation;

namespace ClassRoomSpace.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            Validate();
        }

        public void Change(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Validate();
        }

        private void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 2, "FirstName", "O nome deve conter pelo menos 2 caracteres")
                .HasMaxLen(FirstName, 30, "FirstName", "O nome deve conter no máximo 30 caracteres")
                .HasMinLen(LastName, 2, "LastName", "O sobrenome deve conter pelo menos 2 caracteres")
                .HasMaxLen(LastName, 30, "LastName", "O sobrenome deve conter no máximo 30 caracteres")
            );
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}