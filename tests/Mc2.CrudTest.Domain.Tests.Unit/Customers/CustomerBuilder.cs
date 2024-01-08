
using Mc2.CrudTest.Domain.Models.Customers;
using Mc2.CrudTest.Domain.Services;
using Mc2.Framework.Domain.Events;
using System.Net.Mail;
using Mc2.Framework.Domain.Utils;

namespace Mc2.CrudTest.Domain.Tests.Unit.Customers;

using AutoFixture;
using Moq;

public class
    CustomerBuilder(ICustomerDomainService domainService, IClock clock, IEventPublisher publisher)
{
    private static Fixture _fixture = new Fixture();

    public CustomerId CustomerId { get; private set; } = _fixture.Create<CustomerId>();
    public string Firstname { get;private set; } = _fixture.Create<string>();
    public string Lastname { get;private set; } = _fixture.Create<string>();
    public DateTime DateOfBirth { get;private set; } = _fixture.Create<DateTime>();
    public string PhoneNumber { get;private set; } = _fixture.Create<string>();
    public string Email { get;private set; } = _fixture.Create<MailAddress>().ToString();
    public string BankAccountNumber { get;private set; } = _fixture.Create<string>();

    public long UserId { get;private set; } = _fixture.Create<long>();
    public ICustomerDomainService DomainService { get;private set; } = domainService;
    public IClock Clock { get;private set; } = clock;
    public IEventPublisher Publisher { get;private set; } = publisher;
    
    
    public CustomerBuilder WithFirstName(string firstName)
    {
        Firstname = firstName;
        return this;
    }

    public CustomerBuilder WithLastName(string lastName)
    {
        Lastname = lastName;
        return this;
    }

    public CustomerBuilder WithDateOfBirth(DateTime dateOfBirth)
    {
        DateOfBirth = dateOfBirth;
        return this;
    }

    public CustomerBuilder WithPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return this;
    }

    public CustomerBuilder WithEmail(string email)
    {
        Email = email;
        return this;
    }

    public CustomerBuilder WithBankAccountNumber(string bankAccountNumber)
    {
        BankAccountNumber = bankAccountNumber;
        return this;
    }

    public CustomerBuilder WithDomainService(ICustomerDomainService domainService)
    {
        DomainService = domainService;
        return this;
    }
    
    public CustomerBuilder WithClock(IClock clock)
    {
        Clock = clock;
        return this;
    }
    
    public CustomerBuilder WithEventPublisher(IEventPublisher eventPublisher)
    {
        Publisher = eventPublisher;
        return this;
    }
    

    public Customer Build()
    {
        return new Customer(CustomerId, Firstname, Lastname, DateOfBirth, PhoneNumber, Email, BankAccountNumber,
            DomainService, Clock, Publisher, UserId);
    }
}