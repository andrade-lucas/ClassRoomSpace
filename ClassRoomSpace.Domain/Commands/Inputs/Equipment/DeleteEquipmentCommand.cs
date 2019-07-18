using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Equipment
{
    public class DeleteEquipmentCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}