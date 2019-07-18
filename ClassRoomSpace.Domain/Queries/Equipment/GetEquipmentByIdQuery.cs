using System;
using ClassRoomSpace.Domain.Enums;

namespace ClassRoomSpace.Domain.Queries.Equipment
{
    public class GetEquipmentByIdQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EEquipmentStatus Status { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid IdCollege { get; set; }
    }
}