using System;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Equipment
{
    public class CreateEquipmentCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EEquipmentStatus Status = EEquipmentStatus.Free;
        public DateTime PurchaseDate { get; set; }
        public Guid IdCollege { get; set; }
    }
}