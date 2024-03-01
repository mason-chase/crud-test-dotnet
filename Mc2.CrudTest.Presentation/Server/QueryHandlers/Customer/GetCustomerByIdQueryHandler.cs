using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.Domain;
using Mc2.CrudTest.Presentation.Shared.Interfaces.Data;
using Mc2.CrudTest.Presentation.Shared.Queries;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.QueryHandlers
{

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<CustomerModel>>
    {
        IQueryRepository _queryRepository;
        public GetCustomerByIdQueryHandler(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<Result<CustomerModel>> Handle(GetCustomerByIdQuery req, CancellationToken cancellationToken)
        {
            var result = new Result<CustomerModel>();

            var customer = await _queryRepository.GetByIdAsync<Customer>(req.CustomerId, cancellationToken: cancellationToken);
            if(customer == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                return result;
            }
            var customerModel = new CustomerModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                BankAccountNumber = customer.BankAccountNumber
            };
            result.Data = customerModel;
            return result;
        }
    }
}
