using webapi.Data;
using webapi.Models;
using webapi.DomainModels;

namespace webapi.Application
{
    public class CustomersService
    {
        private CustomerRepository customerRepository;
        private CustomerModel customerModel;

        public CustomersService(CustomerDbContext customerDbContext)
        {
            customerRepository = new CustomerRepository(customerDbContext);
            customerModel = new CustomerModel();
        }

        public List<Customer> GetCustomers()
        {
            return customerRepository.GetCustomers();
        }

        public Customer GetCustomer(int customerId)
        {
            return customerRepository.GetCustomer(customerId);
        }

        public Task<int> AddCustomer(Customer customer)
        {
            Customer oldCustomer = customerRepository.GetCustomerByName(customer.Firstname, customer.Lastname);

            bool phoneNumResult = customerModel.CheckPhoneNumber(customer.PhoneNumber);
            bool emailResult = customerModel.CheckEmail(customer.Email);
            bool accountNumResult = customerModel.CheckAccountNumber(customer.BankAccountNumber);

            bool NameBirthDateResult = true;
            bool CheckEmailResult = true;

            if (oldCustomer != null)
            {
                NameBirthDateResult = customerModel.CheckNameBirthDateUniqueness(customer, oldCustomer);
                CheckEmailResult = customerModel.CheckEmailUniqueness(customer, oldCustomer);
            }

            if (phoneNumResult &&
                emailResult &&
                accountNumResult &&
                NameBirthDateResult &&
                CheckEmailResult)
                return customerRepository.AddCustomer(customer);
            else
                return Task.FromResult(0);
        }

        public Task<int> UpdateCustomer(Customer customer)
        {
            return customerRepository.UpdateCustomer(customer);
        }

        public Task<int> DeleteCustomer(int customerId)
        {
            return customerRepository.DeleteCustomer(customerId);
        }
    }
}