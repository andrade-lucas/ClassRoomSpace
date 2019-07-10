using System;
using ClassRoomSpace.Domain.Commands.Inputs.Professor;
using ClassRoomSpace.Domain.Entities;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface IProfessorRepository
    {
        void Create(CreateProfessorCommand Command);
        void Delete(Guid id);
    }
}