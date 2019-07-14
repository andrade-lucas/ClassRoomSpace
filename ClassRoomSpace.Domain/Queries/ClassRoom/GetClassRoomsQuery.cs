using ClassRoomSpace.Domain.Enums;
using System;

namespace ClassRoomSpace.Domain.Queries.ClassRoom
{
    public class GetClassRoomsQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EClassRoomStatus Status { get; set; }
    }
}