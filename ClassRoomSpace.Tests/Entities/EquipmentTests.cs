using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Entities
{
    [TestClass]
    public class EquipmentTests
    {
        private Equipment _validEquipment;
        private Equipment _invalidEquipment;

        public EquipmentTests()
        {
            _validEquipment = new Equipment("New Equipment");
            _invalidEquipment = new Equipment("");
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenInvalid()
        {
            Assert.AreNotEqual(true, _invalidEquipment.IsValid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenValid()
        {
            Assert.AreEqual(true, _validEquipment.IsValid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenBookValid()
        {
            _validEquipment.Book();
            Assert.AreEqual(EEquipmentStatus.Reserved, _validEquipment.Status);
        }
    }
}