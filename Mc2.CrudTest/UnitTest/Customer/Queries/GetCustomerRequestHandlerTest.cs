using AutoMapper;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService;
using Mc2.CrudTest.DomainService.Customer.Handlers.Queries;
using Mc2.CrudTest.DomainService.Customer.Requests.Queries;
using Mc2.CrudTest.Dto.Customer;
using Mc2.CrudTest.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace Mc2.CrudTest.Test.UnitTest.Customer.Queries
{
    public class GetCustomerRequestHandlerTest
    {
        private readonly GetCustomerRequestHandler _handler;
        private int _response;
        private readonly Mock<ICustomerRepository> _mockCustomer;
        private readonly IMapper _mapper;
        public GetCustomerRequestHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _mockCustomer = MockCustomerRepository.CustomerRepository();

            _handler = new GetCustomerRequestHandler(_mockCustomer.Object, _mapper);
        }

        [Fact]
        public async Task Valid_Customer_Get()
        {
            _response = 1;
            var result = await _handler.Handle(new GetCustomerRequest(_response), CancellationToken.None);
            result.ShouldBeOfType<GetCustomerDto>();

        }

    }
}
