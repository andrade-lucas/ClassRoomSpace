using ClassRoomSpace.Domain.Commands.Inputs.Block;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class BlockHandler : Notifiable, ICommandHandler<CreateBlockCommand>,
        ICommandHandler<EditBlockCommand>, ICommandHandler<DeleteBlockCommand>
    {
        private readonly IBlockRepository _repository;

        public BlockHandler(IBlockRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBlockCommand command)
        {
            var block = new Block(command.Description);
            AddNotifications(block.Notifications);

            if (Invalid)
                return new CommandResult(false, "Erro ao cadastrar bloco", Notifications);

            _repository.Create(block);
            return new CommandResult(true, "Bloco cadastrado com sucesso", null);
        }

        public ICommandResult Handle(EditBlockCommand command)
        {
            var block = new Block(command.Description);
            AddNotifications(block.Notifications);

            if (Invalid)
                return new CommandResult(false, "Erro ao editar bloco", Notifications);

            _repository.Edit(command);
            return new CommandResult(true, "Bloco editado com sucesso", null);
        }

        public ICommandResult Handle(DeleteBlockCommand command)
        {
            string id = command.Id.ToString();
            if (string.IsNullOrEmpty(id))
                AddNotification("Id", "Identificador inválido");

            if (Invalid)
                return new CommandResult(false, "Erro ao deletar bloco", Notifications);

            _repository.Delete(command);
            return new CommandResult(true, "Bloco deletado com sucesso", null);
        }
    }
}