using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Block
{
    public class EditBlockCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid IdCollege { get; set; }
    }
}