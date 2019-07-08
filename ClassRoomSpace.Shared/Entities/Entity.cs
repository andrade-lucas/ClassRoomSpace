using System;
using FluentValidator;
using FluentValidator.Validation;

namespace ClassRoomSpace.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            Id = id;
            Console.WriteLine(id.ToString().Length);
            AddNotifications(new ValidationContract()
                .HasMinLen(Id.ToString(), 32, "Entity", "Identificador inválido")
            );
        }
    }
}