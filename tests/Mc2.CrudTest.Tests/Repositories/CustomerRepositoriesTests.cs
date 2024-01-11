using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure;

namespace Mc2.CrudTest.Tests.Repositories
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public CustomerRepositoryTests()
        {
            var dbName = $"CrudTests_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsAllCustomers()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();

            // Act
            var customerList = await repository.GetAllAsync();

            // Assert
            Assert.AreEqual(0, customerList.Count); // Assuming no data is populated initially
        }

        [TestMethod]
        public async Task GetByIdAsync_WithValidId_ReturnsCustomer()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();
            var customerId = await AddCustomerAndGetId(repository);

            // Act
            var customer = await repository.GetByIdAsync(customerId);

            // Assert
            Assert.IsNotNull(customer);
            Assert.AreEqual(customerId, customer.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Customer Not Found")]
        public async Task GetByIdAsync_WithInvalidId_ThrowsException()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();

            // Act & Assert
            var customer = await repository.GetByIdAsync(123);
            // The test will pass if the exception is thrown.
        }

        [TestMethod]
        public async Task AddAsync_AddsNewCustomer()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();
            var customer = new Customer { Firstname = "John", Lastname = "Doe", Email = "john.doe@example.com" };

            // Act
            var result = await repository.AddAsync(customer);

            // Assert
            Assert.IsTrue(result);
            Assert.AreNotEqual(0, customer.Id);
        }


        [TestMethod]
        public async Task UpdateAsync_WithInvalidCustomer_ReturnsFalse()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();
            var invalidCustomer = new Customer { Id = 123, Firstname = "InvalidJohn" };

            // Act
            var result = await repository.UpdateAsync(invalidCustomer);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task DeleteAsync_WithValidId_DeletesCustomer()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();
            var customerId = await AddCustomerAndGetId(repository);

            // Act
            var result = await repository.DeleteAsync(customerId);

            // Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public async Task DeleteAsync_WithInvalidId_ReturnsFalse()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();

            // Act
            var result = await repository.DeleteAsync(123);

            // Assert
            Assert.IsFalse(result);
        }

        private async Task<CustomerRepository> CreateRepositoryAsync()
        {
            var context = new ApplicationDbContext(_dbContextOptions);
            await context.Database.EnsureCreatedAsync(); // Ensure the in-memory database is created
            return new CustomerRepository(context, new GenericRepository<Customer>(context));
        }

        private async Task<int> AddCustomerAndGetId(CustomerRepository repository)
        {
            var customer = new Customer { Firstname = "John", Lastname = "Doe", Email = "john.doe@example.com" };
            await repository.AddAsync(customer);
            return customer.Id;
        }
    }
}
