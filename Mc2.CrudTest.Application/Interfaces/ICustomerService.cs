using Mc2.CrudTest.Domain.Models;

namespace Mc2.CrudTest.Application.Interfaces;

public interface ICustomerService
{
    Task ValidateCustomer(CustomerModel customerModel, CancellationToken cancellationToken);
}