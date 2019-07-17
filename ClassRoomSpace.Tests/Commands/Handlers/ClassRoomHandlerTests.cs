using System;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.ClassRoom;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Tests.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Commands.Handlers
{
    [TestClass]
    public class ClassRoomHandlerTests
    {
        [TestMethod]
        public void ShouldReturnValidWhenCreateCommandIsValid()
        {
            var command = new CreateClassRoomCommand();
            command.Description = "ClassRoom 1";
            command.Status = EClassRoomStatus.Free;
            command.Type = EClassRoomType.Normal;
            command.IdBlock = Guid.NewGuid();
            var handler = new ClassRoomHandler(new ClassRoomRepositoryMock());
            var result = handler.Handle(command);

            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenEditCommandIsValid()
        {
            var command = new EditClassRoomCommand();
            command.Id = Guid.NewGuid();
            command.Description = "ClassRoom 1";
            command.Status = EClassRoomStatus.Free;
            command.Type = EClassRoomType.Normal;
            command.IdBlock = Guid.NewGuid();
            var handler = new ClassRoomHandler(new ClassRoomRepositoryMock());
            var result = handler.Handle(command);

            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenDeleteCommandIsValid()
        {
            var command = new DeleteClassRoomCommand();
            command.Id = Guid.NewGuid();
            var handler = new ClassRoomHandler(new ClassRoomRepositoryMock());
            var result = handler.Handle(command);

            Assert.AreEqual(true, result.Status);
        }
    }
}