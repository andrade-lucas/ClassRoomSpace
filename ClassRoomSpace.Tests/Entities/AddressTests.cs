using ClassRoomSpace.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Entities
{
    [TestClass]
    public class AddressTests
    {
        private Address _validAddress;
        private Address _invalidAddress;

        public AddressTests()
        {
            _validAddress = new Address(
                "St One", "0102", "00000-000", "Center", "City", "ST", "Brazil"
            );
            _invalidAddress = new Address(
                "", "", "", "", "", "", ""
            );
        }

        [TestMethod]
        public void ShouldReturnValidWhenValid()
        {
            Assert.AreEqual(true, _validAddress.IsValid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenInvalid()
        {
            Assert.AreEqual(true, _invalidAddress.Invalid);
        }
    }
}