using Mc2.CrudTest.Dto.Customer;
using MediatR;

namespace Mc2.CrudTest.DomainService.Customer.Requests.Queries
{
    public class GetCustomerRequest : IRequest<GetCustomerDto>
    {
        public GetCustomerRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
