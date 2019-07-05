using FluentValidator;
using FluentValidator.Validation;

namespace ClassRoomSpace.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address ?? "";
           
            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "E-mail inválido")
            );
        }
    }
}