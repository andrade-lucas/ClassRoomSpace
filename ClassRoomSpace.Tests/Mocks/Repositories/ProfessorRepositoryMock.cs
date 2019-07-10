using System;
using ClassRoomSpace.Domain.Commands.Inputs.Professor;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Repositories;

namespace ClassRoomSpace.Tests.Mocks.Repositories
{
    public class ProfessorRepositoryMock : IProfessorRepository
    {
        public void Create(CreateProfessorCommand command)
        {
            
        }

        public void Delete(Guid id)
        {
            
        }
    }
}