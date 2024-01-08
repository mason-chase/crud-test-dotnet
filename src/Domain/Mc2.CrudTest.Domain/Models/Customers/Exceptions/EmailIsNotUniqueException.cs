
namespace Mc2.CrudTest.Domain.Models.Customers.Exceptions;

public class EmailIsNotUniqueException(string email) : Exception(email);