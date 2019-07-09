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

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IEnumerable<Address> Addresses => _addresses.ToArray();
        public IEnumerable<Block> Blocks => _blocks.ToArray();
        public string Image { get; private set; }

        public College(Name name, Document document, Email email, string phone, string image)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            Image = image;
            _addresses = new List<Address>();
            _blocks = new List<Block>();
        }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public void AddBlock(Block block)
        {
            _blocks.Add(block);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}