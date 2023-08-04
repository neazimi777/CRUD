using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.Customer;
using MediatR;

namespace Mc2.CrudTest.DomainService.Customer.Requests.Commands
{
    public class CreateCustomerRequest:IRequest<BaseCommandResponse>
    {
       public CreateCustomerRequest(CreateCustomerDto createCustomerDto)
        {
            this.createCustomerDto = createCustomerDto;
        }

        public CreateCustomerDto createCustomerDto { get; set; }
    }
}
