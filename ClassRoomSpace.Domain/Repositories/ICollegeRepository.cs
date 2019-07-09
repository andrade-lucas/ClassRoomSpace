using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.College;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.College;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface ICollegeRepository
    {
        IEnumerable<GetCollegesQuery> Get();
        GetCollegeByIdQuery GetById(Guid id);
        void Create(College college);
        void Edit(EditCollegeCommand command);
        void Delete(DeleteCollegeCommand command);
    }
}