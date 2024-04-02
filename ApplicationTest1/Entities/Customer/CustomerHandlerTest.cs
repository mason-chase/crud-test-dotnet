
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Tools;
using Application.Entities.Customer.Handlers.Commands;
using AutoMapper;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using Application.Entities.Customer.Requests.Commands;
using Application.DTOs.Customer.Entities;
using NUnit.Framework.Internal;
using Application.Commom.Models;
using Application.Common.Mappings;

namespace Application.Test.Entities.Customer;

[TestFixture]
public class CustomerHandlerTest
{
    private Mapper mapper;

    private DbContextOptions<CrudTestDbContext> options;
    private AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor;
    private CrudTestDbContext crudTestDbContext;

    private CustomerRepository customerRepository;
    private UnitOfWork unitOfWork;


    [SetUp]
    public void Setup()
    {
        options = new DbContextOptionsBuilder<CrudTestDbContext>().UseInMemoryDatabase(databaseName: "CrudTestDb").Options;
        crudTestDbContext = new CrudTestDbContext(options, auditableEntitySaveChangesInterceptor);
        customerRepository = new CustomerRepository(crudTestDbContext);
        unitOfWork = new UnitOfWork(crudTestDbContext);

        //For IMapper
        var myProfile = new MappingProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        mapper = new Mapper(configuration);

        crudTestDbContext.Database.EnsureDeleted();
    }

    [Test]
    public async Task CreateCustomerHandler_ReturnCustomerId()
    {
        //Arrange
        var command = new CreateCustomerCommand { CreateCustomerDto = new CreateCustomerDto
            ("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789")
        };
        CreateCustomerHandler createCustomerHandler = new CreateCustomerHandler(mapper, customerRepository, unitOfWork);

        //Act
        Result<int> result= await createCustomerHandler.Handle(command, new CancellationToken());

        //Assert
        Assert.That(result.Value, Is.EqualTo(1));
    }

    [Test]
    public async Task UpdateCustomerHandler_ReturnTrue()
    {
        //Arrange
        Domain.Entities.Customer customer = new Domain.Entities.Customer
            ("Arezoo", "khandan", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789");

        await crudTestDbContext.Customers.AddAsync(customer);
        await crudTestDbContext.SaveChangesAsync();

        var command = new UpdateCustomerCommand
        {
            UpdateCustomerDto = new UpdateCustomerDto
            (customer.Id, "SaeedehUpdate", "SaneeiUpdate", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedehUpdate.saneei@gmail.com", "123456789")
        };
        UpdateCustomerHandler UpdateCustomerHandler = new UpdateCustomerHandler(mapper, customerRepository, unitOfWork);

        //Act
        Result<bool> result = await UpdateCustomerHandler.Handle(command, new CancellationToken());

        //Assert
        Assert.That(result.Value, Is.EqualTo(true));
    }

    [Test]
    public async Task DeleteCustomerHandler_ReturnTrue()
    {
        //Arrange
        Domain.Entities.Customer customer = new Domain.Entities.Customer
            ("Arezoo", "khandan", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789");

        await crudTestDbContext.Customers.AddAsync(customer);
        await crudTestDbContext.SaveChangesAsync();

        var command = new DeleteCustomerCommand { Id = customer.Id };
        DeleteCustomerHandler DeleteCustomerHandler = new DeleteCustomerHandler(customerRepository, unitOfWork);

        //Act
        Result<bool> result = await DeleteCustomerHandler.Handle(command, new CancellationToken());

        //Assert
        Assert.That(result.Value, Is.EqualTo(true));
    }
}
