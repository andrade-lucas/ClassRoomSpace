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
        
        public Professor(Name name, Document document, Email email, Course course, string phone, EProfessorStatus status)
        {
            Name = name;
            Document = document;
            Email = email;
            Course = course;
            Phone = phone;
            Status = status;
        }
    }
}