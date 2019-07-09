using System;

namespace ClassRoomSpace.Domain.Queries.User
{
    public class AuthUserQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}