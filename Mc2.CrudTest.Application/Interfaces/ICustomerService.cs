using Mc2.CrudTest.Domain.Models;

namespace Mc2.CrudTest.Application.Interfaces;

public interface ICustomerService
{
    Task CustomerCreateValidation(CustomerModel customerModel, CancellationToken cancellationToken);
    Task CustomerUpdateValidation(CustomerModel customerModel, CancellationToken cancellationToken);
}