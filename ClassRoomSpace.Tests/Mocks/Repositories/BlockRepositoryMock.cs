using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.Block;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.Block;
using ClassRoomSpace.Domain.Repositories;

namespace ClassRoomSpace.Tests.Mocks.Repositories
{
    public class BlockRepositoryMock : IBlockRepository
    {
        public void Create(Block block)
        {
            
        }

        public void Delete(DeleteBlockCommand command)
        {
            
        }

        public void Edit(EditBlockCommand command)
        {
            
        }

        public IEnumerable<GetBlocksQuery> Get()
        {
            return null;
        }

        public GetBlockByIdQuery GetById(Guid id)
        {
            return null;
        }
    }
}