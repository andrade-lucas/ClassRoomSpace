using ClassRoomSpace.Domain.Commands.Inputs.Course;
using ClassRoomSpace.Domain.Commands.Outputs;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Shared.Commands;
using FluentValidator;

namespace ClassRoomSpace.Domain.Commands.Handlers
{
    public class CourseHandler : Notifiable, ICommandHandler<CreateCourseCommand>,
        ICommandHandler<EditCourseCommand>, ICommandHandler<DeleteCourseCommand>
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
            
            _repository.Create(command);
            return new CommandResult(true, "Curso cadastrado com sucesso", null);
        }

        public ICommandResult Handle(EditCourseCommand command)
        {
            var course = new Course(command.Description);

            if (Invalid)
                return new CommandResult(false, "Erro ao editar o curso", Notifications);
            
            _repository.Edit(command);
            return new CommandResult(true, "Curso editado com sucesso", null);
        }

        public ICommandResult Handle(DeleteCourseCommand command)
        {
            string id = command.Id.ToString();
            if (string.IsNullOrEmpty(id))
                AddNotification("Id", "Identificador inválido");

            if (Invalid)
                return new CommandResult(false, "Erro ao deletar curso", Notifications);
            
            _repository.Delete(command);
            return new CommandResult(true, "Curso deletado com sucesso", null);
        }
    }
}