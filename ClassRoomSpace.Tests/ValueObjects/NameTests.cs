using ClassRoomSpace.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        private Name _name;

        public NameTests()
        {
            _name = new Name("Firstname", "LastName");
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenNameLengthIsLessTwoThree()
        {
            var name = new Name("F", "L");
            Assert.AreEqual(false, name.IsValid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenNameIsCorrect()
        {
            var name = new Name("FirstName", "LastName");
            Assert.AreEqual(true, name.IsValid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenNameIsBiggerThanThirty()
        {
            var name = new Name("0123456789123456789123456789123456", "0123456789123456789123456789123456");
            Assert.AreEqual(true, name.Invalid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenChanceNameIsValid()
        {
            _name.Change("FirstAnother", "LastAnother");
            Assert.AreEqual(true, _name.IsValid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenChangeNameInvalid()
        {
            _name.Change("", "");
            Assert.AreNotEqual(true, _name.IsValid);
        }
    }
}