using ClassRoomSpace.Domain.Commands.Inputs.Equipment;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class EquipmentHandler : Notifiable, ICommandHandler<CreateEquipmentCommand>,
        ICommandHandler<EditEquipmentCommand>, ICommandHandler<DeleteEquipmentCommand>, 
        ICommandHandler<BookEquipmentCommand>
    {
        private readonly IEquipmentRepository _repository;

        public EquipmentHandler(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateEquipmentCommand command)
        {
            var equipment = new Equipment(command.Description);
            AddNotifications(equipment.Notifications);
            if (Invalid)
                return new CommandResult(false, "Ocorreu um erro ao criar equipamento", Notifications);

            _repository.Create(command);
            return new CommandResult(true, "Equipamento criado com sucesso", null);
        }

        public ICommandResult Handle(EditEquipmentCommand command)
        {
            var equipment = new Equipment(command.Description, command.Status, command.PurchaseDate);
            AddNotifications(equipment.Notifications);

            if (Invalid)
                return new CommandResult(false, "Erro ao editar registro", Notifications);
            
            _repository.Edit(command);
            return new CommandResult(true, "Registro editado com sucesso", null);
        }

        public ICommandResult Handle(DeleteEquipmentCommand command)
        {
            string id = command.Id.ToString();
            if (string.IsNullOrEmpty(id))
                AddNotification("Id", "Identificador inválido");
            
            if (Invalid)
                return new CommandResult(false, "Erro ao deletar registro", Notifications);
            
            _repository.Delete(command);
            return new CommandResult(true, "Registro deletado com sucesos", null);
        }

        public ICommandResult Handle(BookEquipmentCommand command)
        {
            var equipment = new Equipment(command.Description, command.Status, command.PurchaseDate);
            AddNotifications(equipment.Notifications);

            var status = (EEquipmentStatus)_repository.GetStatus(command.Id);
            if (status != EEquipmentStatus.Free)
                AddNotification("Book", "Equipamento indisponível para reserva");

            equipment.Book();

            if (Invalid)
                return new CommandResult(false, "Erro ao efetuar reserva", Notifications);

            _repository.Book(equipment);
            return new CommandResult(true, "Reserva efetuada com sucesso", null);
        }
    }
}