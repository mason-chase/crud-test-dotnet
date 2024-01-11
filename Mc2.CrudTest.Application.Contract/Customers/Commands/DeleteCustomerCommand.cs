using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Application.Contract.Customers.Commands;

public class DeleteCustomerCommand : IRequest<Result>
{
    [Required]
    public Guid Id { get; init; }
}
