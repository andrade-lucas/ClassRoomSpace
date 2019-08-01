using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.Course;
using ClassRoomSpace.Domain.Queries.Course;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomSpace.Api.Controllers
{
    [Authorize("Bearer")]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _repository;
        private readonly CourseHandler _handler;

        public CoursesController(ICourseRepository repository)
        {
            _repository = repository;
            _handler = new CourseHandler(_repository);
        }

        [HttpGet]
        [Route("v1/courses")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<GetCoursesQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/courses/{id}")]
        public GetCourseByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/courses")]
        public ICommandResult Post([FromBody] CreateCourseCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/courses")]
        public ICommandResult Put([FromBody] EditCourseCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/courses/{id}")]
        public ICommandResult Delete(DeleteCourseCommand command)
        {
            return _handler.Handle(command);
        }
    }
}