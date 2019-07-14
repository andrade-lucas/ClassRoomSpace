using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClassRoomSpace.Domain.Commands.Inputs.ClassRoom;
using ClassRoomSpace.Domain.Queries.ClassRoom;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Infra.Context;
using Dapper;

namespace ClassRoomSpace.Infra.Repositories
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly IDB _db;

        public ClassRoomRepository(IDB db)
        {
            _db = db;
        }

        public void Create(CreateClassRoomCommand command)
        {
            _db.Connection().Execute(
                "spCreateClassRoom",
                new
                {
                    id = command.Id,
                    description = command.Description,
                    status = command.Status,
                    type = command.Type,
                    idBlock = command.IdBlock
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(DeleteClassRoomCommand command)
        {
            _db.Connection().Execute(
                "spDeleteClassRoom",
                new
                {
                    id = command.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditClassRoomCommand command)
        {
            _db.Connection().Execute(
                "spEditClassRoom",
                new
                {
                    id = command.Id,
                    description = command.Description,
                    status = command.Status,
                    type = command.Type,
                    idBlock = command.IdBlock
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<GetClassRoomsQuery> Get()
        {
            return _db.Connection().Query<GetClassRoomsQuery>(
                "spGetClassRooms",
                null,
                commandType: CommandType.StoredProcedure
            );
        }

        public GetClassRoomByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query<GetClassRoomByIdQuery>(
                "spGetClassRooms",
                new
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}