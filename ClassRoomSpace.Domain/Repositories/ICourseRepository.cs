using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.Course;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.Course;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<GetCoursesQuery> Get();
        GetCourseByIdQuery GetById(Guid id);
        void Create(CreateCourseCommand command);
        void Edit(EditCourseCommand command);
        void Delete(DeleteCourseCommand command);
    }
}