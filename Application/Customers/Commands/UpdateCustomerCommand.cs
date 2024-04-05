using Common.Attributes;
using MediatR;
using static Common.Attributes.CustomizedValidationAttribute;

namespace Application.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<(bool, string)>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [CustomizedValidation(ValidationType.MobileNumber)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}