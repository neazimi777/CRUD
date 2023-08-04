using FluentValidation;
using Mc2.CrudTest.Dto.Customer;

namespace Mc2.CrudTest.DomainService.Validations
{
    public class CreateValidationCustomer: AbstractValidator<CreateCustomerDto>
    {
        public CreateValidationCustomer()
        {
            Include(new BaseValidationCustomer());
        }
    }
}
