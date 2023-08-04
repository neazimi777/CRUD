using Mc2.CrudTest.Dto;
using MediatR;

namespace Mc2.CrudTest.DomainService.Customer.Requests.Commands
{
    public class DeleteCustomerRequest : IRequest<BaseCommandResponse>
    {
        public DeleteCustomerRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
