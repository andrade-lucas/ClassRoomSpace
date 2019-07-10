using System;
using ClassRoomSpace.Domain.Enums;

namespace ClassRoomSpace.Domain.Queries.Professor
{
    public class GetProfessorByIdQuery
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public EProfessorStatus Status { get; set; }
        public Guid IdCourse { get; set; }
    }
}