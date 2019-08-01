using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Shared.Entities;

namespace ClassRoomSpace.Domain.Entities
{
    public class Professor : Entity
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Course Course { get; private set; }
        public string Phone { get; private set; }
        public EProfessorStatus Status { get; private set; }
        
        public Professor(Name name, Document document, Email email, Course course, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Course = course;
            Phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            Status = EProfessorStatus.Active;

            AddNotifications(Name.Notifications);
            AddNotifications(Document.Notifications);            
            AddNotifications(Email.Notifications);            
            AddNotifications(Course.Notifications);          
        }

        public void Inactivate()
        {
            Status = EProfessorStatus.Inactive;
        }

        public void Activate()
        {
            Status = EProfessorStatus.Active;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}