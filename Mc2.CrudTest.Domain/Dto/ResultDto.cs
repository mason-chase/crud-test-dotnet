namespace Mc2.CrudTest.Application.Services.Customers.Command.RegisterCustomer
{
    public class ResultDto<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
