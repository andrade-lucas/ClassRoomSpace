using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.User
{
    public class AuthUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        public AuthUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}