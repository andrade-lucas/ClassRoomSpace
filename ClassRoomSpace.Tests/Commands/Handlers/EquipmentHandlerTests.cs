using System;
using ClassRoomSpace.Domain.Commands.Handlers;
using ClassRoomSpace.Domain.Commands.Inputs.Equipment;
using ClassRoomSpace.Domain.Enums;
using ClassRoomSpace.Tests.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Commands.Handlers
{
    [TestClass]
    public class EquipmentHandlerTests
    {
        private readonly EquipmentHandler _handler;

        public EquipmentHandlerTests()
        {
            _handler = new EquipmentHandler(new EquipmentRepositoryMock());
        }

        [TestMethod]
        public void ShouldReturnValidWhenCreateCommandIsValid()
        {
            var command = new CreateEquipmentCommand();
            command.Description = "New Equipment";
            var result = _handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldreturnValidWhenEditCommandIsValid()
        {
            var command = new EditEquipmentCommand();
            command.Id = Guid.NewGuid();
            command.Description = "Edited Equipment";
            command.Status = EEquipmentStatus.Free;
            command.PurchaseDate = DateTime.Now;
            command.IdCollege = Guid.NewGuid();
            var result = _handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenDeleteCommandIsValid()
        {
            var command = new DeleteEquipmentCommand();
            command.Id = Guid.NewGuid();
            var result = _handler.Handle(command);
            Assert.AreEqual(true, result.Status);
        }
    }
}