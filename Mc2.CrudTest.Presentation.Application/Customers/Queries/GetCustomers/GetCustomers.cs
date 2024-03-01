
using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomers
{
    public record GetCustomersQuery : IRequest<Result<List<CustomerModel>>>;


    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, Result<List<CustomerModel>>>
    {
        IQueryRepository _queryRepository;
        public GetCustomersQueryHandler(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<Result<List<CustomerModel>>> Handle(GetCustomersQuery req, CancellationToken cancellationToken)
        {
            var result = new Result<List<CustomerModel>>();

            var customers = await _queryRepository.GetListAsync<Customer>(cancellationToken: cancellationToken);

            var customersList = customers.Select(x => new CustomerModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                BankAccountNumber = x.BankAccountNumber
            }).ToList();

            result.Data = customersList;

            return result;
        }
    }
}
