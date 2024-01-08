using Shouldly;
using Xunit;
using Mc2.CrudTest.Core.Handlers;
using Mc2.CrudTest.NewCore.Commands;
using Mc2.CrudTest.NewCore.Models;
using Mc2.CrudTest.Framework.Domain.ApplicationService;
using Moq;
using Mc2.CrudTest.NewCore.Data;

namespace Mc2.CrudTest.TDD
{
    public class Customer_Creating_Request_Handler_Test
    {
        private readonly CreateCustomerCommandHandler _handler;
        private readonly Mock<ICustomerRepository> _customerRepository;

        public Customer_Creating_Request_Handler_Test()
        {
            //Arrange           
            _customerRepository = new Mock<ICustomerRepository>();
            _handler = new CreateCustomerCommandHandler(_customerRepository.Object);
        }


        [Fact]
        public void Should_Throw_Exception_For_Null_Email()
        {
            //Arrange
            var command = new CreateCustomerCommand
            {
                FirstName = "Sahar",
                LastName = "Amoorezaei",
                Email = null,
                PhoneNumber = "+15879742888",
                AccountBankNumber = "1234567890",
                DateOfBirth = DateTime.Now,
            };


            //Act
            var exception = Should.Throw<ArgumentNullException>(() => _handler.Handle(command));

            //Assert

            exception.ParamName.ShouldBe("Email is required.");
        }
    }
}