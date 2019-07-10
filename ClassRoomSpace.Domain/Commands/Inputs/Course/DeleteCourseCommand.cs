using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Course
{
    public class DeleteCourseCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}