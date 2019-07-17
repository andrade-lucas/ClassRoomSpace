using System;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Shared.Entities;
using FluentValidator.Validation;

namespace ClassRoomSpace.Domain.Entities
{
    public class Equipment : Entity
    {
        public string Description { get; private set; }
        public EEquipmentStatus Status { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        
        public Equipment(string description, DateTime purchaseDate)
        {
            Description = description;
            Status = EEquipmentStatus.Free;
            PurchaseDate = purchaseDate;

            AddNotifications(new ValidationContract()
                .HasMinLen(Description, 2, "Description", "A descrição deve conter pelo menos 2 caracteres")
                .HasMaxLen(Description, 100, "Description", "A descrição deve conter no máximo 100 caracteres")
            );
        }

        public void Book()
        {
            if (Status == EEquipmentStatus.Free)
                Status = EEquipmentStatus.Reserved;
            else
                AddNotification("Book", "Equipamento indisponível para reserva");
        }

        public void SetAsBroken()
        {
            if (Status != EEquipmentStatus.Broken)
                Status = EEquipmentStatus.Broken;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}