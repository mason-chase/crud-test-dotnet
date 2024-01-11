using MediatR;

namespace Application.Customers.Commands.DeleteCustomer;

public sealed record DeleteCustomerCommand(int Id) : IRequest<bool>;
   
