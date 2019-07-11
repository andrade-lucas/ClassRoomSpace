using System;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.User;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Tests.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Commands.Handlers
{
    [TestClass]
    public class UserHandlerTests
    {
        [TestMethod]
        public void ShouldCreateAUser()
        {
            var command = new CreateUserCommand();
            command.FirstName = "FirstName";
            command.LastName = "LastName";
            command.Document = "759.502.280-06";
            command.Email = "example@example.com";
            command.Password = "12345678";
            command.Phone = "000000000000";
            command.Status = EUserStatus.Active;
            command.Image = "image.jpg";
            var handler = new UserHandler(new UserRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShoulReturnValidWhenEditUser()
        {
            var command = new EditUserCommand();
            command.Id = Guid.NewGuid();
            command.FirstName = "FirstName";
            command.LastName = "LastName";
            command.Document = "759.502.280-06";
            command.Phone = "000000000000";
            var handler = new UserHandler(new UserRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenDeleteCommandValid()
        {
            var command = new DeleteUserCommand();
            command.Id = Guid.NewGuid();
            var handler = new UserHandler(new UserRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }
    }
}