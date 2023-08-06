using AutoMapper;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.DomainService;
using Mc2.CrudTest.DomainService.Customer.Handlers.Commands;
using Mc2.CrudTest.DomainService.Customer.Requests.Commands;
using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.Customer;
using Mc2.CrudTest.UnitTest.Mocks;
using MediatR;
using Moq;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.BehaviourTest.Steps
{
    [Binding]
    public class DeleteCustomerSteps
    {
        private readonly DeleteCustomerRequestHandler _handler;
        private BaseCommandResponse _response;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ICustomerRepository> _mockCustomer;
        private readonly IMapper _mapper;
        private  Customer _customer;
        public DeleteCustomerSteps()
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

        [Given(@"a customer for delete with ID (.*) exists")]
        public void GivenACustomerWithIDExists(int customerId)
        {
            _customer = new Customer { Id = customerId, IsActive = true };
        }

        [When(@"I delete the customer with ID (.*)")]
        public async Task WhenIDeleteTheCustomerWithID(int customerId)
        {
            _response = await _handler.Handle(new DeleteCustomerRequest(_customer.Id), CancellationToken.None);
        }

        [Then(@"the customer should be marked as inactive")]
        public void ThenTheCustomerShouldBeMarkedAsInactive()
        {
            Assert.True(_response.Success);
            _mockCustomer.Verify(r => r.Update(It.Is<Customer>(c => c.IsActive == false)), Times.Once);
        }
    }
}


