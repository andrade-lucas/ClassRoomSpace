using ClassRoomSpace.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.ValueObjects
{
    [TestClass]
    public class PasswordTests
    {
        private Password _password;

        public PasswordTests()
        {
            _password = new Password("12345678");
        }

        [TestMethod]
        public void ShoulReturnInvalidWhenPasswordIsNull()
        {
            var pass = new Password(null);
            Assert.AreEqual(false, pass.IsValid);
        }

        [TestMethod]
        public void ShoulReturnInvalidWhenPasswordLengthIsLessThanFive()
        {
            var pass = new Password("1234");
            Assert.AreNotEqual(true, pass.IsValid);
        }

        [TestMethod]
        public void ShoulReturnInvalidWhenPasswordLengthIsBiggerThanTwenty()
        {
            var pass = new Password("012345678912345678912123");
            Assert.AreEqual(true, pass.Invalid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenPasswordIsValid()
        {
            var pass = new Password("123456789");
            Assert.AreEqual(true, pass.IsValid);
        }

        [TestMethod]
        public void ShouldreturnInvalidWhenPasswordsAreNotEqual()
        {
            var pass1 = new Password("12345678");
            var pass2 = new Password("87654321");

            Assert.AreNotEqual(pass1.Value, pass2.Value);
        }

        [TestMethod]
        public void ShouldReturnValidWhenPasswordsAreEqual()
        {
            var pass1 = new Password("12345678");
            var pass2 = new Password("12345678");
            Assert.AreEqual(pass1.Value, pass2.Value);
        }

        [TestMethod]
        public void ShoulReturnNotificationWhenChangePassword()
        {
            _password.Change("123");
            Assert.AreNotEqual(0, _password.Notifications.Count);
        }

        [TestMethod]
        public void ShouldNotReturnNotificationWhenChangePassword()
        {
            _password.Change("123456789");
            Assert.AreEqual(0, _password.Notifications.Count);
        }
    }
}