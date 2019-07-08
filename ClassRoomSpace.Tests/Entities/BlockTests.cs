using ClassRoomSpace.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Entities
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void ShouldCreateAValidBlock()
        {
            var block = new Block("Block A");
            Assert.AreEqual(true, block.IsValid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenInvalid()
        {
            var block = new Block("");
            Assert.AreEqual(true, block.Invalid);
        }
    }
}