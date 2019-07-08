using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Entities
{
    [TestClass]
    public class ProfessorTests
    {
        private Professor _validProfessor;
        private Professor _invalidProfessor;

        public ProfessorTests()
        {
            var invalidName = new Name("", "");
            var invalidDocument = new Document("123.456-00");
            var invalidEmail = new Email("example.com");
            var invalidCourse = new Course("");
            _invalidProfessor = new Professor(invalidName, invalidDocument, invalidEmail, invalidCourse, "");

            var validName = new Name("FirstName", "LastName");
            var validDocument = new Document("202.825.960-46");
            var validEmail = new Email("example@example.com");
            var validCourse = new Course("Computer Science");
            _validProfessor = new Professor(validName, validDocument, validEmail, validCourse, "0000000000000");
        }

        [TestMethod]
        public void ShouldReturnNotificationsWhenInvalid()
        {
            Assert.AreNotEqual(0, _invalidProfessor.Notifications.Count);
        }

        [TestMethod]
        public void ShouldNotReturnNotificationsWhenValid()
        {
            Assert.AreEqual(0, _validProfessor.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnValidWhenValid()
        {
            Assert.AreEqual(true, _validProfessor.IsValid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenInactivateProfessor()
        {
            _validProfessor.Inactivate();
            Assert.AreEqual(true, _validProfessor.IsValid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenActivateProfessor()
        {
            _validProfessor.Activate();
            Assert.AreEqual(true, _validProfessor.IsValid);
        }
    }
}