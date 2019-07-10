using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.Professor;
using ClassRoomSpace.Domain.Queries.Professor;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface IProfessorRepository
    {
        IEnumerable<GetProfessorsQuery> Get();
        GetProfessorByIdQuery GetById(Guid id);
        void Create(CreateProfessorCommand Command);
        void Edit(EditProfessorCommand command);
        void Delete(DeleteProfessorCommand command);
    }
}