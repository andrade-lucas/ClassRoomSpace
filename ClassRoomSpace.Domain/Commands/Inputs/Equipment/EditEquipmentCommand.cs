using System;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Equipment
{
    public class EditEquipmentCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EEquipmentStatus Status { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid IdCollege { get; set; }
    }
}