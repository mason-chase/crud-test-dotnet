using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.Domain;
using Mc2.CrudTest.Presentation.Shared.Interfaces.Data;
using Mc2.CrudTest.Presentation.Shared.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.QueryHandlers
{

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

            var isExist = await _queryRepository.ExistsAsync<Customer>(x=>x.Email == req.Email);

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
