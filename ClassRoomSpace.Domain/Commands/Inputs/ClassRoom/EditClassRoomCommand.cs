using System;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.ClassRoom
{
    public class EditClassRoomCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EClassRoomStatus Status { get; set; }
        public EClassRoomType Type { get; set; }
        public Guid IdBlock { get; set; }
    }
}