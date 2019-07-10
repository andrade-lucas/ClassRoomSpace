using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.Professor;
using ClassRoomSpace.Domain.Queries.Professor;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Domain.Services;
using ClassRoomSpace.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomSpace.Api.Controllers
{
    public class ProfessorsController : Controller
    {
        private readonly IProfessorRepository _repository;
        private readonly IEmailService _emailService;
        private readonly ProfessorHandler _handler;

        public ProfessorsController(IProfessorRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
            _handler = new ProfessorHandler(_repository, _emailService);
        }

        [HttpGet]
        [Route("v1/professors")]
        public IEnumerable<GetProfessorsQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/professors/{id}")]
        public GetProfessorByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/professors")]
        public ICommandResult Post([FromBody] CreateProfessorCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/professors")]
        public ICommandResult Put([FromBody] EditProfessorCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/professors/{id}")]
        public ICommandResult Delete(DeleteProfessorCommand command)
        {
            return _handler.Handle(command);
        }
    }
}