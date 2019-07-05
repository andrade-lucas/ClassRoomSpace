using System;
using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Inputs.User
{
    public class DeleteUserCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}