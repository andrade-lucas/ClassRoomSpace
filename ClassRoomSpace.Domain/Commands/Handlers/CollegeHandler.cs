using ClassRoomSpace.Domain.Commands.Inputs.College;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Domain.Services;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class CollegeHandler : Notifiable, ICommandHandler<CreateCollegeCommand>,
        ICommandHandler<EditCollegeCommand>, ICommandHandler<DeleteCollegeCommand>
    {
        private readonly ICollegeRepository _repository;
        private readonly IEmailService _service;

        public CollegeHandler(ICollegeRepository repository, IEmailService service)
        {
            _repository = repository;
            _service = service;
        }

        public ICommandResult Handle(CreateCollegeCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var college = new College(name, document, email, command.Phone, command.Image);
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(college.Notifications);

            if (Invalid)
                return new CommandResult(false, "Erro ao cadastrar faculdade", Notifications);

            _repository.Create(college);
            _service.Send("example@example.com", email.Address, "Bem-vindo", "Seja bem-vindo ao ClassRoom Space");
            return new CommandResult(true, "Faculdade cadastrada com sucesso", null);
        }

        public ICommandResult Handle(EditCollegeCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);

            if (Invalid)
                return new CommandResult(false, "Erro ao editar faculdade", Notifications);
            
            _repository.Edit(command);
            _service.Send("example@example.com", email.Address, "Modificação", "Modificações realizadas com sucesso");
            return new CommandResult(true, "Faculdade editada com sucesso", null);
        }

        public ICommandResult Handle(DeleteCollegeCommand command)
        {
            string id = command.Id.ToString();
            if (string.IsNullOrEmpty(id))
                AddNotification("Id", "Identificador inválido");
            
            if (Invalid)
                return new CommandResult(false, "Erro ao deletar faculdade", Notifications);
            
            _repository.Delete(command);
            return new CommandResult(true, "Faculdade deletada com sucesso", null);
        }
    }
}