using ClassRoomSpace.Domain.Commands.Inputs.ClassRoom;
using ClassRoomSpace.Domain.Queries.ClassRoom;
using System;
using System.Collections.Generic;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface IClassRoomRepository
    {
        IEnumerable<GetClassRoomsQuery> Get();
        GetClassRoomByIdQuery GetById(Guid id);
        void Create(CreateClassRoomCommand command);
        void Edit(EditClassRoomCommand command);
        void Delete(DeleteClassRoomCommand command);
    }
}
