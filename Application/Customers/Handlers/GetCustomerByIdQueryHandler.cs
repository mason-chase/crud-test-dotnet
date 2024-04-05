using Application.Customers.Queries;
using Core.Interfaces;
using Core.Models;
using MediatR;

namespace Application.Customers.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CustomerRepository.FindById(request.Id);
        }
    }
}
