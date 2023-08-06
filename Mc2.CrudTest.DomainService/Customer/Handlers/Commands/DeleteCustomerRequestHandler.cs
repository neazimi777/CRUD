using AutoMapper;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService.Customer.Requests.Commands;
using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.Customer;
using Mc2.CrudTest.Dto.EventCustomer;
using MediatR;

namespace Mc2.CrudTest.DomainService.Customer.Handlers.Commands
{
    public class DeleteCustomerRequestHandler : IRequestHandler<DeleteCustomerRequest, BaseCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteCustomerRequestHandler(
            ICustomerRepository customerRepository
            , IMapper mapper,
             IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<BaseCommandResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var transaction = await _customerRepository.BeginTransaction();
            try
            {
                var customer = await _customerRepository.Get(request.Id);

                if (customer is null)
                    throw new NotFoundException("Customer is not exist");

                customer.IsActive = false;
                customer.LastModificationTime = DateTime.Now;
                _customerRepository.Update(customer);
                await _customerRepository.SaveAsync();

                var customerEvent = new CreateCustomerEventDto
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth.ToString(),
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    BankAccountNumber = customer.BankAccountNumber,
                    IsActive = customer.IsActive,
                    CreateTime = customer.LastModificationTime
                };
                await _mediator.Publish(new CreateCustomerEventRequest(customerEvent));

                transaction.Commit();
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                response.Success = false;
                response.Message = "Delete Failed ";
            }
            return response;

        }
    }
}
