using System;

namespace ClassRoomSpace.Domain.Queries.College
{
    public class GetCollegeByIdQuery
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
    }
}