using System;

namespace ClassRoomSpace.Domain.Queries.College
{
    public class GetCollegesQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}