using System;
using ClassRoomSpace.Domain.Enums;

namespace ClassRoomSpace.Domain.Queries.User
{
    public class GetUserByIdQuery
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public EUserStatus Status { get; set; }
        public string Image { get; set; }
    }
}