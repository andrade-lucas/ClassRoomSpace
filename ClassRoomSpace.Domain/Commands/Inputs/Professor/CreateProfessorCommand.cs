using System;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Professor
{
    public class CreateProfessorCommand : ICommand
    {
        public Guid Id = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public Guid IdCourse { get; set; }
        public string Phone { get; set; }
        public EProfessorStatus Status { get; set; }
    }
}