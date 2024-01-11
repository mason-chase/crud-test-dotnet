using CQRS.NET;

namespace Application.Customers.Queries.GetCustomerById;

public sealed record GetCustomerByIdQuery(int CustomerId) : IQuery<CustomerResponse>;
