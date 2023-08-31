using com.google.i18n.phonenumbers;
using Mc2.CrudTest.DomainService.Abstraction;
using static com.google.i18n.phonenumbers.Phonenumber;

namespace Mc2.CrudTest.DomainService
{
    public class ValidationService: IValidationService
    {
        public bool BeAValidPhoneNumber(string phoneNumber)
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.getInstance();

            PhoneNumber parsedNumber = phoneNumberUtil.parse(phoneNumber, null);
            return phoneNumberUtil.isValidNumber(parsedNumber);

        }

       
    }
}
