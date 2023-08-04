using Mc2.CrudTest.Dto.EventCustomer;
using MediatR;

namespace Mc2.CrudTest.DomainService.Customer.Requests.Commands
{
    public class CreateCustomerEventRequest : INotification
    {
        public CreateCustomerEventRequest(CreateCustomerEventDto createCustomerEventDto)
        {
            this.createCustomerEventDto = createCustomerEventDto;
        }

        public CreateCustomerEventDto createCustomerEventDto { get; set; }
    }
}
