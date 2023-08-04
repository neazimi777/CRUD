using Mc2.CrudTest.Domain;
using Mc2.CrudTest.DomainService.Customer.Handlers.Commands;
using Mc2.CrudTest.DomainService.Customer.Requests.Commands;
using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.Customer;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.BehaviourTest.Steps
{
    [Binding]
    public class CreateCustomerSteps
    {
        private readonly CreateCustomerRequestHandler _handler;
        private CreateCustomerDto _reques;
        private BaseCommandResponse _response;

        public CreateCustomerSteps()
        {

        }

        [Given("a valid customer request")]
        public void GivenValidCustomerRequest()
        {
            _reques = new CreateCustomerDto
            {
                FirstName = "Ali",
                LastName = "esfandiyar",
                Email = "Ali@gmail.com",
                PhoneNumber = "09125698189",
                BankAccountNumber = "12345678",
                DateOfBirth = DateOnly.Parse("1998/01/02"),

            };
        }

        [When("the request is handled")]
        public async Task WhenRequestIsHandled()
        {

            _response = await _handler.Handle(new CreateCustomerRequest(_reques), CancellationToken.None);
        }


        [Then("the response should be successful")]
        public void ThenResponseShouldBeSuccessful()
        {

            Assert.True(_response.Success);
        }

        [Given("an invalid customer request")]
        public void GivenInvalidCustomerRequest()
        {

            _reques = new CreateCustomerDto
            { 
                FirstName = "Ali",
                LastName = "esfandiyar",
                Email = "Ali@gmail.com",
                PhoneNumber = "09125698189",
                BankAccountNumber = "45678",
                DateOfBirth = DateOnly.Parse("1998/01/02"),
            };
        }

        [Then("the response should be unsuccessful")]
        public void ThenResponseShouldBeUnsuccessful()
        {

            Assert.False(_response.Success);
        }
    }
}

