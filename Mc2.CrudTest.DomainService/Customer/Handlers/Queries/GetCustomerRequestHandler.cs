using AutoMapper;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService.Customer.Requests.Queries;
using Mc2.CrudTest.Dto.Customer;
using MediatR;

namespace Mc2.CrudTest.DomainService.Customer.Handlers.Queries
{
    public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, GetCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerRequestHandler(
            ICustomerRepository customerRepository
            , IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<GetCustomerDto> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(request.Id);
            if (customer is null)
                throw new NotFoundException("Customer is not exist");
            var customerDto = _mapper.Map<GetCustomerDto>(customer);

            return customerDto;
        }
    }
}
