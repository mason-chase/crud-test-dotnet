using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FluentAssertions;
using Mc2.CrudTest.EndToEndTests.Utils;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.GetCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Presentation.Server.ExceptionHandlers;
using Mc2.CrudTest.Presentation.Server.Models.Requests;
using Mc2.CrudTest.Shared.DataStore;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Mc2.CrudTest.EndToEndTests.ControllersTests;

public class CustomersControllerTests
{
    public class Post : TestWebAppFactory
    {
        [Fact]
        public async Task should_return_Created_when_Customer_is_Created()
        {
            // Assert
            Name firstName = Name.Create("John");
            Name lastName = Name.Create("Doe");
            DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
            Phone phoneNumber = Phone.Create("+905317251106");
            Email email = Email.Create("arash@shabbhe.com");
            BankAccountNumber bankAccountNumber = BankAccountNumber.Create("1234567890");

            using HttpClient client = CreateClient();

            // Act
            using HttpResponseMessage response = await client.PostAsJsonAsync("/api/customers/index", new CreateCustomerRequested
            {
                FirstName = firstName.Value,
                LastName = lastName.Value,
                DateOfBirth = dateOfBirth,
                PhoneNumber = $"+{phoneNumber.Value.ToString()}",
                Email = email.Value,
                BankAccountNumber = bankAccountNumber.Value
            });

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            string json = await response.Content.ReadAsStringAsync();
            json.Should().NotBeNullOrEmpty();

            CreateCustomerRequestedResponse? result = JsonSerializer.Deserialize<CreateCustomerRequestedResponse>(json);
            result.Should().NotBeNull();
            result.CustomerId.Should().BeGreaterThan(0);
        }
    }

    public class Put : TestWebAppFactory
    {
        [Fact]
        public async Task should_return_NoContent_when_Customer_is_Updated()
        {
            // Assert
            // Assert
            Name firstName = Name.Create("John");
            Name lastName = Name.Create("Doe");
            DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
            Phone phoneNumber = Phone.Create("+905317251106");
            Email email = Email.Create("arash@shabbhe.com");
            BankAccountNumber bankAccountNumber = BankAccountNumber.Create("1234567890");
            Customer customer = Customer.Create(new CustomerCreatedEvent(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

            await using AsyncServiceScope scope = RootServiceProvider.CreateAsyncScope();
            AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            customer = dbContext.Customers.Add(customer).Entity;
            await dbContext.SaveChangesAsync();

            using HttpClient client = CreateClient();

            // Act
            string newFirstName = "Arash";
            using HttpResponseMessage response = await client.PutAsJsonAsync("/api/customers/index", new UpdateCustomerRequested
            {
                CustomerId = customer.Id,
                FirstName = newFirstName,
                LastName = lastName.Value,
                DateOfBirth = dateOfBirth,
                PhoneNumber = $"+{phoneNumber.Value.ToString()}",
                Email = email.Value,
                BankAccountNumber = bankAccountNumber.Value
            });

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            string json = await response.Content.ReadAsStringAsync();
            json.Should().BeNullOrEmpty();
        }
    }

    public class Delete : TestWebAppFactory
    {
        [Fact]
        public async Task should_return_NoContext_when_Customer_is_Deleted()
        {
            // Assert
            Name firstName = Name.Create("John");
            Name lastName = Name.Create("Doe");
            DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
            Phone phoneNumber = Phone.Create("+905317251106");
            Email email = Email.Create("arash@shabbhe.com");
            BankAccountNumber bankAccountNumber = BankAccountNumber.Create("1234567890");
            Customer customer = Customer.Create(new CustomerCreatedEvent(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

            await using AsyncServiceScope scope = RootServiceProvider.CreateAsyncScope();
            AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            customer = dbContext.Customers.Add(customer).Entity;
            await dbContext.SaveChangesAsync();

            using HttpClient client = CreateClient();

            // Act
            using HttpResponseMessage response = await client.DeleteAsync($"/api/customers/index?id={customer.Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            string json = await response.Content.ReadAsStringAsync();
            json.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task should_return_NotFound_when_Customer_not_found_to_Delete()
        {
            // Arrange
            using HttpClient client = CreateClient();

            // Act
            using HttpResponseMessage response = await client.DeleteAsync("/api/customers/index?id=1");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            string json = await response.Content.ReadAsStringAsync();
            json.Should().NotBeNullOrEmpty();

            ResponseFailed? result = JsonSerializer.Deserialize<ResponseFailed>(json);
            result.Should().NotBeNull();
        }
    }

    public class Get : TestWebAppFactory
    {
        [Fact]
        public async Task should_return_OK_when_getting_current_Customer()
        {
            // Assert
            Name firstName = Name.Create("John");
            Name lastName = Name.Create("Doe");
            DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
            Phone phoneNumber = Phone.Create("+905317251106");
            Email email = Email.Create("arash@shabbhe.com");
            BankAccountNumber bankAccountNumber = BankAccountNumber.Create("1234567890");
            Customer customer = Customer.Create(new CustomerCreatedEvent(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

            await using AsyncServiceScope scope = RootServiceProvider.CreateAsyncScope();
            AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            customer = dbContext.Customers.Add(customer).Entity;
            await dbContext.SaveChangesAsync();

            using HttpClient client = CreateClient();

            // Act
            using HttpResponseMessage response = await client.GetAsync($"/api/customers/index?id={customer.Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string json = await response.Content.ReadAsStringAsync();
            json.Should().NotBeNullOrEmpty();

            CustomerDto? result = JsonSerializer.Deserialize<CustomerDto>(json);
            result.Should().NotBeNull();
            result.FirstName.Should().Be(firstName.Value);
            result.LastName.Should().Be(lastName.Value);
            result.DateOfBirth.Should().Be(dateOfBirth.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc));
            result.PhoneNumber.Should().Be($"+{phoneNumber.Value.ToString()}");
            result.Email.Should().Be(email.Value);
            result.BankAccountNumber.Should().Be(bankAccountNumber.Value);
        }

        [Fact]
        public async Task should_return_NotFound_when_getting_non_existing_Customer()
        {
            // Arrange
            using HttpClient client = CreateClient();

            // Act
            using HttpResponseMessage response = await client.GetAsync("/api/customers/index?id=1");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            string json = await response.Content.ReadAsStringAsync();
            json.Should().NotBeNullOrEmpty();

            ResponseFailed? result = JsonSerializer.Deserialize<ResponseFailed>(json);
            result.Should().NotBeNull();
        }
    }
}