using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.Equipment;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.Equipment;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface IEquipmentRepository 
    {
        IEnumerable<GetEquipmentsQuery> Get();
        GetEquipmentByIdQuery GetById(Guid id);
        void Create(CreateEquipmentCommand command);
        void Edit(EditEquipmentCommand command);
        void Delete(DeleteEquipmentCommand command);
        void Book(Equipment equipment);
        int GetStatus(Guid id);
    }
}