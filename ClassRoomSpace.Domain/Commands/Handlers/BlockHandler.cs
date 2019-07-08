using ClassRoomSpace.Domain.Commands.Inputs;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class BlockHandler : Notifiable, ICommandHandler<CreateBlockCommand>
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
    }
}