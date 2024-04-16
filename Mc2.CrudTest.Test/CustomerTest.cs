using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Interfaces.Context;
using Mc2.CrudTest.Application.Services.Customers.Command.EditCustomer;
using Mc2.CrudTest.Application.Services.Customers.Command.RegisterCustomer;
using Mc2.CrudTest.Application.Services.Customers.Command.RemoveCustomer;
using Mc2.CrudTest.Application.Services.Customers.Query.GetCustomerByID;
using Mc2.CrudTest.Application.Services.Customers.Query.GetCustomers;
using Mc2.CrudTest.Domain.Entities.Customers;
using Mc2.CrudTest.Presistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Mc2.CrudTest.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void GetAllCustomersTest()
        {
            //Arrange
            IQueryable<Customer> customers = new List<Customer>
            {
                new Customer()
                {
                    FirstName="Azadeh",
                    LastName="Yousefi",
                    PhoneNumber=9307609891,
                    Email="Azadeh.yousefi@gmail.com",
                    BankAccountNumber="6851-5481-5823-5842",
                    DateOfBirth=DateTime.Now,
                },
                 new Customer()
                {
                    FirstName="Hossein",
                    LastName="Yousefi",
                    PhoneNumber=9307609891,
                    Email="Hossein.yousefi@gmail.com",
                    BankAccountNumber="7777-5481-5823-5842",
                    DateOfBirth=DateTime.Now,
                }
            }.AsQueryable();

            var mockSet= new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m=>m.Provider).Returns(customers.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customers.GetEnumerator());

            var mockContext=new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Customers).Returns(mockSet.Object);

            //Act
            var getCustomers=new GetCustomersService(mockContext.Object);
            var actual=getCustomers.Execute();

            //Assert
            Assert.AreEqual(2,actual.Count());
            Assert.AreEqual("Azadeh", actual.First().FirstName);

        }
        [TestMethod]
        public void RegisterCustomerTest()
        {
            //Arrange
            var mockset=new Mock<DbSet<Customer>>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Customers).Returns(mockset.Object);

            //Act
            var registerCustomer = new RegisterCustomerService(mockContext.Object);
            registerCustomer.Execute(new Domain.Dto.CustomerDto()
            {
                FirstName="Azadeh",
                LastName="Yousefi",
                PhoneNumber=9307609891,
                Email="Azadeh@yahoo.com",
                BankAccountNumber="2222-4444-5555-6565",
                DateOfBirth=DateTime.Now,
            });

            //Assert
            mockset.Verify(m=>m.Add(It.IsAny<Customer>()),Times.Once);
            mockContext.Verify(m=>m.SaveChanges(), Times.Once);
        }
        [TestMethod]
        public void RemovesCustomerTest()
        {
            // Arrange
            long testId = 123; // Replace with a valid test Id
            var mockContext = new Mock<IDataBaseContext>();
            var mockCustomerSet = new Mock<DbSet<Customer>>(); // Replace Customer with the actual entity type used in your context
            var mockCustomer = new Mock<Customer>(); // Replace Customer with the actual entity type used in your context
            mockContext.Setup(c => c.Customers).Returns(mockCustomerSet.Object);
            mockCustomerSet.Setup(s => s.Find(testId)).Returns(mockCustomer.Object);
            var removeCustomer = new RemoveCustomer(mockContext.Object);

            // Act
            var result = removeCustomer.Execute(testId);

            // Assert
            mockCustomerSet.Verify(s => s.Find(testId), Times.Once);
            mockCustomerSet.Verify(s => s.Remove(mockCustomer.Object), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Successful", result.Message);
        }

        private EditCustomerService _editCustomerService;
        private Mock<IDataBaseContext> _dbContextMock;

        [TestInitialize]
        public void Initialize()
        {
            _dbContextMock = new Mock<IDataBaseContext>();
            _editCustomerService = new EditCustomerService(_dbContextMock.Object);
        }

        [TestMethod]
        public void EditCustomerTest()
        {
            // Arrange
            var customerId = 1;
            var request = new EditCustomerDto
            {
                FirstName = "John",
                LastName = "Doe",
            };

            var existingCustomer = new Customer
            {
                Id= customerId,
                FirstName = "John2",
                LastName = "Doe2",
            };


            _dbContextMock.Setup(c => c.Customers.Find(customerId)).Returns(existingCustomer);

            // Act
            var result = _editCustomerService.Execute(customerId, request);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Succesful", result.Message);

        }

        [TestMethod]
        public void EditCustomer_ReturnsUserNotFound()
        {
            // Arrange
            var customerId = 1;
            var request = new EditCustomerDto
            {
                FirstName="Azad",
                LastName="Yousefi"
            };


            _dbContextMock.Setup(c => c.Customers.Find(customerId)).Returns((Customer)null);

            // Act
            var result = _editCustomerService.Execute(customerId, request);

            // Assert
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual("User not found", result.Message);

        }

    }

}
