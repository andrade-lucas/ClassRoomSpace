using ClassRoomSpace.Shared.Entities;
using FluentValidator.Validation;

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
            Street = street ?? "";
            Number = number ?? "";
            ZipCode = zipCode;
            District = district;
            City = city ?? "";
            State = state ?? "";
            Country = country ?? "";

            AddNotifications(new ValidationContract()
                .HasMinLen(Street, 3, "Street", "O campo deve ter pelo menos 3 caracteres")
                .HasMinLen(City, 3, "City", "O campo deve ter pelo menos 3 caracteres")
                .HasLen(State, 2, "State", "O campo deve ter 2 caracteres")
                .HasMinLen(country, 2, "country", "O campo deve ter pelo menos 2 caracteres")
                .HasMaxLen(City, 60, "City", "O campo deve ter no máximo 60 caracteres")
                .HasMaxLen(Country, 60, "Country", "O campo deve ter no máximo 60 caracteres")
            );
        }
    }
}