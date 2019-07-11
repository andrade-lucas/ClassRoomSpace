using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.College;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.College;
using ClassRoomSpace.Domain.Repositories;

namespace ClassRoomSpace.Tests.Mocks.Repositories
{
    public class CollegeRepositoryMock : ICollegeRepository
    {
        public void Create(College college)
        {
            
        }

        public void Delete(DeleteCollegeCommand command)
        {
            
        }

        public void Edit(EditCollegeCommand command)
        {
            
        }

        public IEnumerable<GetCollegesQuery> Get()
        {
            return null;
        }

        public GetCollegeByIdQuery GetById(Guid id)
        {
            return null;
        }
    }
}