using ClassRoomSpace.Shared.Entities;

namespace ClassRoomSpace.Domain.Entities
{
    public class Address : Entity
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string ZipCode { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        
        public Address(string street, string number, string zipCode, string district, string city, string state, string country)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            District = district;
            City = city;
            State = state;
            Country = country;
        }
    }
}