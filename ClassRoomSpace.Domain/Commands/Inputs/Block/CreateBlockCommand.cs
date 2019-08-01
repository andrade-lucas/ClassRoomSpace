using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Block
{
    public class CreateBlockCommand : ICommand
    {
        public Guid Id = Guid.NewGuid();
        public string Description { get; set; }
        public Guid IdCollege { get; set; }
    }
}