using System;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class ClassRoomHandler : Notifiable, ICommandHandler<CreateClassRoomCommand>
    {
        public ICommandResult Handler(CreateClassRoomCommand command)
        {
            throw new NotImplementedException();
        }
    }
}