using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Shared.Entities;

namespace ClassRoomSpace.Domain.Entities
{
    public class User : Entity
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public string Phone { get; private set; }
        public EUserStatus Status { get; private set; }
        public string Image { get; private set; }
        
        public User(Name name, Document document, Email email, Password password, string phone, EUserStatus status, string image)
        {
            Name = name;
            Document = document;
            Email = email;
            Password = password;
            Phone = phone;
            Status = status;
            Image = image;
        }

        public void ChangePhone(string phone)
        {
            if (!string.IsNullOrEmpty(phone))
                Phone = phone;
        }

        public void ChangeStatus(EUserStatus status) 
        {
            Status = status;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}