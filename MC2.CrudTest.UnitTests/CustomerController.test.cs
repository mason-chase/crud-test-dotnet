using Mc2.CrudTest.Presentation.DomainServices;
using Mc2.CrudTest.Presentation.Server.Controllers;
using Mc2.CrudTest.Presentation.Shared.Entities;
using Moq;

namespace MC2.CrudTest.UnitTests
{
    public class CustomerControllerTests
    {
        private Mock<ICustomerService> _mockCustomerService;
        private CustomerController _controller;
        
        public CustomerControllerTests()
        {
             _mockCustomerService = new Mock<ICustomerService>();
             _controller = new CustomerController(_mockCustomerService.Object);
        }
        [Fact]
        public async Task CreateCustomer_ValidInput_CallsAddCustomerAsync()
        {
            var newCustomer = new Customer("Mohammad", "Dehghani", "+989010596159", "dehghany@gmail.com", "65468489464");
         
            await _controller.CreateCustomer(newCustomer);

            _mockCustomerService.Verify(s => s.CreateCustomerAsync(newCustomer), Times.Once);
        }

        [Fact]
        public async Task UpdateCustomer_ValidInput_CallsUpdateCustomerAsync()
        {
            var existingCustomer = new Customer(); // TODO: complete this
         
            var res = await Record.ExceptionAsync(async () => await _controller.UdateCustomer(existingCustomer));
            
            Assert.Null(res);

        }

        [Fact]
        public async Task DeleteCustomer_ValidInput_CallsDeleteCustomerAsync()
        {
            var id = new Guid();

            var res = await Record.ExceptionAsync(async () => await _controller.DeleteCustomer(id)); 
            
            Assert.Null(res);
        }

        [Fact]
        public async Task GetCustomer_ValidInput_CallsGetCustomerAsync()
        {
            var id = new Guid("1234565487987");
          
            var customer = await _controller.GetCustomer(id);

            Assert.NotNull(customer);
        }
    }
}