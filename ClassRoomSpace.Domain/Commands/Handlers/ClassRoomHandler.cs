using System;
using ClassRoomSpace.Domain.Commands.Inputs.ClassRoom;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class ClassRoomHandler : Notifiable, ICommandHandler<CreateClassRoomCommand>, ICommandHandler<EditClassRoomCommand>, ICommandHandler<DeleteClassRoomCommand>
    {
        private readonly IClassRoomRepository _repository;

        public ClassRoomHandler(IClassRoomRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateClassRoomCommand command)
        {
            var classRoom = new ClassRoom(command.Description, command.Status, command.Type);
            AddNotifications(classRoom.Notifications);

            if (Invalid)
                return new CommandResult(false, "Erro ao cadastrar sala", Notifications);

            _repository.Create(command);
            return new CommandResult(true, "Sala cadastrada com sucesso", null);
        }

        public ICommandResult Handle(EditClassRoomCommand command)
        {
            var classRoom = new ClassRoom(command.Description, command.Status, command.Type);
            AddNotifications(classRoom.Notifications);

            if (Invalid)
                return new CommandResult(false, "Erro ao editar sala", Notifications);

            _repository.Edit(command);
            return new CommandResult(true, "Sala editada com sucesso", null);
        }

        public ICommandResult Handle(DeleteClassRoomCommand command)
        {
            string id = command.Id.ToString();
            if (string.IsNullOrEmpty(id))
                AddNotification("Id", "Identificador inválido");

            if (Invalid)
                return new CommandResult(false, "Erro ao deletar sala", Notifications);
            
            _repository.Delete(command);
            return new CommandResult(true, "Sala deletada com sucesso", null);
        }
    }
}