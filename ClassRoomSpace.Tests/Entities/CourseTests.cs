using System;
using ClassRoomSpace.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomSpace.Tests.Entities
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void ShouldReturnNotificationsWhenDescriptionLengthLessThanTwo()
        {
            var course = new Course("");
            Assert.AreNotEqual(0, course.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenDescriptionIsInvalid()
        {
            var course = new Course(null);
            Assert.AreEqual(true, course.Invalid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenCourseValid()
        {
            var course = new Course("Computer Science");
            Assert.AreEqual(true, course.IsValid);
        }
    }
}