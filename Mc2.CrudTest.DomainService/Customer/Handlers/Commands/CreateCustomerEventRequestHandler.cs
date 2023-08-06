using AutoMapper;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService.Customer.Requests.Commands;
using MediatR;

namespace Mc2.CrudTest.DomainService.Customer.Handlers.Commands
{
    public class CreateCustomerEventRequestHandler : INotificationHandler<CreateCustomerEventRequest>
    {
        private readonly ICustomerEventRepository _customerEventRepository;
        private readonly IMapper _mapper;
        public CreateCustomerEventRequestHandler(ICustomerEventRepository customerEventRepository, IMapper mapper)
        {
            _customerEventRepository = customerEventRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreateCustomerEventRequest notification, CancellationToken cancellationToken)
        {
            var customerEvent = _mapper.Map<CustomerEvent>(notification.createCustomerEventDto);
            customerEvent.DateOfBirth = DateTime.Parse(notification.createCustomerEventDto.DateOfBirth);
            await _customerEventRepository.Add(customerEvent);
            await _customerEventRepository.SaveAsync();

        }
    }
}
