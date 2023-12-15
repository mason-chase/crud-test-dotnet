using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Infrastructure.EF.Models;

namespace Mc2.CrudTest.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static CustomerDto ToDto(this CustomerReadModel customerReadModel)
        {
            CustomerDto customerDto = new CustomerDto()
            {
                BankAccountNumber = customerReadModel.BankAccountNumber,
                Birthday = customerReadModel.Birthday,
                Email = customerReadModel.Email,
                FullName = new FullNameDto
                {
                    FirstName = customerReadModel.FullName.FirstName,
                    LastName = customerReadModel.FullName.LastName
                },
                Id = customerReadModel.Id
            };
            return customerDto;
        }
    }
}
