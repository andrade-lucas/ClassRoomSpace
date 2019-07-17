using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.ClassRoom;
using ClassRoomSpace.Domain.Queries.ClassRoom;
using ClassRoomSpace.Domain.Repositories;

namespace ClassRoomSpace.Tests.Mocks.Repositories
{
    public class ClassRoomRepositoryMock : IClassRoomRepository
    {
        public void Create(CreateClassRoomCommand command)
        {
            
        }

        public void Delete(DeleteClassRoomCommand command)
        {
            
        }

        public void Edit(EditClassRoomCommand command)
        {
            
        }

        public IEnumerable<GetClassRoomsQuery> Get()
        {
            return null;
        }

        public GetClassRoomByIdQuery GetById(Guid id)
        {
            return null;
        }
    }
}