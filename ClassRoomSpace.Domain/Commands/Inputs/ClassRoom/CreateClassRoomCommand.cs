using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Shared.Commands;
using System;

namespace ClassRoomSpace.Domain.Commands.Inputs.ClassRoom
{
    public class CreateClassRoomCommand : ICommand
    {
        public Guid Id = Guid.NewGuid();
        public string Description { get; set; }
        public EClassRoomStatus Status { get; set; }
        public EClassRoomType Type { get; set; }
        public Guid IdBlock { get; set; }
    }
}