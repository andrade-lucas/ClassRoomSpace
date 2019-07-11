using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Course
{
    public class CreateCourseCommand : ICommand
    {
        public Guid Id = Guid.NewGuid();
        public string Description { get; set; }
        public Guid IdCollege { get; set; }
    }
}