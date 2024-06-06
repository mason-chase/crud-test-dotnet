namespace Hamideh.Crud.Test.Application.CustomerFeatures.Queries.GetCustomerList
{
    public record GetCustomerListQueryResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
