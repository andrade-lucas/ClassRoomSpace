using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.Equipment;
using ClassRoomSpace.Domain.Queries.Equipment;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomSpace.Api.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly IEquipmentRepository _repository;
        private readonly EquipmentHandler _handler;

        public EquipmentsController(IEquipmentRepository repository)
        {
            _repository = repository;
            _handler = new EquipmentHandler(_repository);
        }

        [HttpGet]
        [Route("v1/equipments")]
        public IEnumerable<GetEquipmentsQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/equipments/{id}")]
        public GetEquipmentByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/equipments")]
        public ICommandResult Post([FromBody] CreateEquipmentCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/equipments")]
        public ICommandResult Post([FromBody] EditEquipmentCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/equipments/{id}")]
        public ICommandResult Delete(DeleteEquipmentCommand command)
        {
            return _handler.Handle(command);
        }
    }
}