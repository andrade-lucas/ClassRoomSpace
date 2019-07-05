using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Domain.Enums;

namespace ClassRoomSpace.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        private User _user;

        public UserTests()
        {
            var name = new Name("FirstName", "LastName");
            var document = new Document("759.502.280-06");
            var email = new Email("teste@teste.com");
            var password = new Password("12345678");

            _user = new User(name, document, email, password, "000000000000", EUserStatus.Active, "image.jpg");
        }

        [TestMethod]
        public void ShouldCreateAValidUser()
        {
            Assert.AreEqual(true, _user.IsValid);
        }

        [TestMethod]
        public void ShouldChangePhone()
        {
            _user.ChangePhone("111111111111");
            Assert.AreEqual("111111111111", _user.Phone);
        }

        [TestMethod]
        public void ShouldChangeStatus()
        {
            _user.ChangeStatus(EUserStatus.Inactive);
            Assert.AreEqual(EUserStatus.Inactive, _user.Status);
        }
    }
}