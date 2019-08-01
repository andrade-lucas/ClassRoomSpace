using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.Block;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.Block;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface IBlockRepository
    {
        IEnumerable<GetBlocksQuery> Get();
        GetBlockByIdQuery GetById(Guid id);
        void Create(CreateBlockCommand command);
        void Edit(EditBlockCommand command);
        void Delete(DeleteBlockCommand command);
    }
}