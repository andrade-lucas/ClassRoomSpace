using System;

namespace ClassRoomSpace.Domain.Queries.Course
{
    public class GetCourseByIdQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid IdCollege { get; set; }
    }
}