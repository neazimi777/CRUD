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
           
            RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Must(BeAValidPhoneNumber)
            .WithMessage("Invalid phone number.");
        }

        private bool BeAValidPhoneNumber(string phoneNumber)
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.getInstance();

            PhoneNumber parsedNumber = phoneNumberUtil.parse(phoneNumber,null);
            return phoneNumberUtil.isValidNumber(parsedNumber);

        }
    }
}
