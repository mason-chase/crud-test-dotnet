
using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Domain.Entities;
using MediatR;


namespace Mc2.CrudTest.Presentation.Application.Customers.Queries.IsExistCustomer
{

    public record IsExistCustomerNameQuery(string FirstName, string LastName, DateTime DateOfBirth) : IRequest<Result<bool>>;
    public record IsExistCustomerNameForUpdateQuery(int Id, string FirstName, string LastName, DateTime DateOfBirth) : IRequest<Result<bool>>;


    public class IsExistCustomerNameQueryHandler : IRequestHandler<IsExistCustomerNameQuery, Result<bool>>
    {
        IQueryRepository _queryRepository;
        public IsExistCustomerNameQueryHandler(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<Result<bool>> Handle(IsExistCustomerNameQuery req, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var isExist = await _queryRepository.ExistsAsync<Customer>(x => x.FirstName == req.FirstName && x.LastName == req.LastName && x.DateOfBirth == req.DateOfBirth);

            result.Data = isExist;
            return result;
        }
    }

    public class IsExistCustomerNameForUpdateQueryHandler : IRequestHandler<IsExistCustomerNameForUpdateQuery, Result<bool>>
    {
        IQueryRepository _queryRepository;
        public IsExistCustomerNameForUpdateQueryHandler(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<Result<bool>> Handle(IsExistCustomerNameForUpdateQuery req, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var isExist = await _queryRepository.ExistsAsync<Customer>(x => x.Id != req.Id && x.FirstName == req.FirstName && x.LastName == req.LastName && x.DateOfBirth == req.DateOfBirth);

            result.Data = isExist;
            return result;
        }
    }
}
