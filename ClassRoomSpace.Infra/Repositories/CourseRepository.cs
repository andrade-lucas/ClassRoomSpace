using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClassRoomSpace.Domain.Commands.Inputs.Course;
using ClassRoomSpace.Domain.Queries.Course;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Infra.Context;
using Dapper;

namespace ClassRoomSpace.Infra.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDB _db;

        public CourseRepository(IDB db)
        {
            _db = db;
        }

        public void Create(CreateCourseCommand command)
        {
            _db.Connection().Execute(
                "spCreateCourse",
                new
                {
                    id = command.Id,
                    description = command.Description,
                    idCollege = command.IdCollege
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(DeleteCourseCommand command)
        {
            _db.Connection().Execute(
                "spDeleteCourse",
                new
                {
                    id = command.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditCourseCommand command)
        {
            _db.Connection().Execute(
                "spEditCourse",
                new
                {
                    id = command.Id,
                    description = command.Description,
                    idCollege = command.IdCollege
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<GetCoursesQuery> Get()
        {
            return _db.Connection().Query<GetCoursesQuery>(
                "spGetCourses",
                null,
                commandType: CommandType.StoredProcedure
            );
        }

        public GetCourseByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query<GetCourseByIdQuery>(
                "spGetCourseById",
                new
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}