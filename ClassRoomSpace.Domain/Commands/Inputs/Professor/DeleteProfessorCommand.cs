using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Professor
{
    public class DeleteProfessorCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}