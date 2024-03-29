using Mc2.CrudTest.Application.UseCases.Customer.Comands;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.IRepos.Customer;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.Data.Repos.Customer;

public class CustomerRepo : Repo<Domain.Entities.Customer>, ICustomerRepo
{
    public CustomerRepo(ApplicationDbContext context) : base(context)
    {
    }
}