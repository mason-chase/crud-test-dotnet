using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Hamideh.Crud.Test.Application.CustomerFeatures.Command.AddCustomer
{
    public record EditCustomerCommand : IRequest<EditCustomerCommandResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }


        public bool CheckLastNameIsEmpty()
        {
            return LastName.IsNullOrEmpty();
        }

        public bool CheckFirstNameIsEmpty()
        {
            return FirstName.IsNullOrEmpty();
        }
    }
}
