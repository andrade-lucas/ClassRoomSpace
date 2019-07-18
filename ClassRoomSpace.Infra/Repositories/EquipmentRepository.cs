using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClassRoomSpace.Domain.Commands.Inputs.Equipment;
using ClassRoomSpace.Domain.Queries.Equipment;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Infra.Context;
using Dapper;

namespace ClassRoomSpace.Infra.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly IDB _db;

        public EquipmentRepository(IDB db)
        {
            _db = db;
        }

        public void Create(CreateEquipmentCommand command)
        {
            _db.Connection().Execute(
                "spCreateEquipment",
                new
                {
                    id = command.Id,
                    description = command.Description,
                    status = command.Status,
                    purchaseDate = command.PurchaseDate,
                    idCollege = command.IdCollege
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(DeleteEquipmentCommand command)
        {
            _db.Connection().Execute(
                "spDeleteEquipment",
                new
                {
                    id = command.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditEquipmentCommand command)
        {
            _db.Connection().Execute(
                "spEditEquipment",
                new
                {
                    id = command.Id,
                    description = command.Description,
                    status = command.Status,
                    purchaseDate = command.PurchaseDate,
                    idCollege = command.IdCollege
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<GetEquipmentsQuery> Get()
        {
            return _db.Connection().Query<GetEquipmentsQuery>(
                "spGetEquipments",
                null,
                commandType: CommandType.StoredProcedure
            );
        }

        public GetEquipmentByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query<GetEquipmentByIdQuery>(
                "spGetEquipmentById",
                new 
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}