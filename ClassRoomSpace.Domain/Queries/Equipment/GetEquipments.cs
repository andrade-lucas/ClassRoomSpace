using System;
using ClassRoomSpace.Domain.Enums;

namespace ClassRoomSpace.Domain.Queries.Equipment
{
    public class GetEquipments
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EEquipmentStatus Status { get; set; }
    }
}