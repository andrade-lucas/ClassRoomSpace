using System;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Equipment
{
    public class BookEquipmentCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EEquipmentStatus Status = EEquipmentStatus.Reserved;
        public DateTime PurchaseDate { get; set; }
    }
}