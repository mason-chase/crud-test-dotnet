namespace Mc2.CrudTest.Application.Services
{
    public interface ICustomerReadService
    {
        Task<bool> Exists(string firstName, string lastName, DateOnly birthday);
        Task<bool> Exists(string email, Guid id);
    }
}
