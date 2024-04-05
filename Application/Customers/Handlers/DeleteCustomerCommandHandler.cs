using Application.Customers.Commands;
using Core.Interfaces;
using MediatR;

namespace Application.Customers.Handlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, (bool, string)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(bool, string)> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CustomerRepository.Delete(request.Id);

            return result.Item1 ? (true, result.Item2) : (false, result.Item2);
        }
    }
}
