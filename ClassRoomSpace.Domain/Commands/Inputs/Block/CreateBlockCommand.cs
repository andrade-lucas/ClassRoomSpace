using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Block
{
    public class CreateBlockCommand : ICommand
    {
        public string Description { get; set; }
    }
}