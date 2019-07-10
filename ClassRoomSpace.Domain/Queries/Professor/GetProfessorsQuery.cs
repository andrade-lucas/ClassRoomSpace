using System;
using ClassRoomSpace.Domain.Enums;

namespace ClassRoomSpace.Domain.Queries.Professor
{
    public class GetProfessorsQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public EProfessorStatus Status { get; set; }
    }
}