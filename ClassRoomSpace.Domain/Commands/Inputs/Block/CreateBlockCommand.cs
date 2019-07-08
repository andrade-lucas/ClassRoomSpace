using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs
{
    public class CreateBlockCommand : ICommand
    {
        public string Description { get; set; }
    }
}