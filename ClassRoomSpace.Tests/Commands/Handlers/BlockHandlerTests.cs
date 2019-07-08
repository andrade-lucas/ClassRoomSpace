using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs;
using ClassRoomSpace.Tests.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Commands.Handlers
{
    [TestClass]
    public class BlockHandlerTests
    {
        [TestMethod]
        public void ShouldReturnFalseWhenInvalid()
        {
            var command = new CreateBlockCommand();
            command.Description = "";
            var handler = new BlockHandler(new BlockRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreNotEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenValid()
        {
            var command = new CreateBlockCommand();
            command.Description = "Block A";
            var handler = new BlockHandler(new BlockRepositoryMock());
            var result = handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }
    }
}