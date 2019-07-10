using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.Professor;
using ClassRoomSpace.Domain.Queries.Professor;
using ClassRoomSpace.Domain.Repositories;

namespace ClassRoomSpace.Tests.Mocks.Repositories
{
    public class ProfessorRepositoryMock : IProfessorRepository
    {
        public void Create(CreateProfessorCommand command)
        {
            
        }

        public void Delete(DeleteProfessorCommand command)
        {
            
        }

        public void Edit(EditProfessorCommand command)
        {
            
        }

        public IEnumerable<GetProfessorsQuery> Get()
        {
            return null;
        }

        public GetProfessorByIdQuery GetById(Guid id)
        {
            return null;
        }
    }
}