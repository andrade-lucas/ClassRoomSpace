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
            throw new NotImplementedException();
        }

        public ICommandResult Handle(DeleteClassRoomCommand command)
        {
            throw new NotImplementedException();
        }
    }
}