using AutoMapper;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService.Customer.Requests.Commands;
using Mc2.CrudTest.DomainService.Extention;
using Mc2.CrudTest.DomainService.Validations;
using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.EventCustomer;
using MediatR;

namespace Mc2.CrudTest.DomainService.Customer.Handlers.Commands
{
    public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, BaseCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateCustomerRequestHandler(
            ICustomerRepository customerRepository,
             IMapper mapper,
             IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<BaseCommandResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var transaction = await _customerRepository.BeginTransaction();
            try
            {
                var validator = new CreateValidationCustomer();
                var validationResult = await validator.ValidateAsync(request.createCustomerDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                    throw new Domain.Exceptions.ValidationException("Validation error");
                }

                var customer = _mapper.Map<Domain.Customer>(request.createCustomerDto);
                customer.DateOfBirth = DateTime.Parse(request.createCustomerDto.DateOfBirth);
                customer.CheckDuplicate = StringExtension.ToHash(request.createCustomerDto.FirstName, request.createCustomerDto.LastName, request.createCustomerDto.DateOfBirth);
                customer.CreateTime = DateTime.Now;
                customer.IsActive = true;

                await _customerRepository.Add(customer);
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
                    CreateTime = customer.CreateTime
                };
                await _mediator.Publish(new CreateCustomerEventRequest(customerEvent));

                transaction.Commit();
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                response.Success = false;
                response.Message = "Creation Failed";
            }
            return response;
        }
    }
}
