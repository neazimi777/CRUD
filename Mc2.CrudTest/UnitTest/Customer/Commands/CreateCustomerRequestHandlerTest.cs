using AutoMapper;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService;
using Mc2.CrudTest.DomainService.Customer.Handlers.Commands;
using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.Customer;
using Mc2.CrudTest.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;

namespace Mc2.CrudTest.Test.UnitTest.Customer.Commands
{
    public class CreateCustomerRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly CreateCustomerDto _CustomerDto;
        private readonly Mock<ICustomerRepository> _mockCustomer;
        private readonly CreateCustomerRequestHandler _handler;
        private readonly Mock<IMediator> _mediator;
        public CreateCustomerRequestHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mediator = new Mock<IMediator>();
            _mapper = mapperConfig.CreateMapper();
            _mockCustomer = MockCustomerRepository.CustomerRepository();
            _handler = new CreateCustomerRequestHandler(_mockCustomer.Object, _mapper, _mediator.Object);

            _CustomerDto = new CreateCustomerDto
            {
                FirstName = "Test",
                LastName = "TestLastName",
                Email = "Test@gmail.com",
                BankAccountNumber = "45679945",
                DateOfBirth = "1988/01/02",
                PhoneNumber = "+989123456789"
            };
        }

        [Fact]
        public async Task Valid_Customer_Added()
        {
            var result = await _handler.Handle(new DomainService.Customer.Requests.Commands.CreateCustomerRequest(_CustomerDto), CancellationToken.None);

            var customers = await _mockCustomer.Object.GetAll();

            customers.Count.ShouldBe(3);
            result.ShouldBeOfType<BaseCommandResponse>();


        }

        [Fact]
        public async Task InValid_Customer_Added()
        {
            _CustomerDto.BankAccountNumber = "1";

            var result = await _handler.Handle(new DomainService.Customer.Requests.Commands.CreateCustomerRequest(_CustomerDto), CancellationToken.None);

            result.Success.ShouldBeFalse();
        }
    }
}
