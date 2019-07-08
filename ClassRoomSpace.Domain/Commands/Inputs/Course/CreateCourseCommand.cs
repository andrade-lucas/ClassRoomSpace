using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Course
{
    public class CreateCourseCommand : ICommand
    {
        public string Description { get; set; }
    }
}