using System;
using System.Collections.Generic;
using ClassRoomSpace.Domain.Commands.Inputs.User;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Queries.User;
using ClassRoomSpace.Domain.Repositories;

namespace ClassRoomSpace.Tests.Mocks.Repositories
{
    public class UserRepositoryMock : IUserRepository
    {
        public void Create(User user)
        {
        }

        public void Delete(DeleteUserCommand command)
        {
            
        }

        public void Edit(EditUserCommand command)
        {
        }

        public bool EmailExists(string email)
        {
            return false;
        }

        public IEnumerable<GetUsersQuery> Get()
        {
            return null;
        }

        public GetUserByIdQuery GetById(Guid id)
        {
            return null;
        }

        public AuthUserQuery Login(AuthUserCommand command)
        {
            return null;
        }
    }
}