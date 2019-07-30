using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.User;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.User;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<GetUsersQuery> Get();
        GetUserByIdQuery GetById(Guid id);
        bool EmailExists(string email);
        void Create(User user);
        void Edit(EditUserCommand command);
        AuthUserQuery Login(User user);
        void Delete(DeleteUserCommand command);
    }
}