using AutoMapper;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.DomainService.Customer.Handlers.Commands;
using Mc2.CrudTest.DomainService.Customer.Requests.Commands;
using Mc2.CrudTest.Dto.Customer;
using Mc2.CrudTest.Dto;
using MediatR;
using Moq;
using TechTalk.SpecFlow;
using Mc2.CrudTest.DomainService;
using Mc2.CrudTest.UnitTest.Mocks;

namespace Mc2.CrudTest.BehaviourTest.Steps
{
    [Binding]
    public class UpdateCustomerSteps
    {
        private readonly UpdateCustomerRequestHandler _handler;
        private UpdateCustomerDto _reques;
        private BaseCommandResponse _response;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ICustomerRepository> _mockCustomer;
        private readonly IMapper _mapper;


        public UpdateCustomerSteps()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mediator = new Mock<IMediator>();
            _mapper = mapperConfig.CreateMapper();
            _mockCustomer = MockCustomerRepository.CustomerRepository();

            _handler = new UpdateCustomerRequestHandler(_mockCustomer.Object, _mapper, _mediator.Object);
        }

        [Given(@"a customer for update with ID (.*) exists")]
        public void GivenACustomerForUpdateWithIDExists(int customerId)
        {
            _reques = new UpdateCustomerDto
            {
                Id = customerId,
                FirstName = "AliReza",
                LastName = "esfandiyar",
                Email = "Ali@gmail.com",
                PhoneNumber = "+989124446710",
                DateOfBirth = "1998/01/02"
            };
        }

        [When(@"I update the customer with valid data")]
        public async Task WhenIUpdateTheCustomerWithValidData()
        {
            _response = await _handler.Handle(new UpdateCustomerRequest(_reques), CancellationToken.None);
        }

        [Then(@"the customer information should be updated")]
        public void ThenTheCustomerInformationShouldBeUpdated()
        {
            Assert.True(_response.Success);
        }
    }
}
