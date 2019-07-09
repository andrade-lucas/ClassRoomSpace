using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClassRoomSpace.Domain.Commands.Inputs.User;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.User;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Infra.Context;
using Dapper;

namespace ClassRoomSpace.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDB _db;

        public UserRepository(IDB db)
        {
            _db = db;
        }

        public void Create(User user)
        {
            _db.Connection().Execute(
                "spCreateUser",
                new 
                {
                    id = user.Id,
                    firstName = user.Name.FirstName,
                    lastName = user.Name.LastName,
                    document = user.Document.Number,
                    email = user.Email.Address,
                    password = user.Password.Value,
                    phone = user.Phone,
                    status = user.Status,
                    image = user.Image
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(DeleteUserCommand command)
        {
            _db.Connection().Execute(
                "spDeleteUser",
                new 
                {
                    id = command.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Edit(EditUserCommand command)
        {
            _db.Connection().Execute(
                "spEditUser",
                new 
                {
                    id = command.Id,
                    firstName = command.FirstName,
                    lastName = command.LastName,
                    document = command.Document,
                    phone = command.Phone
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public bool EmailExists(string email)
        {
            return _db.Connection().Query<bool>(
                "spEmailExists",
                new 
                {
                    email = email
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }

        public IEnumerable<GetUsersQuery> Get()
        {
            return _db.Connection().Query<GetUsersQuery>(
                "spGetUsers",
                null,
                commandType: CommandType.StoredProcedure
            );
        }

        public GetUserByIdQuery GetById(Guid id)
        {
            return _db.Connection().Query<GetUserByIdQuery>(
                "spGetUserById",
                new 
                {
                    id = id
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }

        public AuthUserQuery Login(AuthUserCommand command)
        {
            return _db.Connection().Query<AuthUserQuery>(
                "spAuthUser",
                new 
                {
                    email = command.Email,
                    password = command.Password
                },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}