using System;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.Block;
using ClassRoomSpace.Tests.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Commands.Handlers
{
    [TestClass]
    public class BlockHandlerTests
    {
        [TestMethod]
        public void ShouldReturnFalseWhenCreateCommandInvalid()
        {
            var command = new CreateBlockCommand();
            command.Description = "";
            var handler = new BlockHandler(new BlockRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreNotEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenCreateCommandValid()
        {
            var command = new CreateBlockCommand();
            command.Description = "Block A";
            var handler = new BlockHandler(new BlockRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenEditCommandInvalid()
        {
            var command = new EditBlockCommand();
            command.Id = Guid.NewGuid();
            command.Description = "";
            var handler = new BlockHandler(new BlockRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreNotEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenEditCommandIsValid()
        {
            var command = new EditBlockCommand();
            command.Id = Guid.NewGuid();
            command.Description = "Block B";
            var handler = new BlockHandler(new BlockRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenDeleteCommandIsValid()
        {
            var command = new DeleteBlockCommand();
            command.Id = Guid.NewGuid();
            var handler = new BlockHandler(new BlockRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }
    }
}