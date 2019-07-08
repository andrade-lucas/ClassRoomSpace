using ClassRoomSpace.Domain.Commands.Inputs.Course;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class CourseHandler : Notifiable, ICommandHandler<CreateCourseCommand>
    {
        private readonly ICourseRepository _repository;

        public CourseHandler(ICourseRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCourseCommand command)
        {
            var course = new Course(command.Description);

            AddNotifications(course.Notifications);
            if (Invalid)
                return new CommandResult(false, "Erro ao cadastrar curso", Notifications);
            
            _repository.Create(course);
            return new CommandResult(true, "Curso cadastrado com sucesso", null);
        }
    }
}