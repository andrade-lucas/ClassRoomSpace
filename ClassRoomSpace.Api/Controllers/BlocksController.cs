using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.Block;
using ClassRoomSpace.Domain.Queries.Block;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomSpace.Api.Controllers
{
    public class BlocksController : Controller
    {
        private readonly IBlockRepository _repository;
        private readonly BlockHandler _handler;

        public BlocksController(IBlockRepository repository)
        {
            _repository = repository;
            _handler = new BlockHandler(_repository);
        }

        [HttpGet]
        [Route("v1/blocks")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<GetBlocksQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/blocks/{id}")]
        public GetBlockByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/blocks")]
        public ICommandResult Post([FromBody] CreateBlockCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/blocks")]
        public ICommandResult Put([FromBody] EditBlockCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/blocks/{id}")]
        public ICommandResult Delete(DeleteBlockCommand command)
        {
            return _handler.Handle(command);
        }
    }
}