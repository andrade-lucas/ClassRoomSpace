using System;
using ClassRoomSpace.Domain.Entities;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface IProfessorRepository
    {
        void Create(Professor professor);
        void Delete(Guid id);
    }
}