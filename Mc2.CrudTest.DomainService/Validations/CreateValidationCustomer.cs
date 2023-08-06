using FluentValidation;
using Mc2.CrudTest.Dto.Customer;

namespace Mc2.CrudTest.DomainService.Validations
{
    public class CreateValidationCustomer: AbstractValidator<CreateCustomerDto>
    {
        public CreateValidationCustomer()
        {
            Include(new BaseValidationCustomer());

            RuleFor(x => x.BankAccountNumber)
               .NotEmpty()
           .WithMessage("Bank account number is required.")
           .Must(BeAValidBankAccount)
           .WithMessage("Invalid bank account number.");

        }
        private bool BeAValidBankAccount(string accountNumber)
        {
            return accountNumber.All(char.IsDigit) && accountNumber.Length >= 6 && accountNumber.Length <= 20;
        }

    }
}
