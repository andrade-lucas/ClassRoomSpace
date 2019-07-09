using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Block
{
    public class DeleteBlockCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}