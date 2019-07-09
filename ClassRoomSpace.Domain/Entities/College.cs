using System.Collections.Generic;
using System.Linq;
using ClassRoomSpace.Domain.ValueObjects;
using ClassRoomSpace.Shared.Entities;

namespace ClassRoomSpace.Domain.Entities
{
    public class College : Entity
    {
        private readonly IList<string> _addresses;
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public string Phone { get; private set; }
        public IEnumerable<string> Addresses => _addresses.ToArray();
        public string Image { get; private set; }
    }
}