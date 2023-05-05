using AndreTurApp.AddressService.Controllers;
using AndreTurApp.AddressService.Data;
using AndreTurApp.Services;
using AndreTurApp.Models;
using AndreTurApp.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AndreTurAppNewVersion.Tests
{
    public class UnitTestAddress
    {
        private DbContextOptions<AndreTurAppAddressServiceContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurAppAddressServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new AndreTurAppAddressServiceContext(options))
            {
                context.Address.Add(new Address { Id = 50, Street = "Rua 1", Number = 600, Neighborhood = "Bairro 1", Complement = "Fundos",
                    City = new City() { Id = 1, Description = "City1" }, ZipCode = "123456789", RegisterDate = DateTime.Now });

                context.Address.Add(new Address { Id = 51, Street = "Rua 2", Number = 666, Neighborhood = "Bairro 2", Complement = "",
                    City = new City() { Id = 2, Description = "City2" }, ZipCode = "987654321", RegisterDate = DateTime.Now });

                context.Address.Add(new Address { Id = 52, Street = "Rua 3", Number = 999, Neighborhood = "Bairro 3", Complement = "Casa2",
                    City = new City() { Id = 3, Description = "City3" }, ZipCode = "159647841", RegisterDate = DateTime.Now });

                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurAppAddressServiceContext(options))
            {
                AddressesController clientController = new AddressesController(context, null);
                IEnumerable<Address> clients = clientController.GetAddress().Result.Value;

                Assert.Equal(3, clients.Count());
            }
        }

        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurAppAddressServiceContext(options))
            {
                int addressId = 50;
                AddressesController addressController = new AddressesController(context, null);
                Address address = addressController.GetAddress(addressId).Result.Value;
                Assert.Equal(50, address.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            Address address = new Address()
            {
                Id = 49,
                Street = "Rua 10",
                Number = 987,
                Neighborhood = "ABCBairro",
                Complement = "",
                City = new() { Id = 10, Description = "City 10", RegisterDate = DateTime.Now },
                ZipCode = "14804300",
                RegisterDate = DateTime.Now
            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurAppAddressServiceContext(options))
            {
                AddressesController clientController = new AddressesController(context, new PostOffice());
                Address ad = clientController.PostAddress(address).Result.Value;
                Assert.Equal("Rua 10", ad.Street);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            AddressDTOPut address = new()
            {
                Id = 50,
                Number = 500,
                Complement = "Novo complemento"
            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurAppAddressServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context, null);
                Address ad = addressController.PutAddress(50, address).Result.Value;
                Assert.Equal(500, address.Number);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurAppAddressServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context, null);
                Address address = addressController.DeleteAddress(49).Result.Value;
                Assert.Null(address);
            }
        }
    }
}
