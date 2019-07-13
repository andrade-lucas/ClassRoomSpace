namespace ClassRoomSpace.Domain.Commands.Inputs.ClassRoom
{
    public class CreateClassRoomCommand : ICommand
    {
        public string Description { get; set; }
        public bool Status { get; set; }
        public EClassRoomType Type { get; set; }
    }
}