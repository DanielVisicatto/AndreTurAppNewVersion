using AndreTurApp.Models.DTOs;

namespace AndreTurApp.Models
{
    public class Address
    {
        #region[Properties]
        public int Id { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? Complement { get; set; }
        public City City { get; set; }
        public string? ZipCode { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion

        #region[Ctors]
        public Address()
        {
        }

        public Address(AddressDTO addressDTO)
        {
            Street = addressDTO.Street;
            Neighborhood = addressDTO.Neighborhood;            
            City = new City() { Description = addressDTO.City, RegisterDate = DateTime.Now}; // passando no construtor dentro da propriedade de City
            RegisterDate = DateTime.Now;
        }
        #endregion
    }
}
