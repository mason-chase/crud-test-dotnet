using Mc2.CrudTest.Presentation.Shared.Domain;
using MediatR;


namespace Mc2.CrudTest.Presentation.Shared.Queries
{
    public record IsExistCustomerEmailQuery(string Email) : IRequest<Result<bool>>;
    public record IsExistCustomerEmailForUpdateQuery(int Id, string Email) : IRequest<Result<bool>>;

    public record IsExistCustomerNameQuery(string FirstName, string LastName, DateTime DateOfBirth) : IRequest<Result<bool>>;
    public record IsExistCustomerNameForUpdateQuery(int Id, string FirstName, string LastName, DateTime DateOfBirth) : IRequest<Result<bool>>;
}
