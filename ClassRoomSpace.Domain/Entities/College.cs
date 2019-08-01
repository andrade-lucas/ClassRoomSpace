using System.Collections.Generic;
using System.Linq;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Shared.Entities;

namespace ClassRoomSpace.Domain.Entities
{
    public class College : Entity
    {
        private readonly IList<Address> _addresses;
        private readonly IList<Block> _blocks;
        private readonly IList<Course> _courses;

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IEnumerable<Address> Addresses => _addresses.ToArray();
        public IEnumerable<Block> Blocks => _blocks.ToArray();
        public IEnumerable<Course> Courses => _courses.ToArray();
        public string Image { get; private set; }

        public College(Name name, Document document, Email email, string phone, string image)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            Image = image;
            _addresses = new List<Address>();
            _blocks = new List<Block>();
            _courses = new List<Course>();
        }

        public void AddAddress(Address address)
        {
            if (address.IsValid)
                _addresses.Add(address);

            AddNotifications(address.Notifications);
        }

        public void AddBlock(Block block)
        {
            if (block.IsValid)
                _blocks.Add(block);

            AddNotifications(block.Notifications);
        }

        public void AddCourse(Course course)
        {
            if (course.IsValid)
                _courses.Add(course);

            AddNotifications(course.Notifications);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}