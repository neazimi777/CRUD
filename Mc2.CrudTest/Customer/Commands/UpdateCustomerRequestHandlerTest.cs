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

namespace Mc2.CrudTest.UnitTest.Customer.Commands
{
    public class UpdateCustomerRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly UpdateCustomerDto _CustomerDto;
        private readonly Mock<ICustomerRepository> _mockCustomer;
        private readonly UpdateCustomerRequestHandler _handler;
        private readonly IMediator _mediator;
        public UpdateCustomerRequestHandlerTest(IMediator mediator)
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mediator = mediator;
            _mapper = mapperConfig.CreateMapper();
            _mockCustomer = MockCustomerRepository.CustomerRepository();
            _handler = new UpdateCustomerRequestHandler(_mockCustomer.Object, _mapper, _mediator);

            _CustomerDto = new UpdateCustomerDto
            {
                Id = 1,
                FirstName = "AliReza",
                LastName = "esfandiyar",
                Email = "Ali@gmail.com",
                PhoneNumber = "09125698189",
                BankAccountNumber = "12345678",
                DateOfBirth = DateOnly.Parse("1998/01/02")
            };
        }

        [Fact]
        public async Task Valid_Customer_Edited()
        {
            var result = await _handler.Handle(new DomainService.Customer.Requests.Commands.UpdateCustomerRequest(_CustomerDto), CancellationToken.None);

            var customers = await _mockCustomer.Object.GetAll();
            var newcustomers = await _mockCustomer.Object.Get(1);

            customers.Count.ShouldBe(2);
            result.ShouldBeOfType<BaseCommandResponse>();
            newcustomers.FirstName.ShouldBe("AliReza");

        }

        [Fact]
        public async Task InValid_Customer_Edited()
        {
            _CustomerDto.BankAccountNumber = "1";

            var result = await _handler.Handle(new DomainService.Customer.Requests.Commands.UpdateCustomerRequest(_CustomerDto), CancellationToken.None);

            var customers = await _mockCustomer.Object.GetAll();
            var newcustomers = await _mockCustomer.Object.Get(1);


            customers.Count.ShouldBe(2);
            result.ShouldBeOfType<BaseCommandResponse>();
            newcustomers.FirstName.ShouldBe("Ali");

        }

    }
}
