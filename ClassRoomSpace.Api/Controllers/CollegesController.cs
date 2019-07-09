using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.College;
using ClassRoomSpace.Domain.Queries.College;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Domain.Services;
using ClassRoomSpace.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomSpace.Api.Controllers
{
    public class CollegesController : Controller
    {
        private readonly ICollegeRepository _repository;
        private readonly CollegeHandler _handler;
        private readonly IEmailService _emailService;

        public CollegesController(ICollegeRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
            _handler = new CollegeHandler(_repository, emailService);
        }

        [HttpGet]
        [Route("v1/colleges")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<GetCollegesQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/colleges/{id}")]
        public GetCollegeByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/colleges")]
        public ICommandResult Post([FromBody] CreateCollegeCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/colleges")]
        public ICommandResult Put([FromBody] EditCollegeCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/colleges/{id}")]
        public ICommandResult Delete(DeleteCollegeCommand command)
        {
            return _handler.Handle(command);
        }
    }
}