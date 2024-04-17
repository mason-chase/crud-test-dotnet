
using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomerById
{
    public record GetCustomerByIdQuery(int CustomerId) : IRequest<Result<CustomerModel>>;

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
            if (customer == null)
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
