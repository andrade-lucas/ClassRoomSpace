using FluentValidator;
using FluentValidator.Validation;

namespace ClassRoomSpace.Domain.Entities
{
    public class Block : Notifiable
    {
        public string Description { get; private set; }

        public Block(string description)
        {
            Description = description ?? "";

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Description, 2, "Description", "O campo deve conter pelo menos 2 caracteres")
                .HasMaxLen(Description, 60, "Description", "O campo deve conter no máximo 60 caracteres")
            );
        }
    }
}