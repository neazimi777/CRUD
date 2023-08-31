using Mc2.CrudTest.DomainService;
using Mc2.CrudTest.DomainService.Abstraction;
using Moq;

namespace Mc2.CrudTest.Test.UnitTest
{
    public class phoneValidationTest
    {
        private readonly ValidationService _validationService;
        public phoneValidationTest()
        {
            _validationService = new  ValidationService();
        }


        [Theory]
        [InlineData("+98844", "+989125698188")]
        public async Task validationPhonenumber(string phoneNumber1, string phoneNumber2)
        {
            Assert.True(_validationService.BeAValidPhoneNumber(phoneNumber2));
            Assert.False(_validationService.BeAValidPhoneNumber(phoneNumber1));

            Task.CompletedTask.Wait();

        }
    }
}
