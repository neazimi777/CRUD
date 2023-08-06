using AutoMapper;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService;
using Mc2.CrudTest.DomainService.Customer.Handlers.Commands;
using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.Customer;
using Mc2.CrudTest.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;

namespace Mc2.CrudTest.Test.UnitTest.Customer.Commands
{
    public class DeleteCustomerRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockCustomer;
        private readonly DeleteCustomerRequestHandler _handler;
        private readonly Mock<IMediator> _mediator;
        public DeleteCustomerRequestHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mediator = new Mock<IMediator>();
            _mapper = mapperConfig.CreateMapper();
            _mockCustomer = MockCustomerRepository.CustomerRepository();
            _handler = new DeleteCustomerRequestHandler(_mockCustomer.Object, _mapper, _mediator.Object);

        }
        [Fact]
        public async Task Valid_Customer_Delete()
        {
            var result = await _handler.Handle(new DomainService.Customer.Requests.Commands.DeleteCustomerRequest(1), CancellationToken.None);
            var Deletecustomers = await _mockCustomer.Object.Get(1);

            result.ShouldBeOfType<BaseCommandResponse>();
            Deletecustomers.IsActive.ShouldBeFalse();

        }

    }
}

