using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.Customer;
using MediatR;

namespace Mc2.CrudTest.DomainService.Customer.Requests.Commands
{
    public class UpdateCustomerRequest : IRequest<BaseCommandResponse>
    {
        public UpdateCustomerRequest(UpdateCustomerDto updateCustomerDto)
        {
            this.updateCustomerDto = updateCustomerDto;
        }
        public UpdateCustomerDto updateCustomerDto { get; set; }
    }
}
