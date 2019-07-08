using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.Course;
using ClassRoomSpace.Tests.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Commands.Handlers
{
    [TestClass]
    public class CourseHandlerTests
    {
        [TestMethod]
        public void ShouldReturnInvalidWhenNull()
        {
            var command = new CreateCourseCommand();
            command.Description = null;
            var handler = new CourseHandler(new CourseRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(false, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenValid()
        {
            var command = new CreateCourseCommand();
            command.Description = "Computer Science";
            var handler = new CourseHandler(new CourseRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }
    }
}