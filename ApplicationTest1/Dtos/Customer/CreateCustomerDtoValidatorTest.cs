using Application.DTOs.Customer.Entities;
using Application.DTOs.Customer.Validations;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;

namespace ApplicationTest.Dtos.Customer;

[TestFixture]
public class CreateCustomerDtoValidatorTest
{

    private DbContextOptions<CrudTestDbContext> options;
    private AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor;
    private CustomerRepository customerRepository ;
    private CrudTestDbContext crudTestDbContext;

    public static string CreateRandomString(int Length)
    {
        string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
        Random randNum = new Random();
        char[] chars = new char[Length];
        int allowedCharCount = _allowedChars.Length;

        for (int i = 0; i < Length; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }

        return new string(chars);
    }

    public static string CreateRandomStringWithNumber(int Length)
    {
        string _allowedChars = "0123456789";
        Random randNum = new Random();
        char[] chars = new char[Length];
        int allowedCharCount = _allowedChars.Length;

        for (int i = 0; i < Length; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }

        return new string(chars);
    }

    [SetUp]
    public void SetUp()
    {
        options=new DbContextOptionsBuilder<CrudTestDbContext>().UseInMemoryDatabase(databaseName: "CrudTestDb").Options;
        crudTestDbContext = new CrudTestDbContext(options,auditableEntitySaveChangesInterceptor);
        customerRepository =new CustomerRepository(crudTestDbContext);
        crudTestDbContext.Database.EnsureDeleted();

    }

