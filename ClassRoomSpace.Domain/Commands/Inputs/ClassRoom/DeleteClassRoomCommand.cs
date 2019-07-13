using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.ClassRoom
{
    public class DeleteClassRoomCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}