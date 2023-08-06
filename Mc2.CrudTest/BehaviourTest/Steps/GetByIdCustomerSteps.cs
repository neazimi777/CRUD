using AutoMapper;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService;
using Mc2.CrudTest.DomainService.Customer.Handlers.Commands;
using Mc2.CrudTest.DomainService.Customer.Handlers.Queries;
using Mc2.CrudTest.DomainService.Customer.Requests.Commands;
using Mc2.CrudTest.DomainService.Customer.Requests.Queries;
using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.Customer;
using Mc2.CrudTest.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System.Reflection.Metadata;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.BehaviourTest.Steps
{
    [Binding]
    public class GetCustomerSteps
    {
        private readonly GetCustomerRequestHandler _handler;
        private GetCustomerDto _response;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ICustomerRepository> _mockCustomer;
        private readonly IMapper _mapper;
        private  int _request;
        public GetCustomerSteps()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mediator = new Mock<IMediator>();
            _mapper = mapperConfig.CreateMapper();
            _mockCustomer = MockCustomerRepository.CustomerRepository();

            _handler = new GetCustomerRequestHandler(_mockCustomer.Object, _mapper);
        }

        [Given(@"a customer with ID (.*) exists")]
        public void GivenACustomerWithIDExists(int customerId)
        {
            _request = customerId;
        }

        [When(@"I request the customer with ID (.*)")]
        public async Task WhenIRequestTheCustomerWithID(int customerId)
        {
            _response = await _handler.Handle(new GetCustomerRequest(_request), CancellationToken.None);
        }

        [Then(@"the customer information should be returned")]
        public void ThenTheCustomerInformationShouldBeReturned()
        {
            Assert.NotNull(_response);
        }
    }
}