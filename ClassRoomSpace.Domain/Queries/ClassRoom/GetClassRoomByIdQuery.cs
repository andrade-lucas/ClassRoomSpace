using System;
using ClassRoomSpace.Domain.Enums;

namespace ClassRoomSpace.Domain.Queries.ClassRoom
{
    public class GetClassRoomByIdQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public EClassRoomType Type { get; set; }
        public Guid IdBlock { get; set; }
    }
}