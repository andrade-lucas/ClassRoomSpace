using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.ClassRoom;
using ClassRoomSpace.Domain.Queries.ClassRoom;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomSpace.Api.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly IClassRoomRepository _repository;
        private readonly ClassRoomHandler _handler;

        public ClassRoomController(IClassRoomRepository repository)
        {
            _repository = repository;
            _handler = new ClassRoomHandler(_repository);
        }

        [HttpGet]
        [Route("v1/classRooms")]
        public IEnumerable<GetClassRoomsQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/classRooms/{id}")]
        public GetClassRoomByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/classRooms")]
        public ICommandResult Post(CreateClassRoomCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPost]
        [Route("v1/classRooms")]
        public ICommandResult Put(EditClassRoomCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/classRooms/{id}")]
        public ICommandResult Delete(DeleteClassRoomCommand command)
        {
            return _handler.Handle(command);
        }
    }
}