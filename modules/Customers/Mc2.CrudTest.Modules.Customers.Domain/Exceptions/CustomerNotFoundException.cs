using Mc2.CrudTest.Shared.BuildingBlocks.Exceptions;

namespace Mc2.CrudTest.Modules.Customers.Domain.Exceptions;

public class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException(int customerId) : base($"Customer {customerId} not found")
    {
        CustomerId = customerId;
    }

    public int CustomerId { get; }
}