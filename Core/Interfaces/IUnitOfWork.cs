namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICustomerRepository CustomerRepository { get; }
        void SaveChanges();
    }
}
