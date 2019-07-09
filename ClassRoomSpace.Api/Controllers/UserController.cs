using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.User;
using ClassRoomSpace.Domain.Queries.User;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomSpace.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
            _handler = new UserHandler(_repository);
        }

        [HttpGet]
        [Route("v1/users")]
        public IEnumerable<GetUsersQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/users/{id}")]
        public GetUserByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/users")]
        public ICommandResult Post([FromBody] CreateUserCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/users")]
        public ICommandResult Put([FromBody] EditUserCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/users/{id}")]
        public ICommandResult Delete(DeleteUserCommand command)
        {
            return _handler.Handle(command);
        }
    }
}