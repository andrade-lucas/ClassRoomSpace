using ClassRoomSpace.Domain.Commands.Inputs.Professor;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Domain.Services;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class ProfessorHandler : Notifiable, ICommandHandler<CreateProfessorCommand>
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
            _service.Send("suporte@classroomspace.com", email.Address, "Bem Vindo", "Seja bem vindo ao ClassRoom Space");
            return new CommandResult(true, "Professor cadastrado com sucesso", null);
        }
    }
}