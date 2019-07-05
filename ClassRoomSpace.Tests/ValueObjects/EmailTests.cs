using ClassRoomSpace.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void shoulReturnInvalidWhenEmailIsNull()
        {
            var email = new Email(null);
            Assert.AreNotEqual(true, email.IsValid);
        }

        [TestMethod]
        public void ShoulReturnInvalidWhenEmailIsInvalid()
        {
            var email = new Email("example.com");
            Assert.AreNotEqual(true, email.IsValid);
        }

        [TestMethod]
        public void ShoulReturnValidWhenEmailIsValid()
        {
            var email = new Email("example@example.com");
            Assert.AreEqual(true, email.IsValid);
        }
    }
}