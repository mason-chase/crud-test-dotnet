using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Application.QueryHandlers;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.GetCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Exceptions;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;
using NSubstitute;

namespace Mc2.CrudTest.Modules.Customers.Tests.QueryHandlersTests;

public class GetCustomerHandlerTests
{
    private IReadModelRepository<CustomerDto> _repository = Substitute.For<IReadModelRepository<CustomerDto>>();
    private GetCustomerHandler Sut => new GetCustomerHandler(_repository);

    private readonly GetCustomerQuery _query;

    public GetCustomerHandlerTests()
    {
        _query = new GetCustomerQuery(1);
    }

    [Fact]
    public async Task Handle_should_throw_CustomerNotFoundException_when_Customer_is_not_found()
    {
        // Arrange
        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
            .Returns((CustomerDto?)null);

        // Act
        var customerId = async () => await Sut.Handle(_query, CancellationToken.None);

        // Assert
        await customerId.Should().ThrowAsync<CustomerNotFoundException>();
        await _repository.Received(1).GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_should_cause_Updating_Customer_in_Repository_and_Committing_Events()
    {
        // Arrange
        var expectedDto = new CustomerDto
        {
            Id = 1,
            FirstName = "John",
        };
        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
            .Returns(expectedDto);

        // Act
        var dto = await Sut.Handle(_query, CancellationToken.None);

        // Assert
        await _repository.Received(1).GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>());
        dto.Should().Be(expectedDto);
    }
}