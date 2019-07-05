using ClassRoomSpace.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnInvalidWhenDocumentIsInvalid()
        {
            var doc = new Document("123.456.789-12");
            Assert.AreNotEqual(true, doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenDocumentIsValid()
        {
            var doc = new Document("759.502.280-06");
            Assert.AreEqual(true, doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenDocumentIsNull()
        {
            var doc = new Document(null);
            Assert.AreNotEqual(true, doc.IsValid);
        }

        [TestMethod]
        public void ShoulReturnInvalidWhenDocumentIsBiggerThanEleven()
        {
            var doc = new Document("12345678912309");
            Assert.AreEqual(false, doc.IsValid);
        }
    }
}