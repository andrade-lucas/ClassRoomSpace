using ClassRoomSpace.Domain.Commands.Inputs.User;
using ClassRoomSpace.Domain.Queries.User;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomSpace.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;

        public AuthController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/auth/login")]
        public AuthUserQuery Login([FromBody] AuthUserCommand command)
        {
            var password = new Password(command.Password);
            command.Password = password.Value;
            return _repository.Login(command);
        }
    }
}