using ClassRoomSpace.Domain.Enums;
using FluentValidator;

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
        }

        public void Book()
        {
            if (Status == EClassRoomStatus.Free)
                Status = EClassRoomStatus.Reserved;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}