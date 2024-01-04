
using Dapper;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Core.Domain.Customers.Dtoes;
using Mc2.CrudTest.Core.Domain.Customers.Queries;
using Microsoft.Data.SqlClient;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Customers
{
    public class CustomerQueryRespository : ICustomerQueryRepository
    {
        private readonly SqlConnection _sqlConnection;

        public CustomerQueryRespository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<CustomerSummary> Query(GetAllCustomersQuery query)
        {
            string sqlQuery = "Select a.Id as 'CustomerId'," +
                              " a.FirstName, a.LastName, a.Email, a.PhoneNumber " +
                              " FROM Customers a " +
                              " Order By a.FirstName";

            var customers = _sqlConnection.Query<CustomerSummary>(sqlQuery);

            return customers.ToList();
        }

        public CustomerSummary Query(GetCustomerByIdQuery query)
        {
            string sqlQuery = "Select top 1 a.Id as 'CustomerId'," +
                              " a.FirstName, a.LastName, a.Email, a.PhoneNumber " +
                              " FROM Customers a " +
                              " Where a.Id = @CustomerId " +
                              " Order By a.FirstName";

            return _sqlConnection.QuerySingleOrDefault<CustomerSummary>(sqlQuery, new { query.CustomerId });
        }

    }
}
