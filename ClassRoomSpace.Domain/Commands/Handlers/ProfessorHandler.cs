using ClassRoomSpace.Domain.Commands.Inputs.Professor;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Domain.Services;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class ProfessorHandler : Notifiable, ICommandHandler<CreateProfessorCommand>,
        ICommandHandler<EditProfessorCommand>, ICommandHandler<DeleteProfessorCommand>
    {
        private readonly IProfessorRepository _repository;
        private readonly IEmailService _service;

        public ProfessorHandler(IProfessorRepository repository, IEmailService service)
        {
            _repository = repository;
            _service = service;
        }

        public ICommandResult Handle(CreateProfessorCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);

            if (Invalid)
                return new CommandResult(false, "Erro ao cadastrar professor", Notifications);

            _repository.Create(command);
            _service.Send("example@example.com", email.Address, "Bem Vindo", "Seja bem vindo ao ClassRoom Space");
            return new CommandResult(true, "Professor cadastrado com sucesso", null);
        }

        public ICommandResult Handle(EditProfessorCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);

            if (Invalid)
                return new CommandResult(false, "Erro ao editar professor", Notifications);

            _repository.Edit(command);
            _service.Send("example@example.com", email.Address, "Modificação", "Professor modificado com sucesso");
            return new CommandResult(true, "Professor modificado com sucesso", null);
        }

        public ICommandResult Handle(DeleteProfessorCommand command)
        {
            string id = command.Id.ToString();
            if (string.IsNullOrEmpty(id))
                AddNotification("Id", "Identificador inválido");

            if (Invalid)
                return new CommandResult(false, "Erro ao deletar professor", Notifications);

            _repository.Delete(command);
            return new CommandResult(true, "Professor deletado com sucesso", null);
        }
    }
}