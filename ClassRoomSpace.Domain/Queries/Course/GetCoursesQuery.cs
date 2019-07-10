using System;

namespace ClassRoomSpace.Domain.Queries.Course
{
    public class GetCoursesQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}