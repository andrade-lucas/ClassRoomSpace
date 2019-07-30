using ClassRoomSpace.Domain.Commands.Inputs.Auth;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class AuthHandler : Notifiable, ICommandHandler<AuthUserCommand>
    {
        private readonly IUserRepository _repository;

        public AuthHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AuthUserCommand command)
        {
            var email = new Email(command.Email);
            var password = new Password(command.Password);
            AddNotifications(email.Notifications);
            AddNotifications(password.Notifications);

            if (Invalid)
                return new CommandResult(false, "Por favor, verifique se os campos estão preenchidos corretamente", Notifications);
            
            var user = new User(email, password);
            var authUserQuery = _repository.Login(user);
            if (authUserQuery == null)
                return new CommandResult(false, "Usuário não encontrado", null);
            
            return new CommandResult(true, "Seja bem-vindo", authUserQuery);
        }
    }
}