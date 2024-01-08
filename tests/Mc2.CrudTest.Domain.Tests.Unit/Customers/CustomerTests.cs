using FluentAssertions;
using Mc2.CrudTest.Domain.Contracts.Events.Customer;
using Mc2.CrudTest.Domain.Models.Customers;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Domain.Services;
using Mc2.CrudTest.Tests.Utils.Stubs;
using Mc2.Framework.Domain.Utils;
using Mc2.Framework.TestDoubles;
using Moq;

namespace Mc2.CrudTest.Domain.Tests.Unit.Customers;

public class CustomerTests
{
    private Mock<ICustomerDomainService> _customerDomainServiceMock;
    private IClock _clock;
    private FakeEventPublisher _eventPublisher;
    private CustomerBuilder _customerBuilder;

    public CustomerTests()
    {
        _customerDomainServiceMock = new Mock<ICustomerDomainService>();
        _clock = new ClockStub();
        _eventPublisher = new();
        _customerBuilder = new CustomerBuilder(_customerDomainServiceMock.Object, _clock, _eventPublisher);
    }

    [Fact]
    public void Instantiating_InputPropsAreValid_ShouldConcreteProperly()
    {
        //arrange
        _customerDomainServiceMock.Setup(c => c.EmailIsUnique(_customerBuilder.Email)).Returns(true);

        //act
        Customer customer = _customerBuilder.Build();

        //assert
        customer.EntityId.Should().Be(_customerBuilder.CustomerId);
        customer.Firstname.Should().Be(_customerBuilder.Firstname);
        customer.Lastname.Should().Be(_customerBuilder.Lastname);
        customer.DateOfBirth.Should().Be(_customerBuilder.DateOfBirth);
        customer.PhoneNumber.Should().Be(_customerBuilder.PhoneNumber);
        customer.Email.Should().Be(_customerBuilder.Email);
        customer.BankAccountNumber.Should().Be(_customerBuilder.BankAccountNumber);
    }

    [Fact]
    public void Instantiating_InputPropsAreValid_ShouldPublishTheCorrectEvent()
    {
        //arrange
        var cb = _customerBuilder;
        var expectedEvent = new CustomerCreated(cb.CustomerId.Id, cb.Firstname, cb.Lastname, cb.DateOfBirth,
            cb.PhoneNumber, cb.Email, cb.BankAccountNumber);
        _customerDomainServiceMock.Setup(c => c.EmailIsUnique(_customerBuilder.Email)).Returns(true);

        //act
        Customer customer = _customerBuilder.Build();

        //assert
        _eventPublisher.GetPublishedEvents().Count.Should().Be(1);
        _eventPublisher.GetLastEvent<CustomerCreated>().Should().BeEquivalentTo(expectedEvent,
            options => 
                options.Excluding(cc => cc.EventId)
                       .Excluding(cc => cc.PublishDateTime));
    }
    
    [Fact]
    public void Instantiating_EmailIsNotUnique_ShouldThrowException()
    {
        //arrange
        bool emailIsUnique = false;
        _customerDomainServiceMock.Setup(c => c.EmailIsUnique(_customerBuilder.Email)).Returns(emailIsUnique);

        //act
        Action act = () =>  _customerBuilder.Build();
        
        //assert
        act.Should().ThrowExactly<EmailIsNotUniqueException>();
    }
}