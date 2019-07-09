using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClassRoomSpace.Domain.Commands.Inputs.Block;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.Block;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Infra.Context;
using Dapper;

namespace ClassRoomSpace.Infra.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        private readonly IDB _db;

        public BlockRepository(IDB db)
        {
            _db = db;
        }

        public void Create(Block block)
        {
            _db.Connection().Execute(
                "spCreateBlock",
                new
                {
                    id = block.Id,
                    description = block.Description
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(DeleteBlockCommand command)
        {
            _db.Connection().Execute(
                "spDeleteBlock",
                new 
                {
                    id = command.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditBlockCommand command)
        {
            _db.Connection().Execute(
                "spEditBlock",
                new 
                {
                    id = command.Id,
                    description = command.Description,
                    idCollege = command.IdCollege
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<GetBlocksQuery> Get()
        {
            return _db.Connection().Query<GetBlocksQuery>(
                "spGetBlocks",
                null,
                commandType: CommandType.StoredProcedure
            );
        }

        public GetBlockByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query<GetBlockByIdQuery>(
                "spGetBlockById",
                new
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}