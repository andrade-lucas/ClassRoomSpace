using System;
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
        public void ShouldReturnInvalidWhenCreateCommandNull()
        {
            var command = new CreateCourseCommand();
            command.Description = null;
            command.IdCollege = Guid.NewGuid();
            var handler = new CourseHandler(new CourseRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(false, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenCreateCommandValid()
        {
            var command = new CreateCourseCommand();
            command.Description = "Computer Science";
            command.IdCollege = Guid.NewGuid();
            var handler = new CourseHandler(new CourseRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenEditCommandInvalid()
        {
            var command = new EditCourseCommand();
            command.Id = Guid.NewGuid();
            command.Description = "";
            command.IdCollege = Guid.NewGuid();
            var handler = new CourseHandler(new CourseRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(false, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenEditCommandIsValid()
        {
            var command = new EditCourseCommand();
            command.Id = Guid.NewGuid();
            command.Description = "Computer Science";
            command.IdCollege = Guid.NewGuid();
            var handler = new CourseHandler(new CourseRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenDeleteCommandValid()
        {
            var command = new DeleteCourseCommand();
            command.Id = Guid.NewGuid();
            var handler = new CourseHandler(new CourseRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }
    }
}