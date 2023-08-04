using AutoMapper;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService.Customer.Requests.Commands;
using Mc2.CrudTest.DomainService.Extention;
using Mc2.CrudTest.DomainService.Validations;
using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.EventCustomer;
using MediatR;
using XAct;
using XAct.Messages;

namespace Mc2.CrudTest.DomainService.Customer.Handlers.Commands
{
    public class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest, BaseCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateCustomerRequestHandler(
            ICustomerRepository customerRepository
            , IMapper mapper,
             IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<BaseCommandResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var transaction = await _customerRepository.BeginTransaction();
            try
            {
                var validator = new UpdateValidationCustomer();
                var validationResult = await validator.ValidateAsync(request.updateCustomerDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Edit Failed";
                }

                var specificCustomer = await _customerRepository.Get(request.updateCustomerDto.Id);

                if (specificCustomer is null)
                    throw new NotFoundException("Customer is not exist");


                var customer = _mapper.Map(request.updateCustomerDto, specificCustomer);
                customer.CheckDuplicate.ToHash(request.updateCustomerDto.FirstName, request.updateCustomerDto.LastName, request.updateCustomerDto.DateOfBirth);
                customer.LastModificationTime = DateTime.Now;

                _customerRepository.Update(customer);
                await _customerRepository.SaveAsync();

                var customerEvent = new CreateCustomerEventDto
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
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
                response.Message = "Edit Failed";
            }
            return response;

        }
    }
}
