namespace Hamideh.Crud.Test.Application.CustomerFeatures.Queries.FindCustomerById
{
    public record GetCustomerByIdQueryResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
