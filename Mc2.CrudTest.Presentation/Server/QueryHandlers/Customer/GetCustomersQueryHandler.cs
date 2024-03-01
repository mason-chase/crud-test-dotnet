using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.Domain;
using Mc2.CrudTest.Presentation.Shared.Interfaces.Data;
using Mc2.CrudTest.Presentation.Shared.Queries;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.QueryHandlers
{

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
