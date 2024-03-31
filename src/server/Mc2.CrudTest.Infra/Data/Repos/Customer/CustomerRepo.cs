using Mc2.CrudTest.Domain.IRepos.Customer;

namespace Mc2.CrudTest.Infra.Data.Repos.Customer;

public class CustomerRepo : Repo<Domain.Entities.Customer>, ICustomerRepo
{
    public CustomerRepo(ApplicationDbContext context) : base(context)
    {
    }
}