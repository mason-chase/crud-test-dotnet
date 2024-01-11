using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mc2.CrudTest.Infrastructure.Query.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomersView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                CREATE VIEW [dbo].[CustomersView]
                WITH SCHEMABINDING
                AS
                SELECT [Id], [Firstname], [Lastname], [Firstname] + ' ' + [Lastname] AS [Fullname], [DateOfBirth], [PhoneNumber], [Email], [BankAccountNumber]
                FROM [dbo].[Customers];");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP VIEW [dbo].[CustomersView];");
        }
    }
}
