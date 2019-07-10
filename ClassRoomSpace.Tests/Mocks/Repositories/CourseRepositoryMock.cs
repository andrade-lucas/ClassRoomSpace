using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.Course;
using ClassRoomSpace.Domain.Queries.Course;
using ClassRoomSpace.Domain.Repositories;

namespace ClassRoomSpace.Tests.Mocks.Repositories
{
    public class CourseRepositoryMock : ICourseRepository
    {
        public void Create(CreateCourseCommand command)
        {
            
        }

        public void Delete(DeleteCourseCommand command)
        {
            
        }

        public void Edit(EditCourseCommand command)
        {
            
        }

        public IEnumerable<GetCoursesQuery> Get()
        {
            return null;
        }

        public GetCourseByIdQuery GetById(Guid id)
        {
            return null;
        }
    }
}