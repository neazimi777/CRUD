using FluentValidation;
using Mc2.CrudTest.Dto.Customer;

namespace Mc2.CrudTest.DomainService.Validations
{
    public class UpdateValidationCustomer : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateValidationCustomer()
        {
            Include(new BaseValidationCustomer());
        }
    }
}
