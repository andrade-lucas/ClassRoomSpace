using ClassRoomSpace.Domain.Commands.Inputs.User;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Shared.Commands;
using ClassRoomSpace.Domain.Repositories;
using FluentValidator;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Queries.User;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class UserHandler : Notifiable, ICommandHandler<CreateUserCommand>,
        ICommandHandler<EditUserCommand>, ICommandHandler<DeleteUserCommand>, ICommandHandler<AuthUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var password = new Password(command.Password);

            var user = new User(name, document, email, password, command.Phone, command.Status, command.Image);
            
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "O endereço de e-mail já está em uso");

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(password.Notifications);

            if (Invalid)
                return new CommandResult(false, "Confira se todos os campos estão corretos", Notifications);
            
            _repository.Create(user);

            return new CommandResult(true, "Usuário registrado com sucesso", null);
        }

        public ICommandResult Handle(EditUserCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);

            if (Invalid)
                return new CommandResult(false, "Confira se todos os campos estão corretos", Notifications);
            
            _repository.Edit(command);

            return new CommandResult(true, "Usuário editado com sucesso", null);
        }

        public ICommandResult Handle(AuthUserCommand command)
        {
            var email = new Email(command.Email);
            var password = new Password(command.Password);

            AddNotifications(email.Notifications);
            AddNotifications(password.Notifications);

            if (Invalid)
                return new CommandResult(false, "Verifique se todos os campos estão corretos", Notifications);

            var result = _repository.Login(command);
            return new CommandResult(true, "Seja bem vindo", result);
        }

        public ICommandResult Handle(DeleteUserCommand command)
        {
            string id = command.Id.ToString();
            if (string.IsNullOrEmpty(id))
                AddNotification("Id", "Identificador inválido");

            if (Invalid)
                return new CommandResult(false, "Erro ao deletar usuário", Notifications);
            
            _repository.Delete(command);
            return new CommandResult(true, "Usuário deletado com sucesso", null);
        }
    }
}