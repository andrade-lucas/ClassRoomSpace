using ClassRoomSpace.Domain.Enums;
using FluentValidator;
using FluentValidator.Validation;

namespace ClassRoomSpace.Domain.Entities
{
    public class ClassRoom : Notifiable
    {
        public string Description { get; set; }
        public EClassRoomStatus Status { get; set; }
        public EClassRoomType Type { get; set; }

        public ClassRoom(string description, EClassRoomStatus status, EClassRoomType type)
        {
            Description = description;
            Status = status;
            Type = type;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Description, 2, "Description", "O campo deve ter pelo menos 2 caracteres")
                .HasMaxLen(Description, 60, "Description", "O campo deve ter no máximo 60 caracteres")
            );
        }

        public void Book()
        {
            if (Status == EClassRoomStatus.Free)
                Status = EClassRoomStatus.Reserved;
        }

        public void SetAsUnvaiable()
        {
            if (Status != EClassRoomStatus.Unavailable)
                Status = EClassRoomStatus.Unavailable;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}