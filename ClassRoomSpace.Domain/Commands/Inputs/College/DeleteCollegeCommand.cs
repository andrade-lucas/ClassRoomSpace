using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.College
{
    public class DeleteCollegeCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}