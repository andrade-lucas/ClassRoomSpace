using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClassRoomSpace.Domain.Commands.Inputs.Professor;
using ClassRoomSpace.Domain.Queries.Professor;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Infra.Context;
using Dapper;

namespace ClassRoomSpace.Infra.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly IDB _db;

        public ProfessorRepository(IDB db)
        {
            _db = db;
        }

        public void Create(CreateProfessorCommand Command)
        {
            _db.Connection().Execute(
                "spCreateProfessor",
                new
                {
                    id = Command.Id,
                    firstName = Command.FirstName,
                    lastName = Command.LastName,
                    document = Command.Document,
                    email = Command.Email,
                    phone = Command.Phone,
                    status = Command.Status,
                    idCourse = Command.IdCourse
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(DeleteProfessorCommand command)
        {
            _db.Connection().Execute(
                "spDeleteProfessor",
                new
                {
                    id = command.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditProfessorCommand command)
        {
            _db.Connection().Execute(
                "spEditProfessor",
                new
                {
                    id = command.Id,
                    firstName = command.FirstName,
                    lastName = command.LastName,
                    document = command.Document,
                    email = command.Email,
                    phone = command.Phone,
                    status = command.Status,
                    idCourse = command.IdCourse
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<GetProfessorsQuery> Get()
        {
            return _db.Connection().Query<GetProfessorsQuery>(
                "spGetProfessors",
                null,
                commandType: CommandType.StoredProcedure
            );
        }

        public GetProfessorByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query<GetProfessorByIdQuery>(
                "spGetProfessorById",
                new 
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}