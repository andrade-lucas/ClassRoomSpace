using System;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.College;
using ClassRoomSpace.Tests.Mocks.Repositories;
using ClassRoomSpace.Tests.Mocks.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Commands.Handlers
{
    [TestClass]
    public class CollegeHandlerTests
    {
        [TestMethod]
        public void ShouldReturnInvalidWhenCreateCommandInvalid()
        {
            var command = new CreateCollegeCommand();
            command.FirstName = "";
            command.LastName = "";
            command.Document = "";
            command.Email = "";
            command.Phone = "";
            command.Image = "";
            var handler = new CollegeHandler(new CollegeRepositoryMock(), new EmailServiceMock());
            var result = handler.Handle(command);
            Assert.AreNotEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenCreateCommandValid()
        {
            var command = new CreateCollegeCommand();
            command.FirstName = "FirstName";
            command.LastName = "LastName";
            command.Document = "34.469.528/0001-26";
            command.Email = "example@example.com";
            command.Phone = "00000000000";
            command.Image = "image.jpeg";
            var handler = new CollegeHandler(new CollegeRepositoryMock(), new EmailServiceMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenEditCommandInvalid()
        {
            var command = new EditCollegeCommand();
            command.Id = Guid.NewGuid();
            command.FirstName = "";
            command.LastName = "";
            command.Document = "";
            command.Email = "example";
            command.Phone = "";
            command.Image = "";
            var handler = new CollegeHandler(new CollegeRepositoryMock(), new EmailServiceMock());
            var result = handler.Handle(command);
            Assert.AreEqual(false, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenEditCommandValid()
        {
            var command = new EditCollegeCommand();
            command.Id = Guid.NewGuid();
            command.FirstName = "FirstName";
            command.LastName = "LastName";
            command.Document = "34.469.528/0001-26";
            command.Email = "example@example.com";
            command.Phone = "00000000000";
            command.Image = "image.jpeg";
            var handler = new CollegeHandler(new CollegeRepositoryMock(), new EmailServiceMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenDeleteCommandValid()
        {
            var command = new DeleteCollegeCommand();
            command.Id = Guid.NewGuid();
            var handler = new CollegeHandler(new CollegeRepositoryMock(), new EmailServiceMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }
    }
}