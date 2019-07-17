using ClassRoomSpace.Domain.Entities;
using ClassRoomSpace.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Entities
{
    [TestClass]
    public class ClassRoomTests
    {
        private ClassRoom _invalidClassRoom;
        private ClassRoom _validClassRoom;

        public ClassRoomTests()
        {
            _invalidClassRoom = new ClassRoom("", EClassRoomStatus.Free, EClassRoomType.Normal);
            _validClassRoom = new ClassRoom("ClassRoom 1", EClassRoomStatus.Free, EClassRoomType.Normal);
        }
        
        [TestMethod]
        public void ShouldReturnInvalidWhenInvalid()
        {
            Assert.AreNotEqual(true, _invalidClassRoom.IsValid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenValid()
        {
            Assert.AreEqual(true, _validClassRoom.IsValid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenBook()
        {
            _validClassRoom.Book();
            Assert.AreEqual(EClassRoomStatus.Reserved, _validClassRoom.Status);
        }

        [TestMethod]
        public void ShouldReturnValidWhenSettingUnvailable()
        {
            _validClassRoom.SetAsUnvaiable();
            Assert.AreEqual(EClassRoomStatus.Unavailable, _validClassRoom.Status);
        }
    }
}