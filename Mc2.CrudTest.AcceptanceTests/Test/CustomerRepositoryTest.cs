using Mc2.CrudTest.AcceptanceTests.Entities;
using NUnit.Framework;

namespace Mc2.CrudTest.AcceptanceTests.Test
{
    public class CustomerRepositoryTest
    {
        private CustomerRepository CustomerRepository;

        [SetUp]
        public void SetUp()
        {
            CustomerRepository = ICustomerRepositoryMock.GetMock();
        }

        [Test]
        public void GetCustomers()
        {
            //Arrange


            //Act
            IList<Customer> lstData = CustomerRepository.GetCustomers();


            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(lstData, Is.Not.Null);
                Assert.That(lstData.Count, Is.GreaterThan(0));
            });
        }

        [Test]
        public void GetCustomerById()
        {
            //Arrange
            int id = 1;

            //Act
            Customer data = CustomerRepository.GetCustomerById(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.Not.Null);
                Assert.That(data.Id, Is.EqualTo(id));
            });
        }

        [Test]
        public void AddCustomer()
        {
            //Arrange
            Customer Customer = new Customer()
            {
                Id = 100,
                FirstName = "New User",
                LastName = "gg",
                Email="geramiraz@yahoo.com",
                BirthDate = DateTime.Now,
                BankAccountNumber="998",

            };

            //Act
            bool data = CustomerRepository.AddCustomer(Customer);
            Customer expectedData = CustomerRepository.GetCustomerById(Customer.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.True);
                Assert.That(expectedData, Is.Not.Null);
                Assert.That(expectedData.Id, Is.EqualTo(expectedData.Id));
            });
        }

        [Test]
        public void UpdateCustomer()
        {
            //Arrange
            int id = 2;
            Customer actualData = CustomerRepository.GetCustomerById(id);
            actualData.FirstName = "Update User";
            actualData.LastName = "Gr";
            actualData.Email = "geramiraz@yahoo.com";
            actualData.BirthDate = DateTime.Now;
            actualData.BankAccountNumber = "998";
            //Act
            bool data = CustomerRepository.UpdateCustomer(actualData);
            Customer expectedData = CustomerRepository.GetCustomerById(actualData.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.True);
                Assert.That(expectedData, Is.Not.Null);
                Assert.That(expectedData, Is.EqualTo(actualData));
            });
        }

        [Test]
        public void DeleteCustomer()
        {
            //Arrange
            int id = 2;
            Customer actualData = CustomerRepository.GetCustomerById(id);

            //Act
            bool data = CustomerRepository.DeleteCustomer(actualData);
            Customer expectedData = CustomerRepository.GetCustomerById(actualData.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.True);
                Assert.That(expectedData, Is.Null);
            });
        }
    }
}
