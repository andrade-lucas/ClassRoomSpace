using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.Auth
{
    public class AuthUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}