    #region ValidateFirstName
    [Test]
    [TestCase(ExpectedResult = true)]
    public async Task<bool> CreateCustomer_FirstNameMustBeRequire_ReturnTrue()
    {
        //Arrange
        var Customer_One= new CreateCustomerDto
            ("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789");

        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    [Test]
    [TestCase(ExpectedResult = false)]
    public async Task<bool> CreateCustomer_FirstNameMustBeRequire_ReturnFalse()
    {
        //Arrange
        var Customer_One= new CreateCustomerDto("", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    [Test]
    [TestCase(ExpectedResult = false)]
    public async Task<bool> CreateCustomer_FirstNameMustBeMaximum50Char_ReturnFalse()
    {
        //Arrange
        string firstName = CreateRandomString(52);
        var Customer_One= new CreateCustomerDto(firstName, "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    #endregion

    #region ValidateLastName
    [Test]
    [TestCase(ExpectedResult = true)]
    public async Task<bool> CreateCustomer_LastNameMustBeRequire_ReturnTrue()
    {
        //Arrange
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    [Test]
    [TestCase(ExpectedResult = false)]
    public async Task<bool> CreateCustomer_LastNameMustBeRequire_ReturnFalse()
    {
        //Arrange
        var Customer_One= new CreateCustomerDto("Saeedeh", "", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    [Test]
    [TestCase(ExpectedResult = false)]
    public async Task<bool> CreateCustomer_LastNameMustBeMaximum50Char_ReturnFalse()
    {
        //Arrange
        string lastName = CreateRandomString(52);
        var Customer_One= new CreateCustomerDto("Saeedeh", lastName, DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    #endregion

    #region ValidateBirthday
    [Test]
    [TestCase(ExpectedResult = true)]
    public async Task<bool> CreateCustomer_BirthdayMustBeRequire_ReturnTrue()
    {
        //Arrange
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    [Test]
    [TestCase(ExpectedResult = "The customer infoes is repetitive.")]
    public async Task<string> CreateCustomer_FirStNameAndLastNameAndBirthDay_MustBeUnique()
    {
        //Arrange
        Domain.Entities.Customer customer = new Domain.Entities.Customer
            ("Sanaz", "Ashrafi", DateTime.Now.Date.AddYears(-35), 9365578320, "em@gmail.com", "123456789");

        await crudTestDbContext.Customers.AddAsync(customer);
        await crudTestDbContext.SaveChangesAsync();

        CreateCustomerDto Customer_with_repetitiveEmail = new CreateCustomerDto
            ("Sanaz", "Ashrafi", DateTime.Now.Date.AddYears(-35), 9365578320, "em@yahoo.com", "123456789");

        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_with_repetitiveEmail);

        //Assert
        return validationResult.Errors.FirstOrDefault() != null ? validationResult.Errors.FirstOrDefault().ErrorMessage : "";

    }

    #endregion

    #region ValidateBankAccountNumber
    [Test]
    [TestCase(ExpectedResult = true)]
    public async Task<bool> CreateCustomer_ValidateBankAccountNumber_ReturnTrue()
    {
        //Arrange
        string bankNumber = CreateRandomStringWithNumber(10);
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", bankNumber);
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    [Test]
    [TestCase(ExpectedResult = "The BankAccountNumber is required.")]
    public async Task<string> CreateCustomer_BankAccountNumberMustBeRequire_ReturnMessage()
    {
        //Arrange
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", "");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.Errors.FirstOrDefault() != null ? validationResult.Errors.FirstOrDefault().ErrorMessage : "";

    }

    [Test]
    [TestCase(ExpectedResult = "Bank account number can be just number and the length is between 9 to 18.")]
    public async Task<string> CreateCustomer_BankAccountNumberMustBeNumber_ReturnMessage()
    {
        //Arrange
        string bankNumber=CreateRandomString(10);
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", bankNumber);
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.Errors.FirstOrDefault() != null ? validationResult.Errors.FirstOrDefault().ErrorMessage : "";
    }

    [Test]
    [TestCase(ExpectedResult = "Bank account number can be just number and the length is between 9 to 18.")]
    public async Task<string> CreateCustomer_BankAccountNumberMustBeMaximum_18_ReturnMessage()
    {
        //Arrange
        string bankNumber = CreateRandomStringWithNumber(19);
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", bankNumber);
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.Errors.FirstOrDefault() != null ? validationResult.Errors.FirstOrDefault().ErrorMessage : "";

    }

    [Test]
    [TestCase(ExpectedResult = "Bank account number can be just number and the length is between 9 to 18.")]
    public async Task<string> CreateCustomer_BankAccountNumberMustBeMinimum_9_ReturnMessage()
    {
        //Arrange
        string bankNumber = CreateRandomStringWithNumber(8);
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, "saeedeh.saneei@gmail.com", bankNumber);
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.Errors.FirstOrDefault() != null ? validationResult.Errors.FirstOrDefault().ErrorMessage : "";

    }
    #endregion

    #region ValidateEmail
    [Test]
    [TestCase(ExpectedResult = true)]
    public async Task<bool> CreateCustomer_EmailMustBeRequire_ReturnTrue()
    {
        //Arrange
        string email = "saeedeh.saneei@gmail.com";
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, email, "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    [Test]
    [TestCase(ExpectedResult = "The Email address is required.")]
    public async Task<string> CreateCustomer_EmailMustBeRequire_ReturnMessage()
    {
        //Arrange
        string email = "";
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, email, "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.Errors.FirstOrDefault() != null ? validationResult.Errors.FirstOrDefault().ErrorMessage : "";
    }

    [Test]
    [TestCase(ExpectedResult = false)]
    public async Task<bool> CreateCustomer_EmailMustBeRequire_ReturnFalse()
    {
        //Arrange
        string email = "";
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, email, "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }
    

    [Test]
    [TestCase(ExpectedResult = false)]
    public async Task<bool> CreateCustomer_EmailMustBeMaximum100Char_ReturnFalse()
    {
        //Arrange
        string email = CreateRandomString(99)+"@gmail.com";
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, email, "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    [Test]
    [TestCase(ExpectedResult = false)]
    public async Task<bool> CreateCustomer_WrongEmailFormat_ReturnFalse()
    {
        //Arrange
        string email = "wrongFormat.gmail";
        var Customer_One= new CreateCustomerDto("Saeedeh", "Saneei", DateTime.Now.Date.AddYears(-35), 9365578320, email, "123456789");
        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_One);

        //Assert
        return validationResult.IsValid;
    }

    [Test]
    [TestCase(ExpectedResult = "The email address is repetitive.")]    
    public async Task<string> CreateCustomer_EmailMustBeUnique_ReturnMessage()
    {
        //Arrange
        string email = "repetitive@gmail.com";
        Domain.Entities.Customer customer = new Domain.Entities.Customer
            ("Arezoo", "khandan", DateTime.Now.Date.AddYears(-35), 9365578320, email, "123456789");

        await crudTestDbContext.Customers.AddAsync(customer);
        await crudTestDbContext.SaveChangesAsync();

        CreateCustomerDto Customer_with_repetitiveEmail = new CreateCustomerDto
            ("Saeed", "Naseri", DateTime.Now.Date.AddYears(-35), 9365578320, email, "123456789");

        var validator = new CreateCustomerDtoValidator(customerRepository);

        //Act
        var validationResult = await validator.ValidateAsync(Customer_with_repetitiveEmail);

        //Assert
        return validationResult.Errors.FirstOrDefault() != null ? validationResult.Errors.FirstOrDefault().ErrorMessage : "";

    }
    #endregion
}
