using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.Equipment;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.Equipment;
using ClassRoomSpace.Domain.Repositories;

namespace ClassRoomSpace.Tests.Mocks.Repositories
{
    public class EquipmentRepositoryMock : IEquipmentRepository
    {
        public void Book(Equipment equipment)
        {
            
        }

        public void Create(CreateEquipmentCommand command)
        {
            
        }

        public void Delete(DeleteEquipmentCommand command)
        {
            
        }

        public void Edit(EditEquipmentCommand command)
        {
            
        }

        public IEnumerable<GetEquipmentsQuery> Get()
        {
            return null;
        }

        public GetEquipmentByIdQuery GetById(Guid id)
        {
            return null;
        }

        public int GetStatus(Guid id)
        {
            return 0;
        }
    }
}