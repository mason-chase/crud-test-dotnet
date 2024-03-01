
using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Domain.Entities;
using MediatR;


namespace Mc2.CrudTest.Presentation.Application.Customers.Queries.IsExistCustomer
{

    public record IsExistCustomerEmailQuery(string Email) : IRequest<Result<bool>>;
    public record IsExistCustomerEmailForUpdateQuery(int Id, string Email) : IRequest<Result<bool>>;

    public class IsExistCustomerEmailQueryHandler : IRequestHandler<IsExistCustomerEmailQuery, Result<bool>>
    {
        IQueryRepository _queryRepository;
        public IsExistCustomerEmailQueryHandler(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<Result<bool>> Handle(IsExistCustomerEmailQuery req, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var isExist = await _queryRepository.ExistsAsync<Customer>(x => x.Email == req.Email);

            result.Data = isExist;
            return result;
        }
    }

    public class IsExistCustomerEmailForUpdateQueryHandler : IRequestHandler<IsExistCustomerEmailForUpdateQuery, Result<bool>>
    {
        IQueryRepository _queryRepository;
        public IsExistCustomerEmailForUpdateQueryHandler(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<Result<bool>> Handle(IsExistCustomerEmailForUpdateQuery req, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var isExist = await _queryRepository.ExistsAsync<Customer>(x => x.Email == req.Email && x.Id != req.Id);

            result.Data = isExist;
            return result;
        }
    }

}
