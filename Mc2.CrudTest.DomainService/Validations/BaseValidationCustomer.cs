using com.google.i18n.phonenumbers;
using FluentValidation;
using Mc2.CrudTest.Dto.Customer;
using static com.google.i18n.phonenumbers.Phonenumber;

namespace Mc2.CrudTest.DomainService.Validations
{
    public class BaseValidationCustomer : AbstractValidator<BaseCustomerDto>
    {
        public BaseValidationCustomer()
        {
            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email address is required.")
            .EmailAddress()
            .WithMessage("Invalid email address.");

            RuleFor(x => x.BankAccountNumber)
                .NotEmpty()
            .WithMessage("Bank account number is required.")
            .Must(BeAValidBankAccount)
            .WithMessage("Invalid bank account number.");

            RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Must(BeAValidPhoneNumber)
            .WithMessage("Invalid phone number.");
        }

        private bool BeAValidBankAccount(string accountNumber)
        {
            return accountNumber.All(char.IsDigit) && accountNumber.Length >= 6 && accountNumber.Length <= 20;
        }

        private bool BeAValidPhoneNumber(string phoneNumber)
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.getInstance();

            PhoneNumber parsedNumber = phoneNumberUtil.parse(phoneNumber, null);
            return phoneNumberUtil.isValidNumber(parsedNumber);

        }
    }
}
